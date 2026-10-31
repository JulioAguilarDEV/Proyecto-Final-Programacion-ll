using Datos;
using Entidad;
using System;

namespace Negocio
{
    public class UsuarioNegocio
    {
        private readonly UsuarioDatos _usuarioDatos = new UsuarioDatos();

        // Revisa que se hayan ingresado los dos campos antes de consultar la base.
        public UsuarioEntidad MtdIniciarSesion(string nombreUsuario, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
            {
                throw new Exception("Debe ingresar el nombre de usuario.");
            }

            if (string.IsNullOrWhiteSpace(contrasena))
            {
                throw new Exception("Debe ingresar la contraseña.");
            }

            return _usuarioDatos.MtdIniciarSesion(nombreUsuario.Trim(), contrasena);
        }
    }
}
