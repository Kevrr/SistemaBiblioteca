using Microsoft.Data.SqlClient;
using SistemaBiblioteca.Modelos;

namespace SistemaBiblioteca.Datos
{
    public class PrestamoDatos
    {
        private const string ConsultaBase =
            @"SELECT P.IdPrestamo, P.IdUsuario, P.IdLibro, P.FechaPrestamo, P.FechaDevolucionPrevista,
                     P.FechaDevolucion, P.Estado,
                     U.Nombre + ' ' + U.Apellido AS NombreUsuario,
                     L.Titulo AS TituloLibro
              FROM Prestamos P
              INNER JOIN Usuarios U ON U.IdUsuario = P.IdUsuario
              INNER JOIN Libros L ON L.IdLibro = P.IdLibro";

        /// <summary>
        /// Lista los préstamos según el estado: "Todos", "Prestado", "Devuelto" o "Vencidos".
        /// </summary>
        public List<Prestamo> Listar(string estado = "Todos")
        {
            string sql = ConsultaBase;

            if (estado == Prestamo.EstadoPrestado || estado == Prestamo.EstadoDevuelto)
                sql += " WHERE P.Estado = @estado";
            else if (estado == "Vencidos")
                sql += " WHERE P.Estado = 'Prestado' AND P.FechaDevolucionPrevista < CAST(GETDATE() AS DATE)";

            sql += " ORDER BY P.FechaPrestamo DESC, P.IdPrestamo DESC";

            List<Prestamo> lista = new List<Prestamo>();

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@estado", estado);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(LeerPrestamo(dr));
                    }
                }
            }

            return lista;
        }

        public Prestamo ObtenerPorId(int idPrestamo)
        {
            string sql = ConsultaBase + " WHERE P.IdPrestamo = @id";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@id", idPrestamo);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                        return LeerPrestamo(dr);
                }
            }

            return null;
        }

        // Préstamos activos que tiene un usuario
        public int ContarActivosUsuario(int idUsuario)
        {
            string sql = "SELECT COUNT(*) FROM Prestamos WHERE IdUsuario = @id AND Estado = 'Prestado'";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@id", idUsuario);
                cn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        // Para que un usuario no tenga el mismo libro prestado dos veces
        public bool UsuarioTieneLibroPrestado(int idUsuario, int idLibro, int idExcluir = 0)
        {
            string sql = @"SELECT COUNT(*) FROM Prestamos
                           WHERE IdUsuario = @idUsuario AND IdLibro = @idLibro
                             AND Estado = 'Prestado' AND IdPrestamo <> @idExcluir";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@idLibro", idLibro);
                cmd.Parameters.AddWithValue("@idExcluir", idExcluir);
                cn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        /// <summary>
        /// Registra el préstamo y descuenta un ejemplar disponible del libro.
        /// Se usa una transacción para que se hagan las dos cosas o ninguna.
        /// </summary>
        public int Registrar(Prestamo prestamo)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                cn.Open();
                SqlTransaction transaccion = cn.BeginTransaction();

                try
                {
                    // 1. Descontar el ejemplar (solo si todavía hay disponibles)
                    string sqlLibro = "UPDATE Libros SET Disponibles = Disponibles - 1 WHERE IdLibro = @idLibro AND Disponibles > 0";
                    SqlCommand cmdLibro = new SqlCommand(sqlLibro, cn, transaccion);
                    cmdLibro.Parameters.AddWithValue("@idLibro", prestamo.IdLibro);

                    if (cmdLibro.ExecuteNonQuery() == 0)
                    {
                        transaccion.Rollback();
                        throw new InvalidOperationException("El libro seleccionado no tiene ejemplares disponibles.");
                    }

                    // 2. Guardar el préstamo
                    string sqlPrestamo = @"INSERT INTO Prestamos (IdUsuario, IdLibro, FechaPrestamo, FechaDevolucionPrevista, Estado)
                                           VALUES (@idUsuario, @idLibro, @fechaPrestamo, @fechaPrevista, 'Prestado');
                                           SELECT CAST(SCOPE_IDENTITY() AS INT);";
                    SqlCommand cmdPrestamo = new SqlCommand(sqlPrestamo, cn, transaccion);
                    cmdPrestamo.Parameters.AddWithValue("@idUsuario", prestamo.IdUsuario);
                    cmdPrestamo.Parameters.AddWithValue("@idLibro", prestamo.IdLibro);
                    cmdPrestamo.Parameters.AddWithValue("@fechaPrestamo", prestamo.FechaPrestamo.Date);
                    cmdPrestamo.Parameters.AddWithValue("@fechaPrevista", prestamo.FechaDevolucionPrevista.Date);

                    int idNuevo = (int)cmdPrestamo.ExecuteScalar();
                    transaccion.Commit();
                    return idNuevo;
                }
                catch (SqlException)
                {
                    transaccion.Rollback();
                    throw;
                }
            }
        }

        // Solo se pueden editar los préstamos que siguen activos.
        // El libro no se cambia para no descuadrar las existencias.
        public bool Actualizar(Prestamo prestamo)
        {
            string sql = @"UPDATE Prestamos
                           SET IdUsuario = @idUsuario, FechaPrestamo = @fechaPrestamo,
                               FechaDevolucionPrevista = @fechaPrevista
                           WHERE IdPrestamo = @id AND Estado = 'Prestado'";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@idUsuario", prestamo.IdUsuario);
                cmd.Parameters.AddWithValue("@fechaPrestamo", prestamo.FechaPrestamo.Date);
                cmd.Parameters.AddWithValue("@fechaPrevista", prestamo.FechaDevolucionPrevista.Date);
                cmd.Parameters.AddWithValue("@id", prestamo.IdPrestamo);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Marca el préstamo como devuelto y suma el ejemplar al libro.
        /// </summary>
        public bool RegistrarDevolucion(int idPrestamo, DateTime fechaDevolucion)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                cn.Open();
                SqlTransaction transaccion = cn.BeginTransaction();

                try
                {
                    string sqlPrestamo = @"UPDATE Prestamos
                                           SET Estado = 'Devuelto', FechaDevolucion = @fecha
                                           WHERE IdPrestamo = @id AND Estado = 'Prestado'";
                    SqlCommand cmdPrestamo = new SqlCommand(sqlPrestamo, cn, transaccion);
                    cmdPrestamo.Parameters.AddWithValue("@fecha", fechaDevolucion.Date);
                    cmdPrestamo.Parameters.AddWithValue("@id", idPrestamo);

                    if (cmdPrestamo.ExecuteNonQuery() == 0)
                    {
                        // No estaba prestado (ya se había devuelto)
                        transaccion.Rollback();
                        return false;
                    }

                    string sqlLibro = @"UPDATE Libros SET Disponibles = Disponibles + 1
                                        WHERE IdLibro = (SELECT IdLibro FROM Prestamos WHERE IdPrestamo = @id)";
                    SqlCommand cmdLibro = new SqlCommand(sqlLibro, cn, transaccion);
                    cmdLibro.Parameters.AddWithValue("@id", idPrestamo);
                    cmdLibro.ExecuteNonQuery();

                    transaccion.Commit();
                    return true;
                }
                catch (SqlException)
                {
                    transaccion.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// Elimina el préstamo. Si todavía estaba prestado se devuelve el ejemplar al libro.
        /// </summary>
        public bool Eliminar(int idPrestamo)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                cn.Open();
                SqlTransaction transaccion = cn.BeginTransaction();

                try
                {
                    string sqlLibro = @"UPDATE Libros SET Disponibles = Disponibles + 1
                                        WHERE IdLibro = (SELECT IdLibro FROM Prestamos
                                                         WHERE IdPrestamo = @id AND Estado = 'Prestado')";
                    SqlCommand cmdLibro = new SqlCommand(sqlLibro, cn, transaccion);
                    cmdLibro.Parameters.AddWithValue("@id", idPrestamo);
                    cmdLibro.ExecuteNonQuery();

                    SqlCommand cmdBorrar = new SqlCommand("DELETE FROM Prestamos WHERE IdPrestamo = @id", cn, transaccion);
                    cmdBorrar.Parameters.AddWithValue("@id", idPrestamo);
                    int filas = cmdBorrar.ExecuteNonQuery();

                    transaccion.Commit();
                    return filas > 0;
                }
                catch (SqlException)
                {
                    transaccion.Rollback();
                    throw;
                }
            }
        }

        private Prestamo LeerPrestamo(SqlDataReader dr)
        {
            Prestamo p = new Prestamo();
            p.IdPrestamo = (int)dr["IdPrestamo"];
            p.IdUsuario = (int)dr["IdUsuario"];
            p.IdLibro = (int)dr["IdLibro"];
            p.FechaPrestamo = (DateTime)dr["FechaPrestamo"];
            p.FechaDevolucionPrevista = (DateTime)dr["FechaDevolucionPrevista"];
            p.FechaDevolucion = dr["FechaDevolucion"] == DBNull.Value ? (DateTime?)null : (DateTime)dr["FechaDevolucion"];
            p.Estado = dr["Estado"].ToString();
            p.NombreUsuario = dr["NombreUsuario"].ToString();
            p.TituloLibro = dr["TituloLibro"].ToString();
            return p;
        }
    }
}
