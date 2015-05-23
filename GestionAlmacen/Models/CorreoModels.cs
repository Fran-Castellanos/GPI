using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Net.Mail;
using System.Net;
using System.Web.UI;


namespace GestionStockGPI.Models
{
    public class CorreoModels
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Desde")]
        public string From { get; set; }

        [Required]
        [ValidatePasswordLength]
        [DataType(DataType.Password)]
        [DisplayName("Contraseña")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Mensaje")]
        public string Mensaje { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Clientes")]
        public IList<String> Clientes { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Proveedores")]
        public IList<String> Proveedores { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Asunto")]
        public string Asunto { get; set; }


        public IList<String> Denegados { get; set; }


        internal void enviarMensaje()
        {
            foreach (String mail in Clientes)
            {
                enviarUnMensaje(mail);
            }

            foreach (String mail in Proveedores)
            {
                enviarUnMensaje(mail);
            }

            

        }

        private void enviarUnMensaje(string mail)
        {
            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(mail));
            email.From = new MailAddress(From);
            email.Subject = Asunto + " (" + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + ")";
            email.Body = Mensaje;
            email.IsBodyHtml = false;
            email.Priority = MailPriority.Normal;
            
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 25;
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(From, Password);

            try{
                 smtp.Send(email);
                 email.Dispose();

                 
            }
            catch (Exception ex)
            {
                Denegados.Add(mail);
            }

            
               

        }

       
        

    }


}