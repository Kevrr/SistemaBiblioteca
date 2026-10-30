using SistemaBiblioteca.Modelos;
using SistemaBiblioteca.Negocio;
using SistemaBiblioteca.Utilidades;

namespace SistemaBiblioteca.Formularios
{
    public partial class FrmAutores : Form
    {
        private readonly AutorNegocio autorNegocio = new AutorNegocio();

        // 0 significa que se está registrando un autor nuevo
        private int idSeleccionado = 0;

        public FrmAutores()
        {
            InitializeComponent();
        }

        private void FrmAutores_Load(object sender, EventArgs e)
        {
            CargarAutores();
            Limpiar();
        }

        private void CargarAutores(string filtro = "")
        {
            try
            {
                dgvAutores.DataSource = null;
                dgvAutores.DataSource = autorNegocio.Listar(filtro);

                Grilla.OcultarColumnas(dgvAutores, "NombreCompleto");
                Grilla.OrdenarColumnas(dgvAutores, "IdAutor", "Nombre", "Apellido", "Nacionalidad", "FechaNacimiento");
                Grilla.CambiarTitulo(dgvAutores, "IdAutor", "Código");
                Grilla.CambiarTitulo(dgvAutores, "FechaNacimiento", "Fecha nacimiento");
                Grilla.FormatoFecha(dgvAutores, "FechaNacimiento");
            }
            catch (Exception ex)
            {
                Mensajes.MostrarExcepcion(ex);
            }
        }

        private void Limpiar()
        {
            idSeleccionado = 0;
            txtIdAutor.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtNacionalidad.Clear();
            dtpFechaNacimiento.Value = DateTime.Today;
            dtpFechaNacimiento.Checked = false;
            btnEliminar.Enabled = false;
            dgvAutores.ClearSelection();
            txtNombre.Focus();
        }

        private Autor ObtenerDatosFormulario()
        {
            DateTime? fecha = null;
            if (dtpFechaNacimiento.Checked)
                fecha = dtpFechaNacimiento.Value.Date;

            return new Autor(idSeleccionado, txtNombre.Text, txtApellido.Text, txtNacionalidad.Text, fecha);
        }

        private void dgvAutores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            Autor autor = (Autor)dgvAutores.Rows[e.RowIndex].DataBoundItem;

            idSeleccionado = autor.IdAutor;
            txtIdAutor.Text = autor.IdAutor.ToString();
            txtNombre.Text = autor.Nombre;
            txtApellido.Text = autor.Apellido;
            txtNacionalidad.Text = autor.Nacionalidad;

            if (autor.FechaNacimiento.HasValue)
            {
                dtpFechaNacimiento.Value = autor.FechaNacimiento.Value;
                dtpFechaNacimiento.Checked = true;
            }
            else
            {
                dtpFechaNacimiento.Value = DateTime.Today;
                dtpFechaNacimiento.Checked = false;
            }

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
                Autor autor = ObtenerDatosFormulario();
                bool esNuevo = autor.IdAutor == 0;

                autorNegocio.Guardar(autor);

                Mensajes.Informacion(esNuevo ? "Autor registrado correctamente." : "Autor actualizado correctamente.");
                CargarAutores(txtBuscar.Text);
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
                Mensajes.Advertencia("Seleccione un autor de la lista.");
                return;
            }

            if (!Mensajes.Confirmar("¿Está seguro de eliminar al autor " + txtNombre.Text + " " + txtApellido.Text + "?"))
                return;

            try
            {
                autorNegocio.Eliminar(idSeleccionado);
                Mensajes.Informacion("Autor eliminado correctamente.");
                CargarAutores(txtBuscar.Text);
                Limpiar();
            }
            catch (Exception ex)
            {
                Mensajes.MostrarExcepcion(ex);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarAutores(txtBuscar.Text);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarAutores(txtBuscar.Text);
                e.SuppressKeyPress = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
