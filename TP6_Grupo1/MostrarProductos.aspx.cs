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
                gvMostrarProductos.DataSource = (DataTable)Session["TablaSeleccionados"];
                gvMostrarProductos.DataBind();
            }
        }

    }
}