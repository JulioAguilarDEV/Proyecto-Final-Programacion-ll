using Datos;
using Entidad;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class OrdenNegocio
    {
        private readonly OrdenDatos _ordenDatos = new OrdenDatos();

        public List<OrdenEntidad> MtdConsultar()
        {
            return _ordenDatos.MtdConsultar();
        }

        public List<OrdenEntidad> MtdBuscar(string filtro)
        {
            if (string.IsNullOrWhiteSpace(filtro))
            {
                throw new Exception("Ingrese el código, cliente, sucursal o estado que desea buscar.");
            }

            if (filtro.Trim().Length > 100)
            {
                throw new Exception("El texto de búsqueda no puede exceder 100 caracteres.");
            }

            return _ordenDatos.MtdBuscar(filtro.Trim());
        }

        public bool MtdAgregar(OrdenEntidad orden)
        {
            MtdValidarDatos(orden);
            return _ordenDatos.MtdAgregar(orden);
        }

        public bool MtdEditar(OrdenEntidad orden)
        {
            if (orden == null || orden.CodigoOrden <= 0)
            {
                throw new Exception("Seleccione una orden válida para editar.");
            }

            MtdValidarDatos(orden);
            return _ordenDatos.MtdEditar(orden);
        }

        public bool MtdEliminar(int codigoOrden)
        {
            if (codigoOrden <= 0)
            {
                throw new Exception("El código de la orden no es válido.");
            }

            return _ordenDatos.MtdEliminar(codigoOrden);
        }

        private void MtdValidarDatos(OrdenEntidad orden)
        {
            if (orden == null)
            {
                throw new Exception("Los datos de la orden no pueden ser nulos.");
            }

            if (orden.CodigoCliente <= 0)
            {
                throw new Exception("Seleccione un cliente.");
            }

            if (orden.CodigoSucursal <= 0)
            {
                throw new Exception("Seleccione una sucursal.");
            }

            if (orden.CodigoProducto <= 0)
            {
                throw new Exception("Seleccione un producto.");
            }

            if (orden.Cantidad <= 0)
            {
                throw new Exception("La cantidad debe ser mayor que cero.");
            }

            if (orden.PrecioUnitario <= 0 || orden.PrecioUnitario > 99999999.99m)
            {
                throw new Exception("El precio debe ser mayor que cero y no superar 99,999,999.99.");
            }

            orden.Subtotal = Math.Round(orden.Cantidad * orden.PrecioUnitario, 2);
            if (orden.Subtotal > 99999999.99m)
            {
                throw new Exception("El subtotal no puede superar 99,999,999.99.");
            }

            if (orden.Estado != "En proceso" &&
                orden.Estado != "Lista" &&
                orden.Estado != "Entregada" &&
                orden.Estado != "Anulada")
            {
                throw new Exception("Seleccione un estado válido para la orden.");
            }
        }
    }
}
