using SistemaBiblioteca.Datos;
using SistemaBiblioteca.Negocio;
using SistemaBiblioteca.Utilidades;

namespace SistemaBiblioteca.Formularios
{
    public partial class FrmPrincipal : Form
    {
        private readonly ReporteNegocio reporteNegocio = new ReporteNegocio();

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lblFecha.Text = "Fecha: " + DateTime.Today.ToString("dddd, dd 'de' MMMM 'de' yyyy");

            // Antes de todo se revisa que haya conexión con SQL Server
            if (!Conexion.ProbarConexion(out string error))
            {
                Mensajes.Error("No fue posible conectarse a la base de datos.\n\n" +
                               "Verifique que SQL Server esté iniciado y que se haya ejecutado el script BibliotecaDB.sql.\n\n" +
                               "Detalle: " + error);
                lblAviso.Text = "Sin conexión con la base de datos.";
                return;
            }

            CargarResumen();
        }

        private void CargarResumen()
        {
            try
            {
                Dictionary<string, int> resumen = reporteNegocio.ObtenerResumen();

                lblTotalLibros.Text = "Títulos registrados: " + resumen["Títulos registrados"];
                lblTotalEjemplares.Text = "Ejemplares disponibles: " + resumen["Ejemplares disponibles"] +
                                          " de " + resumen["Ejemplares en total"];
                lblTotalUsuarios.Text = "Usuarios registrados: " + resumen["Usuarios"];
                lblPrestamosActivos.Text = "Préstamos activos: " + resumen["Préstamos activos"];
                lblPrestamosVencidos.Text = "Préstamos vencidos: " + resumen["Préstamos vencidos"];

                if (resumen["Préstamos vencidos"] > 0)
                    lblAviso.Text = "Hay préstamos vencidos. Revise el módulo de préstamos o reportes.";
                else
                    lblAviso.Text = "";
            }
            catch (Exception ex)
            {
                Mensajes.MostrarExcepcion(ex);
            }
        }

        // Abre el formulario del módulo y al cerrarlo actualiza el resumen
        private void AbrirModulo(Form formulario)
        {
            using (formulario)
            {
                formulario.ShowDialog(this);
            }
            CargarResumen();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            CargarResumen();
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            AbrirModulo(new FrmLibros());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirModulo(new FrmUsuarios());
        }

        private void btnAutores_Click(object sender, EventArgs e)
        {
            AbrirModulo(new FrmAutores());
        }

        private void btnEditoriales_Click(object sender, EventArgs e)
        {
            AbrirModulo(new FrmEditoriales());
        }

        private void btnPrestamos_Click(object sender, EventArgs e)
        {
            AbrirModulo(new FrmPrestamos());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirModulo(new FrmReportes());
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (Mensajes.Confirmar("¿Desea salir del sistema?"))
                Close();
        }
    }
}
