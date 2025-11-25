using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laboratorio201.Controllers
{
    public class MultiplicarController : Controller
    {
        // GET: Multiplicar
        [HttpGet] // Acción para manejar solicitudes GET
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost] // Acción para manejar solicitudes POST
        public ActionResult Index(int numero)
        {
            ViewBag.Numero = numero;
            return View();
        }

    }
}