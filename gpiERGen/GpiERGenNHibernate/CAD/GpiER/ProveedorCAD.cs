
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
            SessionClose();
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
            SessionClose();
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
            SessionClose();
                SessionInitializeTransaction ();
                ProveedorEN proveedorEN = (ProveedorEN)session.Load (typeof(ProveedorEN), proveedor.Nif);

                proveedorEN.Nombre = proveedor.Nombre;


                proveedorEN.Pais = proveedor.Pais;


                proveedorEN.Provincia = proveedor.Provincia;


                proveedorEN.Direccion = proveedor.Direccion;


                proveedorEN.Email = proveedor.Email;


                proveedorEN.Divisa = proveedor.Divisa;


                proveedorEN.DatosBancarios = proveedor.DatosBancarios;


                proveedorEN.Descuento = proveedor.Descuento;


                proveedorEN.DiasCobro = proveedor.DiasCobro;


                proveedorEN.FechaAlta = proveedor.FechaAlta;


                proveedorEN.FechaUltimaModificacion = proveedor.FechaUltimaModificacion;


                proveedorEN.Telefono = proveedor.Telefono;

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
            SessionClose();
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
            SessionClose();
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
                //SessionClose ();
        }

        return proveedorEN;
}

public System.Collections.Generic.IList<ProveedorEN> DameTodosLosProveedores (int first, int size)
{
        System.Collections.Generic.IList<ProveedorEN> result = null;
        try
        {
            SessionClose();
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

public System.Collections.Generic.IList<GpiERGenNHibernate.EN.GpiER.ProveedorEN> ReadFilter (string p_filter)
{
        System.Collections.Generic.IList<GpiERGenNHibernate.EN.GpiER.ProveedorEN> result;
        try
        {
            SessionClose();
                SessionInitializeTransaction ();
                //String sql = @"FROM ProveedorEN self where FROM ProveedorEN c where c.Nif like CONCAT('%',:p_filter,'%') OR c.Nombre like CONCAT('%',:p_filter,'%') OR c.Email like CONCAT('%',:p_filter,'%') OR c.Direccion like CONCAT('%',:p_filter,'%') OR c.Divisa like CONCAT('%',:p_filter,'%') OR c.Pais like CONCAT('%',:p_filter,'%') OR c.Provincia like CONCAT('%',:p_filter,'%') OR c.Telefono like CONCAT('%',:p_filter,'%')";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProveedorENreadFilterHQL");
                query.SetParameter ("p_filter", p_filter);

                result = query.List<GpiERGenNHibernate.EN.GpiER.ProveedorEN>();
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
