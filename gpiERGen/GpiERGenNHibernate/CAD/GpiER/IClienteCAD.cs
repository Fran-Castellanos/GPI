
using System;
using GpiERGenNHibernate.EN.GpiER;

namespace GpiERGenNHibernate.CAD.GpiER
{
public partial interface IClienteCAD
{
ClienteEN ReadOIDDefault (string nif);

string NuevoCliente (ClienteEN cliente);

void ModificaCliente (ClienteEN cliente);


void BorraCliente (string nif);


ClienteEN DameClientePorOID (string nif);


System.Collections.Generic.IList<ClienteEN> DameTodosLosClientes (int first, int size);
}
}
