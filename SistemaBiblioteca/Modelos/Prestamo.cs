namespace SistemaBiblioteca.Modelos
{
    public class Prestamo
    {
        public const string EstadoPrestado = "Prestado";
        public const string EstadoDevuelto = "Devuelto";

        public int IdPrestamo { get; set; }
        public int IdUsuario { get; set; }
        public int IdLibro { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucionPrevista { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public string Estado { get; set; }

        // Datos para mostrar (vienen del JOIN con Usuarios y Libros)
        public string NombreUsuario { get; set; }
        public string TituloLibro { get; set; }

        public bool EstaDevuelto
        {
            get { return Estado == EstadoDevuelto; }
        }

        // Un préstamo está vencido si sigue prestado y ya pasó la fecha prevista
        public bool EstaVencido
        {
            get { return !EstaDevuelto && FechaDevolucionPrevista.Date < DateTime.Today; }
        }

        public Prestamo()
        {
            FechaPrestamo = DateTime.Today;
            FechaDevolucionPrevista = DateTime.Today.AddDays(15);
            Estado = EstadoPrestado;
        }

        public Prestamo(int idUsuario, int idLibro, DateTime fechaPrestamo, DateTime fechaDevolucionPrevista)
        {
            IdUsuario = idUsuario;
            IdLibro = idLibro;
            FechaPrestamo = fechaPrestamo;
            FechaDevolucionPrevista = fechaDevolucionPrevista;
            Estado = EstadoPrestado;
        }
    }
}
