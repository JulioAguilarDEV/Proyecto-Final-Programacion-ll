using Datos;
using Entidad;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class ClienteNegocio
    {
        // =====================================================
        // POO: COMPOSICIÓN
        // La capa Negocio utiliza la capa Datos.
        // (Módulo de Diego: se creó para los ComboBox de Exámenes)
        // =====================================================

        private readonly ClienteDatos _clienteDatos = new ClienteDatos();

        // =====================================================
        // CRUD: CONSULTAR
        // =====================================================

        public List<ClienteEntidad> MtdConsultar()
        {
            return _clienteDatos.MtdConsultar();
        }

        // =====================================================
        // CRUD: AGREGAR
        // =====================================================

        public bool MtdAgregar(ClienteEntidad clienteEntidad)
        {
            if (clienteEntidad == null)
            {
                throw new Exception("Los datos del cliente no pueden ser nulos.");
            }

            // Validar la información antes de enviarla a la base de datos
            MtdValidarDatos(clienteEntidad);

            return _clienteDatos.MtdAgregar(clienteEntidad);
        }

        // =====================================================
        // POO: MÉTODOS DE VALIDACIÓN
        // Valida los datos ingresados según las reglas del negocio.
        // =====================================================

        private void MtdValidarDatos(ClienteEntidad clienteEntidad)
        {
            if (string.IsNullOrWhiteSpace(clienteEntidad.Nombres))
            {
                throw new Exception("Debe ingresar los nombres del cliente.");
            }

            if (string.IsNullOrWhiteSpace(clienteEntidad.Apellidos))
            {
                throw new Exception("Debe ingresar los apellidos del cliente.");
            }

            if (string.IsNullOrWhiteSpace(clienteEntidad.DPI))
            {
                throw new Exception("Debe ingresar el DPI del cliente.");
            }

            string dpi = clienteEntidad.DPI.Trim();
            if (dpi.Length != 13)
            {
                throw new Exception("El DPI debe tener exactamente 13 dígitos.");
            }

            foreach (char caracter in dpi)
            {
                if (!char.IsDigit(caracter))
                {
                    throw new Exception("El DPI solo debe contener números.");
                }
            }

            if (clienteEntidad.FechaNacimiento.Date > DateTime.Now.Date)
            {
                throw new Exception("La fecha de nacimiento no puede ser mayor a la fecha actual.");
            }

            if (string.IsNullOrWhiteSpace(clienteEntidad.Telefono))
            {
                throw new Exception("Debe ingresar un número telefónico.");
            }

            string telefono = clienteEntidad.Telefono.Trim();
            if (telefono.Length < 8 || telefono.Length > 15)
            {
                throw new Exception("El número telefónico debe tener entre 8 y 15 dígitos.");
            }

            foreach (char caracter in telefono)
            {
                if (!char.IsDigit(caracter))
                {
                    throw new Exception("El número telefónico solo debe contener números.");
                }
            }

            // El correo es opcional, pero si se escribe debe ser válido
            if (!string.IsNullOrWhiteSpace(clienteEntidad.Correo))
            {
                if (!clienteEntidad.Correo.Contains("@") || !clienteEntidad.Correo.Contains("."))
                {
                    throw new Exception("Debe ingresar un correo electrónico válido.");
                }
            }

            if (string.IsNullOrWhiteSpace(clienteEntidad.Estado))
            {
                throw new Exception("Debe seleccionar el estado del cliente.");
            }
        }

        // =====================================================
        // CRUD: EDITAR
        // =====================================================

        public bool MtdEditar(ClienteEntidad clienteEntidad)
        {
            if (clienteEntidad == null)
            {
                throw new Exception("Los datos del cliente no pueden ser nulos.");
            }

            if (clienteEntidad.CodigoCliente <= 0)
            {
                throw new Exception("Debe seleccionar un cliente válido.");
            }

            MtdValidarDatos(clienteEntidad);

            return _clienteDatos.MtdEditar(clienteEntidad);
        }

        // =====================================================
        // CRUD: ELIMINAR
        // =====================================================

        public bool MtdEliminar(int codigoCliente)
        {
            // Validar la llave primaria
            if (codigoCliente <= 0)
            {
                throw new Exception("El código del cliente no es válido.");
            }

            return _clienteDatos.MtdEliminar(codigoCliente);
        }

        // =====================================================
        // CRUD: BUSCAR
        // =====================================================

        public ClienteEntidad MtdBuscar(int codigoCliente)
        {
            // Validar que el código sea mayor que cero
            if (codigoCliente <= 0)
            {
                throw new Exception("El código del cliente no es válido.");
            }

            return _clienteDatos.MtdBuscar(codigoCliente);
        }
    }
}
