namespace Entidad
{
    public class ProductoOpticoEntidad
    {
        private int _codigoProducto;
        private int _codigoTipoProducto;
        private string _nombre;
        private string _descripcion;
        private string _marca;
        private decimal _precio;
        private string _estado;
        private string _nombreTipoProducto;

        public int CodigoProducto
        {
            get { return _codigoProducto; }
            set { _codigoProducto = value; }
        }

        public int CodigoTipoProducto
        {
            get { return _codigoTipoProducto; }
            set { _codigoTipoProducto = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public string Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }

        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public string NombreTipoProducto
        {
            get { return _nombreTipoProducto; }
            set { _nombreTipoProducto = value; }
        }

        public ProductoOpticoEntidad()
        {
            _codigoProducto = 0;
            _codigoTipoProducto = 0;
            _nombre = string.Empty;
            _descripcion = string.Empty;
            _marca = string.Empty;
            _precio = 0;
            _estado = string.Empty;
            _nombreTipoProducto = string.Empty;
        }

        public ProductoOpticoEntidad(
            int codigoProducto,
            int codigoTipoProducto,
            string nombre,
            string descripcion,
            string marca,
            decimal precio,
            string estado,
            string nombreTipoProducto)
        {
            _codigoProducto = codigoProducto;
            _codigoTipoProducto = codigoTipoProducto;
            _nombre = nombre;
            _descripcion = descripcion;
            _marca = marca;
            _precio = precio;
            _estado = estado;
            _nombreTipoProducto = nombreTipoProducto;
        }
    }
}
