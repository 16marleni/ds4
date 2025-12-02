using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Parcial3.Clientes
{
    public partial class Clientes : System.Web.UI.Page
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["ConexionMarleni"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();
            }
        }

        private void CargarClientes()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM MB_Clientes", con))
            {
                da.Fill(dt);
            }

            gvClientes.DataSource = dt;
            gvClientes.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hfClienteId.Value))
                InsertarCliente();
            else
                ActualizarCliente();

            LimpiarCampos();
            CargarClientes();
        }

        private void InsertarCliente()
        {
            string query = @"INSERT INTO MB_Clientes (Nombre, Telefono, Email, Direccion, Observaciones)
                             VALUES (@Nombre, @Telefono, @Email, @Direccion, @Observaciones)";

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text.Trim());
                cmd.Parameters.AddWithValue("@Observaciones", txtObservaciones.Text.Trim());

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void ActualizarCliente()
        {
            string query = @"UPDATE MB_Clientes
                             SET Nombre=@Nombre, Telefono=@Telefono, Email=@Email, Direccion=@Direccion, Observaciones=@Observaciones
                             WHERE ClienteId=@ClienteId";

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ClienteId", Convert.ToInt32(hfClienteId.Value));
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text.Trim());
                cmd.Parameters.AddWithValue("@Observaciones", txtObservaciones.Text.Trim());

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        protected void gvClientes_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                CargarClientePorId(id);
            }
            else if (e.CommandName == "Eliminar")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                EliminarCliente(id);
                CargarClientes();
            }
        }

        private void CargarClientePorId(int id)
        {
            string query = "SELECT * FROM MB_Clientes WHERE ClienteId=@ClienteId";

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ClienteId", id);
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        hfClienteId.Value = dr["ClienteId"].ToString();
                        txtNombre.Text = dr["Nombre"].ToString();
                        txtTelefono.Text = dr["Telefono"].ToString();
                        txtEmail.Text = dr["Email"].ToString();
                        txtDireccion.Text = dr["Direccion"].ToString();
                        txtObservaciones.Text = dr["Observaciones"].ToString();
                    }
                }
            }
        }

        private void EliminarCliente(int id)
        {
            string query = "DELETE FROM MB_Clientes WHERE ClienteId=@ClienteId";

            using (SqlConnection con = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ClienteId", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            hfClienteId.Value = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtDireccion.Text = "";
            txtObservaciones.Text = "";
        }
    }
}
