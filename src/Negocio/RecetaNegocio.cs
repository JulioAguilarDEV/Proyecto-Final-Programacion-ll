using Datos;
using Entidad;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class RecetaNegocio
    {
        // =====================================================
        // POO: COMPOSICIÓN
        // La capa Negocio utiliza la capa Datos.
        // =====================================================

        private readonly RecetaDatos _recetaDatos = new RecetaDatos();

        // =====================================================
        // CRUD: CONSULTAR
        // =====================================================

        public List<RecetaEntidad> MtdConsultar()
        {
            return _recetaDatos.MtdConsultar();
        }

        // =====================================================
        // CRUD: AGREGAR
        // =====================================================

        public bool MtdAgregar(RecetaEntidad recetaEntidad)
        {
            if (recetaEntidad == null)
            {
                throw new Exception("Los datos de la receta no pueden ser nulos.");
            }

            // Validar la información antes de enviarla a la base de datos
            MtdValidarDatos(recetaEntidad);

            return _recetaDatos.MtdAgregar(recetaEntidad);
        }

        // =====================================================
        // POO: MÉTODOS DE VALIDACIÓN
        // Valida los datos ingresados según las reglas del negocio.
        // OD = ojo derecho, OI = ojo izquierdo.
        // =====================================================

        private void MtdValidarDatos(RecetaEntidad recetaEntidad)
        {
            if (recetaEntidad.CodigoExamen <= 0)
            {
                throw new Exception("Debe seleccionar el examen visual de la receta.");
            }

            if (recetaEntidad.EsferaOD < -30 || recetaEntidad.EsferaOD > 30 ||
                recetaEntidad.EsferaOI < -30 || recetaEntidad.EsferaOI > 30)
            {
                throw new Exception("La esfera debe estar entre -30.00 y 30.00.");
            }

            if (recetaEntidad.CilindroOD < -10 || recetaEntidad.CilindroOD > 10 ||
                recetaEntidad.CilindroOI < -10 || recetaEntidad.CilindroOI > 10)
            {
                throw new Exception("El cilindro debe estar entre -10.00 y 10.00.");
            }

            if (recetaEntidad.EjeOD < 0 || recetaEntidad.EjeOD > 180 ||
                recetaEntidad.EjeOI < 0 || recetaEntidad.EjeOI > 180)
            {
                throw new Exception("El eje debe estar entre 0 y 180 grados.");
            }

            if (recetaEntidad.Adicion < 0 || recetaEntidad.Adicion > 4)
            {
                throw new Exception("La adición debe estar entre 0.00 y 4.00.");
            }

            if (recetaEntidad.DistanciaPupilar < 40 || recetaEntidad.DistanciaPupilar > 80)
            {
                throw new Exception("La distancia pupilar debe estar entre 40.0 y 80.0 mm.");
            }

            if (recetaEntidad.FechaEmision.Date > DateTime.Now.Date)
            {
                throw new Exception("La fecha de emisión no puede ser mayor a la fecha actual.");
            }

            if (string.IsNullOrWhiteSpace(recetaEntidad.Estado))
            {
                throw new Exception("Debe seleccionar el estado de la receta.");
            }
        }

        // =====================================================
        // CRUD: EDITAR
        // =====================================================

        public bool MtdEditar(RecetaEntidad recetaEntidad)
        {
            if (recetaEntidad == null)
            {
                throw new Exception("Los datos de la receta no pueden ser nulos.");
            }

            if (recetaEntidad.CodigoReceta <= 0)
            {
                throw new Exception("Debe seleccionar una receta válida.");
            }

            MtdValidarDatos(recetaEntidad);

            return _recetaDatos.MtdEditar(recetaEntidad);
        }

        // =====================================================
        // CRUD: ELIMINAR
        // =====================================================

        public bool MtdEliminar(int codigoReceta)
        {
            // Validar la llave primaria
            if (codigoReceta <= 0)
            {
                throw new Exception("El código de la receta no es válido.");
            }

            return _recetaDatos.MtdEliminar(codigoReceta);
        }

        // =====================================================
        // CRUD: BUSCAR
        // =====================================================

        public RecetaEntidad MtdBuscar(int codigoReceta)
        {
            // Validar que el código sea mayor que cero
            if (codigoReceta <= 0)
            {
                throw new Exception("El código de la receta no es válido.");
            }

            return _recetaDatos.MtdBuscar(codigoReceta);
        }
    }
}
