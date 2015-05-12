
using System;

namespace GpiERGenNHibernate.EN.GpiER
{
public partial class ProveedorEN
{
/**
 *
 */

private string nombre;

/**
 *
 */

private string direccion;

/**
 *
 */

private string nif;

/**
 *
 */

private int descuento;

/**
 *
 */

private string diaCobro;

/**
 *
 */

private string divisa;

/**
 *
 */

private string datosBancarios;

/**
 *
 */

private System.Collections.Generic.IList<GpiERGenNHibernate.EN.GpiER.UsuarioEN> usuario;





public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}


public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}


public virtual string Nif {
        get { return nif; } set { nif = value;  }
}


public virtual int Descuento {
        get { return descuento; } set { descuento = value;  }
}


public virtual string DiaCobro {
        get { return diaCobro; } set { diaCobro = value;  }
}


public virtual string Divisa {
        get { return divisa; } set { divisa = value;  }
}


public virtual string DatosBancarios {
        get { return datosBancarios; } set { datosBancarios = value;  }
}


public virtual System.Collections.Generic.IList<GpiERGenNHibernate.EN.GpiER.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}





public ProveedorEN()
{
        usuario = new System.Collections.Generic.List<GpiERGenNHibernate.EN.GpiER.UsuarioEN>();
}



public ProveedorEN(string nif, string nombre, string direccion, int descuento, string diaCobro, string divisa, string datosBancarios, System.Collections.Generic.IList<GpiERGenNHibernate.EN.GpiER.UsuarioEN> usuario)
{
        this.init (nif, nombre, direccion, descuento, diaCobro, divisa, datosBancarios, usuario);
}


public ProveedorEN(ProveedorEN proveedor)
{
        this.init (proveedor.Nif, proveedor.Nombre, proveedor.Direccion, proveedor.Descuento, proveedor.DiaCobro, proveedor.Divisa, proveedor.DatosBancarios, proveedor.Usuario);
}

private void init (string nif, string nombre, string direccion, int descuento, string diaCobro, string divisa, string datosBancarios, System.Collections.Generic.IList<GpiERGenNHibernate.EN.GpiER.UsuarioEN> usuario)
{
        this.Nif = nif;


        this.Nombre = nombre;

        this.Direccion = direccion;

        this.Descuento = descuento;

        this.DiaCobro = diaCobro;

        this.Divisa = divisa;

        this.DatosBancarios = datosBancarios;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ProveedorEN t = obj as ProveedorEN;
        if (t == null)
                return false;
        if (Nif.Equals (t.Nif))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Nif.GetHashCode ();
        return hash;
}
}
}
