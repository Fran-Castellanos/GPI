<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GestionStockGPI.Models.RegisterModel>" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Register
</asp:Content>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-signin" style="max-width:500px">
    <h2>Crea una cuenta nueva</h2>
    <p>
        Usa el formulario de abajo para crear una nueva cuenta
    </p>
    <p>
        La contraseña necesita una longitud mínima de <%: ViewData["PasswordLength"] %> caracteres.
    </p>

    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true, "No ha sido posible crear la cuenta. Por favor corrige los errores y vuelve a intentarlo.") %>
        <div>
        
            <fieldset>
                <legend>Información de cuenta</legend>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.UserName) %>
                    
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.UserName, new { @class = "form-control" })%>
                    <%: Html.ValidationMessageFor(m => m.UserName) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Email) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.Email, new { @class = "form-control" })%>
                    <%: Html.ValidationMessageFor(m => m.Email) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Password) %>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.Password, new { @class = "form-control"})%>
                    <%: Html.ValidationMessageFor(m => m.Password) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.ConfirmPassword) %>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.ConfirmPassword, new { @class = "form-control" })%>
                    <%: Html.ValidationMessageFor(m => m.ConfirmPassword) %>
                </div>
                
                <p>
                    <input type="submit" class="btn btn-lg btn-default btn-block" value="Registrarse" />
                </p>
            </fieldset>
        </div>
        </div>
    <% } %>
    
</asp:Content>
