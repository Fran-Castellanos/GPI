using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GpiERGenNHibernate.EN.GpiER;
using GpiERGenNHibernate.CEN.GpiER;
using GpiERGenNHibernate.Enumerated.GpiER;

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
            ViewData["Paises"] = generatePaises();

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

                cliente.Pais = cliente.PaisEnum.ToString().Replace("_"," ");
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

                try
                {
                    clienteCEN.NuevoCliente(cliente.Nif, cliente.Nombre, cliente.Pais, cliente.Provincia, cliente.Direccion, cliente.Email, cliente.DatosBancarios, cliente.DiasPago, cliente.TipoDescuento, cliente.Descuento, cliente.RiesgosPermitidos, cliente.DatosContables, cliente.DireccionEnvio, cliente.FechaAlta, cliente.FechaUltimaModificacion, cliente.Telefono);
                }
                catch (Exception e)
                {
                    String PathPagina = "../Proveedores/ListaProveedores";
                    Response.Write("<script>alert ('" + "No se ha podido registrar el proveedor. Ese NIF ya existe en la BD." + "');location.href='" + PathPagina + "'</script>");
                    return;
                }
                    
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




        private void convertirPais2Enum(ClienteEN en)
        {
            IEnumerable<PaisEnum> values = Enum.GetValues(typeof(PaisEnum))
            .Cast<PaisEnum>();

            IEnumerable<SelectListItem> items =
                from value in values
                select new SelectListItem
                {
                    Text = value.ToString().Replace("_", " "),
                    Value = value.ToString(),

                };

            foreach (SelectListItem s in items)
            {
                if (s.Text == en.Pais)
                {
                    PaisEnum p;
                    Enum.TryParse(s.Value, out p);
                    en.PaisEnum = p;
                    return;
                    
                }
            }

            return;
        }




        // GET: /Articulos/EditArticulo
        [Authorize]
        public ActionResult EditCliente(string nif)
        {
            ViewData["Paises"] = generatePaises();
            ClienteEN en = clienteCEN.DameClientePorOID(nif);

            convertirPais2Enum(en);

            en.Dias = "";
            int L = 0;
            int i = 0;
            try
            {
                if (en.DiasPago != null)
                {
                    IList<DateTime?> dias = en.DiasPago;
                    

                    L = dias.Count;
                    foreach (DateTime d in en.DiasPago)
                    {
                        if (i != 0)
                            en.Dias += ",";

                        string dia="";
                        string mes = "";
                        string anyo = "";

                        if (d.Day < 10)
                        {
                            dia = "0";
                        }
                        dia += d.Day;

                        if (d.Month < 10)
                        {
                            mes = "0";
                        }
                        mes += d.Month;

                        if (d.Year < 10)
                        {
                            anyo = "0";
                        }
                        anyo += d.Year;


                        en.Dias += dia + "/" + mes + "/" + anyo;
                        ++i;
                    }
                }
                else
                {

                }

            }
            catch (Exception e)
            {
            }

            


            return View(en);
        }



        private object generatePaises()
        {
            IEnumerable<PaisEnum> values = Enum.GetValues(typeof(PaisEnum))
           .Cast<PaisEnum>();

            IEnumerable<SelectListItem> items =
                from value in values
                select new SelectListItem
                {
                    Text = (value.ToString()).Replace("_"," "),
                    Value = value.ToString(),

                };

            return items.ToList();
        }





        [HttpPost]
        public ActionResult EditCliente(ClienteEN a)
        {
            if (a != null)
            {
                a.Pais = a.PaisEnum.ToString().Replace("_", " ");
                String[] fechas = a.Dias.Split(',');
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

                a.DiasPago = dias;

                DateTime fechaRegistro = DateTime.Now;
                a.FechaUltimaModificacion = fechaRegistro;

                ClienteEN c = clienteCEN.DameClientePorOID(a.Nif);


                a.DatosContables = c.DatosContables;
                a.FechaAlta = c.FechaAlta;
                clienteCEN.ModificaCliente(a.Nif, a.Nombre, a.Pais, a.Provincia, a.Direccion, a.Email, a.DatosBancarios, a.DiasPago, a.TipoDescuento
                    , a.Descuento, a.RiesgosPermitidos, a.DatosContables, a.DireccionEnvio, a.FechaAlta, a.FechaUltimaModificacion, a.Telefono);

            }
            return RedirectToAction("ListaClientes");
        }





    }
}