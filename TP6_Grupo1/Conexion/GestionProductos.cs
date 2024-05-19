using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace TP6_Grupo1.Conexion
{
    public class GestionProductos
    {
        public GestionProductos() {
        ///constructor vacío
        }
        ///Metodos
        private DataTable ObtenerTabla(string nombreTabla, string consultaSQL) 
        {
            DataSet dataSet = new DataSet();
            AccesoDatos datos = new AccesoDatos();
            SqlDataAdapter sqlDataAdapter = datos.ObtenerAdaptador(consultaSQL);
            sqlDataAdapter.Fill(dataSet, nombreTabla);
            return dataSet.Tables[nombreTabla];
        }
        public DataTable ObtenerProductos()
        {
            return ObtenerTabla("Productos", "SELECT IdProducto, NombreProducto, CantidadPorUnidad, PrecioUnidad  FROM Productos");
        }
    }
}