using System;

namespace Entidad
{
    public class OrdenEntidad
    {
        private int _codigoOrden;
        private int _codigoDetalle;
        private int _codigoCliente;
        private string _nombreCliente;
        private int _codigoSucursal;
        private string _nombreSucursal;
        private DateTime _fecha;
        private string _estado;
        private int _codigoProducto;
        private string _nombreProducto;
        private int _cantidad;
        private decimal _precioUnitario;
        private decimal _subtotal;

        public int CodigoOrden
        {
            get { return _codigoOrden; }
            set { _codigoOrden = value; }
        }

        public int CodigoDetalle
        {
            get { return _codigoDetalle; }
            set { _codigoDetalle = value; }
        }

        public int CodigoCliente
        {
            get { return _codigoCliente; }
            set { _codigoCliente = value; }
        }

        public string NombreCliente
        {
            get { return _nombreCliente; }
            set { _nombreCliente = value; }
        }

        public int CodigoSucursal
        {
            get { return _codigoSucursal; }
            set { _codigoSucursal = value; }
        }

        public string NombreSucursal
        {
            get { return _nombreSucursal; }
            set { _nombreSucursal = value; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public int CodigoProducto
        {
            get { return _codigoProducto; }
            set { _codigoProducto = value; }
        }

        public string NombreProducto
        {
            get { return _nombreProducto; }
            set { _nombreProducto = value; }
        }

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public decimal PrecioUnitario
        {
            get { return _precioUnitario; }
            set { _precioUnitario = value; }
        }

        public decimal Subtotal
        {
            get { return _subtotal; }
            set { _subtotal = value; }
        }

        public OrdenEntidad()
        {
            _codigoOrden = 0;
            _codigoDetalle = 0;
            _codigoCliente = 0;
            _nombreCliente = string.Empty;
            _codigoSucursal = 0;
            _nombreSucursal = string.Empty;
            _fecha = DateTime.Now.Date;
            _estado = string.Empty;
            _codigoProducto = 0;
            _nombreProducto = string.Empty;
            _cantidad = 0;
            _precioUnitario = 0;
            _subtotal = 0;
        }

        public OrdenEntidad(
            int codigoOrden,
            int codigoDetalle,
            int codigoCliente,
            string nombreCliente,
            int codigoSucursal,
            string nombreSucursal,
            DateTime fecha,
            string estado,
            int codigoProducto,
            string nombreProducto,
            int cantidad,
            decimal precioUnitario,
            decimal subtotal)
        {
            _codigoOrden = codigoOrden;
            _codigoDetalle = codigoDetalle;
            _codigoCliente = codigoCliente;
            _nombreCliente = nombreCliente;
            _codigoSucursal = codigoSucursal;
            _nombreSucursal = nombreSucursal;
            _fecha = fecha;
            _estado = estado;
            _codigoProducto = codigoProducto;
            _nombreProducto = nombreProducto;
            _cantidad = cantidad;
            _precioUnitario = precioUnitario;
            _subtotal = subtotal;
        }
    }
}
