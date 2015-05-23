<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GpiERGenNHibernate.EN.GpiER.ClienteEN>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	NewCliente
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<form data-toggle="validator" role="form" method="post">
    <div class="jumbotron">
           <h2>Añadir Cliente</h2>
       </div>
        <% using (Html.BeginForm()) { %>
           <div class="row margin-top">
               <div class="col-sm-2"><strong>Cif</strong></div>
               <div class="col-sm-10"><%: Html.TextBoxFor(m => m.Nif, new { @class = "form-control", @type = "text", @pattern = "^([_A-z0-9]){3,}$", @maxlength = "9", @minlength = "9", @required = "required" })%></div>
           </div>
           <div class="row margin-top form-group">
               <div class="col-sm-2"><strong>Nombre</strong></div>
               <div class="col-sm-10" ><%: Html.TextBoxFor(m => m.Nombre, new { @class = "form-control", @type = "text", @pattern = "^([_A-z]){3,}$", @maxlength = "20", @required = "required" })%></div>        
           </div>
           <div class="row margin-top">
               <div class="col-sm-2"><strong>Correo</strong></div>
               <div class="col-sm-10"><%: Html.TextBoxFor(m => m.Email, new { @class = "form-control", @type = "email", @required  = "required" })%></div>
           </div>
           <div class="row margin-top">
               <div class="col-sm-2"><strong>Dirección</strong></div>
               <div class="col-sm-10"><%: Html.TextBoxFor(m => m.Direccion, new { @class = "form-control", @type = "text", @maxlength = "50", @required = "required" })%></div>
           </div>
           <div class="row margin-top">
               <div class="col-sm-2"><strong>Dirección de envío</strong></div>
               <div class="col-sm-10"><%: Html.TextBoxFor(m => m.DireccionEnvio, new { @class = "form-control", @type = "text", @pattern = "^([_A-z0-9]){3,}$", @maxlength = "100", @required = "required" })%></div>
           </div>
           <div class="row margin-top">
               <div class="col-sm-2"><strong>Teléfono</strong></div>
               <div class="col-sm-10"><%: Html.TextBoxFor(m => m.Telefono, new { @class = "form-control", @type = "text", @pattern = "^([_0-9]){3,}$", @maxlength = "9", @required = "required" })%></div>
           </div>
           <div class="row margin-top">
               <div class="col-sm-2"><strong>Datos bancarios</strong></div>
               <div class="col-sm-10">
                    <div class="form-group" id="sandbox-container">
                        <div class='input-group date'>
                            <%: Html.TextBoxFor(m => m.DatosBancarios, new { @class = "form-control", @required = "required" })%>
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
               </div>
            </div>
           <div class="row margin-top text-right">
            <div class="col-md-2 col-md-offset-8"><button class="btn btn-success" type="submit">Guardar cliente</button></div>
            <div class="col-md-2"><button class="btn btn-danger" type="button" onclick="location.href = '../../Clientes/ListaClientes'">Cancelar</button></div>
        </div>
        <% } %>
    </form>

</asp:Content>

