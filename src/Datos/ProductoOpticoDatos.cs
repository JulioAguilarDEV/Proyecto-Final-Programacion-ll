using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class ProductoOpticoDatos
    {
        private readonly ConexionBaseDatos _conexionBaseDatos = new ConexionBaseDatos();

        public List<ProductoOpticoEntidad> MtdConsultar()
        {
            List<ProductoOpticoEntidad> listaProductos = new List<ProductoOpticoEntidad>();

            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT p.CodigoProducto, p.CodigoTipoProducto, p.Nombre, p.Descripcion, p.Marca, p.Precio, p.Estado, tp.Nombre AS NombreTipoProducto " +
                    "FROM dbo.ProductoOptico p " +
                    "INNER JOIN dbo.TipoProducto tp ON tp.CodigoTipoProducto = p.CodigoTipoProducto " +
                    "ORDER BY p.CodigoProducto;", conn))
                {
                    conn.Open();

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            listaProductos.Add(new ProductoOpticoEntidad(
                                Convert.ToInt32(rd["CodigoProducto"]),
                                Convert.ToInt32(rd["CodigoTipoProducto"]),
                                rd["Nombre"].ToString(),
                                rd["Descripcion"].ToString(),
                                rd["Marca"].ToString(),
                                Convert.ToDecimal(rd["Precio"]),
                                rd["Estado"].ToString(),
                                rd["NombreTipoProducto"].ToString()));
                        }
                    }
                }

                return listaProductos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar los productos ópticos: " + ex.Message, ex);
            }
        }

        public bool MtdAgregar(ProductoOpticoEntidad producto)
        {
            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                using (SqlCommand cmd = new SqlCommand(
                    "INSERT INTO dbo.ProductoOptico " +
                    "(CodigoTipoProducto, Nombre, Descripcion, Marca, Precio, Estado) " +
                    "VALUES (@CodigoTipoProducto, @Nombre, @Descripcion, @Marca, @Precio, @Estado);", conn))
                {
                    MtdAgregarParametrosProducto(cmd, producto);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    throw new Exception("El tipo de producto seleccionado ya no existe.", ex);
                }

                throw new Exception("Error al agregar el producto óptico: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el producto óptico: " + ex.Message, ex);
            }
        }

        public List<ProductoOpticoEntidad> MtdBuscar(string filtro)
        {
            List<ProductoOpticoEntidad> listaProductos = new List<ProductoOpticoEntidad>();

            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT p.CodigoProducto, p.CodigoTipoProducto, p.Nombre, p.Descripcion, " +
                    "p.Marca, p.Precio, p.Estado, tp.Nombre AS NombreTipoProducto " +
                    "FROM dbo.ProductoOptico p " +
                    "INNER JOIN dbo.TipoProducto tp ON tp.CodigoTipoProducto = p.CodigoTipoProducto " +
                    "WHERE CONVERT(VARCHAR(11), p.CodigoProducto) LIKE @Filtro " +
                    "OR p.Nombre LIKE @Filtro OR p.Descripcion LIKE @Filtro OR p.Marca LIKE @Filtro " +
                    "ORDER BY p.CodigoProducto;", conn))
                {
                    cmd.Parameters.Add("@Filtro", SqlDbType.VarChar, 202).Value = "%" + filtro.Trim() + "%";
                    conn.Open();

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            listaProductos.Add(MtdLeerProducto(rd));
                        }
                    }
                }

                return listaProductos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar productos por código, nombre, descripción o marca: " + ex.Message, ex);
            }
        }

        public ProductoOpticoEntidad MtdBuscar(int codigoProducto)
        {
            ProductoOpticoEntidad productoEncontrado = null;

            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT p.CodigoProducto, p.CodigoTipoProducto, p.Nombre, p.Descripcion, " +
                    "p.Marca, p.Precio, p.Estado, tp.Nombre AS NombreTipoProducto " +
                    "FROM dbo.ProductoOptico p " +
                    "INNER JOIN dbo.TipoProducto tp ON tp.CodigoTipoProducto = p.CodigoTipoProducto " +
                    "WHERE p.CodigoProducto = @CodigoProducto;", conn))
                {
                    cmd.Parameters.Add("@CodigoProducto", SqlDbType.Int).Value = codigoProducto;
                    conn.Open();

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            productoEncontrado = MtdLeerProducto(rd);
                        }
                    }
                }

                return productoEncontrado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el producto óptico: " + ex.Message, ex);
            }
        }

        public bool MtdEditar(ProductoOpticoEntidad producto)
        {
            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE dbo.ProductoOptico SET CodigoTipoProducto = @CodigoTipoProducto, " +
                    "Nombre = @Nombre, Descripcion = @Descripcion, Marca = @Marca, " +
                    "Precio = @Precio, Estado = @Estado WHERE CodigoProducto = @CodigoProducto;", conn))
                {
                    cmd.Parameters.Add("@CodigoProducto", SqlDbType.Int).Value = producto.CodigoProducto;
                    MtdAgregarParametrosProducto(cmd, producto);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    throw new Exception("El tipo de producto seleccionado ya no existe.", ex);
                }

                throw new Exception("Error al editar el producto óptico: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el producto óptico: " + ex.Message, ex);
            }
        }

        public bool MtdEliminar(int codigoProducto)
        {
            try
            {
                using (SqlConnection conn = _conexionBaseDatos.MtdObtenerDatos())
                using (SqlCommand cmd = new SqlCommand(
                    "DELETE FROM dbo.ProductoOptico WHERE CodigoProducto = @CodigoProducto;", conn))
                {
                    cmd.Parameters.Add("@CodigoProducto", SqlDbType.Int).Value = codigoProducto;
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    throw new Exception(
                        "No se puede eliminar este producto porque forma parte de una orden. " +
                        "Para retirarlo del catálogo sin afectar el historial, edítelo y márquelo Inactivo.",
                        ex);
                }

                throw new Exception("Error al eliminar el producto óptico: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el producto óptico: " + ex.Message, ex);
            }
        }

        private void MtdAgregarParametrosProducto(SqlCommand cmd, ProductoOpticoEntidad producto)
        {
            cmd.Parameters.Add("@CodigoTipoProducto", SqlDbType.Int).Value = producto.CodigoTipoProducto;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = producto.Nombre;
            cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar, 200).Value = producto.Descripcion;
            cmd.Parameters.Add("@Marca", SqlDbType.VarChar, 60).Value = producto.Marca;

            SqlParameter parametroPrecio = cmd.Parameters.Add("@Precio", SqlDbType.Decimal);
            parametroPrecio.Precision = 10;
            parametroPrecio.Scale = 2;
            parametroPrecio.Value = producto.Precio;

            cmd.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = producto.Estado;
        }

        private ProductoOpticoEntidad MtdLeerProducto(SqlDataReader rd)
        {
            return new ProductoOpticoEntidad(
                Convert.ToInt32(rd["CodigoProducto"]),
                Convert.ToInt32(rd["CodigoTipoProducto"]),
                rd["Nombre"].ToString(),
                rd["Descripcion"].ToString(),
                rd["Marca"].ToString(),
                Convert.ToDecimal(rd["Precio"]),
                rd["Estado"].ToString(),
                rd["NombreTipoProducto"].ToString());
        }
    }
}
