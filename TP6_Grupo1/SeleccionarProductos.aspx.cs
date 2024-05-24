using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using TP6_Grupo1.Conexion;


namespace TP6_Grupo1
{
    public partial class SeleccionarProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            

                ObtenerDatosDeProductos();
           

        }
        public void ObtenerDatosDeProductos()
        {
            GestionProductos gestionProductos = new GestionProductos();
            gvSelectProd.DataSource = gestionProductos.ObtenerProductos();
            gvSelectProd.DataBind();
        }

     
       
        protected void gvSelectProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener los valores de las celdas seleccionadas
            string IdProducto = ((Label)gvSelectProd.Rows[gvSelectProd.SelectedIndex].FindControl("Lb_it_IdProduc")).Text;
            string NombreProducto = ((Label)gvSelectProd.Rows[gvSelectProd.SelectedIndex].FindControl("Lb_It_Nombre")).Text;
            string IdProveedor = ((Label)gvSelectProd.Rows[gvSelectProd.SelectedIndex].FindControl("Lb_It_IdProveedor")).Text;
            string PrecioUnidad = ((Label)gvSelectProd.Rows[gvSelectProd.SelectedIndex].FindControl("Lb_It_Precio")).Text;
            lblSeleccion.Text = " Usted seleccionó: " + "  "+ "Número de Producto: " + IdProducto + " Producto: " + NombreProducto + " Proveedor:  " + IdProveedor + " Precio: $  " + PrecioUnidad;
        }

        protected void gvSelectProd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Cambia el índice de la página
            gvSelectProd.PageIndex = e.NewPageIndex;

            // Vuelve a cargar los datos del GridView
            ObtenerDatosDeProductos();
        }
    }
}
