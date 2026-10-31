using System.Collections.Generic;

namespace Entidad
{
    public class RolEntidad
    {
        // Propiedades que corresponden a dbo.Rol.
        public int CodigoRol { get; set; }
        public string NombreRol { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        // Lista de accesos del rol, obtenida de dbo.RolAcceso.
        public List<string> Accesos { get; set; }

        // Inicializa los textos y la lista de accesos.
        public RolEntidad()
        {
            NombreRol = string.Empty;
            Descripcion = string.Empty;
            Estado = string.Empty;
            Accesos = new List<string>();
        }

        // Carga los datos principales del rol consultado.
        public RolEntidad(int codigoRol, string nombreRol, string descripcion, string estado)
            : this()
        {
            CodigoRol = codigoRol;
            NombreRol = nombreRol;
            Descripcion = descripcion;
            Estado = estado;
        }
    }
}
