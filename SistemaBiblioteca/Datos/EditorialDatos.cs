using Microsoft.Data.SqlClient;
using SistemaBiblioteca.Modelos;

namespace SistemaBiblioteca.Datos
{
    public class EditorialDatos
    {
        public List<Editorial> Listar(string filtro = "")
        {
            List<Editorial> lista = new List<Editorial>();

            string sql = @"SELECT IdEditorial, Nombre, Pais, Telefono, Correo
                           FROM Editoriales
                           WHERE Nombre LIKE @filtro OR Pais LIKE @filtro
                           ORDER BY Nombre";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(LeerEditorial(dr));
                    }
                }
            }

            return lista;
        }

        public Editorial ObtenerPorId(int idEditorial)
        {
            string sql = @"SELECT IdEditorial, Nombre, Pais, Telefono, Correo
                           FROM Editoriales WHERE IdEditorial = @id";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@id", idEditorial);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                        return LeerEditorial(dr);
                }
            }

            return null;
        }

        // Revisa si ya hay otra editorial con el mismo nombre.
        // idExcluir sirve para que al editar no se compare con ella misma.
        public bool ExisteNombre(string nombre, int idExcluir = 0)
        {
            string sql = "SELECT COUNT(*) FROM Editoriales WHERE Nombre = @nombre AND IdEditorial <> @id";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@id", idExcluir);
                cn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public int Insertar(Editorial editorial)
        {
            string sql = @"INSERT INTO Editoriales (Nombre, Pais, Telefono, Correo)
                           VALUES (@nombre, @pais, @telefono, @correo);
                           SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                AgregarParametros(cmd, editorial);
                cn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public bool Actualizar(Editorial editorial)
        {
            string sql = @"UPDATE Editoriales
                           SET Nombre = @nombre, Pais = @pais, Telefono = @telefono, Correo = @correo
                           WHERE IdEditorial = @id";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                AgregarParametros(cmd, editorial);
                cmd.Parameters.AddWithValue("@id", editorial.IdEditorial);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int idEditorial)
        {
            string sql = "DELETE FROM Editoriales WHERE IdEditorial = @id";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@id", idEditorial);
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public int ContarLibros(int idEditorial)
        {
            string sql = "SELECT COUNT(*) FROM Libros WHERE IdEditorial = @id";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@id", idEditorial);
                cn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        private void AgregarParametros(SqlCommand cmd, Editorial editorial)
        {
            cmd.Parameters.AddWithValue("@nombre", editorial.Nombre);
            cmd.Parameters.AddWithValue("@pais", Conexion.ValorONulo(editorial.Pais));
            cmd.Parameters.AddWithValue("@telefono", Conexion.ValorONulo(editorial.Telefono));
            cmd.Parameters.AddWithValue("@correo", Conexion.ValorONulo(editorial.Correo));
        }

        private Editorial LeerEditorial(SqlDataReader dr)
        {
            return new Editorial(
                (int)dr["IdEditorial"],
                dr["Nombre"].ToString(),
                dr["Pais"] == DBNull.Value ? null : dr["Pais"].ToString(),
                dr["Telefono"] == DBNull.Value ? null : dr["Telefono"].ToString(),
                dr["Correo"] == DBNull.Value ? null : dr["Correo"].ToString()
            );
        }
    }
}
