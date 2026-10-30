using System.Data;
using SistemaBiblioteca.Datos;

namespace SistemaBiblioteca.Negocio
{
    public class ReporteNegocio
    {
        private readonly ReporteDatos reporteDatos = new ReporteDatos();

        // Nombres que se muestran en el ComboBox del formulario de reportes
        public static readonly string[] TiposReporte =
        {
            "Resumen general",
            "Libros registrados",
            "Libros sin ejemplares disponibles",
            "Libros más prestados",
            "Autores",
            "Editoriales",
            "Usuarios registrados",
            "Préstamos activos",
            "Préstamos devueltos",
            "Préstamos vencidos",
            "Historial de préstamos"
        };

        public DataTable Generar(string tipoReporte)
        {
            switch (tipoReporte)
            {
                case "Resumen general": return reporteDatos.ResumenGeneral();
                case "Libros registrados": return reporteDatos.LibrosRegistrados();
                case "Libros sin ejemplares disponibles": return reporteDatos.LibrosSinDisponibles();
                case "Libros más prestados": return reporteDatos.LibrosMasPrestados();
                case "Autores": return reporteDatos.AutoresConLibros();
                case "Editoriales": return reporteDatos.EditorialesConLibros();
                case "Usuarios registrados": return reporteDatos.UsuariosRegistrados();
                case "Préstamos activos": return reporteDatos.Prestamos("Prestado");
                case "Préstamos devueltos": return reporteDatos.Prestamos("Devuelto");
                case "Préstamos vencidos": return reporteDatos.PrestamosVencidos();
                case "Historial de préstamos": return reporteDatos.Prestamos(null);
                default:
                    throw new ValidacionException("Debe seleccionar un tipo de reporte.");
            }
        }

        // Datos para los indicadores de la pantalla de inicio
        public Dictionary<string, int> ObtenerResumen()
        {
            Dictionary<string, int> resumen = new Dictionary<string, int>();
            DataTable tabla = reporteDatos.ResumenGeneral();

            foreach (DataRow fila in tabla.Rows)
            {
                resumen[fila["Concepto"].ToString()] = Convert.ToInt32(fila["Cantidad"]);
            }

            return resumen;
        }
    }
}
