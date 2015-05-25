using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GpiERGenNHibernate.EN.GpiER;
using GpiERGenNHibernate.CEN.GpiER;

namespace GestionStockGPI.Controllers
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
            if (cliente == null || cliente.Nif == null)
            {
                Response.Redirect("~/Clientes/NewCliente");
                return;
            }
            else
            {
                String[] fechas = cliente.Dias.Split(',');
                IList<DateTime?> dias = new List<DateTime?>();
               
                foreach (String f in fechas)
                {
                    String[] param = f.Split('/');
                    int anyo = Convert.ToInt32(param[2]);
                    int mes = Convert.ToInt32(param[1]);
                    int dia = Convert.ToInt32(param[0]);
                    DateTime d = new DateTime(anyo, mes, dia);
                    dias.Add(d);
                }

                cliente.DiasPago = dias;

                DateTime fechaRegistro = DateTime.Now;
                cliente.FechaAlta = fechaRegistro;
                cliente.FechaUltimaModificacion = fechaRegistro;
                cliente.DatosContables = "0";
                cliente.TipoDescuento = GpiERGenNHibernate.Enumerated.GpiER.TipoDescuentoEnum.OTRO;

                clienteCEN.NuevoCliente(cliente.Nif, cliente.Nombre, cliente.Pais, cliente.Provincia, cliente.Direccion, cliente.Email, cliente.DatosBancarios, cliente.DiasPago, cliente.TipoDescuento, cliente.Descuento, cliente.RiesgosPermitidos, cliente.DatosContables, cliente.DireccionEnvio, cliente.FechaAlta, cliente.FechaUltimaModificacion, cliente.Telefono);
                Response.Redirect("~/Clientes/ListaClientes");
            }
        }



        // GET: /Clientes/BorrarCliente/NIF
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
            if (a != null)
            {
                DateTime fechaRegistro = DateTime.Now;
                a.FechaUltimaModificacion = fechaRegistro;

                clienteCEN.ModificaCliente(a.Nif, a.Nombre, a.Pais, a.Provincia, a.Direccion, a.Email, a.DatosBancarios, a.DiasPago, a.TipoDescuento
                    , a.Descuento, a.RiesgosPermitidos, a.DatosContables, a.DireccionEnvio, a.FechaAlta, a.FechaUltimaModificacion, a.Telefono);

            }
            return RedirectToAction("ListaClientes");
        }





    }
}