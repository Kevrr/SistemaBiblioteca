using SistemaBiblioteca.Datos;
using SistemaBiblioteca.Modelos;

namespace SistemaBiblioteca.Negocio
{
    public class PrestamoNegocio
    {
        // Reglas del préstamo
        public const int MaximoPrestamosActivos = 3;
        public const int MaximoDiasPrestamo = 30;

        private readonly PrestamoDatos prestamoDatos = new PrestamoDatos();
        private readonly UsuarioDatos usuarioDatos = new UsuarioDatos();
        private readonly LibroDatos libroDatos = new LibroDatos();

        public List<Prestamo> Listar(string estado = "Todos")
        {
            return prestamoDatos.Listar(estado);
        }

        public Prestamo ObtenerPorId(int idPrestamo)
        {
            return prestamoDatos.ObtenerPorId(idPrestamo);
        }

        public void Registrar(Prestamo prestamo)
        {
            ValidarDatosGenerales(prestamo);

            Libro libro = libroDatos.ObtenerPorId(prestamo.IdLibro);
            if (libro == null)
                throw new ValidacionException("El libro seleccionado no existe.");

            if (!libro.HayDisponibles())
                throw new ValidacionException("No hay ejemplares disponibles de \"" + libro.Titulo + "\".");

            if (prestamoDatos.ContarActivosUsuario(prestamo.IdUsuario) >= MaximoPrestamosActivos)
                throw new ValidacionException("El usuario ya tiene " + MaximoPrestamosActivos +
                                              " préstamos activos. Debe devolver un libro antes de pedir otro.");

            if (prestamoDatos.UsuarioTieneLibroPrestado(prestamo.IdUsuario, prestamo.IdLibro))
                throw new ValidacionException("El usuario ya tiene prestado este mismo libro.");

            try
            {
                prestamo.IdPrestamo = prestamoDatos.Registrar(prestamo);
            }
            catch (InvalidOperationException ex)
            {
                // Puede pasar si otro préstamo se llevó el último ejemplar justo antes
                throw new ValidacionException(ex.Message);
            }
        }

        public void Actualizar(Prestamo prestamo)
        {
            Prestamo actual = prestamoDatos.ObtenerPorId(prestamo.IdPrestamo);
            if (actual == null)
                throw new ValidacionException("No se encontró el préstamo.");

            if (actual.EstaDevuelto)
                throw new ValidacionException("No se puede editar un préstamo que ya fue devuelto.");

            ValidarDatosGenerales(prestamo);

            // Si se cambia el usuario hay que revisar las mismas reglas que al registrar
            if (prestamo.IdUsuario != actual.IdUsuario)
            {
                if (prestamoDatos.ContarActivosUsuario(prestamo.IdUsuario) >= MaximoPrestamosActivos)
                    throw new ValidacionException("El nuevo usuario ya tiene " + MaximoPrestamosActivos + " préstamos activos.");

                if (prestamoDatos.UsuarioTieneLibroPrestado(prestamo.IdUsuario, actual.IdLibro, prestamo.IdPrestamo))
                    throw new ValidacionException("El nuevo usuario ya tiene prestado este libro.");
            }

            prestamoDatos.Actualizar(prestamo);
        }

        public void RegistrarDevolucion(int idPrestamo, DateTime fechaDevolucion)
        {
            Prestamo prestamo = prestamoDatos.ObtenerPorId(idPrestamo);
            if (prestamo == null)
                throw new ValidacionException("No se encontró el préstamo.");

            if (prestamo.EstaDevuelto)
                throw new ValidacionException("Este préstamo ya fue devuelto.");

            if (fechaDevolucion.Date < prestamo.FechaPrestamo.Date)
                throw new ValidacionException("La fecha de devolución no puede ser anterior a la fecha del préstamo.");

            if (fechaDevolucion.Date > DateTime.Today)
                throw new ValidacionException("La fecha de devolución no puede ser una fecha futura.");

            if (!prestamoDatos.RegistrarDevolucion(idPrestamo, fechaDevolucion))
                throw new ValidacionException("No se pudo registrar la devolución.");
        }

        public void Eliminar(int idPrestamo)
        {
            if (!prestamoDatos.Eliminar(idPrestamo))
                throw new ValidacionException("No se encontró el préstamo que se quiere eliminar.");
        }

        private void ValidarDatosGenerales(Prestamo prestamo)
        {
            if (prestamo.IdUsuario <= 0 || usuarioDatos.ObtenerPorId(prestamo.IdUsuario) == null)
                throw new ValidacionException("Debe seleccionar un usuario válido.");

            if (prestamo.IdLibro <= 0)
                throw new ValidacionException("Debe seleccionar un libro.");

            if (prestamo.FechaPrestamo.Date > DateTime.Today)
                throw new ValidacionException("La fecha del préstamo no puede ser una fecha futura.");

            if (prestamo.FechaDevolucionPrevista.Date < prestamo.FechaPrestamo.Date)
                throw new ValidacionException("La fecha de devolución prevista no puede ser anterior a la fecha del préstamo.");

            if ((prestamo.FechaDevolucionPrevista.Date - prestamo.FechaPrestamo.Date).TotalDays > MaximoDiasPrestamo)
                throw new ValidacionException("El préstamo no puede ser mayor a " + MaximoDiasPrestamo + " días.");
        }
    }
}
