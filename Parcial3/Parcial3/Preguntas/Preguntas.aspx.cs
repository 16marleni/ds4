using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Parcial3.Preguntas
{
    public partial class Preguntas : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(
            ConfigurationManager.ConnectionStrings["ConexionMarleni"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPreguntas();
            }
        }

        // Cargar todas las preguntas en el GridView
        private void CargarPreguntas()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT Id, Pregunta, Respuesta, Fecha FROM MB_Preguntas ORDER BY Fecha DESC", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            gvPreguntas.DataSource = dt;
            gvPreguntas.DataBind();
        }

        // Iniciar edición de fila
        protected void gvPreguntas_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvPreguntas.EditIndex = e.NewEditIndex;
            CargarPreguntas();
        }

        // Actualizar la respuesta
        protected void gvPreguntas_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvPreguntas.DataKeys[e.RowIndex].Value);
            string nuevaRespuesta = ((System.Web.UI.WebControls.TextBox)gvPreguntas.Rows[e.RowIndex].FindControl("txtRespuesta")).Text;

            SqlCommand cmd = new SqlCommand(
                "UPDATE MB_Preguntas SET Respuesta=@Respuesta, Fecha=GETDATE() WHERE Id=@Id", con);
            cmd.Parameters.AddWithValue("@Respuesta", nuevaRespuesta);
            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            gvPreguntas.EditIndex = -1;
            CargarPreguntas();
        }


        // Cancelar edición
        protected void gvPreguntas_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvPreguntas.EditIndex = -1;
            CargarPreguntas();
        }
    }
}
