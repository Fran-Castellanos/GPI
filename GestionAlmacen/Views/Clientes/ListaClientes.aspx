<%@ Page Title="Lista de clientes" Language="C#" MasterPageFile="~/Views/Buscador/Buscador.Master" AutoEventWireup="true"
    CodeBehind="ListaClientes.aspx.cs" Inherits="Clientes.ListaClientes" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="Title" runat="server" ContentPlaceHolderID="SectionTitle">
Lista de clientes
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <form runat="server">
        <asp:GridView ID="gridClientes" runat="server" CellPadding="4" CssClass="table table-striped"
            onselectedindexchanged="gridClientes_SelectedIndexChanged">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="CIF" DataNavigateUrlFormatString="~/Clientes/EditCliente/?CIF={0}" Text="Editar" > </asp:HyperLinkField>
                <asp:HyperLinkField DataNavigateUrlFields="CIF" DataNavigateUrlFormatString="~/Clientes/BorrarCliente/?CIF={0}" Text="Borrar"> </asp:HyperLinkField>
            </Columns>
        </asp:GridView>
    </form>

</asp:Content>
