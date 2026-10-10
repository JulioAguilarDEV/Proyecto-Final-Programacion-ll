using System;

namespace Entidad
{
    public class OptometristaEntidad
    {
        // =====================================================
        // POO: ENCAPSULAMIENTO
        // Los atributos se mantienen privados.
        // =====================================================

        private int _codigoOptometrista;
        private string _nombres;
        private string _apellidos;
        private string _numeroColegiado;
        private string _telefono;
        private string _correo;
        private string _estado;

        // =====================================================
        // POO: PROPIEDADES
        // Permiten acceder de forma controlada a los atributos.
        // =====================================================

        public int CodigoOptometrista
        {
            get { return _codigoOptometrista; }
            set { _codigoOptometrista = value; }
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
        public string NumeroColegiado
        {
            get { return _numeroColegiado; }
            set { _numeroColegiado = value; }
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

        public OptometristaEntidad()
        {
            _codigoOptometrista = 0;
            _nombres = string.Empty;
            _apellidos = string.Empty;
            _numeroColegiado = string.Empty;
            _telefono = string.Empty;
            _correo = string.Empty;
            _estado = string.Empty;
        }

        // =====================================================
        // POO: SOBRECARGA DE CONSTRUCTORES
        // Constructor utilizado para Consultar, Editar y Buscar.
        // =====================================================

        public OptometristaEntidad(
            int codigoOptometrista,
            string nombres,
            string apellidos,
            string numeroColegiado,
            string telefono,
            string correo,
            string estado)
        {
            _codigoOptometrista = codigoOptometrista;
            _nombres = nombres;
            _apellidos = apellidos;
            _numeroColegiado = numeroColegiado;
            _telefono = telefono;
            _correo = correo;
            _estado = estado;
        }

        // =====================================================
        // POO: SOBRECARGA DE CONSTRUCTORES
        // Constructor utilizado para Agregar.
        // No recibe el código porque es IDENTITY en la BDD.
        // =====================================================

        public OptometristaEntidad(
            string nombres,
            string apellidos,
            string numeroColegiado,
            string telefono,
            string correo,
            string estado)
        {
            _codigoOptometrista = 0;
            _nombres = nombres;
            _apellidos = apellidos;
            _numeroColegiado = numeroColegiado;
            _telefono = telefono;
            _correo = correo;
            _estado = estado;
        }
    }
}
