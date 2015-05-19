using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GpiERGenNHibernate.EN.GpiER;
using GpiERGenNHibernate.CEN.GpiER;

namespace GestorAlmacenGPI.Controllers
{
    public class ProveedoresController : Controller
    {
        private ProveedorCEN proCEN = new ProveedorCEN();


        //
        // GET: /Proveedores/
        public ActionResult Index()
        {
            return View();
        }



        // URL: /Proveedores/NewProveedor
        [Authorize]
        public ActionResult NewProveedor()
        {
            return View();
        }

        // URL: /Proveedores/NewProveedor (POST)
        [HttpPost]
        public void NewProveedor(ProveedorEN proveedor)
        {
            proCEN.NuevoProveedor(proveedor.Nombre, proveedor.Direccion, proveedor.Nif, proveedor.Descuento, proveedor.DiaCobro, proveedor.Divisa, proveedor.DatosBancarios);
            Response.Redirect("~/Proveedores/ListaProveedores");
        }



        // URL: /Proveedores/ListaProveedores
        [Authorize]
        public ActionResult ListaProveedores()
        {
            return View();
        }



        // GET: /Proveedores/BorrarProveedor/ID
        [Authorize]
        public void BorrarProveedor(string nif)
        {
            proCEN.BorraProveedor(nif);
            Response.Redirect("~/Ventas/ListaProveedores");

        }



        // GET: /Proveedores/EditProveedor
        [Authorize]
        public ActionResult EditProveedor(string nif)
        {
            ProveedorEN en = proCEN.DameProveedorPorOID(nif);
            return View(en);
        }


        [HttpPost]
        public ActionResult EditProveedor(ProveedorEN a)
        {
            if (a != null)
                proCEN.ModificaProveedor(a.Nif, a.Nombre, a.Direccion, a.Descuento, a.DiaCobro, a.Divisa, a.DatosBancarios);

            return RedirectToAction("ListaProveedores");
        }




    }
}
