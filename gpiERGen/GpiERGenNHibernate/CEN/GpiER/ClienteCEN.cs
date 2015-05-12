

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
public partial class ClienteCEN
{
private IClienteCAD _IClienteCAD;

public ClienteCEN()
{
        this._IClienteCAD = new ClienteCAD ();
}

public ClienteCEN(IClienteCAD _IClienteCAD)
{
        this._IClienteCAD = _IClienteCAD;
}

public IClienteCAD get_IClienteCAD ()
{
        return this._IClienteCAD;
}

public string NuevoCliente (string p_nombre, string p_nif, string p_direccion, string p_provincia, string p_email, string p_datosBancarios, string p_diasPago, string p_tipoDescuento, string p_riesgosPermitidos, string p_datosContables, string p_direccionEnvio)
{
        ClienteEN clienteEN = null;
        string oid;

        //Initialized ClienteEN
        clienteEN = new ClienteEN ();
        clienteEN.Nombre = p_nombre;

        clienteEN.Nif = p_nif;

        clienteEN.Direccion = p_direccion;

        clienteEN.Provincia = p_provincia;

        clienteEN.Email = p_email;

        clienteEN.DatosBancarios = p_datosBancarios;

        clienteEN.DiasPago = p_diasPago;

        clienteEN.TipoDescuento = p_tipoDescuento;

        clienteEN.RiesgosPermitidos = p_riesgosPermitidos;

        clienteEN.DatosContables = p_datosContables;

        clienteEN.DireccionEnvio = p_direccionEnvio;

        //Call to ClienteCAD

        oid = _IClienteCAD.NuevoCliente (clienteEN);
        return oid;
}

public void ModificaCliente (string p_Cliente_OID, string p_nombre, string p_direccion, string p_provincia, string p_email, string p_datosBancarios, string p_diasPago, string p_tipoDescuento, string p_riesgosPermitidos, string p_datosContables, string p_direccionEnvio)
{
        ClienteEN clienteEN = null;

        //Initialized ClienteEN
        clienteEN = new ClienteEN ();
        clienteEN.Nif = p_Cliente_OID;
        clienteEN.Nombre = p_nombre;
        clienteEN.Direccion = p_direccion;
        clienteEN.Provincia = p_provincia;
        clienteEN.Email = p_email;
        clienteEN.DatosBancarios = p_datosBancarios;
        clienteEN.DiasPago = p_diasPago;
        clienteEN.TipoDescuento = p_tipoDescuento;
        clienteEN.RiesgosPermitidos = p_riesgosPermitidos;
        clienteEN.DatosContables = p_datosContables;
        clienteEN.DireccionEnvio = p_direccionEnvio;
        //Call to ClienteCAD

        _IClienteCAD.ModificaCliente (clienteEN);
}

public void BorraCliente (string nif)
{
        _IClienteCAD.BorraCliente (nif);
}

public ClienteEN DameClientePorOID (string nif)
{
        ClienteEN clienteEN = null;

        clienteEN = _IClienteCAD.DameClientePorOID (nif);
        return clienteEN;
}

public System.Collections.Generic.IList<ClienteEN> DameTodosLosClientes (int first, int size)
{
        System.Collections.Generic.IList<ClienteEN> list = null;

        list = _IClienteCAD.DameTodosLosClientes (first, size);
        return list;
}
}
}
