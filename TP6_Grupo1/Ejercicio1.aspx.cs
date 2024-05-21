using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP6_Grupo1.Conexion;

namespace TP6_Grupo1
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGVProductos();
            }
        }

            private void CargarGVProductos()
        {
            GestionProductos gestionProductos = new GestionProductos();
            GVProductos.DataSource = gestionProductos.ObtenerProductos(); // DataTable
            GVProductos.DataBind();
        }

        protected void GVProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVProductos.PageIndex = e.NewPageIndex;
            CargarGVProductos();
        }
        protected void GVProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVProductos.EditIndex = e.NewEditIndex;
            CargarGVProductos();
        }
        protected void GVProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVProductos.EditIndex = -1;
            CargarGVProductos();
        }

        protected void GVProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }


        protected void GVProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //busco el id que seleccione
            string ProductoSelected = ((Label)GVProductos.Rows[e.RowIndex].FindControl("lb_it_IdProducto")).Text;

            //creo el objeto de tipo producto y le cargo el id a eliminar
            Productos producto = new Productos(Convert.ToInt32(ProductoSelected));

            //creo la instancia para ejecutar el procedure
            GestionProductos gp = new GestionProductos();
            //ejecuto el delete y chequeo si se elimino correctamente
            if(gp.DeleteProducto(producto) == true)
            {
                lb_Mensaje.Text = "Se Elimino El Registro Exitosamente";
            }
            else
            {
                lb_Mensaje.ForeColor = System.Drawing.Color.Red;
                lb_Mensaje.Text = "ERROR Al Eliminar El Registro";
            }

            CargarGVProductos();
        }

        protected void GVProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}