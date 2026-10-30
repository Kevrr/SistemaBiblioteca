using Microsoft.Data.SqlClient;
using SistemaBiblioteca.Modelos;

namespace SistemaBiblioteca.Datos
{
    public class AutorDatos
    {
        public List<Autor> Listar(string filtro = "")
        {
            List<Autor> lista = new List<Autor>();

            string sql = @"SELECT IdAutor, Nombre, Apellido, Nacionalidad, FechaNacimiento
                           FROM Autores
                           WHERE Nombre LIKE @filtro OR Apellido LIKE @filtro OR Nacionalidad LIKE @filtro
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
                        lista.Add(LeerAutor(dr));
                    }
                }
            }

            return lista;
        }

        public Autor ObtenerPorId(int idAutor)
        {
            string sql = @"SELECT IdAutor, Nombre, Apellido, Nacionalidad, FechaNacimiento
                           FROM Autores WHERE IdAutor = @id";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@id", idAutor);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                        return LeerAutor(dr);
                }
            }

            return null;
        }

        public int Insertar(Autor autor)
        {
            string sql = @"INSERT INTO Autores (Nombre, Apellido, Nacionalidad, FechaNacimiento)
                           VALUES (@nombre, @apellido, @nacionalidad, @fecha);
                           SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                AgregarParametros(cmd, autor);
                cn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public bool Actualizar(Autor autor)
        {
            string sql = @"UPDATE Autores
                           SET Nombre = @nombre, Apellido = @apellido,
                               Nacionalidad = @nacionalidad, FechaNacimiento = @fecha
                           WHERE IdAutor = @id";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                AgregarParametros(cmd, autor);
                cmd.Parameters.AddWithValue("@id", autor.IdAutor);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int idAutor)
        {
            string sql = "DELETE FROM Autores WHERE IdAutor = @id";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@id", idAutor);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Cuántos libros tiene registrados el autor (para no dejarlo eliminar)
        public int ContarLibros(int idAutor)
        {
            string sql = "SELECT COUNT(*) FROM Libros WHERE IdAutor = @id";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@id", idAutor);
                cn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        private void AgregarParametros(SqlCommand cmd, Autor autor)
        {
            cmd.Parameters.AddWithValue("@nombre", autor.Nombre);
            cmd.Parameters.AddWithValue("@apellido", autor.Apellido);
            cmd.Parameters.AddWithValue("@nacionalidad", Conexion.ValorONulo(autor.Nacionalidad));
            cmd.Parameters.AddWithValue("@fecha", Conexion.ValorONulo(autor.FechaNacimiento));
        }

        private Autor LeerAutor(SqlDataReader dr)
        {
            return new Autor(
                (int)dr["IdAutor"],
                dr["Nombre"].ToString(),
                dr["Apellido"].ToString(),
                dr["Nacionalidad"] == DBNull.Value ? null : dr["Nacionalidad"].ToString(),
                dr["FechaNacimiento"] == DBNull.Value ? (DateTime?)null : (DateTime)dr["FechaNacimiento"]
            );
        }
    }
}
