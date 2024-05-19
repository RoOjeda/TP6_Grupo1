using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace TP6_Grupo1.Conexion

{
    public class AccesoDatos
    {
        /// PROPIEDADES
        string rutaProductos = @"Data Source=localhost\SQLEXPRESS;Initial Catalog = Neptuno; Integrated Security = True";

        public AccesoDatos()
        {
            // Constructor Vacio
        }
        //Metodos
        public SqlConnection ObtenerConexion()
        {
            SqlConnection sqlConexion = new SqlConnection(rutaProductos);
            try
            {
                sqlConexion.Open();
                return sqlConexion;
            }
            catch (Exception )
            {
                return null;
            }
        }
        public SqlDataAdapter ObtenerAdaptador(string consultaSql)
        {
            SqlDataAdapter sqlDataAdapter;
            try
            {
                sqlDataAdapter = new SqlDataAdapter(consultaSql, ObtenerConexion());
                return sqlDataAdapter;
            }
            catch (Exception )
            {
                return null;
            }
        }
        public int EjecutarProcedimientoAlmacenado(SqlCommand comandoSQL, string ProcedimientoAlmacenado) //comandoSQL recibe tiene los parametros incluidos
        {
            int FilasCambiadas;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand = comandoSQL;
            sqlCommand.Connection = Conexion;
            sqlCommand.CommandType = CommandType.StoredProcedure;   ///SE TRATA DE UN PROCEDIMIENTO ALMACENADO
            sqlCommand.CommandText = ProcedimientoAlmacenado; /// NOMBRE DEL PROCEDIMIENTO ALMACENADO
            FilasCambiadas = sqlCommand.ExecuteNonQuery();          /// SE EJECUTA EL PROCEDIMIENTO ALMACENADO
            Conexion.Close();
            return FilasCambiadas;
        }
    }
   


}