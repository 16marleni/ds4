using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.UI;
using Newtonsoft.Json;

namespace Proyecto223
{
    public partial class WebForm1 : Page
    {
        // URL base de la API 
        private const string API_BASE_URL = "https://localhost:44354/api/Calculos/";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Registrar eventos de los botones
                btnSumas.Click += btnSumas_Click;
                btnRestas.Click += btnRestas_Click;
                btnMultiplicaciones.Click += btnMultiplicaciones_Click;
                btnDivisiones.Click += btnDivisiones_Click;
                btnTodos.Click += btnTodos_Click;
            }
        }

        protected async void btnSumas_Click(object sender, EventArgs e)
        {
            await CargarDatos("ObtenerSumas");
        }

        protected async void btnRestas_Click(object sender, EventArgs e)
        {
            await CargarDatos("ObtenerRestas");
        }

        protected async void btnMultiplicaciones_Click(object sender, EventArgs e)
        {
            await CargarDatos("ObtenerMultiplicaciones");
        }

        protected async void btnDivisiones_Click(object sender, EventArgs e)
        {
            await CargarDatos("ObtenerDivisiones");
        }

        protected async void btnTodos_Click(object sender, EventArgs e)
        {
            await CargarDatos("ObtenerTodos");
        }

        protected async void btnRecientes_Click(object sender, EventArgs e)
        {
            await CargarDatos("ObtenerCalculosRecientes");
        }

        private async Task CargarDatos(string endpoint)
        {
            try
            {
                ListBox1.Items.Clear();
                ListBox1.Items.Add("Cargando...");

                using (HttpClient client = new HttpClient())
                {
                    // Configurar el cliente HTTP
                    client.BaseAddress = new Uri(API_BASE_URL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    // Llamar al API
                    HttpResponseMessage response = await client.GetAsync(endpoint);

                    ListBox1.Items.Clear();

                    if (response.IsSuccessStatusCode)
                    {
                        // Leer la respuesta
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        // Deserializar el JSON a una lista de objetos
                        List<Calculo> calculos = JsonConvert.DeserializeObject<List<Calculo>>(jsonResponse);

                        // Mostrar en el ListBox
                        if (calculos != null && calculos.Count > 0)
                        {
                            foreach (var calculo in calculos)
                            {
                                string item = $"ID: {calculo.Id} | {calculo.Expresion} = {calculo.Resultado} | {calculo.Fecha:dd/MM/yyyy HH:mm}";
                                ListBox1.Items.Add(item);
                            }
                        }
                        else
                        {
                            ListBox1.Items.Add("No se encontraron resultados");
                        }
                    }
                    else
                    {
                        ListBox1.Items.Add($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                ListBox1.Items.Clear();
                ListBox1.Items.Add("Error de conexión con el API");
                ListBox1.Items.Add("Asegúrate de que el Web API esté ejecutándose");
                ListBox1.Items.Add($"Detalle: {ex.Message}");
            }
            catch (Exception ex)
            {
                ListBox1.Items.Clear();
                ListBox1.Items.Add($"Error: {ex.Message}");
            }
        }

        
    }

    // Clase modelo para deserializar la respuesta
    public class Calculo
    {
        public int Id { get; set; }
        public string Expresion { get; set; }
        public decimal Resultado { get; set; }
        public DateTime Fecha { get; set; }
    }
}