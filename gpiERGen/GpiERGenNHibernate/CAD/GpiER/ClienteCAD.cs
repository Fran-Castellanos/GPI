
using System;
using System.Text;
using GpiERGenNHibernate.CEN.GpiER;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using GpiERGenNHibernate.EN.GpiER;
using GpiERGenNHibernate.Exceptions;

namespace GpiERGenNHibernate.CAD.GpiER
{
public partial class ClienteCAD : BasicCAD, IClienteCAD
{
public ClienteCAD() : base ()
{
}

public ClienteCAD(ISession sessionAux) : base (sessionAux)
{
}



public ClienteEN ReadOIDDefault (string nif)
{
        ClienteEN clienteEN = null;

        try
        {
                SessionInitializeTransaction ();
                clienteEN = (ClienteEN)session.Get (typeof(ClienteEN), nif);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GpiERGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new GpiERGenNHibernate.Exceptions.DataLayerException ("Error in ClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return clienteEN;
}


public string NuevoCliente (ClienteEN cliente)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (cliente);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GpiERGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new GpiERGenNHibernate.Exceptions.DataLayerException ("Error in ClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cliente.Nif;
}

public void ModificaCliente (ClienteEN cliente)
{
        try
        {
                SessionInitializeTransaction ();
                ClienteEN clienteEN = (ClienteEN)session.Load (typeof(ClienteEN), cliente.Nif);

                clienteEN.Nombre = cliente.Nombre;


                clienteEN.Direccion = cliente.Direccion;


                clienteEN.Provincia = cliente.Provincia;


                clienteEN.Email = cliente.Email;


                clienteEN.DatosBancarios = cliente.DatosBancarios;


                clienteEN.DiasPago = cliente.DiasPago;


                clienteEN.TipoDescuento = cliente.TipoDescuento;


                clienteEN.RiesgosPermitidos = cliente.RiesgosPermitidos;


                clienteEN.DatosContables = cliente.DatosContables;


                clienteEN.DireccionEnvio = cliente.DireccionEnvio;

                session.Update (clienteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GpiERGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new GpiERGenNHibernate.Exceptions.DataLayerException ("Error in ClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorraCliente (string nif)
{
        try
        {
                SessionInitializeTransaction ();
                ClienteEN clienteEN = (ClienteEN)session.Load (typeof(ClienteEN), nif);
                session.Delete (clienteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GpiERGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new GpiERGenNHibernate.Exceptions.DataLayerException ("Error in ClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public ClienteEN DameClientePorOID (string nif)
{
        ClienteEN clienteEN = null;

        try
        {
                SessionInitializeTransaction ();
                clienteEN = (ClienteEN)session.Get (typeof(ClienteEN), nif);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GpiERGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new GpiERGenNHibernate.Exceptions.DataLayerException ("Error in ClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return clienteEN;
}

public System.Collections.Generic.IList<ClienteEN> DameTodosLosClientes (int first, int size)
{
        System.Collections.Generic.IList<ClienteEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ClienteEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ClienteEN>();
                else
                        result = session.CreateCriteria (typeof(ClienteEN)).List<ClienteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GpiERGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new GpiERGenNHibernate.Exceptions.DataLayerException ("Error in ClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
