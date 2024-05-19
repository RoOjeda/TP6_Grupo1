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
        private int _IdProveedor;
        private int _IdCategoria;
        private string _NombreProducto;
        private int _CantidadPorUnidad;
        private decimal _PrecioUnidad;
        private int _UnidadesEnExistencia;
        private int _UnidadesEnPedido;
        private int _NivelNuevoPedido;
        private int _Suspendido;

        public Productos()
        {
            /// CONSTRUCTOR por defecto o vacío
        }

        public Productos(int IdProductos)
        {
            _IdProducto = IdProductos;
        }

        public Productos( int IdProveedor, int IdCategoria, string NombreProducto, int CantidadPorUnidad, 
            decimal PrecioUnidad, int UnidadesEnExistencia, int UnidadesEnPedido,  int NivelNuevoPedido, int Suspendido) 
        {
            _IdProveedor = IdProveedor;
            _IdCategoria = IdCategoria;
            _NombreProducto = NombreProducto;
            _CantidadPorUnidad = CantidadPorUnidad;
            _PrecioUnidad = PrecioUnidad;
            _UnidadesEnExistencia = UnidadesEnExistencia;
            _UnidadesEnPedido = UnidadesEnPedido;
            _NivelNuevoPedido = NivelNuevoPedido;
            _Suspendido = Suspendido;
        
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
        public int IdProveedor
        {
            get
            {
                return _IdProveedor;
            }
            set
            {
                _IdProveedor = value;
            }
        }
        public int IdCategoria
        {
            get
            {
                return _IdCategoria;
            }
            set
            {
                _IdCategoria = value;
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
        public int CantidadPorUnidad
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
        public int UnidadesEnExistencia
        {
            get
            {
                return _UnidadesEnExistencia;
            }
            set
            {
                _UnidadesEnExistencia = value;
            }
        }
        public int UnidadesEnPedido
        {
            get
            {
                return _UnidadesEnPedido;
            }
            set
            {
                _UnidadesEnPedido = value;
            }
        }
        public int NivelNuevoPedido
        {
            get
            {
                return _NivelNuevoPedido;
            }
            set
            {
                _NivelNuevoPedido = value;
            }
        }
        public int Suspendido
        {
            get
            {
                return _Suspendido;
            }
            set
            {
                _Suspendido = value;
            }
        }
    }
}