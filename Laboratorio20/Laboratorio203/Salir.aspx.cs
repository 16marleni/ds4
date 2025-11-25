//Se crea salir ya que en web no se puede salir como en Forms normal
using System;

namespace Laboratorio203
{
    public partial class Salir : System.Web.UI.Page
    {
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx"); // Vuelve a la página principal
        }
    }
}
