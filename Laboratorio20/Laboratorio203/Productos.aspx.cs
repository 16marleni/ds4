using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace Laboratorio203
{
    public partial class Productos : System.Web.UI.Page  //System.Web.UI contiene varias de las clases que utilizamos en el código
    {
        // Cadena de conexión a nivel de clase
        private string connectionString;

        // Flag para saber si es un nuevo registro
        bool Nuevo
        {
            get { return (bool)(ViewState["Nuevo"] ?? false); }
            set { ViewState["Nuevo"] = value; }
        }

        //Editamos el web.config para conectar la base de datos
        protected void Page_Load(object sender, EventArgs e)
        {
            // Inicializamos la cadena de conexión desde Web.config
            connectionString = ConfigurationManager.ConnectionStrings["ConexionProductos"].ConnectionString;

            if (!IsPostBack)
                Inicial();
        }

        // ------------------------ MÉTODOS ------------------------

        private void Inicial()
        {
            ImgBtnNuevo.Enabled = true;
            ImgBtnGuardar.Enabled = false;
            ImgBtnCancelar.Enabled = false;
            ImgBtnEliminar.Enabled = false;

            txtId.Enabled = false;
            txtNombre.Enabled = false;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;

            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";

            tstId.Text = "";
        }

        private void MostrarMensaje(string mensaje)
        {
            string script = $"alert('{mensaje}');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", script, true);
        }

        // ------------------------ EVENTOS ------------------------

        protected void ImgBtnNuevo_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            ImgBtnNuevo.Enabled = false;
            ImgBtnGuardar.Enabled = true;
            ImgBtnCancelar.Enabled = true;
            ImgBtnEliminar.Enabled = false;

            txtId.Enabled = false;
            txtId.Text = "Id automático";

            txtNombre.Enabled = true;
            txtPrecio.Enabled = true;
            txtStock.Enabled = true;

            Nuevo = true;  // Variable de control para saber si se está creando un nuevo registro
        }

        protected void ImgBtnGuardar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            decimal precio;
            float stock;

            if (!decimal.TryParse(txtPrecio.Text, out precio) ||
                !float.TryParse(txtStock.Text, out stock))
            {
                MostrarMensaje("Precio o Stock inválido.");
                return;
            }

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd;

                if (Nuevo)
                {
                    cmd = new SqlCommand(
                        "INSERT INTO LAPTOPS (Nombre, Precio, Stock) VALUES (@n, @p, @s)", cn);
                }
                else
                {
                    cmd = new SqlCommand(
                        "UPDATE LAPTOPS SET Nombre=@n, Precio=@p, Stock=@s WHERE Id=@id", cn);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtId.Text));
                }

                cmd.Parameters.AddWithValue("@n", txtNombre.Text);
                cmd.Parameters.AddWithValue("@p", precio);
                cmd.Parameters.AddWithValue("@s", stock);

                cmd.ExecuteNonQuery();
            }

            MostrarMensaje("Registro guardado correctamente.");
            Inicial();
        }

        protected void ImgBtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Inicial();
        }

        protected void ImgBtnEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MostrarMensaje("Debe buscar un registro antes de eliminar.");
                return;
            }

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM LAPTOPS WHERE Id=@id", cn);

                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtId.Text));
                cmd.ExecuteNonQuery();
            }

            MostrarMensaje("Registro eliminado correctamente.");
            Inicial();
        }

        protected void ImgBtnBuscar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            int id;
            if (!int.TryParse(tstId.Text, out id))
            {
                MostrarMensaje("Id inválido.");
                return;
            }

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM LAPTOPS WHERE Id=@id", cn);

                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtId.Text = dr["Id"].ToString();
                    txtNombre.Text = dr["Nombre"].ToString();
                    txtPrecio.Text = dr["Precio"].ToString();
                    txtStock.Text = dr["Stock"].ToString();

                    ImgBtnNuevo.Enabled = false;
                    ImgBtnGuardar.Enabled = true;
                    ImgBtnCancelar.Enabled = true;
                    ImgBtnEliminar.Enabled = true;

                    txtNombre.Enabled = true;
                    txtPrecio.Enabled = true;
                    txtStock.Enabled = true;

                    Nuevo = false;
                }
                else
                {
                    MostrarMensaje("No se encontró ese Id.");
                }
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Salir.aspx"); //Redireccionamiento a página de salir
        }
    }
}