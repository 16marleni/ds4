using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Parcial3.Abogados
{
    public partial class Abogados : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(
            ConfigurationManager.ConnectionStrings["ConexionMarleni"].ConnectionString
        );

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAbogados();
            }
        }

        private void CargarAbogados()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM MB_Abogados", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvAbogados.DataSource = dt;
            gvAbogados.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (hfAbogadoId.Value == "")
                InsertarAbogado();
            else
                ActualizarAbogado();

            LimpiarCampos();
            CargarAbogados();
        }

        private void InsertarAbogado()
        {
            string query = "INSERT INTO MB_Abogados (Nombre, Especialidad, Telefono, Email) " +
                           "VALUES (@Nombre, @Especialidad, @Telefono, @Email)";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
            cmd.Parameters.AddWithValue("@Especialidad", txtEspecialidad.Text);
            cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void ActualizarAbogado()
        {
            string query = "UPDATE MB_Abogados SET Nombre=@Nombre, Especialidad=@Especialidad, Telefono=@Telefono, Email=@Email " +
                           "WHERE AbogadoId=@AbogadoId";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@AbogadoId", hfAbogadoId.Value);
            cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
            cmd.Parameters.AddWithValue("@Especialidad", txtEspecialidad.Text);
            cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        protected void gvAbogados_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                CargarAbogadoPorId(id);
            }
            else if (e.CommandName == "Eliminar")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                EliminarAbogado(id);
                CargarAbogados();
            }
        }

        private void CargarAbogadoPorId(int id)
        {
            string query = "SELECT * FROM MB_Abogados WHERE AbogadoId=@AbogadoId";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@AbogadoId", id);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                hfAbogadoId.Value = dr["AbogadoId"].ToString();
                txtNombre.Text = dr["Nombre"].ToString();
                txtEspecialidad.Text = dr["Especialidad"].ToString();
                txtTelefono.Text = dr["Telefono"].ToString();
                txtEmail.Text = dr["Email"].ToString();
            }
            con.Close();
        }

        private void EliminarAbogado(int id)
        {
            string query = "DELETE FROM MB_Abogados WHERE AbogadoId=@AbogadoId";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@AbogadoId", id);

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
            hfAbogadoId.Value = "";
            txtNombre.Text = "";
            txtEspecialidad.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
        }
    }
}
