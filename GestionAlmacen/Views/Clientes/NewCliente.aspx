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
               <div class="col-sm-2"><strong>NIF</strong></div>
               <div class="col-sm-10"><%: Html.TextBoxFor(m => m.Nif, new { @class = "form-control", @type = "text", @pattern = "^([_A-z0-9]){3,}$", @maxlength = "9", @minlength = "9", @required = "required" })%></div>
           </div>
           <div class="row margin-top form-group">
               <div class="col-sm-2"><strong>Nombre</strong></div>
               <div class="col-sm-10" ><%: Html.TextBoxFor(m => m.Nombre, new { @class = "form-control", @type = "text", @pattern = "^([_A-z ñáéíóú]){3,}$", @maxlength = "80", @required = "required" })%></div>        
           </div>
           <div class="row margin-top">
               <div class="col-sm-2"><strong>País</strong></div>
               <div class="col-sm-10"><%: Html.TextBoxFor(m => m.Pais, new { @class = "form-control", @type = "text", @pattern = "^([_A-z ñáéíóú]){3,}$", @maxlength = "40", @minlength = "9", @required = "required" })%></div>
           </div>
           <div class="row margin-top">
               <div class="col-sm-2"><strong>Provincia</strong></div>
               <div class="col-sm-10"><%: Html.TextBoxFor(m => m.Provincia, new { @class = "form-control", @type = "text", @pattern = "^([_A-z ñáéíóú]){3,}$", @maxlength = "50", @minlength = "9", @required = "required" })%></div>
           </div>
           <div class="row margin-top">
               <div class="col-sm-2"><strong>Dirección</strong></div>
               <div class="col-sm-10"><%: Html.TextBoxFor(m => m.Direccion, new { @class = "form-control", @type = "text", @pattern = "^([_A-z0-9 ñáéíóú]){3,}$", @maxlength = "70", @minlength = "9", @required = "required" })%></div>
           </div>
           <div class="row margin-top">
               <div class="col-sm-2"><strong>Dirección de envío</strong></div>
               <div class="col-sm-10"><%: Html.TextBoxFor(m => m.DireccionEnvio, new { @class = "form-control", @type = "text", @pattern = "^([_A-z0-9 ñáéíóú]){3,}$", @maxlength = "70", @minlength = "9", @required = "required" })%></div>
           </div>
           <div class="row margin-top">
               <div class="col-sm-2"><strong>Correo electrónico</strong></div>
               <div class="col-sm-10"><%: Html.TextBoxFor(m => m.Email, new { @class = "form-control", @type = "email", @required  = "required" })%></div>
           </div>
           <div class="row margin-top">
               <div class="col-sm-2"><strong>Descuento (%)</strong></div>
               <div class="col-sm-10"><%: Html.TextBoxFor(m => m.Descuento, new { @class = "form-control", @type = "number", @min = "0", @max = "100", @maxlength = "3", @required = "required" })%></div>
           </div>
           <div class="row margin-top">
               <div class="col-sm-2"><strong>Riesgos permitidos</strong></div>
               <div class="col-sm-10"><%: Html.TextBoxFor(m => m.RiesgosPermitidos, new { @class = "form-control", @type = "number", @maxlength = "10", @required = "required" })%></div>
           </div>
           <div class="row margin-top">
               <div class="col-sm-2"><strong>Datos bancarios</strong></div>
               <div class="col-sm-10"><%: Html.TextBoxFor(m => m.DatosBancarios, new { @class = "form-control", @type = "text", @maxlength = "50", @required = "required" })%></div>
           </div>
           <div class="row margin-top">
               <div class="col-sm-2"><strong>Teléfono</strong></div>
               <div class="col-sm-10"><%: Html.TextBoxFor(m => m.Telefono, new { @class = "form-control", @type = "text", @pattern = "^([_0-9]){3,}$", @maxlength = "9", @required = "required" })%></div>
           </div>
           

            <div class="row margin-top">
               
                <div class="form-group">
                        <div id="Div1">
                            <div class="input-group input-daterange" id="datepicker">
                                <span class="input-group-addon">Días de pago</span>
                                <input type="text" class="form-control" name="DiasPago" value="" placeholder="Seleccione días de pago"/>
                                <span class="input-group-btn">
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


<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">
    <script src="http://cdnjs.cloudflare.com/ajax/libs/select2/4.0.0/js/select2.min.js"></script>
    <script type="text/javascript">
        $('#datepicker').datepicker({
                multidate: true,
            });

            $('#sandbox-container .input-daterange').datepicker({
        format: "dd/mm/yyyy",
        todayBtn: "linked",
        language: "es",
        orientation: "top auto",
        todayHighlight: true
    });
    </script>
</asp:Content>
