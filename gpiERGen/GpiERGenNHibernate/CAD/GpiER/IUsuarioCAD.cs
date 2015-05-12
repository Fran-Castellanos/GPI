
using System;
using GpiERGenNHibernate.EN.GpiER;

namespace GpiERGenNHibernate.CAD.GpiER
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (string email);

string NuevoUsuario (UsuarioEN usuario);

void ModificaUsuario (UsuarioEN usuario);


void BorraUsuario (string email);


UsuarioEN DameUsuarioPorOID (string email);


System.Collections.Generic.IList<UsuarioEN> DameTodosLosUsuarios (int first, int size);
}
}
