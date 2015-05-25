using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using GpiERGenNHibernate.EN.GpiER;
using GpiERGenNHibernate.CEN.GpiER;
using GestionStockGPI.Models;

namespace GestionStockGPI.Controllers
{
    public class CorreoController : Controller
    {

        MailMessage m = new MailMessage();
        SmtpClient smtp = new SmtpClient();



        /*
        [HttpPost]
        public void EnviarCorreo(string from, string password, string mensaje)
        {
            try
            {
                
                MIEMPRESACEN empresaCEN = new MIEMPRESACEN();
                IList<MIEMPRESAEN> empresa = empresaCEN.ReadAll(0, 1);

                m.From = new MailAddress(from);
                m.To.Add(new MailAddress(empresa[0].Correo));
                m.Body = mensaje;
                m.Subject = "Aviso gestor";
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential(from, password);
                smtp.EnableSsl = true;
                smtp.Send(m);
                //return true;
                
                Response.Redirect("~/Home/Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                //return false;
                Response.Redirect("~/Correo/EnviarCorreo");
            }
         }
         * */



        [HttpPost]
        public void EnviarCorreo(CorreoModels correo_model)
        {
           String PathPagina = "../Correo/EnviarCorreo";
            try
            {
                correo_model.enviarMensaje();
                correo_model.Denegados = new List<String>();

                if (correo_model.Denegados!=null && correo_model.Denegados.Count > 0)
                {
                    String m = "No se ha podido enviar el mensaje a:\n";
                    foreach (String mail in correo_model.Denegados)
                    {
                        m += mail + "\n";
                    }
                    Response.Write("<script>alert ('" + m + "');location.href='" + PathPagina + "'</script>");
                    //Response.Write("<script>var x = window.alert('" + m + "') if(x){Response.Redirect(\"~/Cor1eo/EnviarCorreo\")}</script>");
                }
                PathPagina = "../";
                Response.Write("<script>alert ('" + "El mensaje se ha enviado satisfactoriamente" + "');location.href='" + PathPagina + "'</script>");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Response.Write("<script>alert ('" + "No se ha podido enviar el mensaje" + "');location.href='" + PathPagina + "'</script>");
                //Response.Write("<script>var x = window.alert('" + "No se ha podido enviar el mensaje" + "') if(!x){Response.Redirect(\"~/Correo/EnviarCorreo\")}</script>");
            }
        }




        //
        // GET: /Correo/

        public ActionResult Index()
        {
            return View();
        }

        // GET: /Correo/EnviarCorreo
        [Authorize]
        public ActionResult EnviarCorreo()
        {
            ViewData["Clientes"] = generateClientes();
            ViewData["Proveedores"] = generateProveedores();

            return View();
        }




        // Devuelve la lista de proveedores para un DropdownList
        private List<SelectListItem> generateProveedores()
        {
            ProveedorCEN pCEN = new ProveedorCEN();
            var proveedores = (from p in pCEN.DameTodosLosProveedores(0, 100)
                               select new SelectListItem
                               {
                                   Text = p.Nombre + " - " + p.Email,
                                   Value = p.Email.ToString()
                               });
            return proveedores.ToList();
        }


        // Devuelve la lista de clientes para un DropdownList
        private List<SelectListItem> generateClientes()
        {
            ClienteCEN cCEN = new ClienteCEN();
            var proveedores = (from p in cCEN.DameTodosLosClientes(0, 100)
                               select new SelectListItem
                               {
                                   Text = p.Nombre + " - " + p.Email,
                                   Value = p.Email.ToString()
                               });
            return proveedores.ToList();
        }
       

    }
}
