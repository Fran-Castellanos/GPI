
using System;

namespace GpiERGenNHibernate.EN.GpiER
{
public partial class ClienteEN
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

private string datosBancarios;

/**
 *
 */

private System.Collections.Generic.IList<Nullable<DateTime> > diasPago;

/**
 *
 */

private GpiERGenNHibernate.Enumerated.GpiER.TipoDescuentoEnum tipoDescuento;

/**
 *
 */

private double descuento;

/**
 *
 */

private double riesgosPermitidos;

/**
 *
 */

private System.Collections.Generic.IList<GpiERGenNHibernate.EN.GpiER.UsuarioEN> usuario;

/**
 *
 */

private string datosContables;

/**
 *
 */

private string direccionEnvio;

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


public virtual string DatosBancarios {
        get { return datosBancarios; } set { datosBancarios = value;  }
}


public virtual System.Collections.Generic.IList<Nullable<DateTime> > DiasPago {
        get { return diasPago; } set { diasPago = value;  }
}


public virtual GpiERGenNHibernate.Enumerated.GpiER.TipoDescuentoEnum TipoDescuento {
        get { return tipoDescuento; } set { tipoDescuento = value;  }
}


public virtual double Descuento {
        get { return descuento; } set { descuento = value;  }
}


public virtual double RiesgosPermitidos {
        get { return riesgosPermitidos; } set { riesgosPermitidos = value;  }
}


public virtual System.Collections.Generic.IList<GpiERGenNHibernate.EN.GpiER.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}


public virtual string DatosContables {
        get { return datosContables; } set { datosContables = value;  }
}


public virtual string DireccionEnvio {
        get { return direccionEnvio; } set { direccionEnvio = value;  }
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





public ClienteEN()
{
        usuario = new System.Collections.Generic.List<GpiERGenNHibernate.EN.GpiER.UsuarioEN>();
}



public ClienteEN(string nif, string nombre, string pais, string provincia, string direccion, string email, string datosBancarios, System.Collections.Generic.IList<Nullable<DateTime> > diasPago, GpiERGenNHibernate.Enumerated.GpiER.TipoDescuentoEnum tipoDescuento, double descuento, double riesgosPermitidos, System.Collections.Generic.IList<GpiERGenNHibernate.EN.GpiER.UsuarioEN> usuario, string datosContables, string direccionEnvio, Nullable<DateTime> fechaAlta, Nullable<DateTime> fechaUltimaModificacion, string telefono)
{
        this.init (nif, nombre, pais, provincia, direccion, email, datosBancarios, diasPago, tipoDescuento, descuento, riesgosPermitidos, usuario, datosContables, direccionEnvio, fechaAlta, fechaUltimaModificacion, telefono);
}


public ClienteEN(ClienteEN cliente)
{
        this.init (cliente.Nif, cliente.Nombre, cliente.Pais, cliente.Provincia, cliente.Direccion, cliente.Email, cliente.DatosBancarios, cliente.DiasPago, cliente.TipoDescuento, cliente.Descuento, cliente.RiesgosPermitidos, cliente.Usuario, cliente.DatosContables, cliente.DireccionEnvio, cliente.FechaAlta, cliente.FechaUltimaModificacion, cliente.Telefono);
}

private void init (string nif, string nombre, string pais, string provincia, string direccion, string email, string datosBancarios, System.Collections.Generic.IList<Nullable<DateTime> > diasPago, GpiERGenNHibernate.Enumerated.GpiER.TipoDescuentoEnum tipoDescuento, double descuento, double riesgosPermitidos, System.Collections.Generic.IList<GpiERGenNHibernate.EN.GpiER.UsuarioEN> usuario, string datosContables, string direccionEnvio, Nullable<DateTime> fechaAlta, Nullable<DateTime> fechaUltimaModificacion, string telefono)
{
        this.Nif = nif;


        this.Nombre = nombre;

        this.Pais = pais;

        this.Provincia = provincia;

        this.Direccion = direccion;

        this.Email = email;

        this.DatosBancarios = datosBancarios;

        this.DiasPago = diasPago;

        this.TipoDescuento = tipoDescuento;

        this.Descuento = descuento;

        this.RiesgosPermitidos = riesgosPermitidos;

        this.Usuario = usuario;

        this.DatosContables = datosContables;

        this.DireccionEnvio = direccionEnvio;

        this.FechaAlta = fechaAlta;

        this.FechaUltimaModificacion = fechaUltimaModificacion;

        this.Telefono = telefono;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ClienteEN t = obj as ClienteEN;
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
