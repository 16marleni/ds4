using ProyectoFinal.DAL;
using ProyectoFinal.Models;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class UsuariosController : Controller
    {
        // Instancia del DAL
        UsuarioDAL dal = new UsuarioDAL();

        // Lista todos los usuarios
        public ActionResult Index()
        {
            var usuarios = dal.Listar();
            return View(usuarios);
        }

        // Muestra el formulario para crear un nuevo usuario
        public ActionResult Create()
        {
            return View();
        }

        // Recibe los datos del formulario y crea un nuevo usuario
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                dal.Insertar(usuario);
                TempData["MensajeExito"] = $"El usuario '{usuario.Nombre}' se agregó correctamente.";
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // Muestra el formulario para editar un usuario
        public ActionResult Edit(int id)
        {
            var usuario = dal.ObtenerPorId(id);
            if (usuario == null)
                return HttpNotFound();

            return View(usuario);
        }

        // Recibe los datos del formulario y actualiza el usuario
        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                dal.Actualizar(usuario);
                TempData["MensajeInfo"] = $"El usuario '{usuario.Nombre}' se editó correctamente.";
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // Confirma eliminación del usuario
        public ActionResult Delete(int id)
        {
            var usuario = dal.ObtenerPorId(id);
            if (usuario == null)
                return HttpNotFound();

            return View(usuario);
        }

        // Elimina el usuario
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var usuario = dal.ObtenerPorId(id);
            dal.Eliminar(id);
            TempData["MensajeAdvertencia"] = $"El usuario '{usuario.Nombre}' se eliminó correctamente.";
            return RedirectToAction("Index");
        }

        // Detalles de un usuario
        public ActionResult Details(int id)
        {
            var usuario = dal.ObtenerPorId(id);
            if (usuario == null)
                return HttpNotFound();

            return View(usuario);
        }
    }
}
