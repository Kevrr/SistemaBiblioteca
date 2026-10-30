using SistemaBiblioteca.Datos;
using SistemaBiblioteca.Modelos;
using SistemaBiblioteca.Utilidades;

namespace SistemaBiblioteca.Negocio
{
    public class UsuarioNegocio
    {
        private readonly UsuarioDatos usuarioDatos = new UsuarioDatos();

        public List<Usuario> Listar(string filtro = "")
        {
            return usuarioDatos.Listar(filtro.Trim());
        }

        public Usuario ObtenerPorId(int idUsuario)
        {
            return usuarioDatos.ObtenerPorId(idUsuario);
        }

        public void Guardar(Usuario usuario)
        {
            Validar(usuario);

            if (usuario.IdUsuario == 0)
            {
                usuario.IdUsuario = usuarioDatos.Insertar(usuario);
            }
            else
            {
                if (!usuarioDatos.Actualizar(usuario))
                    throw new ValidacionException("No se encontró el usuario que se quiere modificar.");
            }
        }

        // No se deja eliminar un usuario con préstamos para no perder el historial
        public void Eliminar(int idUsuario)
        {
            int prestamos = usuarioDatos.ContarPrestamos(idUsuario);
            if (prestamos > 0)
                throw new ValidacionException("No se puede eliminar el usuario porque tiene " + prestamos + " préstamo(s) en el historial.");

            usuarioDatos.Eliminar(idUsuario);
        }

        private void Validar(Usuario usuario)
        {
            if (Validaciones.EstaVacio(usuario.Documento))
                throw new ValidacionException("El documento es obligatorio.");

            if (!Validaciones.SoloNumeros(usuario.Documento))
                throw new ValidacionException("El documento solo debe contener números.");

            if (usuario.Documento.Length < 5 || usuario.Documento.Length > 20)
                throw new ValidacionException("El documento debe tener entre 5 y 20 dígitos.");

            if (Validaciones.EstaVacio(usuario.Nombre))
                throw new ValidacionException("El nombre es obligatorio.");

            if (Validaciones.EstaVacio(usuario.Apellido))
                throw new ValidacionException("El apellido es obligatorio.");

            if (!Validaciones.LongitudValida(usuario.Nombre, 60) || !Validaciones.LongitudValida(usuario.Apellido, 60))
                throw new ValidacionException("El nombre y el apellido no pueden tener más de 60 caracteres.");

            if (usuario.Telefono != null)
            {
                if (!Validaciones.SoloNumeros(usuario.Telefono))
                    throw new ValidacionException("El teléfono solo debe contener números.");

                if (usuario.Telefono.Length < 7 || usuario.Telefono.Length > 20)
                    throw new ValidacionException("El teléfono debe tener entre 7 y 20 dígitos.");
            }

            if (usuario.Correo != null)
            {
                if (!Validaciones.CorreoValido(usuario.Correo))
                    throw new ValidacionException("El correo electrónico no tiene un formato válido.");

                if (!Validaciones.LongitudValida(usuario.Correo, 100))
                    throw new ValidacionException("El correo no puede tener más de 100 caracteres.");
            }

            if (usuarioDatos.ExisteDocumento(usuario.Documento, usuario.IdUsuario))
                throw new ValidacionException("Ya existe un usuario registrado con ese documento.");
        }
    }
}
