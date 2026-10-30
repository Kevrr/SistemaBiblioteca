namespace SistemaBiblioteca.Modelos
{
    /// <summary>
    /// Clase base para las personas del sistema (autores y usuarios).
    /// Se usa herencia porque ambos comparten nombre y apellido.
    /// </summary>
    public abstract class Persona
    {
        private string nombre;
        private string apellido;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value?.Trim(); }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value?.Trim(); }
        }

        // Propiedad calculada, solo lectura
        public string NombreCompleto
        {
            get { return Nombre + " " + Apellido; }
        }

        protected Persona()
        {
        }

        protected Persona(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }

        // Cada clase hija decide cómo se describe (polimorfismo)
        public abstract string ObtenerDescripcion();

        public override string ToString()
        {
            return NombreCompleto;
        }
    }
}
