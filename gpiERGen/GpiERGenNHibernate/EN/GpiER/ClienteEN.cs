
using System;

namespace GpiERGenNHibernate.EN.GpiER
{
public partial class ClienteEN
{
/**
 *
 */

private string nombre;

/**
 *
 */

private string nif;

/**
 *
 */

private string direccion;

/**
 *
 */

private string provincia;

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

private string diasPago;

/**
 *
 */

private string tipoDescuento;

/**
 *
 */

private string riesgosPermitidos;

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

private System.Collections.Generic.IList<GpiERGenNHibernate.EN.GpiER.UsuarioEN> usuario;





public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}


public virtual string Nif {
        get { return nif; } set { nif = value;  }
}


public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}


public virtual string Provincia {
        get { return provincia; } set { provincia = value;  }
}


public virtual string Email {
        get { return email; } set { email = value;  }
}


public virtual string DatosBancarios {
        get { return datosBancarios; } set { datosBancarios = value;  }
}


public virtual string DiasPago {
        get { return diasPago; } set { diasPago = value;  }
}


public virtual string TipoDescuento {
        get { return tipoDescuento; } set { tipoDescuento = value;  }
}


public virtual string RiesgosPermitidos {
        get { return riesgosPermitidos; } set { riesgosPermitidos = value;  }
}


public virtual string DatosContables {
        get { return datosContables; } set { datosContables = value;  }
}


public virtual string DireccionEnvio {
        get { return direccionEnvio; } set { direccionEnvio = value;  }
}


public virtual System.Collections.Generic.IList<GpiERGenNHibernate.EN.GpiER.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}





public ClienteEN()
{
        usuario = new System.Collections.Generic.List<GpiERGenNHibernate.EN.GpiER.UsuarioEN>();
}



public ClienteEN(string nif, string nombre, string direccion, string provincia, string email, string datosBancarios, string diasPago, string tipoDescuento, string riesgosPermitidos, string datosContables, string direccionEnvio, System.Collections.Generic.IList<GpiERGenNHibernate.EN.GpiER.UsuarioEN> usuario)
{
        this.init (nif, nombre, direccion, provincia, email, datosBancarios, diasPago, tipoDescuento, riesgosPermitidos, datosContables, direccionEnvio, usuario);
}


public ClienteEN(ClienteEN cliente)
{
        this.init (cliente.Nif, cliente.Nombre, cliente.Direccion, cliente.Provincia, cliente.Email, cliente.DatosBancarios, cliente.DiasPago, cliente.TipoDescuento, cliente.RiesgosPermitidos, cliente.DatosContables, cliente.DireccionEnvio, cliente.Usuario);
}

private void init (string nif, string nombre, string direccion, string provincia, string email, string datosBancarios, string diasPago, string tipoDescuento, string riesgosPermitidos, string datosContables, string direccionEnvio, System.Collections.Generic.IList<GpiERGenNHibernate.EN.GpiER.UsuarioEN> usuario)
{
        this.Nif = nif;


        this.Nombre = nombre;

        this.Direccion = direccion;

        this.Provincia = provincia;

        this.Email = email;

        this.DatosBancarios = datosBancarios;

        this.DiasPago = diasPago;

        this.TipoDescuento = tipoDescuento;

        this.RiesgosPermitidos = riesgosPermitidos;

        this.DatosContables = datosContables;

        this.DireccionEnvio = direccionEnvio;

        this.Usuario = usuario;
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
