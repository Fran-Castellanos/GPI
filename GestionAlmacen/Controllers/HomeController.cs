using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionStockGPI.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "¡Bienvenido a AutoGestor!";
            ViewData["Description"] = "La mejor aplicación para gestionar el stock de tu empresa";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
