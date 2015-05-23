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


namespace Proveedores
{
    public partial class ListaProveedores : System.Web.Mvc.ViewPage
    {
        ProveedorCEN proveedor = new ProveedorCEN();
        IList<ProveedorEN> listaProveedores = null;
        BuscadorModels buscador = new BuscadorModels();


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
                //if (buscador.comprobarTextoBusqueda(Request.QueryString["TextoBusqueda"]))
                    //listaProveedores = proveedor.ReadFilter(buscador.TextoBusqueda);
                //else
                    listaProveedores = proveedor.DameTodosLosProveedores(0, 100);
            }
            catch (Exception)
            {
                listaProveedores = null;
            }
           
            
            

            gridClientes.DataSource = listaProveedores;
            gridClientes.DataBind();
        }
        

        protected void gridClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
