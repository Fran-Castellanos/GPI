<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GpiERGenNHibernate.EN.GpiER.ProveedorEN>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	NewProveedor
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<form data-toggle="validator" role="form" method="post" runat="server">
    <div class="jumbotron">
           <h2>Añadir Proveedor</h2> 
       </div>
        <% using (Html.BeginForm()) { %>
           <div  class="row margin-top">
               <div class="col-sm-2"><strong>Cif</strong></div>
               <div class="col-sm-10"><%: Html.TextBoxFor(m => m.Nif, new { @class = "form-control", @type = "text", @pattern = "^([_A-z0-9]){3,}$", @maxlength = "9", @minlength = "9", @required = "required" })%></div>
           </div>
           <div class="row margin-top">
               <div class="col-sm-2"><strong>Nombre</strong></div>
               <div class="col-sm-10"><%: Html.TextBoxFor(m => m.Nombre, new { @class = "form-control", @type = "text", @pattern = "^([_A-z ñáéíóú]){3,}$", @maxlength = "80", @required = "required" })%></div>
           </div>
           <div class="row margin-top">
               <div class="col-sm-2"><strong>País</strong></div>
               <div class="col-sm-10">
                   <%= Html.DropDownListFor(m => m.PaisEnum, (IEnumerable<SelectListItem>)ViewData["Paises"], new {@class = "form-control" })%>
               </div>
            </div>
           <div  class="row margin-top">
               <div class="col-sm-2"><strong>Provincia</strong></div>
               <div class="col-sm-10"><%: Html.TextBoxFor(m => m.Provincia, new { @class = "form-control", @type = "text", @pattern = "^([_A-z0-9 ñáéíóú]){3,}$", @maxlength = "50", @minlength = "9", @required = "required" })%></div>
           </div>
           <div  class="row margin-top">
               <div class="col-sm-2"><strong>Dirección</strong></div>
               <div class="col-sm-10"><%: Html.TextBoxFor(m => m.Direccion, new { @class = "form-control", @type = "text", @pattern = "^([_A-z0-9 ñáéíóú]){3,}$", @maxlength = "70", @minlength = "9", @required = "required" })%></div>
           </div>
           <div class="row margin-top">
               <div class="col-sm-2"><strong>Correo electrónico</strong></div>
               <div class="col-sm-10"><%: Html.TextBoxFor(m => m.Email, new { @class = "form-control", @type = "email", @required = "required" })%></div>
           </div>
           <div class="row margin-top">
               <div class="col-sm-2"><strong>Descuento (%)</strong></div>
               <div class="col-sm-10"><%: Html.TextBoxFor(m => m.Descuento, new { @class = "form-control", @type = "number", @min = "0", @max="100", @maxlength = "3", @required = "required" })%></div>
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
               <div class="col-sm-2"><strong>Divisa</strong></div>
               <div class="col-sm-10">
                   <%= Html.DropDownListFor(m => m.Divisa, (IEnumerable<SelectListItem>)ViewData["Divisas"], new {@class = "form-control" })%>
               </div>
            </div>
           
        <div class="row margin-top">
               <div class="col-sm-2"><strong>Días de pago</strong></div>
               <div class="col-sm-10">
                    <div class="form-group" id="sandbox-container">
                        <div class='input-group date' id="datepicker">
                            <%: Html.TextBoxFor(m => m.Dias , new { @class = "form-control", @required = "required" })%>
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
               </div>
            </div>


         <div class="row margin-top text-right">
            <div class="col-md-2 col-md-offset-8"><button class="btn btn-success" type="submit">Guardar proveedor</button></div>
            <div class="col-md-2"><button class="btn btn-danger" type="button" onclick="location.href = '../../Proveedores/ListaProveedores'">Cancelar</button></div>
        </div>

        <% } %>
        </form>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">
    <script src="http://cdnjs.cloudflare.com/ajax/libs/select2/4.0.0/js/select2.min.js"></script>
    <script type="text/javascript">
        $('select').select2({
            language: "es",
            placeholder: "Seleccione una divisa"
        });
        $('#datepicker').datepicker({
                multidate: true, format: "dd/mm/yyyy",
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
