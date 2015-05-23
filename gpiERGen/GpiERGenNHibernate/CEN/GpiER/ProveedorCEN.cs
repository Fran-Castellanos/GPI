

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using GpiERGenNHibernate.EN.GpiER;
using GpiERGenNHibernate.CAD.GpiER;

namespace GpiERGenNHibernate.CEN.GpiER
{
public partial class ProveedorCEN
{
private IProveedorCAD _IProveedorCAD;

public ProveedorCEN()
{
        this._IProveedorCAD = new ProveedorCAD ();
}

public ProveedorCEN(IProveedorCAD _IProveedorCAD)
{
        this._IProveedorCAD = _IProveedorCAD;
}

public IProveedorCAD get_IProveedorCAD ()
{
        return this._IProveedorCAD;
}

public string NuevoProveedor (string p_nif, string p_nombre, string p_pais, string p_provincia, string p_direccion, string p_email, GpiERGenNHibernate.Enumerated.GpiER.DivisaEnum p_divisa, string p_datosBancarios, double p_descuento, System.Collections.Generic.IList<Nullable<DateTime> > p_diasCobro, Nullable<DateTime> p_fechaAlta, Nullable<DateTime> p_fechaUltimaModificacion, string p_telefono)
{
        ProveedorEN proveedorEN = null;
        string oid;

        //Initialized ProveedorEN
        proveedorEN = new ProveedorEN ();
        proveedorEN.Nif = p_nif;

        proveedorEN.Nombre = p_nombre;

        proveedorEN.Pais = p_pais;

        proveedorEN.Provincia = p_provincia;

        proveedorEN.Direccion = p_direccion;

        proveedorEN.Email = p_email;

        proveedorEN.Divisa = p_divisa;

        proveedorEN.DatosBancarios = p_datosBancarios;

        proveedorEN.Descuento = p_descuento;

        proveedorEN.DiasCobro = p_diasCobro;

        proveedorEN.FechaAlta = p_fechaAlta;

        proveedorEN.FechaUltimaModificacion = p_fechaUltimaModificacion;

        proveedorEN.Telefono = p_telefono;

        //Call to ProveedorCAD

        oid = _IProveedorCAD.NuevoProveedor (proveedorEN);
        return oid;
}

public void ModificaProveedor (string p_Proveedor_OID, string p_nombre, string p_pais, string p_provincia, string p_direccion, string p_email, GpiERGenNHibernate.Enumerated.GpiER.DivisaEnum p_divisa, string p_datosBancarios, double p_descuento, System.Collections.Generic.IList<Nullable<DateTime> > p_diasCobro, Nullable<DateTime> p_fechaAlta, Nullable<DateTime> p_fechaUltimaModificacion, string p_telefono)
{
        ProveedorEN proveedorEN = null;

        //Initialized ProveedorEN
        proveedorEN = new ProveedorEN ();
        proveedorEN.Nif = p_Proveedor_OID;
        proveedorEN.Nombre = p_nombre;
        proveedorEN.Pais = p_pais;
        proveedorEN.Provincia = p_provincia;
        proveedorEN.Direccion = p_direccion;
        proveedorEN.Email = p_email;
        proveedorEN.Divisa = p_divisa;
        proveedorEN.DatosBancarios = p_datosBancarios;
        proveedorEN.Descuento = p_descuento;
        proveedorEN.DiasCobro = p_diasCobro;
        proveedorEN.FechaAlta = p_fechaAlta;
        proveedorEN.FechaUltimaModificacion = p_fechaUltimaModificacion;
        proveedorEN.Telefono = p_telefono;
        //Call to ProveedorCAD

        _IProveedorCAD.ModificaProveedor (proveedorEN);
}

public void BorraProveedor (string nif)
{
        _IProveedorCAD.BorraProveedor (nif);
}

public ProveedorEN DameProveedorPorOID (string nif)
{
        ProveedorEN proveedorEN = null;

        proveedorEN = _IProveedorCAD.DameProveedorPorOID (nif);
        return proveedorEN;
}

public System.Collections.Generic.IList<ProveedorEN> DameTodosLosProveedores (int first, int size)
{
        System.Collections.Generic.IList<ProveedorEN> list = null;

        list = _IProveedorCAD.DameTodosLosProveedores (first, size);
        return list;
}
public System.Collections.Generic.IList<GpiERGenNHibernate.EN.GpiER.ProveedorEN> ReadFilter (string p_filter)
{
        return _IProveedorCAD.ReadFilter (p_filter);
}
}
}
