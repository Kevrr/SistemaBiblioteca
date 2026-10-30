using Microsoft.Data.SqlClient;

namespace SistemaBiblioteca.Datos
{
    /// <summary>
    /// Maneja la cadena de conexión con SQL Server.
    /// </summary>
    public static class Conexion
    {
        private const string CadenaConexion =
            @"Server=localhost\SQLEXPRESS;Database=BibliotecaDB;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(CadenaConexion);
        }

        // Se usa al iniciar la aplicación para saber si la base de datos responde
        public static bool ProbarConexion(out string mensajeError)
        {
            mensajeError = "";
            try
            {
                using (SqlConnection cn = ObtenerConexion())
                {
                    cn.Open();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                mensajeError = ex.Message;
                return false;
            }
        }

        // Se usa para enviar un NULL a la base de datos cuando un campo opcional viene vacío
        public static object ValorONulo(object valor)
        {
            return valor ?? DBNull.Value;
        }
    }
}
