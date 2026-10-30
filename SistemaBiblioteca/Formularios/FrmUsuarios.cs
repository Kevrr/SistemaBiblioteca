using SistemaBiblioteca.Modelos;
using SistemaBiblioteca.Negocio;
using SistemaBiblioteca.Utilidades;

namespace SistemaBiblioteca.Formularios
{
    public partial class FrmUsuarios : Form
    {
        private readonly UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        private int idSeleccionado = 0;

        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            Limpiar();
        }

        private void CargarUsuarios(string filtro = "")
        {
            try
            {
                dgvUsuarios.DataSource = null;
                dgvUsuarios.DataSource = usuarioNegocio.Listar(filtro);

                Grilla.OcultarColumnas(dgvUsuarios, "NombreCompleto");
                Grilla.OrdenarColumnas(dgvUsuarios, "IdUsuario", "Documento", "Nombre", "Apellido",
                                       "Telefono", "Correo", "FechaRegistro");
                Grilla.CambiarTitulo(dgvUsuarios, "IdUsuario", "Código");
                Grilla.CambiarTitulo(dgvUsuarios, "Telefono", "Teléfono");
                Grilla.CambiarTitulo(dgvUsuarios, "FechaRegistro", "Fecha registro");
                Grilla.FormatoFecha(dgvUsuarios, "FechaRegistro");
            }
            catch (Exception ex)
            {
                Mensajes.MostrarExcepcion(ex);
            }
        }

        private void Limpiar()
        {
            idSeleccionado = 0;
            txtIdUsuario.Clear();
            txtDocumento.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            dtpFechaRegistro.Value = DateTime.Today;
            btnEliminar.Enabled = false;
            dgvUsuarios.ClearSelection();
            txtDocumento.Focus();
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            Usuario usuario = (Usuario)dgvUsuarios.Rows[e.RowIndex].DataBoundItem;

            idSeleccionado = usuario.IdUsuario;
            txtIdUsuario.Text = usuario.IdUsuario.ToString();
            txtDocumento.Text = usuario.Documento;
            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtTelefono.Text = usuario.Telefono;
            txtCorreo.Text = usuario.Correo;
            dtpFechaRegistro.Value = usuario.FechaRegistro;
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
                Usuario usuario = new Usuario(idSeleccionado, txtDocumento.Text, txtNombre.Text, txtApellido.Text,
                                              txtTelefono.Text, txtCorreo.Text, dtpFechaRegistro.Value.Date);
                bool esNuevo = usuario.IdUsuario == 0;

                usuarioNegocio.Guardar(usuario);

                Mensajes.Informacion(esNuevo ? "Usuario registrado correctamente." : "Usuario actualizado correctamente.");
                CargarUsuarios(txtBuscar.Text);
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
                Mensajes.Advertencia("Seleccione un usuario de la lista.");
                return;
            }

            if (!Mensajes.Confirmar("¿Está seguro de eliminar al usuario " + txtNombre.Text + " " + txtApellido.Text + "?"))
                return;

            try
            {
                usuarioNegocio.Eliminar(idSeleccionado);
                Mensajes.Informacion("Usuario eliminado correctamente.");
                CargarUsuarios(txtBuscar.Text);
                Limpiar();
            }
            catch (Exception ex)
            {
                Mensajes.MostrarExcepcion(ex);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarUsuarios(txtBuscar.Text);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarUsuarios(txtBuscar.Text);
                e.SuppressKeyPress = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
