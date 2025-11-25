using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laboratorio202.Controllers
{
    public class MatrizController : Controller
    {
        // GET: Matriz
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int n)
        {
            ViewBag.N = n; // Pasar el tamaño de la matriz a la vista
            return View();
        }

    }
}