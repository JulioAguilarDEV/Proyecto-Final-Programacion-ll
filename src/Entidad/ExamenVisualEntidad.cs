using System;

namespace Entidad
{
    public class ExamenVisualEntidad
    {
        // =====================================================
        // POO: ENCAPSULAMIENTO
        // Los atributos se mantienen privados.
        // =====================================================

        private int _codigoExamen;
        private int _codigoCliente;
        private int _codigoOptometrista;
        private int _codigoCita;          // 0 = el examen no tiene cita (NULL en la BDD)
        private DateTime _fecha;
        private string _observaciones;
        private string _resultadoGeneral;
        private string _estado;

        // =====================================================
        // POO: PROPIEDADES
        // Permiten acceder de forma controlada a los atributos.
        // =====================================================

        public int CodigoExamen
        {
            get { return _codigoExamen; }
            set { _codigoExamen = value; }
        }
        public int CodigoCliente
        {
            get { return _codigoCliente; }
            set { _codigoCliente = value; }
        }
        public int CodigoOptometrista
        {
            get { return _codigoOptometrista; }
            set { _codigoOptometrista = value; }
        }
        public int CodigoCita
        {
            get { return _codigoCita; }
            set { _codigoCita = value; }
        }
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        public string Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }
        public string ResultadoGeneral
        {
            get { return _resultadoGeneral; }
            set { _resultadoGeneral = value; }
        }
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        // =====================================================
        // PROPIEDAD DE SOLO LECTURA
        // Se usa para mostrar el examen en los ComboBox (Recetas).
        // No aparece en el DataGridView porque sus columnas son fijas (AutoGenerateColumns = false).
        // =====================================================

        public string Descripcion
        {
            get { return "Examen #" + _codigoExamen + " - " + _fecha.ToString("dd/MM/yyyy"); }
        }

        // =====================================================
        // POO: CONSTRUCTOR VACÍO
        // Inicializa un objeto sin recibir parámetros.
        // =====================================================

        public ExamenVisualEntidad()
        {
            _codigoExamen = 0;
            _codigoCliente = 0;
            _codigoOptometrista = 0;
            _codigoCita = 0;
            _fecha = DateTime.Now.Date;
            _observaciones = string.Empty;
            _resultadoGeneral = string.Empty;
            _estado = string.Empty;
        }

        // =====================================================
        // POO: SOBRECARGA DE CONSTRUCTORES
        // Constructor utilizado para Consultar, Editar y Buscar.
        // =====================================================

        public ExamenVisualEntidad(
            int codigoExamen,
            int codigoCliente,
            int codigoOptometrista,
            int codigoCita,
            DateTime fecha,
            string observaciones,
            string resultadoGeneral,
            string estado)
        {
            _codigoExamen = codigoExamen;
            _codigoCliente = codigoCliente;
            _codigoOptometrista = codigoOptometrista;
            _codigoCita = codigoCita;
            _fecha = fecha;
            _observaciones = observaciones;
            _resultadoGeneral = resultadoGeneral;
            _estado = estado;
        }

        // =====================================================
        // POO: SOBRECARGA DE CONSTRUCTORES
        // Constructor utilizado para Agregar.
        // No recibe el código porque es IDENTITY en la BDD.
        // =====================================================

        public ExamenVisualEntidad(
            int codigoCliente,
            int codigoOptometrista,
            int codigoCita,
            DateTime fecha,
            string observaciones,
            string resultadoGeneral,
            string estado)
        {
            _codigoExamen = 0;
            _codigoCliente = codigoCliente;
            _codigoOptometrista = codigoOptometrista;
            _codigoCita = codigoCita;
            _fecha = fecha;
            _observaciones = observaciones;
            _resultadoGeneral = resultadoGeneral;
            _estado = estado;
        }
    }
}
