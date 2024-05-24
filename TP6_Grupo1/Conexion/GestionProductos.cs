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

        private const string SP_ELIMINAR = "ProcedureDeleteProducto";
        private const string SP_MODIFICAR = "ProcedureModificarProducto";
        private const string SP_TODOS = "ProcedureTodosProducto";

        private AccesoDatos accesoDatos = new AccesoDatos();


        public GestionProductos() {
        ///constructor vacío
        }
        ///Metodos

        public DataTable ObtenerProductos()
        {
            return accesoDatos.EjecutarProcedimientoAlmacenado(SP_TODOS);
        }
        private void ProductoParameter(ref SqlCommand Comando, Productos producto)
        {
            
            Comando.Parameters.AddWithValue("@IDPRODUCTO", producto.IdProducto);
            if (producto.NombreProducto != null) { Comando.Parameters.AddWithValue("@NombreProducto", producto.NombreProducto); }        
            if (producto.CantidadPorUnidad != null) { Comando.Parameters.AddWithValue("@CantidadPorUnidad", producto.CantidadPorUnidad); }  
            if (producto.PrecioUnidad != 0) { Comando.Parameters.AddWithValue("@PrecioUnidad", producto.PrecioUnidad); }          


        }

        public bool DeleteProducto(Productos producto)
        {
            SqlCommand sqlCommand = new SqlCommand();
            //ajusto el parametro q deseo eliminar
            ProductoParameter(ref sqlCommand, producto);

            int FilasInsertadas = accesoDatos.EjecutarProcedimientoAlmacenado(SP_ELIMINAR, sqlCommand);
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


        public bool UpdateProducto(Productos producto)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "ProcedureModificarProducto";

            // Agregar parámetros

            ProductoParameter(ref sqlCommand, producto);


            // Crear la instancia para acceder a la DB y ejecutar el procedimiento
            AccesoDatos accesoDatos = new AccesoDatos();

            int filasActualizadas = accesoDatos.EjecutarProcedimientoAlmacenado("ProcedureModificarProducto", sqlCommand);

            //reviso si se elimino correctamente
            if (filasActualizadas == 1)
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