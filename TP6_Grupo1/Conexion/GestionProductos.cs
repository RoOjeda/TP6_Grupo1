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
        private void ProductoDeleteParameter(ref SqlCommand Comando, Productos producto)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IdProducto", SqlDbType.Int);
            SqlParametros.Value = producto.IdProducto;
        }

        public bool DeleteProducto(Productos producto)
        {
            SqlCommand sqlCommand = new SqlCommand();
            //ajusto el parametro q deseo eliminar
            ProductoDeleteParameter(ref sqlCommand, producto);
            //creo la instancia para acceder a la DB NEPTUNO Y ejecuto el procedure
            AccesoDatos accesoDatos = new AccesoDatos();
            int FilasInsertadas = accesoDatos.EjecutarProcedimientoAlmacenado(sqlCommand, "ProcedureDeleteProducto");
            //reviso si se elimino correctamente
            if (FilasInsertadas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}