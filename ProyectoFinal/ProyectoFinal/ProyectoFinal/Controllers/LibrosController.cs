using ProyectoFinal.DAL;
using ProyectoFinal.Models;
using System.Web.Mvc;
using Rotativa;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace ProyectoFinal.Controllers
{
    public class LibrosController : Controller
    {
        // Instancia del DAL
        LibroDAL dal = new LibroDAL();

        // Lista todos los libros (desde el DAL directamente)
        //public ActionResult Index()
        //{
        //  var libros = dal.Listar();
        //  return View(libros);
        //}

        // Lista todos los libros (consumiendo la API)
        // Importante webconfig, globalasax y librosapicontroller
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            System.Collections.Generic.List<Libro> libros;

            using (var client = new System.Net.Http.HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("https://localhost:44334/api/libros");
                var json = await response.Content.ReadAsStringAsync();
                libros = Newtonsoft.Json.JsonConvert.DeserializeObject<
                    System.Collections.Generic.List<Libro>>(json);
            }

            return View(libros);
        }

        // Muestra el formulario para crear un nuevo libro
        public ActionResult Create()
        {
            return View();
        }

        // Recibe los datos del formulario y crea un nuevo libro
        [HttpPost]
        public ActionResult Create(Libro libro)
        {
            if (ModelState.IsValid)
            {
                dal.Insertar(libro);
                TempData["MensajeExito"] = $"El libro '{libro.Titulo}' se agregó correctamente.";
                return RedirectToAction("Index");
            }
            return View(libro);
        }

        // Muestra el formulario para editar un libro
        public ActionResult Edit(int id)
        {
            var libro = dal.ObtenerPorId(id);
            if (libro == null)
                return HttpNotFound();

            return View(libro);
        }

        // Recibe los datos del formulario y actualiza el libro
        [HttpPost]
        public ActionResult Edit(Libro libro)
        {
            if (ModelState.IsValid)
            {
                dal.Actualizar(libro);
                TempData["MensajeInfo"] = $"El libro '{libro.Titulo}' se editó correctamente.";
                return RedirectToAction("Index");
            }
            return View(libro);
        }


        // Confirma eliminación del libro
        public ActionResult Delete(int id)
        {
            var libro = dal.ObtenerPorId(id);
            if (libro == null)
                return HttpNotFound();

            return View(libro);
        }

        // Elimina el libro
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var libro = dal.ObtenerPorId(id);
            dal.Eliminar(id);
            TempData["MensajeAdvertencia"] = $"El libro '{libro.Titulo}' se eliminó correctamente.";
            return RedirectToAction("Index");
        }

        // Reporte de libros disponibles
        public ActionResult Disponibles()
        {
            var libros = dal.ListarDisponibles();
            return View(libros);
        }

        // Generar PDF de libros disponibles
        public ActionResult ExportarPDF()
        {
            var libros = dal.ListarDisponibles();
            ViewBag.EsPDF = true; // Para ocultar botones en el PDF
            return new ViewAsPdf("Disponibles", libros)
            {
                FileName = "Reporte_Libros_Disponibles.pdf",
                PageSize = Rotativa.Options.Size.Letter,
                PageOrientation = Rotativa.Options.Orientation.Portrait,
            };
        }

        // Detalles de un libro (opcional)
        public ActionResult Details(int id)
        {
            var libro = dal.ObtenerPorId(id);
            if (libro == null)
                return HttpNotFound();

            return View(libro);
        }
    }
}
