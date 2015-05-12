

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

public string NuevoProveedor (string p_nombre, string p_direccion, string p_nif, int p_descuento, string p_diaCobro, string p_divisa, string p_datosBancarios)
{
        ProveedorEN proveedorEN = null;
        string oid;

        //Initialized ProveedorEN
        proveedorEN = new ProveedorEN ();
        proveedorEN.Nombre = p_nombre;

        proveedorEN.Direccion = p_direccion;

        proveedorEN.Nif = p_nif;

        proveedorEN.Descuento = p_descuento;

        proveedorEN.DiaCobro = p_diaCobro;

        proveedorEN.Divisa = p_divisa;

        proveedorEN.DatosBancarios = p_datosBancarios;

        //Call to ProveedorCAD

        oid = _IProveedorCAD.NuevoProveedor (proveedorEN);
        return oid;
}

public void ModificaProveedor (string p_Proveedor_OID, string p_nombre, string p_direccion, int p_descuento, string p_diaCobro, string p_divisa, string p_datosBancarios)
{
        ProveedorEN proveedorEN = null;

        //Initialized ProveedorEN
        proveedorEN = new ProveedorEN ();
        proveedorEN.Nif = p_Proveedor_OID;
        proveedorEN.Nombre = p_nombre;
        proveedorEN.Direccion = p_direccion;
        proveedorEN.Descuento = p_descuento;
        proveedorEN.DiaCobro = p_diaCobro;
        proveedorEN.Divisa = p_divisa;
        proveedorEN.DatosBancarios = p_datosBancarios;
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
}
}
