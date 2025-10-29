
using System; // Importa el espacio de nombres para clases básicas
using System.Linq; // Importa el espacio de nombres para LINQ
using System.Text.RegularExpressions; // Importa el espacio de nombres para expresiones regulares
using System.Windows.Forms; // Importa el espacio de nombres para formularios de Windows
using System.Data; // Importa el espacio de nombres para DataTable
using Microsoft.Data.SqlClient; // Importa el espacio de nombres para SQL Server


namespace Proyecto1 //Nombre del Proyecto
{
    public partial class FormCalculadora : Form // Clase parcial para el formulario de la calculadora
    {
        //Conexión y variable global
        private SqlConnection conexion;
        string connectionString = @"Server=.\SQLEXPRESS;Database=CalculadoraDB;Trusted_Connection=True;Encrypt=False;";

        public FormCalculadora() // Constructor del formulario
        {
            InitializeComponent();
            conexion = new SqlConnection(connectionString); // Crea una nueva conexión SQL con la cadena de conexión proporcionada
        }

        // Números del 0 al 9
        private void btnNumero_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button; //sender es el botón que se presionó
            lblResultados.Text += btn.Text; // Agrega el texto del botón al label de resultados
        }

        // Operadores básicos: + - * /
        private void btnOperador_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            lblResultados.Text += " " + btn.Text + " ";
        }

        // Punto decimal
        private void btnPunto_Click(object sender, EventArgs e)
        {
            lblResultados.Text += ".";
        }

        // Funciones: raíz, cuadrado, cubo, porcentaje
        private void btnFuncion_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string funcion = btn.Text;

            // Si hay un número antes, la función se aplica al número (ej: 5x²)
            if (!string.IsNullOrWhiteSpace(lblResultados.Text) && char.IsDigit(lblResultados.Text.Last())) //Verifica 1 si el texto no está vacío y 2 si el último carácter es un dígito
            {
                lblResultados.Text += funcion; // Agrega la función directamente después del número
            }
            else
            {
                // Si no hay número antes (ej: √9)
                lblResultados.Text += funcion + " "; // Agrega la función seguida de un espacio
            }
        }


        // Evaluar operación completa
        private void btnIgual_Click(object sender, EventArgs e)
        {
            try
            {
                string expresionVisual = lblResultados.Text;

                // Reemplazar operadores visuales correctamente
                string expresionInterna = expresionVisual.Replace("÷", "/");
                expresionInterna = Regex.Replace(expresionInterna, @"x(?![²³])", "*");
                expresionInterna = expresionInterna.Replace(" ", ""); // Elimina espacios para facilitar el procesamiento

                // Procesar funciones antes de evaluar
                string expresionProcesada = Calculos.ProcesarFunciones(expresionInterna); // Procesa funciones como raíz, potencia y porcentaje
                double resultado = Calculos.EvaluarOperacion(expresionProcesada); // Evalúa la expresión matemática

                GuardarResultadoEnBD(expresionVisual, resultado); // Guarda la expresión original mostrada
                lblResultados.Text = resultado.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // Muestra un mensaje de error si la operación es inválida
            }

        }

        // Limpiar todo
        private void btnC_Click(object sender, EventArgs e)
        {
            lblResultados.Text = "";
        }

        // Borrar último carácter
        private void btnCE_Click(object sender, EventArgs e)
        {
            if (lblResultados.Text.Length > 0)
            {
                lblResultados.Text = lblResultados.Text.Substring(0, lblResultados.Text.Length - 1); // Elimina el último carácter del texto
            }
        }

        // Guardar resultado en la base de datos
        private void GuardarResultadoEnBD(string expresionOriginal, double resultado)
        {
            try
            {
                string query = "INSERT INTO ResultadosCalculadora (Expresion, Resultado) VALUES (@expresion, @resultado)"; // Consulta SQL para insertar el resultado
                using (SqlCommand cmd = new SqlCommand(query, conexion)) // Crea un comando SQL con la consulta y la conexión
                {
                    cmd.Parameters.AddWithValue("@expresion", expresionOriginal); // cmd es el comando SQL, parametros es una colección de parámetros, addwithvalue agrega un nuevo parámetro con su valor
                    cmd.Parameters.AddWithValue("@resultado", resultado); // Agrega el parámetro del resultado

                    conexion.Open(); // Abre la conexión
                    cmd.ExecuteNonQuery(); // Ejecuta la consulta de inserción
                    conexion.Close(); // Cierra la conexión
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en la base de datos: " + ex.Message); // Muestra un mensaje de error si ocurre un problema
                if (conexion.State == ConnectionState.Open) // Verifica si la conexión está abierta
                    conexion.Close(); // Cierra la conexión si está abierta
            }
        }

        //Mostrar historial de cálculos
        private void btnCalculos_Click(object sender, EventArgs e)
        {
            try
            {
                lbCalculos.Items.Clear(); // Limpia la lista antes de cargar nuevos datos

                string query = "SELECT Expresion, Resultado, Fecha FROM ResultadosCalculadora ORDER BY Fecha DESC"; // Consulta SQL para obtener los resultados ordenados por fecha descendente
                using (SqlCommand cmd = new SqlCommand(query, conexion)) // Crea un comando SQL con la consulta y la conexión
                {
                    conexion.Open();
                    SqlDataReader reader = cmd.ExecuteReader(); // Ejecuta la consulta y obtiene un lector de datos

                    while (reader.Read()) // Lee cada fila del resultado
                    {
                        string expresion = reader["Expresion"].ToString(); // Obtiene la expresión
                        double resultado = Convert.ToDouble(reader["Resultado"]); // Obtiene el resultado
                        DateTime fecha = Convert.ToDateTime(reader["Fecha"]); // Obtiene la fecha del cálculo

                        string linea = $"{fecha:dd/MM/yyyy HH:mm} → {expresion} = {resultado}"; //Texto formateado para mostrar en la lista
                        lbCalculos.Items.Add(linea); // Agrega la línea a la lista de cálculos
                    }

                    reader.Close(); // Cierra el lector de datos
                    conexion.Close(); // Cierra la conexión
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar resultados: " + ex.Message); // Muestra un mensaje de error si ocurre un problema
                if (conexion.State == ConnectionState.Open) // Verifica si la conexión está abierta
                    conexion.Close(); // Cierra la conexión si está abierta
            }

        }
    }
}
