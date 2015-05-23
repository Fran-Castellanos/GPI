using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GpiERGenNHibernate.EN.GpiER;
using GpiERGenNHibernate.CEN.GpiER;

namespace GestionStockGPI.Controllers
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
            if (proveedor == null || proveedor.Nif == null)
            {
                Response.Redirect("~/Proveedores/NewProveedor");
                return;
            }
            else
            {

                proCEN.NuevoProveedor(proveedor.Nif, proveedor.Nombre, proveedor.Pais, proveedor.Provincia, proveedor.Direccion, proveedor.Email, proveedor.Divisa, proveedor.DatosBancarios, proveedor.Descuento, proveedor.DiasCobro, proveedor.FechaAlta, proveedor.FechaUltimaModificacion, proveedor.Telefono);

                Response.Redirect("~/Proveedores/ListaProveedores");
            }
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
                proCEN.ModificaProveedor(a.Nif, a.Nombre, a.Pais, a.Provincia, a.Direccion, a.Email, a.Divisa, a.DatosBancarios, a.Descuento, a.DiasCobro, a.FechaAlta, a.FechaUltimaModificacion, a.Telefono);
                

            return RedirectToAction("ListaProveedores");
        }




    }
}
