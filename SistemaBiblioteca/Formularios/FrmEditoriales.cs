using SistemaBiblioteca.Modelos;
using SistemaBiblioteca.Negocio;
using SistemaBiblioteca.Utilidades;

namespace SistemaBiblioteca.Formularios
{
    public partial class FrmEditoriales : Form
    {
        private readonly EditorialNegocio editorialNegocio = new EditorialNegocio();
        private int idSeleccionado = 0;

        public FrmEditoriales()
        {
            InitializeComponent();
        }

        private void FrmEditoriales_Load(object sender, EventArgs e)
        {
            CargarEditoriales();
            Limpiar();
        }

        private void CargarEditoriales(string filtro = "")
        {
            try
            {
                dgvEditoriales.DataSource = null;
                dgvEditoriales.DataSource = editorialNegocio.Listar(filtro);

                Grilla.OrdenarColumnas(dgvEditoriales, "IdEditorial", "Nombre", "Pais", "Telefono", "Correo");
                Grilla.CambiarTitulo(dgvEditoriales, "IdEditorial", "Código");
                Grilla.CambiarTitulo(dgvEditoriales, "Pais", "País");
                Grilla.CambiarTitulo(dgvEditoriales, "Telefono", "Teléfono");
            }
            catch (Exception ex)
            {
                Mensajes.MostrarExcepcion(ex);
            }
        }

        private void Limpiar()
        {
            idSeleccionado = 0;
            txtIdEditorial.Clear();
            txtNombre.Clear();
            txtPais.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            btnEliminar.Enabled = false;
            dgvEditoriales.ClearSelection();
            txtNombre.Focus();
        }

        private void dgvEditoriales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            Editorial editorial = (Editorial)dgvEditoriales.Rows[e.RowIndex].DataBoundItem;

            idSeleccionado = editorial.IdEditorial;
            txtIdEditorial.Text = editorial.IdEditorial.ToString();
            txtNombre.Text = editorial.Nombre;
            txtPais.Text = editorial.Pais;
            txtTelefono.Text = editorial.Telefono;
            txtCorreo.Text = editorial.Correo;
            btnEliminar.Enabled = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Editorial editorial = new Editorial(idSeleccionado, txtNombre.Text, txtPais.Text,
                                                    txtTelefono.Text, txtCorreo.Text);
                bool esNuevo = editorial.IdEditorial == 0;

                editorialNegocio.Guardar(editorial);

                Mensajes.Informacion(esNuevo ? "Editorial registrada correctamente." : "Editorial actualizada correctamente.");
                CargarEditoriales(txtBuscar.Text);
                Limpiar();
            }
            catch (Exception ex)
            {
                Mensajes.MostrarExcepcion(ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                Mensajes.Advertencia("Seleccione una editorial de la lista.");
                return;
            }

            if (!Mensajes.Confirmar("¿Está seguro de eliminar la editorial " + txtNombre.Text + "?"))
                return;

            try
            {
                editorialNegocio.Eliminar(idSeleccionado);
                Mensajes.Informacion("Editorial eliminada correctamente.");
                CargarEditoriales(txtBuscar.Text);
                Limpiar();
            }
            catch (Exception ex)
            {
                Mensajes.MostrarExcepcion(ex);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarEditoriales(txtBuscar.Text);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarEditoriales(txtBuscar.Text);
                e.SuppressKeyPress = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
