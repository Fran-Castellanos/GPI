
using System;
using System.Text;
using GpiERGenNHibernate.CEN.GpiER;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using GpiERGenNHibernate.EN.GpiER;
using GpiERGenNHibernate.Exceptions;
using System.Collections.Generic;
using System.Threading;

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

                IList<DateTime?> dias = clienteEN.DiasPago;
                clienteEN.DiasPago = dias;
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
            SessionClose();
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
            SessionClose();
                SessionInitializeTransaction ();
                ClienteEN clienteEN = (ClienteEN)session.Load (typeof(ClienteEN), cliente.Nif);

                clienteEN.Nombre = cliente.Nombre;


                clienteEN.Pais = cliente.Pais;


                clienteEN.Provincia = cliente.Provincia;


                clienteEN.Direccion = cliente.Direccion;


                clienteEN.Email = cliente.Email;


                clienteEN.DatosBancarios = cliente.DatosBancarios;


                clienteEN.DiasPago = cliente.DiasPago;


                clienteEN.TipoDescuento = cliente.TipoDescuento;


                clienteEN.Descuento = cliente.Descuento;


                clienteEN.RiesgosPermitidos = cliente.RiesgosPermitidos;


                clienteEN.DatosContables = cliente.DatosContables;


                clienteEN.DireccionEnvio = cliente.DireccionEnvio;


                clienteEN.FechaAlta = cliente.FechaAlta;


                clienteEN.FechaUltimaModificacion = cliente.FechaUltimaModificacion;


                clienteEN.Telefono = cliente.Telefono;

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
            SessionClose();
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
            SessionClose();
                SessionInitializeTransaction ();
                clienteEN = (ClienteEN)session.Get (typeof(ClienteEN), nif);

                SessionCommit ();

                IList<DateTime?> dias = clienteEN.DiasPago;
                clienteEN.DiasPago = dias;
                
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GpiERGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new GpiERGenNHibernate.Exceptions.DataLayerException ("Error in ClienteCAD.", ex);
        }


        finally
        {
            //SessionClose();
        }

        return clienteEN;
}

public System.Collections.Generic.IList<ClienteEN> DameTodosLosClientes (int first, int size)
{
        System.Collections.Generic.IList<ClienteEN> result = null;
        try
        {
            SessionClose();
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

public System.Collections.Generic.IList<GpiERGenNHibernate.EN.GpiER.ClienteEN> ReadFilter (string p_filter)
{
        System.Collections.Generic.IList<GpiERGenNHibernate.EN.GpiER.ClienteEN> result;
        try
        {
            SessionClose();
                SessionInitializeTransaction ();
                //String sql = @"FROM ClienteEN self where FROM ClienteEN c where c.Nif like CONCAT('%',:p_filter,'%') OR c.Nombre like CONCAT('%',:p_filter,'%') OR c.Email like CONCAT('%',:p_filter,'%') OR c.Direccion like CONCAT('%',:p_filter,'%') OR c.DireccionEnvio like CONCAT('%',:p_filter,'%')  OR c.Pais like CONCAT('%',:p_filter,'%') OR c.Provincia like CONCAT('%',:p_filter,'%') OR c.Telefono like CONCAT('%',:p_filter,'%')";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ClienteENreadFilterHQL");
                query.SetParameter ("p_filter", p_filter);

                result = query.List<GpiERGenNHibernate.EN.GpiER.ClienteEN>();
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
