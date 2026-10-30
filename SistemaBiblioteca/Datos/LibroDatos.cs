using Microsoft.Data.SqlClient;
using SistemaBiblioteca.Modelos;

namespace SistemaBiblioteca.Datos
{
    public class LibroDatos
    {
        // Consulta base con los nombres del autor y la editorial
        private const string ConsultaBase =
            @"SELECT L.IdLibro, L.ISBN, L.Titulo, L.IdAutor, L.IdEditorial, L.AnioPublicacion,
                     L.Genero, L.Existencias, L.Disponibles,
                     A.Nombre + ' ' + A.Apellido AS NombreAutor,
                     E.Nombre AS NombreEditorial
              FROM Libros L
              INNER JOIN Autores A ON A.IdAutor = L.IdAutor
              INNER JOIN Editoriales E ON E.IdEditorial = L.IdEditorial";

        /// <summary>
        /// Lista los libros. El criterio puede ser "Título", "ISBN" o "Autor".
        /// </summary>
        public List<Libro> Listar(string criterio = "Título", string filtro = "")
        {
            string condicion;

            switch (criterio)
            {
                case "ISBN":
                    condicion = "L.ISBN LIKE @filtro";
                    break;
                case "Autor":
                    condicion = "(A.Nombre + ' ' + A.Apellido) LIKE @filtro";
                    break;
                default:
                    condicion = "L.Titulo LIKE @filtro";
                    break;
            }

            string sql = ConsultaBase + " WHERE " + condicion + " ORDER BY L.Titulo";
            List<Libro> lista = new List<Libro>();

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(LeerLibro(dr));
                    }
                }
            }

            return lista;
        }

        public Libro ObtenerPorId(int idLibro)
        {
            string sql = ConsultaBase + " WHERE L.IdLibro = @id";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@id", idLibro);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                        return LeerLibro(dr);
                }
            }

            return null;
        }

        public bool ExisteISBN(string isbn, int idExcluir = 0)
        {
            string sql = "SELECT COUNT(*) FROM Libros WHERE ISBN = @isbn AND IdLibro <> @id";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@isbn", isbn);
                cmd.Parameters.AddWithValue("@id", idExcluir);
                cn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        // Al registrar un libro nuevo todos sus ejemplares están disponibles
        public int Insertar(Libro libro)
        {
            string sql = @"INSERT INTO Libros (ISBN, Titulo, IdAutor, IdEditorial, AnioPublicacion, Genero, Existencias, Disponibles)
                           VALUES (@isbn, @titulo, @idAutor, @idEditorial, @anio, @genero, @existencias, @existencias);
                           SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                AgregarParametros(cmd, libro);
                cn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        // Si cambian las existencias, los disponibles se ajustan con la misma diferencia
        public bool Actualizar(Libro libro)
        {
            string sql = @"UPDATE Libros
                           SET ISBN = @isbn, Titulo = @titulo, IdAutor = @idAutor, IdEditorial = @idEditorial,
                               AnioPublicacion = @anio, Genero = @genero,
                               Disponibles = Disponibles + (@existencias - Existencias),
                               Existencias = @existencias
                           WHERE IdLibro = @id";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                AgregarParametros(cmd, libro);
                cmd.Parameters.AddWithValue("@id", libro.IdLibro);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int idLibro)
        {
            string sql = "DELETE FROM Libros WHERE IdLibro = @id";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@id", idLibro);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public int ContarPrestamos(int idLibro)
        {
            string sql = "SELECT COUNT(*) FROM Prestamos WHERE IdLibro = @id";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@id", idLibro);
                cn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        private void AgregarParametros(SqlCommand cmd, Libro libro)
        {
            cmd.Parameters.AddWithValue("@isbn", libro.ISBN);
            cmd.Parameters.AddWithValue("@titulo", libro.Titulo);
            cmd.Parameters.AddWithValue("@idAutor", libro.IdAutor);
            cmd.Parameters.AddWithValue("@idEditorial", libro.IdEditorial);
            cmd.Parameters.AddWithValue("@anio", Conexion.ValorONulo(libro.AnioPublicacion));
            cmd.Parameters.AddWithValue("@genero", Conexion.ValorONulo(libro.Genero));
            cmd.Parameters.AddWithValue("@existencias", libro.Existencias);
        }

        private Libro LeerLibro(SqlDataReader dr)
        {
            Libro libro = new Libro(
                (int)dr["IdLibro"],
                dr["ISBN"].ToString(),
                dr["Titulo"].ToString(),
                (int)dr["IdAutor"],
                (int)dr["IdEditorial"],
                dr["AnioPublicacion"] == DBNull.Value ? (int?)null : (int)dr["AnioPublicacion"],
                dr["Genero"] == DBNull.Value ? null : dr["Genero"].ToString(),
                (int)dr["Existencias"],
                (int)dr["Disponibles"]
            );

            libro.NombreAutor = dr["NombreAutor"].ToString();
            libro.NombreEditorial = dr["NombreEditorial"].ToString();
            return libro;
        }
    }
}
