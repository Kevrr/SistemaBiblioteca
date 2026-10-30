namespace SistemaBiblioteca.Negocio
{
    /// <summary>
    /// Excepción propia para los errores de validación.
    /// Así en los formularios se puede diferenciar un dato mal ingresado
    /// de un error inesperado (por ejemplo, que se caiga la conexión).
    /// </summary>
    public class ValidacionException : Exception
    {
        public ValidacionException(string mensaje) : base(mensaje)
        {
        }
    }
}
