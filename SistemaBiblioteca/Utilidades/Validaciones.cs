using System.Text.RegularExpressions;

namespace SistemaBiblioteca.Utilidades
{
    /// <summary>
    /// Métodos de validación que se repiten en varios módulos.
    /// </summary>
    public static class Validaciones
    {
        public static bool EstaVacio(string texto)
        {
            return string.IsNullOrWhiteSpace(texto);
        }

        public static bool SoloNumeros(string texto)
        {
            return !string.IsNullOrEmpty(texto) && texto.All(char.IsDigit);
        }

        public static bool CorreoValido(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo))
                return false;

            return Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        // Para el ISBN se permiten números, guiones y la X final
        public static bool ISBNValido(string isbn)
        {
            return Regex.IsMatch(isbn, @"^[0-9Xx\-]+$");
        }

        public static bool LongitudValida(string texto, int maximo)
        {
            return texto == null || texto.Length <= maximo;
        }
    }
}
