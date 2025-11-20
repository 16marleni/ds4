using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

// Controlador modificado para obtener solo el valor con ID 2, se consume la API del Laboratorio181

namespace Laboratorio193.Controllers
{
    public class HomeController : Controller
    {
        // Método que obtiene solo el valor con ID 2
        public async Task<ActionResult> Index()
        {
            string url = "https://localhost:44343/api/values/2"; // Ajusta el puerto según tu Lab181

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();

                try
                {
                    // La respuesta es un string simple
                    ViewBag.Value = JsonConvert.DeserializeObject<string>(json);
                }
                catch (JsonReaderException)
                {
                    ViewBag.Value = "Error al obtener el dato: " + json;
                }
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}