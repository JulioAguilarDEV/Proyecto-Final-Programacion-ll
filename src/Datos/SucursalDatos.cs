using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos
{
    public class SucursalDatos
    {
        private readonly ConexionBaseDatos _conexionBaseDatos = new ConexionBaseDatos();

        public List<SucursalEntidad> MtdConsultar()
        {
            List<SucursalEntidad> listaSucursales = new List<SucursalEntidad>();

            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT CodigoSucursal, Nombre, Estado FROM dbo.Sucursal ORDER BY Nombre;", conn))
                {
                    conn.Open();

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            listaSucursales.Add(new SucursalEntidad(
                                Convert.ToInt32(rd["CodigoSucursal"]),
                                rd["Nombre"].ToString(),
                                rd["Estado"].ToString()));
                        }
                    }
                }

                return listaSucursales;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar el catálogo de sucursales: " + ex.Message, ex);
            }
        }
    }
}
