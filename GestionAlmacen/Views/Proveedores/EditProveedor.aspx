<%@ Page Title="MODIFICAR PROVEEDOR" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
    Inherits="System.Web.Mvc.ViewPage<StockManagerOOH4RIAGenNHibernate.EN.Default_.PROVEEDOREN>" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="TitleContent">
</asp:Content>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="jumbotron">
        <div class="row">
            <div class="col-sm-8">
                <h2>Modificar proveedor</h2>
            </div>
            <div class="col-sm-4 margin-top padding-top">
                <form id="formBuscar" method="get" >
                    <div class="form-group">
                        <div class="input-group">
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <form id="formulario" runat="server" method="post">
        <div class="row">
            <div class="col-md-8"></div>
            <div class="col-md-4">
                <h3 class="text-left">ID: <%: Html.DisplayTextFor(m => m.CIF) %></h3>
                <h3>CIF De La Empresa Proveedora: </h3><%: Html.TextBoxFor(m => m.CIF, new { @class = "form-control" })%>
            </div>
        </div>
        <div class="row">
            <div class="col-md-8">
            <p>&nbsp;</p>
                <h4>NOMBRE</h4>
                <%: Html.TextBoxFor(m => m.Name, new { @class = "form-control" })%>
            </div>
            <div class="col-md-4">
            <p>&nbsp;</p>
                <h4>FECHA DE REGISTRO</h4>
                
                <%: Html.TextBoxFor(m => m.FechaRegistro, new { @class = "form-control" })%>
            </div>   
        </div>
        <div class="row">
            <div class="col-md-6">
            <p>&nbsp;</p>
                <h4>CORREO</h4>
                
                <%: Html.TextBoxFor(m => m.Correo, new { @class = "form-control" })%>
            </div>
            <div class="col-md-6">
            <p>&nbsp;</p>
                <h4>TELÉFONO</h4>
                
                <%: Html.TextBoxFor(m => m.Telefono, new { @class = "form-control" })%>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
            <p>&nbsp;</p>
                <h4>DESCRIPCIÓN</h4>
                
                <%: Html.TextAreaFor(m => m.Descripcion, new { @class = "form-control" })%>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
            <p>&nbsp;</p>
                <h4>DIRECCIÓN</h4>
                
                <%: Html.TextAreaFor(m => m.Direccion, new { @class = "form-control" })%>
            </div>
        </div>
        <div class="row margin-top text-right">
            <div class="col-md-2 col-md-offset-8"><button class="btn btn-success" type="submit">Guardar Cambios</button></div>
            <div class="col-md-2"><button class="btn btn-danger" type="button" onclick="location.href = '../../Proveedores/ListaProveedores'">Cancelar</button></div>
        </div>
    </form>

</asp:Content>
