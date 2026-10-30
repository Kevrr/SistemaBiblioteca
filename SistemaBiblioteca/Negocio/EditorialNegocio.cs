using SistemaBiblioteca.Datos;
using SistemaBiblioteca.Modelos;
using SistemaBiblioteca.Utilidades;

namespace SistemaBiblioteca.Negocio
{
    public class EditorialNegocio
    {
        private readonly EditorialDatos editorialDatos = new EditorialDatos();

        public List<Editorial> Listar(string filtro = "")
        {
            return editorialDatos.Listar(filtro.Trim());
        }

        public Editorial ObtenerPorId(int idEditorial)
        {
            return editorialDatos.ObtenerPorId(idEditorial);
        }

        public void Guardar(Editorial editorial)
        {
            Validar(editorial);

            if (editorial.IdEditorial == 0)
            {
                editorial.IdEditorial = editorialDatos.Insertar(editorial);
            }
            else
            {
                if (!editorialDatos.Actualizar(editorial))
                    throw new ValidacionException("No se encontró la editorial que se quiere modificar.");
            }
        }

        public void Eliminar(int idEditorial)
        {
            int libros = editorialDatos.ContarLibros(idEditorial);
            if (libros > 0)
                throw new ValidacionException("No se puede eliminar la editorial porque tiene " + libros + " libro(s) asociado(s).");

            editorialDatos.Eliminar(idEditorial);
        }

        private void Validar(Editorial editorial)
        {
            if (Validaciones.EstaVacio(editorial.Nombre))
                throw new ValidacionException("El nombre de la editorial es obligatorio.");

            if (!Validaciones.LongitudValida(editorial.Nombre, 100))
                throw new ValidacionException("El nombre no puede tener más de 100 caracteres.");

            if (!Validaciones.LongitudValida(editorial.Pais, 50))
                throw new ValidacionException("El país no puede tener más de 50 caracteres.");

            if (editorial.Telefono != null && (!Validaciones.SoloNumeros(editorial.Telefono) || editorial.Telefono.Length > 20))
                throw new ValidacionException("El teléfono solo debe tener números (máximo 20).");

            if (editorial.Correo != null && !Validaciones.CorreoValido(editorial.Correo))
                throw new ValidacionException("El correo electrónico no tiene un formato válido.");

            if (editorialDatos.ExisteNombre(editorial.Nombre, editorial.IdEditorial))
                throw new ValidacionException("Ya existe una editorial con ese nombre.");
        }
    }
}
