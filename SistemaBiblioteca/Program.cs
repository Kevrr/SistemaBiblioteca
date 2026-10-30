using SistemaBiblioteca.Formularios;

namespace SistemaBiblioteca
{
    internal static class Program
    {
        /// <summary>
        ///  Entrada de la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmPrincipal());
        }
    }
}
