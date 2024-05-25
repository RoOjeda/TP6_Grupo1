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
            if (!IsPostBack)
            {
                GestionProductos gestionProductos = new GestionProductos();

                DataTable tabla = new DataTable();
                tabla = ((DataTable)gestionProductos.ObtenerProductos()).Clone();
                Session["TablaSeleccionados"] = (DataTable)tabla;

                ObtenerDatosDeProductos();
            }
        }
        public void ObtenerDatosDeProductos()
        {
            GestionProductos gestionProductos = new GestionProductos();
            gvSelectProd.DataSource = gestionProductos.ObtenerProductos();
            gvSelectProd.DataBind();
        }

        protected void gvSelectProd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Cambia el índice de la página
            gvSelectProd.PageIndex = e.NewPageIndex;

            // Vuelve a cargar los datos del GridView
            ObtenerDatosDeProductos();
        }

        protected void gvSelectProd_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            

            string IdProducto = ((Label)gvSelectProd.Rows[e.NewSelectedIndex].FindControl("Lb_it_IdProduc")).Text;

            if (existeSeleccionado(IdProducto)) {
                lblSeleccion.Text = "Usted Ya seleccionó anteriormente el id: " + "  " + IdProducto;
                return;
            }
            
            string NombreProducto = ((Label)gvSelectProd.Rows[e.NewSelectedIndex].FindControl("Lb_It_Nombre")).Text;
            string IdProveedor = ((Label)gvSelectProd.Rows[e.NewSelectedIndex].FindControl("Lb_It_IdProveedor")).Text;
            string PrecioUnidad = ((Label)gvSelectProd.Rows[e.NewSelectedIndex].FindControl("Lb_It_Precio")).Text;

            DataRow data = ((DataTable)Session["TablaSeleccionados"]).NewRow();
            data["IdProducto"] = IdProducto;
            data["NombreProducto"] = NombreProducto;
            data["idProveedor"] = IdProveedor;
            data["PrecioUnidad"] = PrecioUnidad;


            ((DataTable)Session["TablaSeleccionados"]).Rows.Add(data);

            lblSeleccion.Text = "Usted seleccionó: " + "  " + NombreProducto;
        }

        private bool existeSeleccionado(string idProducto)
        {
            foreach (DataRow producto in ((DataTable)Session["TablaSeleccionados"]).Rows)
            {
                string idcomp = ((int)producto["IdProducto"]).ToString();
                if (idcomp.CompareTo(idProducto) == 0) { return true; }
            }
            return false;
        }
    }
}
