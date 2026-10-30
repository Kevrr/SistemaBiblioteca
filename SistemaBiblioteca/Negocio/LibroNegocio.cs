using SistemaBiblioteca.Datos;
using SistemaBiblioteca.Modelos;
using SistemaBiblioteca.Utilidades;

namespace SistemaBiblioteca.Negocio
{
    public class LibroNegocio
    {
        private readonly LibroDatos libroDatos = new LibroDatos();
        private readonly AutorDatos autorDatos = new AutorDatos();
        private readonly EditorialDatos editorialDatos = new EditorialDatos();

        public List<Libro> Listar(string criterio = "Título", string filtro = "")
        {
            return libroDatos.Listar(criterio, filtro.Trim());
        }

        public Libro ObtenerPorId(int idLibro)
        {
            return libroDatos.ObtenerPorId(idLibro);
        }

        public void Guardar(Libro libro)
        {
            Validar(libro);

            if (libro.IdLibro == 0)
            {
                libro.IdLibro = libroDatos.Insertar(libro);
            }
            else
            {
                // No se puede dejar el libro con menos ejemplares de los que están prestados
                Libro actual = libroDatos.ObtenerPorId(libro.IdLibro);
                if (actual == null)
                    throw new ValidacionException("No se encontró el libro que se quiere modificar.");

                if (libro.Existencias < actual.Prestados)
                    throw new ValidacionException("Hay " + actual.Prestados + " ejemplar(es) prestado(s). " +
                                                  "Las existencias no pueden ser menores a esa cantidad.");

                libroDatos.Actualizar(libro);
            }
        }

        public void Eliminar(int idLibro)
        {
            int prestamos = libroDatos.ContarPrestamos(idLibro);
            if (prestamos > 0)
                throw new ValidacionException("No se puede eliminar el libro porque tiene " + prestamos + " préstamo(s) registrado(s).");

            libroDatos.Eliminar(idLibro);
        }

        private void Validar(Libro libro)
        {
            if (Validaciones.EstaVacio(libro.ISBN))
                throw new ValidacionException("El ISBN es obligatorio.");

            if (!Validaciones.ISBNValido(libro.ISBN) || libro.ISBN.Length > 20)
                throw new ValidacionException("El ISBN solo puede tener números y guiones (máximo 20 caracteres).");

            if (Validaciones.EstaVacio(libro.Titulo))
                throw new ValidacionException("El título es obligatorio.");

            if (!Validaciones.LongitudValida(libro.Titulo, 150))
                throw new ValidacionException("El título no puede tener más de 150 caracteres.");

            if (!Validaciones.LongitudValida(libro.Genero, 50))
                throw new ValidacionException("El género no puede tener más de 50 caracteres.");

            if (libro.AnioPublicacion.HasValue &&
                (libro.AnioPublicacion < 1450 || libro.AnioPublicacion > DateTime.Today.Year))
                throw new ValidacionException("El año de publicación debe estar entre 1450 y " + DateTime.Today.Year + ".");

            if (libro.Existencias < 0)
                throw new ValidacionException("Las existencias no pueden ser negativas.");

            // Se comprueba que el autor y la editorial existan en la base de datos
            if (libro.IdAutor <= 0 || autorDatos.ObtenerPorId(libro.IdAutor) == null)
                throw new ValidacionException("Debe seleccionar un autor válido.");

            if (libro.IdEditorial <= 0 || editorialDatos.ObtenerPorId(libro.IdEditorial) == null)
                throw new ValidacionException("Debe seleccionar una editorial válida.");

            if (libroDatos.ExisteISBN(libro.ISBN, libro.IdLibro))
                throw new ValidacionException("Ya existe un libro registrado con ese ISBN.");
        }
    }
}
