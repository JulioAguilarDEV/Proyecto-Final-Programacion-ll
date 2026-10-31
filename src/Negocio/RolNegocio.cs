using Datos;
using Entidad;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class RolNegocio
    {
        private readonly RolDatos _rolDatos = new RolDatos();

        public static readonly string[] AccesosDisponibles =
        {
            "Inicio", "Sucursales", "Usuarios", "Clientes", "Citas", "Optometristas",
            "Examenes", "Recetas", "TiposProducto", "Productos", "Ordenes", "Entregas"
        };

        // Consulta todos los roles con la lista de accesos asignados.
        public List<RolEntidad> MtdConsultar()
        {
            return _rolDatos.MtdConsultar();
        }

        // Valida y guarda un rol nuevo junto con sus accesos.
        public bool MtdAgregar(RolEntidad rol)
        {
            MtdValidarDatos(rol);
            return _rolDatos.MtdAgregar(rol);
        }

        // Valida y actualiza el rol y los accesos seleccionados.
        public bool MtdEditar(RolEntidad rol, string nombreAnterior)
        {
            if (rol == null || rol.CodigoRol <= 0)
            {
                throw new Exception("Debe seleccionar un rol válido.");
            }

            MtdValidarDatos(rol);

            if (nombreAnterior == "Administrador"
                && (rol.NombreRol.Trim() != "Administrador" || rol.Estado != "Activo"))
            {
                throw new Exception("El rol Administrador debe conservar su nombre y permanecer activo.");
            }

            return _rolDatos.MtdEditar(rol, nombreAnterior);
        }

        // Comprueba que el rol se pueda eliminar antes de borrarlo.
        public bool MtdEliminar(int codigoRol)
        {
            if (codigoRol <= 0)
            {
                throw new Exception("El código del rol no es válido.");
            }

            RolEntidad rol = _rolDatos.MtdBuscar(codigoRol);
            if (rol != null && rol.NombreRol == "Administrador")
            {
                throw new Exception("No se puede eliminar el rol Administrador.");
            }

            return _rolDatos.MtdEliminar(codigoRol);
        }

        // Busca un rol por su código.
        public RolEntidad MtdBuscar(int codigoRol)
        {
            if (codigoRol <= 0)
            {
                throw new Exception("El código del rol no es válido.");
            }

            return _rolDatos.MtdBuscar(codigoRol);
        }

        // Comprueba los campos, el estado y los accesos permitidos.
        private void MtdValidarDatos(RolEntidad rol)
        {
            if (rol == null)
            {
                throw new Exception("Los datos del rol no pueden ser nulos.");
            }

            if (string.IsNullOrWhiteSpace(rol.NombreRol) || rol.NombreRol.Trim().Length > 30)
            {
                throw new Exception("El nombre del rol es obligatorio y no debe exceder 30 caracteres.");
            }

            if (rol.Descripcion == null || rol.Descripcion.Trim().Length > 150)
            {
                throw new Exception("La descripción no debe exceder 150 caracteres.");
            }

            if (rol.Estado != "Activo" && rol.Estado != "Inactivo")
            {
                throw new Exception("Debe seleccionar un estado válido.");
            }

            if (rol.Accesos == null || !rol.Accesos.Contains("Inicio"))
            {
                throw new Exception("Todo rol debe tener acceso a Inicio.");
            }

            foreach (string acceso in rol.Accesos)
            {
                bool accesoValido = false;
                foreach (string accesoDisponible in AccesosDisponibles)
                {
                    if (acceso == accesoDisponible)
                    {
                        accesoValido = true;
                        break;
                    }
                }

                if (!accesoValido)
                {
                    throw new Exception("Se seleccionó un acceso de menú no válido.");
                }
            }
        }
    }
}
