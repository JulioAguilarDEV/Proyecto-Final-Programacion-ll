using System;

namespace Entidad
{
    public class RecetaEntidad
    {
        // =====================================================
        // POO: ENCAPSULAMIENTO
        // Los atributos se mantienen privados.
        // OD = ojo derecho, OI = ojo izquierdo.
        // =====================================================

        private int _codigoReceta;
        private int _codigoExamen;
        private decimal _esferaOD;
        private decimal _cilindroOD;
        private int _ejeOD;
        private decimal _esferaOI;
        private decimal _cilindroOI;
        private int _ejeOI;
        private decimal _adicion;
        private decimal _distanciaPupilar;
        private DateTime _fechaEmision;
        private string _observaciones;
        private string _estado;

        // =====================================================
        // POO: PROPIEDADES
        // Permiten acceder de forma controlada a los atributos.
        // =====================================================

        public int CodigoReceta
        {
            get { return _codigoReceta; }
            set { _codigoReceta = value; }
        }
        public int CodigoExamen
        {
            get { return _codigoExamen; }
            set { _codigoExamen = value; }
        }
        public decimal EsferaOD
        {
            get { return _esferaOD; }
            set { _esferaOD = value; }
        }
        public decimal CilindroOD
        {
            get { return _cilindroOD; }
            set { _cilindroOD = value; }
        }
        public int EjeOD
        {
            get { return _ejeOD; }
            set { _ejeOD = value; }
        }
        public decimal EsferaOI
        {
            get { return _esferaOI; }
            set { _esferaOI = value; }
        }
        public decimal CilindroOI
        {
            get { return _cilindroOI; }
            set { _cilindroOI = value; }
        }
        public int EjeOI
        {
            get { return _ejeOI; }
            set { _ejeOI = value; }
        }
        public decimal Adicion
        {
            get { return _adicion; }
            set { _adicion = value; }
        }
        public decimal DistanciaPupilar
        {
            get { return _distanciaPupilar; }
            set { _distanciaPupilar = value; }
        }
        public DateTime FechaEmision
        {
            get { return _fechaEmision; }
            set { _fechaEmision = value; }
        }
        public string Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        // =====================================================
        // POO: CONSTRUCTOR VACÍO
        // Inicializa un objeto sin recibir parámetros.
        // =====================================================

        public RecetaEntidad()
        {
            _codigoReceta = 0;
            _codigoExamen = 0;
            _esferaOD = 0;
            _cilindroOD = 0;
            _ejeOD = 0;
            _esferaOI = 0;
            _cilindroOI = 0;
            _ejeOI = 0;
            _adicion = 0;
            _distanciaPupilar = 0;
            _fechaEmision = DateTime.Now.Date;
            _observaciones = string.Empty;
            _estado = string.Empty;
        }

        // =====================================================
        // POO: SOBRECARGA DE CONSTRUCTORES
        // Constructor utilizado para Consultar, Editar y Buscar.
        // =====================================================

        public RecetaEntidad(
            int codigoReceta,
            int codigoExamen,
            decimal esferaOD,
            decimal cilindroOD,
            int ejeOD,
            decimal esferaOI,
            decimal cilindroOI,
            int ejeOI,
            decimal adicion,
            decimal distanciaPupilar,
            DateTime fechaEmision,
            string observaciones,
            string estado)
        {
            _codigoReceta = codigoReceta;
            _codigoExamen = codigoExamen;
            _esferaOD = esferaOD;
            _cilindroOD = cilindroOD;
            _ejeOD = ejeOD;
            _esferaOI = esferaOI;
            _cilindroOI = cilindroOI;
            _ejeOI = ejeOI;
            _adicion = adicion;
            _distanciaPupilar = distanciaPupilar;
            _fechaEmision = fechaEmision;
            _observaciones = observaciones;
            _estado = estado;
        }

        // =====================================================
        // POO: SOBRECARGA DE CONSTRUCTORES
        // Constructor utilizado para Agregar.
        // No recibe el código porque es IDENTITY en la BDD.
        // =====================================================

        public RecetaEntidad(
            int codigoExamen,
            decimal esferaOD,
            decimal cilindroOD,
            int ejeOD,
            decimal esferaOI,
            decimal cilindroOI,
            int ejeOI,
            decimal adicion,
            decimal distanciaPupilar,
            DateTime fechaEmision,
            string observaciones,
            string estado)
        {
            _codigoReceta = 0;
            _codigoExamen = codigoExamen;
            _esferaOD = esferaOD;
            _cilindroOD = cilindroOD;
            _ejeOD = ejeOD;
            _esferaOI = esferaOI;
            _cilindroOI = cilindroOI;
            _ejeOI = ejeOI;
            _adicion = adicion;
            _distanciaPupilar = distanciaPupilar;
            _fechaEmision = fechaEmision;
            _observaciones = observaciones;
            _estado = estado;
        }
    }
}
