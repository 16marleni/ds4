//Librerias utilizadas
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace Laboratorio14 //Nombre del proyecto
{
    public partial class frmProductos : Form //Clase
    {
        //Conexión y variable global
        private SqlConnection conexion;
        string connectionString = @"Server=.\SQLEXPRESS;Database=Productos;Trusted_Connection=True;Encrypt=False;";
        bool nuevo;

        // Constructor del formulario
        public frmProductos()
        {
            InitializeComponent(); // Inicializa los componentes visuales del formulario
            conexion = new SqlConnection(connectionString); // Crea una nueva conexión SQL con la cadena de conexión proporcionada
        }

        // Evento que se ejecuta al cargar el formulario
        private void frmProductos_Load(object sender, EventArgs e)
        {
            // Habilita y deshabilita botones y campos al iniciar el formulario
            tsbNuevo.Enabled = true;
            tsbGuardar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbEliminar.Enabled = false;
            txtId.Enabled = false;
            tstId.Enabled = true;
            tsbBuscar.Enabled = true;
            txtNombre.Enabled = false;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;
        }

        // Evento que se ejecuta al hacer clic en "Nuevo"
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            // Configura el estado para ingresar un nuevo registro
            tsbNuevo.Enabled = false;
            tsbGuardar.Enabled = true;
            tsbCancelar.Enabled = true;
            tsbEliminar.Enabled = false;
            txtId.Enabled = false;
            txtId.Text = "Id automática"; // Indica que el Id será generado automáticamente
            tstId.Enabled = false;
            tsbBuscar.Enabled = false;
            txtNombre.Enabled = true;
            txtPrecio.Enabled = true;
            txtStock.Enabled = true;
            txtNombre.Focus(); // Coloca el cursor en el campo Nombre
            nuevo = true; // Variable de control para saber si se está creando un nuevo registro
        }

        // Evento al hacer clic en "Guardar"
        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            decimal precio;
            float stock;

            // Validación de que los valores ingresados sean numéricos
            if (!decimal.TryParse(txtPrecio.Text, out precio) || !float.TryParse(txtStock.Text, out stock))
            {
                MessageBox.Show("Precio o Stock inválido.");
                return;
            }

            conexion.Open(); // Abre la conexión a la base de datos

            if (nuevo) // Si es un nuevo registro
            {
                // Consulta SQL para insertar un nuevo registro
                string sql = "INSERT INTO LAPTOPS (Nombre, Precio, Stock) VALUES (@nombre, @precio, @stock)";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                // Se agregan los parámetros a la consulta
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@stock", stock);

                try
                {
                    int i = cmd.ExecuteNonQuery(); // Ejecuta la consulta
                    if (i > 0)
                    {
                        MessageBox.Show("Registro ingresado correctamente !");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
            }
            else // Si se está modificando un registro existente
            {
                int id;
                if (!int.TryParse(txtId.Text, out id)) // Verifica que el ID sea válido
                {
                    MessageBox.Show("Id inválido.");
                    conexion.Close();
                    return;
                }

                // Consulta SQL para actualizar el registro existente
                string sql = "UPDATE LAPTOPS SET Nombre = @nombre, Precio = @precio, Stock = @stock WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@stock", stock);
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    int i = cmd.ExecuteNonQuery(); // Ejecuta la actualización
                    if (i > 0)
                    {
                        MessageBox.Show("Registro actualizado correctamente !");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
            }

            conexion.Close(); // Cierra la conexión a la base de datos

            // Restablece la interfaz a su estado inicial
            tsbNuevo.Enabled = true;
            tsbGuardar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbEliminar.Enabled = false;
            txtId.Enabled = false;
            tstId.Enabled = true;
            tsbBuscar.Enabled = true;
            txtNombre.Enabled = false;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;
            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }

        // Evento al hacer clic en "Cancelar"
        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            // Restaura los controles a su estado original
            tsbNuevo.Enabled = true;
            tsbGuardar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbEliminar.Enabled = false;
            txtId.Enabled = false;
            tstId.Enabled = true;
            tsbBuscar.Enabled = true;
            txtNombre.Enabled = false;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;
            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }

        // Evento al hacer clic en "Eliminar"
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txtId.Text, out id)) // Verifica que el ID sea válido
            {
                MessageBox.Show("Id inválido.");
                return;
            }

            conexion.Open(); // Abre la conexión
            string sql = "DELETE FROM LAPTOPS WHERE Id = @id"; // Consulta para eliminar
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@id", id); // Asigna el valor del parámetro

            try
            {
                int i = cmd.ExecuteNonQuery(); // Ejecuta el DELETE
                if (i > 0)
                {
                    MessageBox.Show("Registro eliminado correctamente !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }

            conexion.Close(); // Cierra la conexión

            // Restablece la interfaz
            tsbNuevo.Enabled = true;
            tsbGuardar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbEliminar.Enabled = false;
            txtId.Enabled = false;
            tsbBuscar.Enabled = true;
            txtNombre.Enabled = false;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;
            tstId.Text = "";
            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }

        // Evento al hacer clic en "Buscar"
        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(tstId.Text, out id)) // Verifica que el ID ingresado sea válido
            {
                MessageBox.Show("Id inválido.");
                return;
            }

            conexion.Open(); // Abre la conexión
            string sql = "SELECT * FROM LAPTOPS WHERE Id = @id"; // Consulta para buscar por ID
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@id", id); // Asigna el parámetro

            try
            {
                SqlDataReader reader = cmd.ExecuteReader(); // Ejecuta la consulta y obtiene los datos
                if (reader.Read()) // Si se encontró un registro
                {
                    // Habilita o deshabilita los botones y campos según sea necesario
                    tsbNuevo.Enabled = false;
                    tsbGuardar.Enabled = true;
                    tsbCancelar.Enabled = true;
                    tsbEliminar.Enabled = true;
                    txtId.Enabled = false;
                    tstId.Text = "";
                    tstId.Enabled = true;
                    tsbBuscar.Enabled = true;
                    txtNombre.Enabled = true;
                    txtPrecio.Enabled = true;
                    txtStock.Enabled = true;
                    txtNombre.Focus();

                    // Muestra los datos recuperados en los campos correspondientes
                    txtId.Text = reader[0].ToString();
                    txtNombre.Text = reader[1].ToString();
                    txtPrecio.Text = reader[2].ToString();
                    txtStock.Text = reader[3].ToString();
                    nuevo = false; // Indica que no es un nuevo registro
                }
                else
                {
                    MessageBox.Show("Ningún registro encontrado con el Id ingresado !");
                }
                reader.Close(); // Cierra el DataReader
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }

            conexion.Close(); // Cierra la conexión
        }

        // Evento para cerrar el formulario
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra la ventana del formulario
        }

    }
}
