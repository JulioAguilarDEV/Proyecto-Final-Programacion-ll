using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos
{
    public class ClienteDatos
    {
        // =====================================================
        // POO: COMPOSICIÓN
        // ClienteDatos utiliza un objeto ConexionBaseDatos.
        // (Módulo de Diego: se creó para los ComboBox de Exámenes)
        // =====================================================

        private readonly ConexionBaseDatos _conexionBaseDatos = new ConexionBaseDatos();

        // =====================================================
        // CRUD: CONSULTAR
        // =====================================================

        public List<ClienteEntidad> MtdConsultar()
        {
            // Lista que guardará un objeto por cada fila de la tabla
            List<ClienteEntidad> listaCliente = new List<ClienteEntidad>();

            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    string queryConsultar = @"
                                            Select
                                                CodigoCliente,
                                                Nombres,
                                                Apellidos,
                                                DPI,
                                                FechaNacimiento,
                                                Telefono,
                                                Correo,
                                                Direccion,
                                                Estado
                                            From Cliente;";

                    using (SqlCommand cmd = new SqlCommand(queryConsultar, conn))
                    {
                        conn.Open();

                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                // POO: INSTANCIA DE UN OBJETO
                                // Correo y Direccion pueden venir NULL: ToString() los deja vacíos
                                ClienteEntidad cliente = new ClienteEntidad(
                                    Convert.ToInt32(rd["CodigoCliente"]),
                                    rd["Nombres"].ToString(),
                                    rd["Apellidos"].ToString(),
                                    rd["DPI"].ToString(),
                                    Convert.ToDateTime(rd["FechaNacimiento"]),
                                    rd["Telefono"].ToString(),
                                    rd["Correo"].ToString(),
                                    rd["Direccion"].ToString(),
                                    rd["Estado"].ToString()
                                );

                                listaCliente.Add(cliente);
                            }
                        }
                    }
                }

                return listaCliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar los clientes: " + ex.Message, ex);
            }
        }

        // =====================================================
        // CRUD: AGREGAR
        // =====================================================

        public bool MtdAgregar(ClienteEntidad clienteEntidad)
        {
            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    string queryAgregar = @"
                                            Insert Into Cliente
                                            (
                                                Nombres,
                                                Apellidos,
                                                DPI,
                                                FechaNacimiento,
                                                Telefono,
                                                Correo,
                                                Direccion,
                                                Estado
                                            )
                                            Values
                                            (
                                                @Nombres,
                                                @Apellidos,
                                                @DPI,
                                                @FechaNacimiento,
                                                @Telefono,
                                                @Correo,
                                                @Direccion,
                                                @Estado
                                            );";

                    using (SqlCommand cmd = new SqlCommand(queryAgregar, conn))
                    {
                        MtdAgregarParametros(cmd, clienteEntidad);

                        conn.Open();

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Error 2627 / 2601: se repitió un valor que debe ser único (UNIQUE)
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    throw new Exception("Ya existe un cliente con ese DPI.", ex);
                }

                throw new Exception("Error al agregar el cliente: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el cliente: " + ex.Message, ex);
            }
        }

        // =====================================================
        // CRUD: EDITAR
        // =====================================================

        public bool MtdEditar(ClienteEntidad clienteEntidad)
        {
            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    string queryEditar = @"
                                            Update Cliente
                                            Set
                                                Nombres = @Nombres,
                                                Apellidos = @Apellidos,
                                                DPI = @DPI,
                                                FechaNacimiento = @FechaNacimiento,
                                                Telefono = @Telefono,
                                                Correo = @Correo,
                                                Direccion = @Direccion,
                                                Estado = @Estado
                                            Where CodigoCliente = @CodigoCliente;";

                    using (SqlCommand cmd = new SqlCommand(queryEditar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoCliente", clienteEntidad.CodigoCliente);
                        MtdAgregarParametros(cmd, clienteEntidad);

                        conn.Open();

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    throw new Exception("Ya existe un cliente con ese DPI.", ex);
                }

                throw new Exception("Error al editar el cliente: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el cliente: " + ex.Message, ex);
            }
        }

        // =====================================================
        // PARÁMETROS DE AGREGAR Y EDITAR
        // =====================================================

        private void MtdAgregarParametros(SqlCommand cmd, ClienteEntidad clienteEntidad)
        {
            cmd.Parameters.AddWithValue("@Nombres", clienteEntidad.Nombres);
            cmd.Parameters.AddWithValue("@Apellidos", clienteEntidad.Apellidos);
            cmd.Parameters.AddWithValue("@DPI", clienteEntidad.DPI);
            cmd.Parameters.AddWithValue("@FechaNacimiento", clienteEntidad.FechaNacimiento);
            cmd.Parameters.AddWithValue("@Telefono", clienteEntidad.Telefono);

            // Correo permite valores nulos en la base de datos
            if (string.IsNullOrWhiteSpace(clienteEntidad.Correo))
            {
                cmd.Parameters.AddWithValue("@Correo", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Correo", clienteEntidad.Correo);
            }

            // Direccion permite valores nulos en la base de datos
            if (string.IsNullOrWhiteSpace(clienteEntidad.Direccion))
            {
                cmd.Parameters.AddWithValue("@Direccion", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Direccion", clienteEntidad.Direccion);
            }

            cmd.Parameters.AddWithValue("@Estado", clienteEntidad.Estado);
        }

        // =====================================================
        // CRUD: ELIMINAR
        // =====================================================

        public bool MtdEliminar(int codigoCliente)
        {
            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    string queryEliminar = @"
                                            Delete From Cliente
                                            Where CodigoCliente = @CodigoCliente;";

                    using (SqlCommand cmd = new SqlCommand(queryEliminar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoCliente", codigoCliente);

                        conn.Open();

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Error 547: el registro se está usando en otra tabla (llave foránea)
                if (ex.Number == 547)
                {
                    throw new Exception("No se puede eliminar el cliente porque tiene citas, exámenes u órdenes registradas.", ex);
                }

                throw new Exception("Error al eliminar el cliente: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el cliente: " + ex.Message, ex);
            }
        }

        // =====================================================
        // CRUD: BUSCAR
        // =====================================================

        public ClienteEntidad MtdBuscar(int codigoCliente)
        {
            // El objeto inicia vacío (null) por si no se encuentra
            ClienteEntidad clienteEncontrado = null;

            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                {
                    string queryBuscar = @"
                                            Select
                                                CodigoCliente,
                                                Nombres,
                                                Apellidos,
                                                DPI,
                                                FechaNacimiento,
                                                Telefono,
                                                Correo,
                                                Direccion,
                                                Estado
                                            From Cliente
                                            Where CodigoCliente = @CodigoCliente;";

                    using (SqlCommand cmd = new SqlCommand(queryBuscar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoCliente", codigoCliente);

                        conn.Open();

                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            if (rd.Read())
                            {
                                clienteEncontrado = new ClienteEntidad(
                                    Convert.ToInt32(rd["CodigoCliente"]),
                                    rd["Nombres"].ToString(),
                                    rd["Apellidos"].ToString(),
                                    rd["DPI"].ToString(),
                                    Convert.ToDateTime(rd["FechaNacimiento"]),
                                    rd["Telefono"].ToString(),
                                    rd["Correo"].ToString(),
                                    rd["Direccion"].ToString(),
                                    rd["Estado"].ToString()
                                );
                            }
                        }
                    }
                }

                // Devuelve el objeto encontrado o null
                return clienteEncontrado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el cliente: " + ex.Message, ex);
            }
        }
    }
}
