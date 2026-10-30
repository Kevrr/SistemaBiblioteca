using Microsoft.Data.SqlClient;
using SistemaBiblioteca.Negocio;

namespace SistemaBiblioteca.Utilidades
{
    /// <summary>
    /// Mensajes que se muestran al usuario, para no repetir MessageBox en todos los formularios.
    /// </summary>
    public static class Mensajes
    {
        public static void Informacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Advertencia(string mensaje)
        {
            MessageBox.Show(mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Error(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool Confirmar(string mensaje)
        {
            return MessageBox.Show(mensaje, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        /// <summary>
        /// Muestra el mensaje adecuado según el tipo de excepción.
        /// </summary>
        public static void MostrarExcepcion(Exception ex)
        {
            if (ex is ValidacionException)
            {
                Advertencia(ex.Message);
            }
            else if (ex is SqlException sqlEx)
            {
                // 547 = conflicto con una clave foránea o un CHECK
                // 2627 y 2601 = registro duplicado
                if (sqlEx.Number == 547)
                    Advertencia("La operación no se puede realizar porque afecta registros relacionados.");
                else if (sqlEx.Number == 2627 || sqlEx.Number == 2601)
                    Advertencia("Ya existe un registro con esos datos.");
                else
                    Error("Error en la base de datos:\n" + sqlEx.Message);
            }
            else
            {
                Error("Ocurrió un error inesperado:\n" + ex.Message);
            }
        }
    }
}
