using SistemaBiblioteca.Negocio;
using SistemaBiblioteca.Utilidades;

namespace SistemaBiblioteca.Formularios
{
    public partial class FrmReportes : Form
    {
        private readonly ReporteNegocio reporteNegocio = new ReporteNegocio();

        public FrmReportes()
        {
            InitializeComponent();
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            cmbTipoReporte.Items.AddRange(ReporteNegocio.TiposReporte);
            cmbTipoReporte.SelectedIndex = 0;
            GenerarReporte();
        }

        private void GenerarReporte()
        {
            if (cmbTipoReporte.SelectedItem == null)
            {
                Mensajes.Advertencia("Seleccione el tipo de reporte.");
                return;
            }

            try
            {
                dgvReporte.DataSource = null;
                dgvReporte.DataSource = reporteNegocio.Generar(cmbTipoReporte.SelectedItem.ToString());
                Grilla.FormatoFechasAutomatico(dgvReporte);

                lblTotal.Text = "Total de registros: " + dgvReporte.Rows.Count;
            }
            catch (Exception ex)
            {
                Mensajes.MostrarExcepcion(ex);
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            GenerarReporte();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
