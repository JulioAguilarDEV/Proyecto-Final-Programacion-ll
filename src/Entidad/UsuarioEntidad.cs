using System.Collections.Generic;

namespace Entidad
{
    public class UsuarioEntidad
    {
        // Datos del usuario que se utilizan durante el inicio de sesión.
        public int CodigoUsuario { get; set; }
        public int CodigoSucursal { get; set; }
        public string NombreCompleto { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string Rol { get; set; }
        public string Estado { get; set; }

        // Accesos que se cargan desde las tablas del rol.
        public List<string> Accesos { get; set; }

        // Inicializa los textos y la lista de accesos.
        public UsuarioEntidad()
        {
            NombreCompleto = string.Empty;
            NombreUsuario = string.Empty;
            Contrasena = string.Empty;
            Rol = string.Empty;
            Estado = string.Empty;
            Accesos = new List<string>();
        }
    }
}
