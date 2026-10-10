using Datos;
using Entidad;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class CitaNegocio
    {
        // =====================================================
        // POO: COMPOSICIÓN
        // La capa Negocio utiliza la capa Datos.
        // (Módulo de Diego: se creó para los ComboBox de Exámenes)
        // =====================================================

        private readonly CitaDatos _citaDatos = new CitaDatos();

        // =====================================================
        // CRUD: CONSULTAR
        // =====================================================

        public List<CitaEntidad> MtdConsultar()
        {
            return _citaDatos.MtdConsultar();
        }

        // =====================================================
        // CRUD: AGREGAR
        // =====================================================

        public bool MtdAgregar(CitaEntidad citaEntidad)
        {
            if (citaEntidad == null)
            {
                throw new Exception("Los datos de la cita no pueden ser nulos.");
            }

            // Una cita nueva no puede programarse en una fecha pasada
            if (citaEntidad.Fecha.Date < DateTime.Now.Date)
            {
                throw new Exception("La fecha de la cita no puede ser anterior a la fecha actual.");
            }

            // Validar la información antes de enviarla a la base de datos
            MtdValidarDatos(citaEntidad);

            return _citaDatos.MtdAgregar(citaEntidad);
        }

        // =====================================================
        // POO: MÉTODOS DE VALIDACIÓN
        // Valida los datos ingresados según las reglas del negocio.
        // =====================================================

        private void MtdValidarDatos(CitaEntidad citaEntidad)
        {
            if (citaEntidad.CodigoCliente <= 0)
            {
                throw new Exception("Debe seleccionar el cliente.");
            }

            if (citaEntidad.CodigoSucursal <= 0)
            {
                throw new Exception("Debe seleccionar la sucursal.");
            }

            if (citaEntidad.CodigoOptometrista <= 0)
            {
                throw new Exception("Debe seleccionar el optometrista.");
            }

            if (string.IsNullOrWhiteSpace(citaEntidad.MotivoConsulta))
            {
                throw new Exception("Debe ingresar el motivo de la consulta.");
            }

            if (string.IsNullOrWhiteSpace(citaEntidad.Estado))
            {
                throw new Exception("Debe seleccionar el estado de la cita.");
            }
        }

        // =====================================================
        // CRUD: EDITAR
        // =====================================================

        public bool MtdEditar(CitaEntidad citaEntidad)
        {
            if (citaEntidad == null)
            {
                throw new Exception("Los datos de la cita no pueden ser nulos.");
            }

            if (citaEntidad.CodigoCita <= 0)
            {
                throw new Exception("Debe seleccionar una cita válida.");
            }

            MtdValidarDatos(citaEntidad);

            return _citaDatos.MtdEditar(citaEntidad);
        }

        // =====================================================
        // CRUD: ELIMINAR
        // =====================================================

        public bool MtdEliminar(int codigoCita)
        {
            // Validar la llave primaria
            if (codigoCita <= 0)
            {
                throw new Exception("El código de la cita no es válido.");
            }

            return _citaDatos.MtdEliminar(codigoCita);
        }

        // =====================================================
        // CRUD: BUSCAR
        // =====================================================

        public CitaEntidad MtdBuscar(int codigoCita)
        {
            // Validar que el código sea mayor que cero
            if (codigoCita <= 0)
            {
                throw new Exception("El código de la cita no es válido.");
            }

            return _citaDatos.MtdBuscar(codigoCita);
        }
    }
}
