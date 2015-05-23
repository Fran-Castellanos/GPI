
using System;
using GpiERGenNHibernate.EN.GpiER;

namespace GpiERGenNHibernate.CAD.GpiER
{
public partial interface IProveedorCAD
{
ProveedorEN ReadOIDDefault (string nif);

string NuevoProveedor (ProveedorEN proveedor);

void ModificaProveedor (ProveedorEN proveedor);


void BorraProveedor (string nif);


ProveedorEN DameProveedorPorOID (string nif);


System.Collections.Generic.IList<ProveedorEN> DameTodosLosProveedores (int first, int size);


System.Collections.Generic.IList<GpiERGenNHibernate.EN.GpiER.ProveedorEN> ReadFilter (string p_filter);
}
}
