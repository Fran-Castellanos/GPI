<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<ul class="nav navbar-nav navbar-right">
<%
    if (Request.IsAuthenticated) {
%>
        <li><a href="<%= Url.Action("LogOff", new {controller = "Account"}) %>"><span class="glyphicon glyphicon-off"></span>Cerrar Sesión</a></li>
<%
    }
    else {
%> 
        <li><a href="<%= Url.Action("LogOn", new {controller = "Account"}) %>"><span class="glyphicon glyphicon-user"></span> Iniciar sesión</a></li>
        <li><a href="<%= Url.Action("Register", new {controller = "Account"}) %>"><span class="glyphicon glyphicon-log-in"></span> Registrarse</a></li>
<%
    }
%>
</ul>
