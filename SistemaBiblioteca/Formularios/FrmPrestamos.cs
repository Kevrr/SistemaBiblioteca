using SistemaBiblioteca.Modelos;
using SistemaBiblioteca.Negocio;
using SistemaBiblioteca.Utilidades;

namespace SistemaBiblioteca.Formularios
{
    public partial class FrmPrestamos : Form
    {
        private readonly PrestamoNegocio prestamoNegocio = new PrestamoNegocio();
        private readonly UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        private readonly LibroNegocio libroNegocio = new LibroNegocio();

        private int idSeleccionado = 0;
        private bool cargando = true;

        public FrmPrestamos()
        {
            InitializeComponent();
        }

        private void FrmPrestamos_Load(object sender, EventArgs e)
        {
            cmbFiltroEstado.Items.AddRange(new object[] { "Todos", "Prestado", "Devuelto", "Vencidos" });
            cmbFiltroEstado.SelectedIndex = 0;

            // Para que los ComboBox muestren el texto del ToString() y no el Id
            cmbUsuario.Format += cmbMostrarTexto_Format;
            cmbLibro.Format += cmbMostrarTexto_Format;

            CargarCombos();
            CargarPrestamos();
            Limpiar();
            cargando = false;
        }

        private void cmbMostrarTexto_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = e.ListItem.ToString();
        }

        private void CargarCombos()
        {
            try
            {
                cmbUsuario.DataSource = usuarioNegocio.Listar();
                cmbUsuario.ValueMember = "IdUsuario";

                cmbLibro.DataSource = libroNegocio.Listar();
                cmbLibro.ValueMember = "IdLibro";
            }
            catch (Exception ex)
            {
                Mensajes.MostrarExcepcion(ex);
            }
        }

        private void CargarPrestamos()
        {
            try
            {
                string estado = cmbFiltroEstado.SelectedItem?.ToString() ?? "Todos";

                dgvPrestamos.DataSource = null;
                dgvPrestamos.DataSource = prestamoNegocio.Listar(estado);

                Grilla.OcultarColumnas(dgvPrestamos, "IdUsuario", "IdLibro", "EstaDevuelto", "EstaVencido");
                Grilla.OrdenarColumnas(dgvPrestamos, "IdPrestamo", "NombreUsuario", "TituloLibro", "FechaPrestamo",
                                       "FechaDevolucionPrevista", "FechaDevolucion", "Estado");
                Grilla.CambiarTitulo(dgvPrestamos, "IdPrestamo", "N°");
                Grilla.CambiarTitulo(dgvPrestamos, "NombreUsuario", "Usuario");
                Grilla.CambiarTitulo(dgvPrestamos, "TituloLibro", "Libro");
                Grilla.CambiarTitulo(dgvPrestamos, "FechaPrestamo", "Préstamo");
                Grilla.CambiarTitulo(dgvPrestamos, "FechaDevolucionPrevista", "Dev. prevista");
                Grilla.CambiarTitulo(dgvPrestamos, "FechaDevolucion", "Devuelto el");
                Grilla.FormatoFecha(dgvPrestamos, "FechaPrestamo", "FechaDevolucionPrevista", "FechaDevolucion");

                if (dgvPrestamos.Columns.Contains("IdPrestamo"))
                    dgvPrestamos.Columns["IdPrestamo"].FillWeight = 40;
                if (dgvPrestamos.Columns.Contains("TituloLibro"))
                    dgvPrestamos.Columns["TituloLibro"].FillWeight = 160;
            }
            catch (Exception ex)
            {
                Mensajes.MostrarExcepcion(ex);
            }
        }

        private void Limpiar()
        {
            idSeleccionado = 0;
            txtIdPrestamo.Clear();
            cmbUsuario.SelectedIndex = -1;
            cmbLibro.SelectedIndex = -1;
            cmbLibro.Enabled = true;
            dtpFechaPrestamo.Value = DateTime.Today;
            dtpFechaPrevista.Value = DateTime.Today.AddDays(15);
            txtEstado.Text = "Nuevo";
            txtFechaDevolucion.Clear();
            dtpFechaDevolucion.Value = DateTime.Today;

            btnGuardar.Enabled = true;
            btnEliminar.Enabled = false;
            grpDevolucion.Enabled = false;
            dgvPrestamos.ClearSelection();
        }

        private void dgvPrestamos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            Prestamo prestamo = (Prestamo)dgvPrestamos.Rows[e.RowIndex].DataBoundItem;

            idSeleccionado = prestamo.IdPrestamo;
            txtIdPrestamo.Text = prestamo.IdPrestamo.ToString();
            cmbUsuario.SelectedValue = prestamo.IdUsuario;
            cmbLibro.SelectedValue = prestamo.IdLibro;
            dtpFechaPrestamo.Value = prestamo.FechaPrestamo;
            dtpFechaPrevista.Value = prestamo.FechaDevolucionPrevista;
            txtEstado.Text = prestamo.EstaVencido ? "Prestado (vencido)" : prestamo.Estado;
            txtFechaDevolucion.Text = prestamo.FechaDevolucion?.ToString("dd/MM/yyyy") ?? "";

            // El libro no se cambia en un préstamo ya registrado
            cmbLibro.Enabled = false;

            // Un préstamo devuelto ya no se puede editar ni devolver otra vez
            btnGuardar.Enabled = !prestamo.EstaDevuelto;
            grpDevolucion.Enabled = !prestamo.EstaDevuelto;
            btnEliminar.Enabled = true;
            dtpFechaDevolucion.Value = DateTime.Today;
        }

        // Pinta de rojo los préstamos vencidos
        private void dgvPrestamos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvPrestamos.Rows[e.RowIndex].DataBoundItem is Prestamo prestamo && prestamo.EstaVencido)
            {
                e.CellStyle.ForeColor = Color.Firebrick;
            }
        }

        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargando)
                return;

            CargarPrestamos();
            Limpiar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Prestamo prestamo = new Prestamo();
                prestamo.IdPrestamo = idSeleccionado;
                prestamo.IdUsuario = cmbUsuario.SelectedValue == null ? 0 : (int)cmbUsuario.SelectedValue;
                prestamo.IdLibro = cmbLibro.SelectedValue == null ? 0 : (int)cmbLibro.SelectedValue;
                prestamo.FechaPrestamo = dtpFechaPrestamo.Value.Date;
                prestamo.FechaDevolucionPrevista = dtpFechaPrevista.Value.Date;

                if (idSeleccionado == 0)
                {
                    prestamoNegocio.Registrar(prestamo);
                    Mensajes.Informacion("Préstamo registrado correctamente.");
                }
                else
                {
                    prestamoNegocio.Actualizar(prestamo);
                    Mensajes.Informacion("Préstamo actualizado correctamente.");
                }

                // Se recargan los libros porque cambió la cantidad disponible
                CargarCombos();
                CargarPrestamos();
                Limpiar();
            }
            catch (Exception ex)
            {
                Mensajes.MostrarExcepcion(ex);
            }
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                Mensajes.Advertencia("Seleccione un préstamo de la lista.");
                return;
            }

            if (!Mensajes.Confirmar("¿Registrar la devolución del préstamo N° " + idSeleccionado + "?"))
                return;

            try
            {
                prestamoNegocio.RegistrarDevolucion(idSeleccionado, dtpFechaDevolucion.Value.Date);
                Mensajes.Informacion("Devolución registrada correctamente.");

                CargarCombos();
                CargarPrestamos();
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
                Mensajes.Advertencia("Seleccione un préstamo de la lista.");
                return;
            }

            string mensaje = "¿Está seguro de eliminar el préstamo N° " + idSeleccionado + "?";
            if (txtEstado.Text.StartsWith("Prestado"))
                mensaje += "\nEl libro todavía no ha sido devuelto, el ejemplar volverá a quedar disponible.";

            if (!Mensajes.Confirmar(mensaje))
                return;

            try
            {
                prestamoNegocio.Eliminar(idSeleccionado);
                Mensajes.Informacion("Préstamo eliminado correctamente.");

                CargarCombos();
                CargarPrestamos();
                Limpiar();
            }
            catch (Exception ex)
            {
                Mensajes.MostrarExcepcion(ex);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
