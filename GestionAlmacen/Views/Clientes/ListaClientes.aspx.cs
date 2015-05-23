using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using GpiERGenNHibernate.CEN.GpiER;
using GpiERGenNHibernate.EN.GpiER;
using StockManager.Models;


namespace Clientes
{
    public partial class ListaClientes : System.Web.Mvc.ViewPage
    {
        ClienteCEN cliente = new ClienteCEN();
        IList<ClienteEN> listaClientes = null;
        BuscadorModels buscador = new BuscadorModels();

        private string cif;

        public virtual string CIF
        {
            get { return cif; }
            set { cif = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                reload(sender,e);
            }
        }


        private void reload(object sender, EventArgs e)
        {
            try
            {
                if (buscador.comprobarTextoBusqueda(Request.QueryString["TextoBusqueda"]))
                    listaClientes = cliente.ReadFilter(buscador.TextoBusqueda);
                else
                    listaClientes = cliente.DameTodosLosClientes(0, 100);
            }
            catch (Exception)
            {
                listaClientes = null;
            }
           
            
            

            gridClientes.DataSource = listaClientes;
            gridClientes.DataBind();
        }
        

        protected void gridClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
