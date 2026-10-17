namespace Entidad
{
    public class TipoProductoEntidad
    {
        private int _codigoTipoProducto;
        private string _nombre;
        private string _descripcion;
        private string _estado;

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

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public TipoProductoEntidad()
        {
            _codigoTipoProducto = 0;
            _nombre = string.Empty;
            _descripcion = string.Empty;
            _estado = string.Empty;
        }

        public TipoProductoEntidad(int codigoTipoProducto, string nombre, string descripcion, string estado)
        {
            _codigoTipoProducto = codigoTipoProducto;
            _nombre = nombre;
            _descripcion = descripcion;
            _estado = estado;
        }

        public TipoProductoEntidad(string nombre, string descripcion, string estado)
        {
            _codigoTipoProducto = 0;
            _nombre = nombre;
            _descripcion = descripcion;
            _estado = estado;
        }
    }
}