using SistemaBiblioteca.Modelos;
using SistemaBiblioteca.Negocio;
using SistemaBiblioteca.Utilidades;

namespace SistemaBiblioteca.Formularios
{
    public partial class FrmLibros : Form
    {
        private readonly LibroNegocio libroNegocio = new LibroNegocio();
        private readonly AutorNegocio autorNegocio = new AutorNegocio();
        private readonly EditorialNegocio editorialNegocio = new EditorialNegocio();
        private int idSeleccionado = 0;

        public FrmLibros()
        {
            InitializeComponent();
        }

        private void FrmLibros_Load(object sender, EventArgs e)
        {
            cmbCriterio.Items.AddRange(new object[] { "Título", "ISBN", "Autor" });
            cmbCriterio.SelectedIndex = 0;

            CargarCombos();
            CargarLibros();
            Limpiar();
        }

        private void CargarCombos()
        {
            try
            {
                cmbAutor.DataSource = autorNegocio.Listar();
                cmbAutor.DisplayMember = "NombreCompleto";
                cmbAutor.ValueMember = "IdAutor";

                cmbEditorial.DataSource = editorialNegocio.Listar();
                cmbEditorial.DisplayMember = "Nombre";
                cmbEditorial.ValueMember = "IdEditorial";
            }
            catch (Exception ex)
            {
                Mensajes.MostrarExcepcion(ex);
            }
        }

        private void CargarLibros()
        {
            try
            {
                string criterio = cmbCriterio.SelectedItem?.ToString() ?? "Título";

                dgvLibros.DataSource = null;
                dgvLibros.DataSource = libroNegocio.Listar(criterio, txtBuscar.Text);

                Grilla.OcultarColumnas(dgvLibros, "IdAutor", "IdEditorial", "Prestados");
                Grilla.OrdenarColumnas(dgvLibros, "IdLibro", "ISBN", "Titulo", "NombreAutor", "NombreEditorial",
                                       "AnioPublicacion", "Genero", "Existencias", "Disponibles");
                Grilla.CambiarTitulo(dgvLibros, "IdLibro", "Código");
                Grilla.CambiarTitulo(dgvLibros, "Titulo", "Título");
                Grilla.CambiarTitulo(dgvLibros, "NombreAutor", "Autor");
                Grilla.CambiarTitulo(dgvLibros, "NombreEditorial", "Editorial");
                Grilla.CambiarTitulo(dgvLibros, "AnioPublicacion", "Año");
                Grilla.CambiarTitulo(dgvLibros, "Genero", "Género");

                // El título es la columna más larga
                if (dgvLibros.Columns.Contains("Titulo"))
                    dgvLibros.Columns["Titulo"].FillWeight = 200;
            }
            catch (Exception ex)
            {
                Mensajes.MostrarExcepcion(ex);
            }
        }

        private void Limpiar()
        {
            idSeleccionado = 0;
            txtIdLibro.Clear();
            txtISBN.Clear();
            txtTitulo.Clear();
            cmbAutor.SelectedIndex = -1;
            cmbEditorial.SelectedIndex = -1;
            txtAnio.Clear();
            txtGenero.Clear();
            nudExistencias.Value = 1;
            txtDisponibles.Text = "";
            btnEliminar.Enabled = false;
            dgvLibros.ClearSelection();
            txtISBN.Focus();
        }

        private Libro ObtenerDatosFormulario()
        {
            int? anio = null;
            if (!string.IsNullOrWhiteSpace(txtAnio.Text))
            {
                if (!int.TryParse(txtAnio.Text.Trim(), out int valor))
                    throw new ValidacionException("El año de publicación debe ser un número.");
                anio = valor;
            }

            Libro libro = new Libro();
            libro.IdLibro = idSeleccionado;
            libro.ISBN = txtISBN.Text;
            libro.Titulo = txtTitulo.Text;
            libro.IdAutor = cmbAutor.SelectedValue == null ? 0 : (int)cmbAutor.SelectedValue;
            libro.IdEditorial = cmbEditorial.SelectedValue == null ? 0 : (int)cmbEditorial.SelectedValue;
            libro.AnioPublicacion = anio;
            libro.Genero = txtGenero.Text;
            libro.Existencias = (int)nudExistencias.Value;
            return libro;
        }

        private void dgvLibros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            Libro libro = (Libro)dgvLibros.Rows[e.RowIndex].DataBoundItem;

            idSeleccionado = libro.IdLibro;
            txtIdLibro.Text = libro.IdLibro.ToString();
            txtISBN.Text = libro.ISBN;
            txtTitulo.Text = libro.Titulo;
            cmbAutor.SelectedValue = libro.IdAutor;
            cmbEditorial.SelectedValue = libro.IdEditorial;
            txtAnio.Text = libro.AnioPublicacion?.ToString() ?? "";
            txtGenero.Text = libro.Genero;
            nudExistencias.Value = libro.Existencias;
            txtDisponibles.Text = libro.Disponibles.ToString();
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
                Libro libro = ObtenerDatosFormulario();
                bool esNuevo = libro.IdLibro == 0;

                libroNegocio.Guardar(libro);

                Mensajes.Informacion(esNuevo ? "Libro registrado correctamente." : "Libro actualizado correctamente.");
                CargarLibros();
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
                Mensajes.Advertencia("Seleccione un libro de la lista.");
                return;
            }

            if (!Mensajes.Confirmar("¿Está seguro de eliminar el libro \"" + txtTitulo.Text + "\"?"))
                return;

            try
            {
                libroNegocio.Eliminar(idSeleccionado);
                Mensajes.Informacion("Libro eliminado correctamente.");
                CargarLibros();
                Limpiar();
            }
            catch (Exception ex)
            {
                Mensajes.MostrarExcepcion(ex);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarLibros();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarLibros();
                e.SuppressKeyPress = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
