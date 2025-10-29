//Instrucciones para asociar a SQL Client

using System.Data;
using Microsoft.Data.SqlClient; //Se cambia a Microsoft por que System manda error de obsoleta

namespace Laboratorio13
{
    public partial class Form1 : Form
    {
        private SqlConnection conexion; //Variable global para poder utilizarla libremente en los procesos
        string connectionString = @"Server=.\sqlexpress;Database=Northwind; TrustServerCertificate=true;Integrated Security=SSPI;";
        public Form1()
        {
            InitializeComponent();
            conexion = new SqlConnection(connectionString); //Inicializa la conexión con la cadena de conexión
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try //try, catch, finally para manejo de errores siempre deben ir juntos
            {
                conexion.Open();
                MessageBox.Show("Se abrió la conexión con el servidor SQL Server y se seleccionó la base de datos");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la conexión: " + ex.Message);
            }
            finally // finally siempre se ejecuta para cerrar la conexión y liberar recursos
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Se cerró la conexión.");
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarProductos(); // Llama al método cuando se carga el formulario
        }

        private void CargarProductos() // Nuevo método para cargar productos puede ser escrito en una clase aparte
        {

            listBox1.Items.Clear(); // Limpia el ListBox antes de llenarlo

            string query = "SELECT ProductName FROM [dbo].[Products]";

            SqlCommand comando = new SqlCommand(query, conexion); // Crea el comando SQL para ejecutar la consulta

            try
            {
                conexion.Open();
                SqlDataReader lector = comando.ExecuteReader(); // Ejecuta el comando y obtiene un lector de datos

                while (lector.Read())
                {
                    string nombreProducto = lector["ProductName"].ToString(); // Lee el nombre del producto
                    listBox1.Items.Add(nombreProducto); // Agrega el nombre del producto al ListBox
                }

                lector.Close();
            }
            catch (Exception ex) // Manejo de errores
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message); // Muestra un mensaje de error si ocurre una excepción
            }

            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }
    }
}
