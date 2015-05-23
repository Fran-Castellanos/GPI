<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GestionStockGPI.Models.LogOnModel>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Iniciar Sesión
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    

    <div class="form-signin">
    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true, "No ha sido posible iniciar sesión. Corrige los errores y vuelve a intentarlo") %>
        <div> 
            <h2 class="form-signin-heading">Por favor inicie sesión</h2>
                    <%: Html.TextBoxFor(m => m.UserName, new { @class = "form-control", PlaceHolder = "Usuario" })%>
                    <%: Html.ValidationMessageFor(m => m.UserName) %>

                    <%: Html.PasswordFor(m => m.Password, new { @class = "form-control", PlaceHolder = "Contraseña" })%>
                    <%: Html.ValidationMessageFor(m => m.Password) %>
                <div class="checkbox">
                    <%: Html.CheckBoxFor(m => m.RememberMe)%>
                    <%: Html.LabelFor(m => m.RememberMe) %>
                </div>
                <p>
                    <input type="submit" class="btn btn-lg btn-default btn-block" value="Log On" />
                </p>
                <p><%: Html.ActionLink("Regístrate", "Register")%> si no tienes cuenta.</p>
        </div>
    </div>
    <% } %>
</asp:Content>
