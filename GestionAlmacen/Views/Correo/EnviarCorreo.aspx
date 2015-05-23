<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<StockManager.Models.CorreoModels>"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	EnviarCorreo
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<form role="form" runat="server" method="post">
    <div class="jumbotron">
           <h2>Enviar correo</h2>
       </div>
        <% using (Html.BeginForm()) { %>
           <div class="row margin-top">
               <div class="col-sm-2"><strong>Correo de</strong></div>
               <div class="col-sm-10"><%: Html.TextBoxFor(m => m.From, new { @class = "form-control", @type = "email", @required  = "required" })%></div>
           </div>
           <div class="row margin-top">
               <div class="col-sm-2"><strong>Contraseña</strong></div>
               <div class="col-sm-10"><%: Html.TextBoxFor(m => m.Password, new { @class = "form-control", @type = "password", @required  = "required" })%></div>
           </div>
           <div class="row margin-top">
               <div class="col-sm-2"><strong>Mensaje</strong></div>
               <div class="col-sm-10"><%: Html.TextAreaFor(m => m.Mensaje, new { @class = "form-control", @type = "text", @maxlength = "500", @required = "required", @style="resize:vertical" })%></div>
           </div>
           <div class="text-right margin">
               <input type="submit" class="btn btn-default" value="Enviar"/>
           </div>
        <% } %>
    </form>

</asp:Content>

