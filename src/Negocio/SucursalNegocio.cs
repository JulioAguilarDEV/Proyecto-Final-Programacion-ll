using Datos;
using Entidad;
using System.Collections.Generic;

namespace Negocio
{
    public class SucursalNegocio
    {
        private readonly SucursalDatos _sucursalDatos = new SucursalDatos();

        public List<SucursalEntidad> MtdConsultar()
        {
            return _sucursalDatos.MtdConsultar();
        }
    }
}
