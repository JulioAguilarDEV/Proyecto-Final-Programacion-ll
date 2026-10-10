using Datos;
using Entidad;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class ExamenVisualNegocio
    {
        // =====================================================
        // POO: COMPOSICIÓN
        // La capa Negocio utiliza la capa Datos.
        // =====================================================

        private readonly ExamenVisualDatos _examenVisualDatos = new ExamenVisualDatos();

        // =====================================================
        // CRUD: CONSULTAR
        // =====================================================

        public List<ExamenVisualEntidad> MtdConsultar()
        {
            return _examenVisualDatos.MtdConsultar();
        }

        // =====================================================
        // CRUD: AGREGAR
        // =====================================================

        public bool MtdAgregar(ExamenVisualEntidad examenVisualEntidad)
        {
            if (examenVisualEntidad == null)
            {
                throw new Exception("Los datos del examen visual no pueden ser nulos.");
            }

            // Validar la información antes de enviarla a la base de datos
            MtdValidarDatos(examenVisualEntidad);

            return _examenVisualDatos.MtdAgregar(examenVisualEntidad);
        }

        // =====================================================
        // POO: MÉTODOS DE VALIDACIÓN
        // Valida los datos ingresados según las reglas del negocio.
        // =====================================================

        private void MtdValidarDatos(ExamenVisualEntidad examenVisualEntidad)
        {
            if (examenVisualEntidad.CodigoCliente <= 0)
            {
                throw new Exception("Debe seleccionar el cliente.");
            }

            if (examenVisualEntidad.CodigoOptometrista <= 0)
            {
                throw new Exception("Debe seleccionar el optometrista.");
            }

            // La cita es opcional (0 = sin cita), no se valida

            if (examenVisualEntidad.Fecha.Date > DateTime.Now.Date)
            {
                throw new Exception("La fecha del examen no puede ser mayor a la fecha actual.");
            }

            if (string.IsNullOrWhiteSpace(examenVisualEntidad.ResultadoGeneral))
            {
                throw new Exception("Debe ingresar el resultado general del examen.");
            }

            if (string.IsNullOrWhiteSpace(examenVisualEntidad.Estado))
            {
                throw new Exception("Debe seleccionar el estado del examen.");
            }
        }

        // =====================================================
        // CRUD: EDITAR
        // =====================================================

        public bool MtdEditar(ExamenVisualEntidad examenVisualEntidad)
        {
            if (examenVisualEntidad == null)
            {
                throw new Exception("Los datos del examen visual no pueden ser nulos.");
            }

            if (examenVisualEntidad.CodigoExamen <= 0)
            {
                throw new Exception("Debe seleccionar un examen visual válido.");
            }

            MtdValidarDatos(examenVisualEntidad);

            return _examenVisualDatos.MtdEditar(examenVisualEntidad);
        }

        // =====================================================
        // CRUD: ELIMINAR
        // =====================================================

        public bool MtdEliminar(int codigoExamen)
        {
            // Validar la llave primaria
            if (codigoExamen <= 0)
            {
                throw new Exception("El código del examen visual no es válido.");
            }

            return _examenVisualDatos.MtdEliminar(codigoExamen);
        }

        // =====================================================
        // CRUD: BUSCAR
        // =====================================================

        public ExamenVisualEntidad MtdBuscar(int codigoExamen)
        {
            // Validar que el código sea mayor que cero
            if (codigoExamen <= 0)
            {
                throw new Exception("El código del examen visual no es válido.");
            }

            return _examenVisualDatos.MtdBuscar(codigoExamen);
        }
    }
}
