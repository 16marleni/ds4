using ProyectoFinal.DAL;
using ProyectoFinal.Models;
using Rotativa;
using System;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class PrestamosController : Controller
    {
        PrestamosDAL dal = new PrestamosDAL();
        UsuarioDAL usuarioDAL = new UsuarioDAL();
        LibroDAL libroDAL = new LibroDAL();

        public ActionResult Index()
        {
            return View(dal.Listar());
        }

        public ActionResult Activos()
        {
            return View(dal.ListarActivos());
        }

        public ActionResult ExportarPDF()
        {
            ViewBag.EsPDF = true;
            return new ViewAsPdf("Activos", dal.ListarActivos())
            {
                FileName = "Reporte_Prestamos_Activos.pdf",
                PageSize = Rotativa.Options.Size.Letter,
                PageOrientation = Rotativa.Options.Orientation.Portrait,
            };
        }

        public ActionResult Create()
        {
            ViewBag.Usuarios = new SelectList(usuarioDAL.Listar(), "UsuarioId", "Nombre");
            ViewBag.Libros = new SelectList(libroDAL.ListarDisponibles(), "LibroId", "Titulo");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Prestamos prestamo)
        {
            try
            {
                dal.RegistrarPrestamo(prestamo.UsuarioId, prestamo.LibroId);
                TempData["MensajeExito"] = "Préstamo registrado correctamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensajeAdvertencia"] = ex.Message;
            }

            ViewBag.Usuarios = new SelectList(usuarioDAL.Listar(), "UsuarioId", "Nombre", prestamo.UsuarioId);
            ViewBag.Libros = new SelectList(libroDAL.ListarDisponibles(), "LibroId", "Titulo", prestamo.LibroId);

            return View(prestamo);
        }

        public ActionResult Devolver(int id)
        {
            return View(dal.ObtenerPorId(id));
        }

        [HttpPost, ActionName("Devolver")]
        public ActionResult DevolverConfirmado(int id)
        {
            dal.DevolverLibro(id);
            TempData["MensajeInfo"] = "Libro devuelto correctamente.";
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            return View(dal.ObtenerPorId(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            dal.Eliminar(id);
            TempData["MensajeAdvertencia"] = "Préstamo eliminado.";
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(dal.ObtenerPorId(id));
        }
    }
}
