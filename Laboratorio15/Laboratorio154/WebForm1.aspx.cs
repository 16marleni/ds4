using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio154
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSumar_Click(object sender, EventArgs e)
        {
            try
            {
                // Intentamos convertir directamente los textos a números
                double primerNumero = Convert.ToDouble(txtBNumero1.Text);
                double segundoNumero = Convert.ToDouble(txtBNumero2.Text);

                double resultado = primerNumero + segundoNumero;

                lblResultado.Text = resultado.ToString();
            }
            catch (FormatException)
            {
                // Se ejecuta si alguno de los textos no es un número válido
                lblResultado.Text = "Error: Por favor ingrese números válidos.";
            }
        }
    }
}