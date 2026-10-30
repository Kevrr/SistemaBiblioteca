namespace SistemaBiblioteca.Modelos
{
    public class Autor : Persona
    {
        private string nacionalidad;

        public int IdAutor { get; set; }

        public string Nacionalidad
        {
            get { return nacionalidad; }
            set { nacionalidad = string.IsNullOrWhiteSpace(value) ? null : value.Trim(); }
        }

        public DateTime? FechaNacimiento { get; set; }

        public Autor()
        {
        }

        public Autor(int idAutor, string nombre, string apellido, string nacionalidad, DateTime? fechaNacimiento)
            : base(nombre, apellido)
        {
            IdAutor = idAutor;
            Nacionalidad = nacionalidad;
            FechaNacimiento = fechaNacimiento;
        }

        public override string ObtenerDescripcion()
        {
            if (string.IsNullOrEmpty(Nacionalidad))
                return "Autor: " + NombreCompleto;

            return "Autor: " + NombreCompleto + " (" + Nacionalidad + ")";
        }
    }
}
