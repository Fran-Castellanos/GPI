using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StockManager.Models
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
    }
}