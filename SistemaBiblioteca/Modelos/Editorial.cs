namespace SistemaBiblioteca.Modelos
{
    public class Editorial
    {
        private string nombre;
        private string pais;
        private string telefono;
        private string correo;

        public int IdEditorial { get; set; }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value?.Trim(); }
        }

        public string Pais
        {
            get { return pais; }
            set { pais = string.IsNullOrWhiteSpace(value) ? null : value.Trim(); }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = string.IsNullOrWhiteSpace(value) ? null : value.Trim(); }
        }

        public string Correo
        {
            get { return correo; }
            set { correo = string.IsNullOrWhiteSpace(value) ? null : value.Trim().ToLower(); }
        }

        public Editorial()
        {
        }

        public Editorial(int idEditorial, string nombre, string pais, string telefono, string correo)
        {
            IdEditorial = idEditorial;
            Nombre = nombre;
            Pais = pais;
            Telefono = telefono;
            Correo = correo;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
