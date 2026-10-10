using System;

namespace Entidad
{
    public class ClienteEntidad
    {
        // =====================================================
        // POO: ENCAPSULAMIENTO
        // Los atributos se mantienen privados.
        // =====================================================

        private int _codigoCliente;
        private string _nombres;
        private string _apellidos;
        private string _dpi;
        private DateTime _fechaNacimiento;
        private string _telefono;
        private string _correo;           // Permite NULL en la BDD
        private string _direccion;        // Permite NULL en la BDD
        private string _estado;

        // =====================================================
        // POO: PROPIEDADES
        // Permiten acceder de forma controlada a los atributos.
        // =====================================================

        public int CodigoCliente
        {
            get { return _codigoCliente; }
            set { _codigoCliente = value; }
        }
        public string Nombres
        {
            get { return _nombres; }
            set { _nombres = value; }
        }
        public string Apellidos
        {
            get { return _apellidos; }
            set { _apellidos = value; }
        }
        public string DPI
        {
            get { return _dpi; }
            set { _dpi = value; }
        }
        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        // =====================================================
        // PROPIEDAD DE SOLO LECTURA
        // Se usa para mostrar el nombre completo en los ComboBox.
        // No aparece en el DataGridView porque sus columnas son fijas (AutoGenerateColumns = false).
        // =====================================================

        public string NombreCompleto
        {
            get { return _nombres + " " + _apellidos; }
        }

        // =====================================================
        // POO: CONSTRUCTOR VACÍO
        // Inicializa un objeto sin recibir parámetros.
        // =====================================================

        public ClienteEntidad()
        {
            _codigoCliente = 0;
            _nombres = string.Empty;
            _apellidos = string.Empty;
            _dpi = string.Empty;
            _fechaNacimiento = DateTime.Now.Date;
            _telefono = string.Empty;
            _correo = string.Empty;
            _direccion = string.Empty;
            _estado = string.Empty;
        }

        // =====================================================
        // POO: SOBRECARGA DE CONSTRUCTORES
        // Constructor utilizado para Consultar, Editar y Buscar.
        // =====================================================

        public ClienteEntidad(
            int codigoCliente,
            string nombres,
            string apellidos,
            string dpi,
            DateTime fechaNacimiento,
            string telefono,
            string correo,
            string direccion,
            string estado)
        {
            _codigoCliente = codigoCliente;
            _nombres = nombres;
            _apellidos = apellidos;
            _dpi = dpi;
            _fechaNacimiento = fechaNacimiento;
            _telefono = telefono;
            _correo = correo;
            _direccion = direccion;
            _estado = estado;
        }

        // =====================================================
        // POO: SOBRECARGA DE CONSTRUCTORES
        // Constructor utilizado para Agregar.
        // No recibe el código porque es IDENTITY en la BDD.
        // =====================================================

        public ClienteEntidad(
            string nombres,
            string apellidos,
            string dpi,
            DateTime fechaNacimiento,
            string telefono,
            string correo,
            string direccion,
            string estado)
        {
            _codigoCliente = 0;
            _nombres = nombres;
            _apellidos = apellidos;
            _dpi = dpi;
            _fechaNacimiento = fechaNacimiento;
            _telefono = telefono;
            _correo = correo;
            _direccion = direccion;
            _estado = estado;
        }
    }
}
