using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

// Controlador modificado para obtener todos los valores, se consume la API del Laboratorio181

namespace Laboratorio192.Controllers
{
    public class HomeController : Controller
    {

        // Index modificado para consumir API
        public async Task<ActionResult> Index() 
        {
            string url = "https://localhost:44343/api/values"; // asegúrate del puerto correcto

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();

                // Deserializa como lista de strings
                var values = JsonConvert.DeserializeObject<List<string>>(json);

                ViewBag.Values = values; // pasamos los datos a la vista
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