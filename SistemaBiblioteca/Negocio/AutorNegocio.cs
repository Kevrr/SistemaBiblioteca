using SistemaBiblioteca.Datos;
using SistemaBiblioteca.Modelos;
using SistemaBiblioteca.Utilidades;

namespace SistemaBiblioteca.Negocio
{
    public class AutorNegocio
    {
        private readonly AutorDatos autorDatos = new AutorDatos();

        public List<Autor> Listar(string filtro = "")
        {
            return autorDatos.Listar(filtro.Trim());
        }

        public Autor ObtenerPorId(int idAutor)
        {
            return autorDatos.ObtenerPorId(idAutor);
        }

        // Si el IdAutor es 0 se inserta, si no se actualiza
        public void Guardar(Autor autor)
        {
            Validar(autor);

            if (autor.IdAutor == 0)
            {
                autor.IdAutor = autorDatos.Insertar(autor);
            }
            else
            {
                if (!autorDatos.Actualizar(autor))
                    throw new ValidacionException("No se encontró el autor que se quiere modificar.");
            }
        }

        public void Eliminar(int idAutor)
        {
            int libros = autorDatos.ContarLibros(idAutor);
            if (libros > 0)
                throw new ValidacionException("No se puede eliminar el autor porque tiene " + libros + " libro(s) registrado(s).");

            autorDatos.Eliminar(idAutor);
        }

        private void Validar(Autor autor)
        {
            if (Validaciones.EstaVacio(autor.Nombre))
                throw new ValidacionException("El nombre del autor es obligatorio.");

            if (Validaciones.EstaVacio(autor.Apellido))
                throw new ValidacionException("El apellido del autor es obligatorio.");

            if (!Validaciones.LongitudValida(autor.Nombre, 60) || !Validaciones.LongitudValida(autor.Apellido, 60))
                throw new ValidacionException("El nombre y el apellido no pueden tener más de 60 caracteres.");

            if (!Validaciones.LongitudValida(autor.Nacionalidad, 50))
                throw new ValidacionException("La nacionalidad no puede tener más de 50 caracteres.");

            if (autor.FechaNacimiento.HasValue && autor.FechaNacimiento.Value.Date >= DateTime.Today)
                throw new ValidacionException("La fecha de nacimiento debe ser anterior a la fecha actual.");
        }
    }
}
