using ProyectoFinal.DAL;
using ProyectoFinal.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class InicioController : Controller
    {
        UsuarioDAL usuarioDAL = new UsuarioDAL();
        PrestamosDAL prestamoDAL = new PrestamosDAL();


        // GET: Inicio
        public ActionResult Index()
        {

            ViewBag.Prestamos = new List<Prestamos>(); // Evita null en la vista
            return View();
        }

        // POST: Login
        [HttpPost]
        public ActionResult Login(string correo)
        {
            var usuario = usuarioDAL.Listar()
                .Find(u => u.Correo.ToLower() == correo.ToLower());

            if (usuario == null)
            {
                // Mensaje de error
                TempData["ErrorLogin"] = "El correo ingresado no está registrado.";
                return RedirectToAction("Index");
            }

            // Usuario válido
            Session["UsuarioId"] = usuario.UsuarioId;
            Session["NombreUsuario"] = usuario.Nombre;
            Session["TipoUsuario"] = usuario.TipoUsuario;

            return RedirectToAction("Index");
        }


        // POST: Consultar préstamos por correo
        [HttpPost]
        public ActionResult ConsultarPrestamos(string correo)
        {
            var usuario = usuarioDAL.Listar().Find(u => u.Correo.ToLower() == correo.ToLower());
            List<Prestamos> prestamos = new List<Prestamos>();

            if (usuario != null)
            {
                prestamos = prestamoDAL.ListarPorUsuario(usuario.UsuarioId);
            }

            ViewBag.Prestamos = prestamos;
            ViewBag.CorreoConsulta = correo;
            return View("Index");
        }

        // GET: Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
