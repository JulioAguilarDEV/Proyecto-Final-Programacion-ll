using Datos;
using Entidad;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class ProductoOpticoNegocio
    {
        private readonly ProductoOpticoDatos _productoOpticoDatos = new ProductoOpticoDatos();

        public List<ProductoOpticoEntidad> MtdConsultar()
        {
            return _productoOpticoDatos.MtdConsultar();
        }

        public bool MtdAgregar(ProductoOpticoEntidad producto)
        {
            MtdValidarDatos(producto);
            return _productoOpticoDatos.MtdAgregar(producto);
        }

        public List<ProductoOpticoEntidad> MtdBuscar(string filtro)
        {
            if (string.IsNullOrWhiteSpace(filtro))
            {
                throw new Exception("Ingrese un código, nombre, descripción o marca para buscar.");
            }

            if (filtro.Trim().Length > 200)
            {
                throw new Exception("El texto de búsqueda no puede exceder 200 caracteres.");
            }

            return _productoOpticoDatos.MtdBuscar(filtro.Trim());
        }

        public ProductoOpticoEntidad MtdBuscar(int codigoProducto)
        {
            if (codigoProducto <= 0)
            {
                throw new Exception("El código del producto debe ser mayor que cero.");
            }

            return _productoOpticoDatos.MtdBuscar(codigoProducto);
        }

        public bool MtdEditar(ProductoOpticoEntidad producto)
        {
            if (producto == null || producto.CodigoProducto <= 0)
            {
                throw new Exception("Debe seleccionar un producto válido para editar.");
            }

            MtdValidarDatos(producto);
            return _productoOpticoDatos.MtdEditar(producto);
        }

        public bool MtdEliminar(int codigoProducto)
        {
            if (codigoProducto <= 0)
            {
                throw new Exception("El código del producto no es válido.");
            }

            return _productoOpticoDatos.MtdEliminar(codigoProducto);
        }

        private void MtdValidarDatos(ProductoOpticoEntidad producto)
        {
            if (producto == null)
            {
                throw new Exception("Los datos del producto no pueden ser nulos.");
            }

            if (producto.CodigoTipoProducto <= 0)
            {
                throw new Exception("Seleccione un tipo de producto.");
            }

            if (string.IsNullOrWhiteSpace(producto.Nombre) || producto.Nombre.Trim().Length > 100)
            {
                throw new Exception("Ingrese un nombre de producto de hasta 100 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(producto.Descripcion) || producto.Descripcion.Trim().Length > 200)
            {
                throw new Exception("Ingrese una descripción de hasta 200 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(producto.Marca) || producto.Marca.Trim().Length > 60)
            {
                throw new Exception("Ingrese una marca de hasta 60 caracteres.");
            }

            if (producto.Precio <= 0 || producto.Precio > 99999999.99m)
            {
                throw new Exception("El precio debe ser mayor que cero y no superar 99,999,999.99.");
            }

            if (producto.Estado != "Activo" && producto.Estado != "Inactivo")
            {
                throw new Exception("Seleccione un estado válido.");
            }
        }
    }
}
