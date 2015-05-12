

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
public partial class UsuarioCEN
{
private IUsuarioCAD _IUsuarioCAD;

public UsuarioCEN()
{
        this._IUsuarioCAD = new UsuarioCAD ();
}

public UsuarioCEN(IUsuarioCAD _IUsuarioCAD)
{
        this._IUsuarioCAD = _IUsuarioCAD;
}

public IUsuarioCAD get_IUsuarioCAD ()
{
        return this._IUsuarioCAD;
}

public string NuevoUsuario (string p_email, string p_nick, string p_password)
{
        UsuarioEN usuarioEN = null;
        string oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Email = p_email;

        usuarioEN.Nick = p_nick;

        usuarioEN.Password = p_password;

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.NuevoUsuario (usuarioEN);
        return oid;
}

public void ModificaUsuario (string p_Usuario_OID, string p_nick, string p_password)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Email = p_Usuario_OID;
        usuarioEN.Nick = p_nick;
        usuarioEN.Password = p_password;
        //Call to UsuarioCAD

        _IUsuarioCAD.ModificaUsuario (usuarioEN);
}

public void BorraUsuario (string email)
{
        _IUsuarioCAD.BorraUsuario (email);
}

public UsuarioEN DameUsuarioPorOID (string email)
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioCAD.DameUsuarioPorOID (email);
        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> DameTodosLosUsuarios (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> list = null;

        list = _IUsuarioCAD.DameTodosLosUsuarios (first, size);
        return list;
}
}
}
