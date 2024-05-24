using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace TP6_Grupo1.Conexion
{
    public class Productos
    {
        /// PROPIEDADES ((IdProducto, Nombre Producto, CantidadPorUnidad, PrecioUnidad)


        private int _IdProducto;
        private int _idProveedor;
        private string _NombreProducto = null;
        private string _CantidadPorUnidad = null;
        private decimal _PrecioUnidad;


        public Productos()
        {
            /// CONSTRUCTOR por defecto o vacío
        }

        public Productos(int IdProductos)
        {
            _IdProducto = IdProductos;
            
        }

        public Productos(string NombreProducto, string CantidadPorUnidad,
            decimal PrecioUnidad)
        {

            _NombreProducto = NombreProducto;
            _CantidadPorUnidad = CantidadPorUnidad;
            _PrecioUnidad = PrecioUnidad;


        }
        /// METODOS GETTER Y SETTERS
        public int IdProducto
        {
            get
            {
                return _IdProducto;
            }
            set
            {
                _IdProducto = value;
            }
        }

        public int idProveedor
        {
            get
            {
                return _idProveedor;
            }
            set
            {
                _idProveedor = value;
            }
        }




        public string NombreProducto
        {
            get
            {
                return _NombreProducto;
            }
            set
            {
                _NombreProducto = value;
            }
        }
        public string CantidadPorUnidad
        {
            get
            {
                return _CantidadPorUnidad;
            }
            set
            {
                _CantidadPorUnidad = value;
            }
        }

        public decimal PrecioUnidad
        {
            get
            {
                return _PrecioUnidad;
            }
            set
            {
                _PrecioUnidad = value;
            }
        }


    }
}