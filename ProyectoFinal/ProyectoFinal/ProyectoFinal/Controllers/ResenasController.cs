using ProyectoFinal.DAL;
using ProyectoFinal.Models;
using Rotativa;
using System.Linq;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class ResenasController : Controller
    {
        private ResenasDAL dal = new ResenasDAL();
        private LibroDAL libroDAL = new LibroDAL();

        // =========================
        // LISTADO GENERAL
        // =========================
        public ActionResult Index()
        {
            return View(dal.Listar());
        }

        // =========================
        // EXPORTAR PDF
        // =========================
        public ActionResult ExportarPDF()
        {
            ViewBag.EsPDF = true;
            return new ViewAsPdf("Index", dal.Listar())
            {
                FileName = "Reporte_Reseñas.pdf",
                PageSize = Rotativa.Options.Size.Letter,
                PageOrientation = Rotativa.Options.Orientation.Portrait,
            };
        }

        public ActionResult PDFMisResenas()
        {
            ViewBag.EsPDF = true;
            return new ViewAsPdf("MisResenas", dal.Listar())
            {
                FileName = "Reporte_MisReseñas.pdf",
                PageSize = Rotativa.Options.Size.Letter,
                PageOrientation = Rotativa.Options.Orientation.Portrait,
            };
        }

        // =========================
        // DETALLES
        // =========================
        public ActionResult Details(int id)
        {
            var resena = dal.ObtenerPorId(id);
            if (resena == null)
                return HttpNotFound();

            int usuarioId = (int)Session["UsuarioId"];
            string tipoUsuario = Session["TipoUsuario"].ToString();

            // Cliente solo ve la suya
            if (tipoUsuario == "Cliente" && resena.UsuarioId != usuarioId)
                return new HttpStatusCodeResult(403);

            return View(resena);
        }

        // =========================
        // CREAR
        // =========================
        public ActionResult Create()
        {
            ViewBag.Libros = new SelectList(libroDAL.Listar(), "LibroId", "Titulo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Resenas resena)
        {
            if (ModelState.IsValid)
            {
                int usuarioId = (int)Session["UsuarioId"];
                dal.Insertar(resena.LibroId, resena.Comentario, resena.Calificacion, usuarioId);
                TempData["MensajeExito"] = "Reseña agregada correctamente.";
                return RedirectToAction("ReporteResenas");
            }

            ViewBag.Libros = new SelectList(libroDAL.Listar(), "LibroId", "Titulo", resena.LibroId);
            return View(resena);
        }

        // =========================
        // EDITAR (SOLO CLIENTE)
        // =========================
        public ActionResult Edit(int id)
        {
            var resena = dal.ObtenerPorId(id);
            if (resena == null)
                return HttpNotFound();

            int usuarioId = (int)Session["UsuarioId"];
            string tipoUsuario = Session["TipoUsuario"].ToString();

            // Cliente y Admin solo editan sus propias reseñas
            if (resena.UsuarioId != usuarioId)
                return new HttpStatusCodeResult(403);

            return View(resena);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Resenas resena)
        {
            var original = dal.ObtenerPorId(resena.ResenaId);
            if (original == null)
                return HttpNotFound();

            int usuarioId = (int)Session["UsuarioId"];

            // Cliente y Admin solo editan sus propias reseñas
            if (original.UsuarioId != usuarioId)
                return new HttpStatusCodeResult(403);

            if (ModelState.IsValid)
            {
                dal.Actualizar(resena.ResenaId, resena.Comentario, resena.Calificacion);
                TempData["MensajeExito"] = "Reseña actualizada correctamente.";
                return RedirectToAction("ReporteResenas");
            }

            return View(resena);
        }


        // =========================
        // ELIMINAR (CLIENTE Y ADMIN)
        // =========================
        public ActionResult Delete(int id)
        {
            var resena = dal.ObtenerPorId(id);
            if (resena == null)
                return HttpNotFound();

            int usuarioId = (int)Session["UsuarioId"];
            string tipoUsuario = Session["TipoUsuario"].ToString();

            if (tipoUsuario == "Cliente" && resena.UsuarioId != usuarioId)
                return new HttpStatusCodeResult(403);

            return View(resena);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var resena = dal.ObtenerPorId(id);
            if (resena == null)
                return HttpNotFound();

            int usuarioId = (int)Session["UsuarioId"];
            string tipoUsuario = Session["TipoUsuario"].ToString();

            if (tipoUsuario == "Cliente" && resena.UsuarioId != usuarioId)
                return new HttpStatusCodeResult(403);

            dal.Eliminar(id);
            TempData["MensajeAdvertencia"] = "Reseña eliminada correctamente.";

            return RedirectToAction("ReporteResenas");
        }

        // =========================
        // REPORTE ADMIN
        // =========================
        public ActionResult ReporteResenas()
        {
            return View(dal.Listar());
        }

        // =========================
        // MIS RESEÑAS (CLIENTE)
        // =========================
        public ActionResult MisResenas()
        {
            int usuarioId = (int)Session["UsuarioId"];
            return View(dal.Listar().Where(r => r.UsuarioId == usuarioId).ToList());
        }
    }
}
