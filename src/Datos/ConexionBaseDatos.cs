using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ConexionBaseDatos
    {
        // =====================================================
        // POO: ENCAPSULAMIENTO
        // La cadena de conexión solamente puede utilizarse
        // dentro de esta clase.
        // =====================================================


        //Definición de variable que almacenará la cadena de conexión.
        private readonly string _cadenaConexion;

        // =====================================================
        // POO: CONSTRUCTOR
        // Obtiene la cadena desde App.config.
        // =====================================================

        //Constructor que busca la cadena de conexión en el archivo App.config y la guarda en la variable _cadenaConexion.
        public ConexionBaseDatos()
        {
            _cadenaConexion = ConfigurationManager.ConnectionStrings["ConexionSQLServer"].ConnectionString;
        }


        // =====================================================
        // POO: MÉTODO
        // Devuelve una conexión a SQL Server.
        // =====================================================

        //Método que se encarga de mostrar la cadena de conexión cuand sea necesitado.
        public SqlConnection MtdObtenerDatos()
        {
            string cadenaConexion = _cadenaConexion.TrimEnd(';') + ";Initial Catalog=OpticaGrupo8;";
            return new SqlConnection(cadenaConexion);
        }

        /*Análisis del método: Se crea un método de tipo SqlConnection que devolverá un objeto igualmente de tipo SqlConnection
         que en este caso gracias a la variable _CadenaConexion que se le pasa como parámetro la cual almacena la cadena de conexion
        de la base de datos.*/
    }
}
