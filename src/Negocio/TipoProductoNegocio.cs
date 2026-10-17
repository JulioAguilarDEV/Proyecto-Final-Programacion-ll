using Datos;
using Entidad;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class TipoProductoNegocio
    {
        private readonly TipoProductoDatos _tipoProductoDatos = new TipoProductoDatos();

        public List<TipoProductoEntidad> MtdConsultar()
        {
            return _tipoProductoDatos.MtdConsultar();
        }

        public bool MtdAgregar(TipoProductoEntidad tipoProducto)
        {
            MtdValidarDatos(tipoProducto);
            return _tipoProductoDatos.MtdAgregar(tipoProducto);
        }

        public TipoProductoEntidad MtdBuscar(int codigoTipoProducto)
        {
            if (codigoTipoProducto <= 0)
            {
                throw new Exception("El código del tipo de producto debe ser mayor que cero.");
            }

            return _tipoProductoDatos.MtdBuscar(codigoTipoProducto);
        }

        public bool MtdEditar(TipoProductoEntidad tipoProducto)
        {
            if (tipoProducto == null || tipoProducto.CodigoTipoProducto <= 0)
            {
                throw new Exception("Debe seleccionar un tipo de producto válido.");
            }

            MtdValidarDatos(tipoProducto);
            return _tipoProductoDatos.MtdEditar(tipoProducto);
        }

        public bool MtdEliminar(int codigoTipoProducto)
        {
            if (codigoTipoProducto <= 0)
            {
                throw new Exception("El código del tipo de producto no es válido.");
            }

            return _tipoProductoDatos.MtdEliminar(codigoTipoProducto);
        }

        private void MtdValidarDatos(TipoProductoEntidad tipoProducto)
        {
            if (tipoProducto == null)
            {
                throw new Exception("Los datos del tipo de producto no pueden ser nulos.");
            }

            if (string.IsNullOrWhiteSpace(tipoProducto.Nombre))
            {
                throw new Exception("Debe ingresar el nombre del tipo de producto.");
            }

            if (tipoProducto.Nombre.Trim().Length > 80)
            {
                throw new Exception("El nombre no puede exceder 80 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(tipoProducto.Descripcion))
            {
                throw new Exception("Debe ingresar la descripción del tipo de producto.");
            }

            if (tipoProducto.Descripcion.Trim().Length > 200)
            {
                throw new Exception("La descripción no puede exceder 200 caracteres.");
            }

            if (tipoProducto.Estado != "Activo" && tipoProducto.Estado != "Inactivo")
            {
                throw new Exception("Debe seleccionar un estado válido.");
            }
        }
    }
}