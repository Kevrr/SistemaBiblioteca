namespace SistemaBiblioteca.Modelos
{
    public class Usuario : Persona
    {
        private string documento;
        private string telefono;
        private string correo;

        public int IdUsuario { get; set; }

        public string Documento
        {
            get { return documento; }
            set { documento = value?.Trim(); }
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

        public DateTime FechaRegistro { get; set; }

        public Usuario()
        {
            FechaRegistro = DateTime.Today;
        }

        public Usuario(int idUsuario, string documento, string nombre, string apellido,
                       string telefono, string correo, DateTime fechaRegistro)
            : base(nombre, apellido)
        {
            IdUsuario = idUsuario;
            Documento = documento;
            Telefono = telefono;
            Correo = correo;
            FechaRegistro = fechaRegistro;
        }

        public override string ObtenerDescripcion()
        {
            return "Usuario: " + NombreCompleto + " - Doc. " + Documento;
        }

        // En los ComboBox se muestra el documento y el nombre
        public override string ToString()
        {
            return Documento + " - " + NombreCompleto;
        }
    }
}
