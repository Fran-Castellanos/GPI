using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionStockGPI.Models
{
    public partial class BuscadorModels : System.Web.UI.MasterPage
    {
        private string textobusqueda;



        public virtual string TextoBusqueda
        {
            get { return textobusqueda; }
            set { textobusqueda = value; }
        }




        public bool comprobarTextoBusqueda(string parametro)
        {
            TextoBusqueda = parametro;
            

            if (TextoBusqueda != null && TextoBusqueda.Length > 0)
                return true;

            return false;


        }



    }
}