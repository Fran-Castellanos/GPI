using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GpiERGenNHibernate.EN.GpiER;
using GpiERGenNHibernate.CEN.GpiER;

namespace GestorAlmacenGPI.Controllers
{
    public class ClientesController : Controller
    {

        private ClienteCEN clienteCEN = new ClienteCEN();


        //
        // GET: /Articulos/
        public ActionResult Index()
        {
            return View();
        }


        // URL: /Clientes/ListaClientes
        [Authorize]
        public ActionResult ListaClientes()
        {
            return View();
        }


        // URL: /Clientes/NewCliente
        [Authorize]
        public ActionResult NewCliente()
        {
            return View();
        }

        // URL: /Clientes/NewCliente (POST)
        [HttpPost]
        public void NewCliente(ClienteEN cliente)
        {
            clienteCEN.NuevoCliente(cliente.Nombre, cliente.Nif, cliente.Direccion, cliente.Provincia, cliente.Email, 
                                    cliente.DatosBancarios, cliente.DiasPago, cliente.TipoDescuento, cliente.RiesgosPermitidos, 
                                    cliente.DatosContables, cliente.DireccionEnvio);
            Response.Redirect("~/Clientes/ListaClientes");
        }



        // GET: /Clientes/BorrarCliente/CIF
        [Authorize]
        public void BorrarCliente(string nif)
        {
            clienteCEN.BorraCliente(nif);
            Response.Redirect("~/Clientes/ListaClientes");

        }




        // GET: /Articulos/EditArticulo
        [Authorize]
        public ActionResult EditCliente(string nif)
        {
            ClienteEN en = clienteCEN.DameClientePorOID(nif);
            return View(en);
        }

        [HttpPost]
        public ActionResult EditCliente(ClienteEN a)
        {
            if(a!=null)
                clienteCEN.ModificaCliente(a.Nif, a.Nombre, a.Direccion, a.Provincia, a.Email, a.DatosBancarios, a.DiasPago,a.TipoDescuento, a.RiesgosPermitidos, a.DatosContables,a.DireccionEnvio);
            
            return RedirectToAction("ListaClientes");
        }





    }
}