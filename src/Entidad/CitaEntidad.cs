using System;

namespace Entidad
{
    public class CitaEntidad
    {
        // =====================================================
        // POO: ENCAPSULAMIENTO
        // Los atributos se mantienen privados.
        // =====================================================

        private int _codigoCita;
        private int _codigoCliente;
        private int _codigoSucursal;
        private int _codigoOptometrista;
        private DateTime _fecha;
        private TimeSpan _hora;
        private string _motivoConsulta;
        private string _estado;

        // =====================================================
        // POO: PROPIEDADES
        // Permiten acceder de forma controlada a los atributos.
        // =====================================================

        public int CodigoCita
        {
            get { return _codigoCita; }
            set { _codigoCita = value; }
        }
        public int CodigoCliente
        {
            get { return _codigoCliente; }
            set { _codigoCliente = value; }
        }
        public int CodigoSucursal
        {
            get { return _codigoSucursal; }
            set { _codigoSucursal = value; }
        }
        public int CodigoOptometrista
        {
            get { return _codigoOptometrista; }
            set { _codigoOptometrista = value; }
        }
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        public TimeSpan Hora
        {
            get { return _hora; }
            set { _hora = value; }
        }
        public string MotivoConsulta
        {
            get { return _motivoConsulta; }
            set { _motivoConsulta = value; }
        }
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        // =====================================================
        // PROPIEDAD DE SOLO LECTURA
        // Se usa para mostrar la cita en los ComboBox (Exámenes).
        // No aparece en el DataGridView porque sus columnas son fijas (AutoGenerateColumns = false).
        // =====================================================

        public string Descripcion
        {
            get { return "Cita #" + _codigoCita + " - " + _fecha.ToString("dd/MM/yyyy"); }
        }

        // =====================================================
        // POO: CONSTRUCTOR VACÍO
        // Inicializa un objeto sin recibir parámetros.
        // =====================================================

        public CitaEntidad()
        {
            _codigoCita = 0;
            _codigoCliente = 0;
            _codigoSucursal = 0;
            _codigoOptometrista = 0;
            _fecha = DateTime.Now.Date;
            _hora = DateTime.Now.TimeOfDay;
            _motivoConsulta = string.Empty;
            _estado = string.Empty;
        }

        // =====================================================
        // POO: SOBRECARGA DE CONSTRUCTORES
        // Constructor utilizado para Consultar, Editar y Buscar.
        // =====================================================

        public CitaEntidad(
            int codigoCita,
            int codigoCliente,
            int codigoSucursal,
            int codigoOptometrista,
            DateTime fecha,
            TimeSpan hora,
            string motivoConsulta,
            string estado)
        {
            _codigoCita = codigoCita;
            _codigoCliente = codigoCliente;
            _codigoSucursal = codigoSucursal;
            _codigoOptometrista = codigoOptometrista;
            _fecha = fecha;
            _hora = hora;
            _motivoConsulta = motivoConsulta;
            _estado = estado;
        }

        // =====================================================
        // POO: SOBRECARGA DE CONSTRUCTORES
        // Constructor utilizado para Agregar.
        // No recibe el código porque es IDENTITY en la BDD.
        // =====================================================

        public CitaEntidad(
            int codigoCliente,
            int codigoSucursal,
            int codigoOptometrista,
            DateTime fecha,
            TimeSpan hora,
            string motivoConsulta,
            string estado)
        {
            _codigoCita = 0;
            _codigoCliente = codigoCliente;
            _codigoSucursal = codigoSucursal;
            _codigoOptometrista = codigoOptometrista;
            _fecha = fecha;
            _hora = hora;
            _motivoConsulta = motivoConsulta;
            _estado = estado;
        }
    }
}
