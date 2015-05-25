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
            ViewData["Divisas"] = generateDivisas();
            ViewData["Paises"] = generatePaises();

            return View();
        }



        private List<SelectListItem> generateDivisas()
        {
            IEnumerable<DivisaEnum> values = Enum.GetValues(typeof(DivisaEnum))
            .Cast<DivisaEnum>();

            IEnumerable<SelectListItem> items =
                from value in values
                select new SelectListItem
                {
                    Text = value.ToString(),
                    Value = value.ToString(),
                    
                };

            return items.ToList();
        }


        private object generatePaises()
        {
            IEnumerable<PaisEnum> values = Enum.GetValues(typeof(PaisEnum))
           .Cast<PaisEnum>();

            IEnumerable<SelectListItem> items =
                from value in values
                select new SelectListItem
                {
                    Text = (value.ToString()).Replace("_", " "),
                    Value = value.ToString(),

                };

            return items.ToList();
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
                proveedor.Pais = proveedor.PaisEnum.ToString().Replace("_", " ");
                String[] fechas = proveedor.Dias.Split(',');
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

                proveedor.DiasCobro = dias;


                DateTime fechaRegistro = DateTime.Now;
                proveedor.FechaAlta = fechaRegistro;
                proveedor.FechaUltimaModificacion = fechaRegistro;
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




        private void convertirPais2Enum(ProveedorEN en)
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




        // GET: /Proveedores/EditProveedor
        [Authorize]
        public ActionResult EditProveedor(string nif)
        {
            ViewData["Paises"] = generatePaises();
            ViewData["Divisas"] = generateDivisas();
            ProveedorEN en = proCEN.DameProveedorPorOID(nif);
            convertirPais2Enum(en);
            en.Dias = "";
            int L = 0;
            int i = 0;
            try
            {
                if (en.DiasCobro != null)
                {
                    IList<DateTime?> dias = en.DiasCobro;
                    L = dias.Count;
                    foreach (DateTime d in en.DiasCobro)
                    {
                        if (i != 0)
                            en.Dias += ",";

                        string dia = "";
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



        [HttpPost]
        public ActionResult EditProveedor(ProveedorEN a)
        {
            if (a != null)
            {
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

                a.DiasCobro = dias;

                DateTime fechaRegistro = DateTime.Now;
                a.FechaUltimaModificacion = fechaRegistro;

                ProveedorEN c = proCEN.DameProveedorPorOID(a.Nif);
                a.FechaAlta = c.FechaAlta;

                a.Pais = a.PaisEnum.ToString().Replace("_", " ");

                proCEN.ModificaProveedor(a.Nif, a.Nombre, a.Pais, a.Provincia, a.Direccion, a.Email, a.Divisa, a.DatosBancarios, a.Descuento, a.DiasCobro, a.FechaAlta, a.FechaUltimaModificacion, a.Telefono);

            }
            return RedirectToAction("ListaProveedores");
        }




    }
}
