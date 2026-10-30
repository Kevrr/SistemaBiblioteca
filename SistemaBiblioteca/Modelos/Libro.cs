namespace SistemaBiblioteca.Modelos
{
    public class Libro
    {
        private string isbn;
        private string titulo;
        private string genero;

        public int IdLibro { get; set; }

        public string ISBN
        {
            get { return isbn; }
            set { isbn = value?.Trim(); }
        }

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value?.Trim(); }
        }

        public int IdAutor { get; set; }
        public int IdEditorial { get; set; }
        public int? AnioPublicacion { get; set; }

        public string Genero
        {
            get { return genero; }
            set { genero = string.IsNullOrWhiteSpace(value) ? null : value.Trim(); }
        }

        public int Existencias { get; set; }
        public int Disponibles { get; set; }

        // Estos dos campos no están en la tabla Libros, vienen del JOIN
        // y se usan para mostrar los nombres en la tabla del formulario
        public string NombreAutor { get; set; }
        public string NombreEditorial { get; set; }

        // Cantidad de ejemplares que están prestados en este momento
        public int Prestados
        {
            get { return Existencias - Disponibles; }
        }

        public bool HayDisponibles()
        {
            return Disponibles > 0;
        }

        public Libro()
        {
        }

        public Libro(int idLibro, string isbn, string titulo, int idAutor, int idEditorial,
                     int? anioPublicacion, string genero, int existencias, int disponibles)
        {
            IdLibro = idLibro;
            ISBN = isbn;
            Titulo = titulo;
            IdAutor = idAutor;
            IdEditorial = idEditorial;
            AnioPublicacion = anioPublicacion;
            Genero = genero;
            Existencias = existencias;
            Disponibles = disponibles;
        }

        public override string ToString()
        {
            return Titulo + " (Disp: " + Disponibles + ")";
        }
    }
}
