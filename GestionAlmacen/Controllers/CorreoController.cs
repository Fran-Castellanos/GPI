using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using GpiERGenNHibernate.EN.GpiER;
using GpiERGenNHibernate.CEN.GpiER;

namespace StockManager.Controllers
{
    public class CorreoController : Controller
    {

        MailMessage m = new MailMessage();
        SmtpClient smtp = new SmtpClient();

        [HttpPost]
        public void EnviarCorreo(string from, string password, string mensaje)
        {
            try
            {
                /*
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
                 * */
                Response.Redirect("~/Home/Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                //return false;
                Response.Redirect("~/Correo/EnviarCorreo");
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
            return View();
        }

       

    }
}
