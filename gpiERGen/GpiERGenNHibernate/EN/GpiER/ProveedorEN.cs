
using System;
using GpiERGenNHibernate.Enumerated.GpiER;

namespace GpiERGenNHibernate.EN.GpiER
{
public partial class ProveedorEN
{
/**
 *
 */

private string nif;

/**
 *
 */

private string nombre;

/**
 *
 */

private string pais;

private string dias;

/**
 *
 */

private string provincia;

/**
 *
 */

private string direccion;

/**
 *
 */

private string email;

/**
 *
 */

private GpiERGenNHibernate.Enumerated.GpiER.DivisaEnum divisa;

/**
 *
 */

private System.Collections.Generic.IList<GpiERGenNHibernate.EN.GpiER.UsuarioEN> usuario;

/**
 *
 */

private string datosBancarios;

/**
 *
 */

private double descuento;

/**
 *
 */

private System.Collections.Generic.IList<Nullable<DateTime> > diasCobro;

/**
 *
 */

private Nullable<DateTime> fechaAlta;

/**
 *
 */

private Nullable<DateTime> fechaUltimaModificacion;

/**
 *
 */

private string telefono;


private PaisEnum paisEnum;

public virtual string Dias {
    get { return dias; }
    set { dias = value; }
}



public virtual PaisEnum PaisEnum
{
    get { return paisEnum; }
    set { paisEnum = value; }
}
public virtual string Nif {
        get { return nif; } set { nif = value;  }
}


public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}


public virtual string Pais {
        get { return pais; } set { pais = value;  }
}


public virtual string Provincia {
        get { return provincia; } set { provincia = value;  }
}


public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}


public virtual string Email {
        get { return email; } set { email = value;  }
}


public virtual GpiERGenNHibernate.Enumerated.GpiER.DivisaEnum Divisa {
        get { return divisa; } set { divisa = value;  }
}


public virtual System.Collections.Generic.IList<GpiERGenNHibernate.EN.GpiER.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}


public virtual string DatosBancarios {
        get { return datosBancarios; } set { datosBancarios = value;  }
}


public virtual double Descuento {
        get { return descuento; } set { descuento = value;  }
}


public virtual System.Collections.Generic.IList<Nullable<DateTime> > DiasCobro {
        get { return diasCobro; } set { diasCobro = value;  }
}


public virtual Nullable<DateTime> FechaAlta {
        get { return fechaAlta; } set { fechaAlta = value;  }
}


public virtual Nullable<DateTime> FechaUltimaModificacion {
        get { return fechaUltimaModificacion; } set { fechaUltimaModificacion = value;  }
}


public virtual string Telefono {
        get { return telefono; } set { telefono = value;  }
}





public ProveedorEN()
{
        usuario = new System.Collections.Generic.List<GpiERGenNHibernate.EN.GpiER.UsuarioEN>();
}



public ProveedorEN(string nif, string nombre, string pais, string provincia, string direccion, string email, GpiERGenNHibernate.Enumerated.GpiER.DivisaEnum divisa, System.Collections.Generic.IList<GpiERGenNHibernate.EN.GpiER.UsuarioEN> usuario, string datosBancarios, double descuento, System.Collections.Generic.IList<Nullable<DateTime> > diasCobro, Nullable<DateTime> fechaAlta, Nullable<DateTime> fechaUltimaModificacion, string telefono)
{
        this.init (nif, nombre, pais, provincia, direccion, email, divisa, usuario, datosBancarios, descuento, diasCobro, fechaAlta, fechaUltimaModificacion, telefono);
}


public ProveedorEN(ProveedorEN proveedor)
{
        this.init (proveedor.Nif, proveedor.Nombre, proveedor.Pais, proveedor.Provincia, proveedor.Direccion, proveedor.Email, proveedor.Divisa, proveedor.Usuario, proveedor.DatosBancarios, proveedor.Descuento, proveedor.DiasCobro, proveedor.FechaAlta, proveedor.FechaUltimaModificacion, proveedor.Telefono);
}

private void init (string nif, string nombre, string pais, string provincia, string direccion, string email, GpiERGenNHibernate.Enumerated.GpiER.DivisaEnum divisa, System.Collections.Generic.IList<GpiERGenNHibernate.EN.GpiER.UsuarioEN> usuario, string datosBancarios, double descuento, System.Collections.Generic.IList<Nullable<DateTime> > diasCobro, Nullable<DateTime> fechaAlta, Nullable<DateTime> fechaUltimaModificacion, string telefono)
{
        this.Nif = nif;


        this.Nombre = nombre;

        this.Pais = pais;

        this.Provincia = provincia;

        this.Direccion = direccion;

        this.Email = email;

        this.Divisa = divisa;

        this.Usuario = usuario;

        this.DatosBancarios = datosBancarios;

        this.Descuento = descuento;

        this.DiasCobro = diasCobro;

        this.FechaAlta = fechaAlta;

        this.FechaUltimaModificacion = fechaUltimaModificacion;

        this.Telefono = telefono;
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
