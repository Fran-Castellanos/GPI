<%@ Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GestionStockGPI.Models.CorreoModels>"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	EnviarCorreo
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<form runat="server" method="post">
    <div class="jumbotron">
           <h2>Enviar correo</h2>
       </div>
        <% using (Html.BeginForm()) { %>
           <div class="row margin-top">
               <div class="col-sm-2"><strong>Correo electrónico</strong></div>
               <div class="col-sm-10"><%: Html.TextBoxFor(m => m.From, new { @class = "form-control", @type = "email", @required  = "required" })%></div>
           </div>
           <div class="row margin-top">
               <div class="col-sm-2"><strong>Contraseña del email</strong></div>
               <div class="col-sm-10"><%: Html.TextBoxFor(m => m.Password, new { @class = "form-control", @type = "password", @required  = "required" })%></div>
           </div>
           <hr />
           <br />
           <div class="form-group">
            <div class="row">
                <div class="col-md-6">
                  <label for="total">Clientes:</label>
                  <%= Html.ListBoxFor(m => m.Clientes, (IEnumerable<SelectListItem>)ViewData["Clientes"], new { multiple = "multiple", @class="form-control" })%>
                </div>
            </div>
        </div>

        <div class="form-group">
            <div class="row">
                <div class="col-md-6">
                  <label for="total">Proveedores:</label>
                  <%= Html.ListBoxFor(m => m.Proveedores, (IEnumerable<SelectListItem>)ViewData["Proveedores"], new { multiple = "multiple", @class="form-control" })%>
                </div>
            </div>
        </div>
         <div class="row margin-top">
               <div class="col-sm-2"><strong>Asunto</strong></div>
               <div class="col-sm-10"><%: Html.TextBoxFor(m => m.Asunto, new { @class = "form-control", @type = "text", @required  = "required" })%></div>
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

<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">
    <script src="http://cdnjs.cloudflare.com/ajax/libs/select2/4.0.0/js/select2.min.js"></script>
    <script type="text/javascript">
        $('select').select2({
            language: "es",
            placeholder: "Selecciona los destinatarios"
        });
    </script>
</asp:Content>