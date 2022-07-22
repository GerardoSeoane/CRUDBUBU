using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Validaciones;

namespace IGrafica.Controllers
{
    public class HomeController : Controller
    {
        Validar validar = new Validar();
        // GET: Home
        public ActionResult Mostrar()
        {
            List<EntPersonas> Lista = validar.Mostrar();
            return View(Lista);
        }
        public ActionResult Agregar()
        {
            return View();
        }
    }
}