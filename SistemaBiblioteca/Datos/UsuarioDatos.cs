using Microsoft.Data.SqlClient;
using SistemaBiblioteca.Modelos;

namespace SistemaBiblioteca.Datos
{
    public class UsuarioDatos
    {
        public List<Usuario> Listar(string filtro = "")
        {
            List<Usuario> lista = new List<Usuario>();

            string sql = @"SELECT IdUsuario, Documento, Nombre, Apellido, Telefono, Correo, FechaRegistro
                           FROM Usuarios
                           WHERE Documento LIKE @filtro OR Nombre LIKE @filtro OR Apellido LIKE @filtro
                           ORDER BY Apellido, Nombre";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(LeerUsuario(dr));
                    }
                }
            }

            return lista;
        }

        public Usuario ObtenerPorId(int idUsuario)
        {
            string sql = @"SELECT IdUsuario, Documento, Nombre, Apellido, Telefono, Correo, FechaRegistro
                           FROM Usuarios WHERE IdUsuario = @id";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@id", idUsuario);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                        return LeerUsuario(dr);
                }
            }

            return null;
        }

        public bool ExisteDocumento(string documento, int idExcluir = 0)
        {
            string sql = "SELECT COUNT(*) FROM Usuarios WHERE Documento = @doc AND IdUsuario <> @id";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@doc", documento);
                cmd.Parameters.AddWithValue("@id", idExcluir);
                cn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public int Insertar(Usuario usuario)
        {
            string sql = @"INSERT INTO Usuarios (Documento, Nombre, Apellido, Telefono, Correo, FechaRegistro)
                           VALUES (@documento, @nombre, @apellido, @telefono, @correo, @fechaRegistro);
                           SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                AgregarParametros(cmd, usuario);
                cmd.Parameters.AddWithValue("@fechaRegistro", usuario.FechaRegistro.Date);
                cn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        // La fecha de registro no se modifica al editar
        public bool Actualizar(Usuario usuario)
        {
            string sql = @"UPDATE Usuarios
                           SET Documento = @documento, Nombre = @nombre, Apellido = @apellido,
                               Telefono = @telefono, Correo = @correo
                           WHERE IdUsuario = @id";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                AgregarParametros(cmd, usuario);
                cmd.Parameters.AddWithValue("@id", usuario.IdUsuario);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int idUsuario)
        {
            string sql = "DELETE FROM Usuarios WHERE IdUsuario = @id";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@id", idUsuario);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public int ContarPrestamos(int idUsuario)
        {
            string sql = "SELECT COUNT(*) FROM Prestamos WHERE IdUsuario = @id";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@id", idUsuario);
                cn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        private void AgregarParametros(SqlCommand cmd, Usuario usuario)
        {
            cmd.Parameters.AddWithValue("@documento", usuario.Documento);
            cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
            cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
            cmd.Parameters.AddWithValue("@telefono", Conexion.ValorONulo(usuario.Telefono));
            cmd.Parameters.AddWithValue("@correo", Conexion.ValorONulo(usuario.Correo));
        }

        private Usuario LeerUsuario(SqlDataReader dr)
        {
            return new Usuario(
                (int)dr["IdUsuario"],
                dr["Documento"].ToString(),
                dr["Nombre"].ToString(),
                dr["Apellido"].ToString(),
                dr["Telefono"] == DBNull.Value ? null : dr["Telefono"].ToString(),
                dr["Correo"] == DBNull.Value ? null : dr["Correo"].ToString(),
                (DateTime)dr["FechaRegistro"]
            );
        }
    }
}
