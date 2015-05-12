
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
public partial class ProveedorCAD : BasicCAD, IProveedorCAD
{
public ProveedorCAD() : base ()
{
}

public ProveedorCAD(ISession sessionAux) : base (sessionAux)
{
}



public ProveedorEN ReadOIDDefault (string nif)
{
        ProveedorEN proveedorEN = null;

        try
        {
                SessionInitializeTransaction ();
                proveedorEN = (ProveedorEN)session.Get (typeof(ProveedorEN), nif);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GpiERGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new GpiERGenNHibernate.Exceptions.DataLayerException ("Error in ProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return proveedorEN;
}


public string NuevoProveedor (ProveedorEN proveedor)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (proveedor);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GpiERGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new GpiERGenNHibernate.Exceptions.DataLayerException ("Error in ProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return proveedor.Nif;
}

public void ModificaProveedor (ProveedorEN proveedor)
{
        try
        {
                SessionInitializeTransaction ();
                ProveedorEN proveedorEN = (ProveedorEN)session.Load (typeof(ProveedorEN), proveedor.Nif);

                proveedorEN.Nombre = proveedor.Nombre;


                proveedorEN.Direccion = proveedor.Direccion;


                proveedorEN.Descuento = proveedor.Descuento;


                proveedorEN.DiaCobro = proveedor.DiaCobro;


                proveedorEN.Divisa = proveedor.Divisa;


                proveedorEN.DatosBancarios = proveedor.DatosBancarios;

                session.Update (proveedorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GpiERGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new GpiERGenNHibernate.Exceptions.DataLayerException ("Error in ProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorraProveedor (string nif)
{
        try
        {
                SessionInitializeTransaction ();
                ProveedorEN proveedorEN = (ProveedorEN)session.Load (typeof(ProveedorEN), nif);
                session.Delete (proveedorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GpiERGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new GpiERGenNHibernate.Exceptions.DataLayerException ("Error in ProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public ProveedorEN DameProveedorPorOID (string nif)
{
        ProveedorEN proveedorEN = null;

        try
        {
                SessionInitializeTransaction ();
                proveedorEN = (ProveedorEN)session.Get (typeof(ProveedorEN), nif);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GpiERGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new GpiERGenNHibernate.Exceptions.DataLayerException ("Error in ProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return proveedorEN;
}

public System.Collections.Generic.IList<ProveedorEN> DameTodosLosProveedores (int first, int size)
{
        System.Collections.Generic.IList<ProveedorEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ProveedorEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ProveedorEN>();
                else
                        result = session.CreateCriteria (typeof(ProveedorEN)).List<ProveedorEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GpiERGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new GpiERGenNHibernate.Exceptions.DataLayerException ("Error in ProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
