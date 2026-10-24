namespace Entidad
{
    public class SucursalEntidad
    {
        private int _codigoSucursal;
        private string _nombre;
        private string _estado;

        public int CodigoSucursal
        {
            get { return _codigoSucursal; }
            set { _codigoSucursal = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public SucursalEntidad()
        {
            _codigoSucursal = 0;
            _nombre = string.Empty;
            _estado = string.Empty;
        }

        public SucursalEntidad(int codigoSucursal, string nombre, string estado)
        {
            _codigoSucursal = codigoSucursal;
            _nombre = nombre;
            _estado = estado;
        }
    }
}
