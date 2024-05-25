using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace TP6_Grupo1
{
    public partial class MostrarProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductosSeleccionados();
            }
        }
        private void CargarProductosSeleccionados()
        {
            DataTable dtSeleccionados = Session["ProductosSeleccionados"] as DataTable;
            if (dtSeleccionados != null)
            {
                gvMostrarProductos.DataSource = dtSeleccionados;
                gvMostrarProductos.DataBind();
            }
        }
    }
}