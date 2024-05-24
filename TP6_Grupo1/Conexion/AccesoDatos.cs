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
        private SqlConnection ObtenerConexion()
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
        private SqlDataAdapter ObtenerAdaptador(string storeProcedure)
        {
            SqlDataAdapter sqlDataAdapter;
            try
            {
                sqlDataAdapter = new SqlDataAdapter(storeProcedure, ObtenerConexion());
                return sqlDataAdapter;
            }
            catch (Exception )
            {
                return null;
            }
        }

        public int EjecutarProcedimientoAlmacenado(String storeProcedure, SqlCommand sqlCommand) //comandoSQL recibe tiene los parametros incluidos
        {
            int FilasCambiadas;
            SqlConnection Conexion = ObtenerConexion();
            sqlCommand.Connection = Conexion;
            sqlCommand.CommandType = CommandType.StoredProcedure;   ///SE TRATA DE UN PROCEDIMIENTO ALMACENADO
            sqlCommand.CommandText = storeProcedure;                /// EL STORE PROCEDURE SE RECIBE POR PARAMETRO
            FilasCambiadas = sqlCommand.ExecuteNonQuery();          /// SE EJECUTA EL PROCEDIMIENTO ALMACENADO
            Conexion.Close();
            return FilasCambiadas;
        }
    

        public DataTable EjecutarProcedimientoAlmacenado(String storeProcedure)
        {
            DataTable dataTable = new DataTable();
            AccesoDatos datos = new AccesoDatos();
            SqlDataAdapter sqlDataAdapter = ObtenerAdaptador(storeProcedure);
            sqlDataAdapter.Fill(dataTable);
            
            return dataTable;

        }


    }
   

}