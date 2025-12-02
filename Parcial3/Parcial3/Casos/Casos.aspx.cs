using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Parcial3.Casos
{
    public partial class Casos : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(
            ConfigurationManager.ConnectionStrings["ConexionMarleni"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();
                CargarCasos();
            }
        }

        private void CargarClientes()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT ClienteId, Nombre FROM MB_Clientes", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            ddlCliente.DataSource = dt;
            ddlCliente.DataTextField = "Nombre";
            ddlCliente.DataValueField = "ClienteId";
            ddlCliente.DataBind();
        }

        private void CargarCasos()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT CasoId, CodigoCaso, Titulo, FechaInicio, Estado FROM MB_Casos", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            gvCasos.DataSource = dt;
            gvCasos.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (hfCasoId.Value == "")
                InsertarCaso();
            else
                ActualizarCaso();

            LimpiarCampos();
            CargarCasos();
        }

        private void InsertarCaso()
        {
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO MB_Casos (CodigoCaso, Titulo, Descripcion, FechaInicio, FechaVencimiento, Estado, ClienteId) " +
                "VALUES (@CodigoCaso, @Titulo, @Descripcion, @FechaInicio, @FechaVencimiento, @Estado, @ClienteId)", con);

            cmd.Parameters.AddWithValue("@CodigoCaso", txtCodigo.Text);
            cmd.Parameters.AddWithValue("@Titulo", txtTitulo.Text);
            cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
            cmd.Parameters.AddWithValue("@FechaInicio", txtFechaInicio.Text);
            cmd.Parameters.AddWithValue("@FechaVencimiento", (object)txtFechaVenc.Text ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Estado", ddlEstado.SelectedValue);
            cmd.Parameters.AddWithValue("@ClienteId", ddlCliente.SelectedValue);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void ActualizarCaso()
        {
            SqlCommand cmd = new SqlCommand(
                "UPDATE MB_Casos SET CodigoCaso=@CodigoCaso, Titulo=@Titulo, Descripcion=@Descripcion, " +
                "FechaInicio=@FechaInicio, FechaVencimiento=@FechaVencimiento, Estado=@Estado, ClienteId=@ClienteId " +
                "WHERE CasoId=@CasoId", con);

            cmd.Parameters.AddWithValue("@CasoId", hfCasoId.Value);
            cmd.Parameters.AddWithValue("@CodigoCaso", txtCodigo.Text);
            cmd.Parameters.AddWithValue("@Titulo", txtTitulo.Text);
            cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
            cmd.Parameters.AddWithValue("@FechaInicio", txtFechaInicio.Text);
            cmd.Parameters.AddWithValue("@FechaVencimiento", (object)txtFechaVenc.Text ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Estado", ddlEstado.SelectedValue);
            cmd.Parameters.AddWithValue("@ClienteId", ddlCliente.SelectedValue);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        protected void gvCasos_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {
                CargarCasoPorId(id);
            }
            else if (e.CommandName == "Eliminar")
            {
                EliminarCaso(id);
                CargarCasos();
            }
        }

        private void CargarCasoPorId(int id)
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT * FROM MB_Casos WHERE CasoId=@CasoId", con);

            cmd.Parameters.AddWithValue("@CasoId", id);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                hfCasoId.Value = dr["CasoId"].ToString();
                txtCodigo.Text = dr["CodigoCaso"].ToString();
                txtTitulo.Text = dr["Titulo"].ToString();
                txtDescripcion.Text = dr["Descripcion"].ToString();
                txtFechaInicio.Text = Convert.ToDateTime(dr["FechaInicio"]).ToString("yyyy-MM-dd");
                txtFechaVenc.Text = dr["FechaVencimiento"] != DBNull.Value
                    ? Convert.ToDateTime(dr["FechaVencimiento"]).ToString("yyyy-MM-dd")
                    : "";
                ddlEstado.SelectedValue = dr["Estado"].ToString();
                ddlCliente.SelectedValue = dr["ClienteId"].ToString();
            }

            con.Close();
        }

        private void EliminarCaso(int id)
        {
            SqlCommand cmd = new SqlCommand(
                "DELETE FROM MB_Casos WHERE CasoId=@CasoId", con);

            cmd.Parameters.AddWithValue("@CasoId", id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            hfCasoId.Value = "";
            txtCodigo.Text = "";
            txtTitulo.Text = "";
            txtDescripcion.Text = "";
            txtFechaInicio.Text = "";
            txtFechaVenc.Text = "";
            ddlEstado.SelectedIndex = 0;
            if (ddlCliente.Items.Count > 0)
                ddlCliente.SelectedIndex = 0;
        }
    }
}
