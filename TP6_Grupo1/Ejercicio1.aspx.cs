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
            GestionProductos gestionProductos= new GestionProductos();
            GVProductos.DataSource = gestionProductos.ObtenerProductos();//Data table
            GVProductos.DataBind();
        }

        protected void GVProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}