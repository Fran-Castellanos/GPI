using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestorAlmacenGPI.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "¡Bienvenido al gestor de almacenes de GPI!";
            ViewData["Description"] = "La mejor aplicación para gestionar el stock de tu empresa";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
