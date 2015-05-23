<%@ Page Title="Lista de clientes" Language="C#" MasterPageFile="~/Views/Buscador/Buscador.Master" AutoEventWireup="true"
    CodeBehind="ListaProveedores.aspx.cs" Inherits="Proveedores.ListaProveedores" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="Title" runat="server" ContentPlaceHolderID="SectionTitle">
Lista de proveedores
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <form id="Form1" runat="server">
        <asp:GridView ID="gridClientes" runat="server" CellPadding="4" CssClass="table table-striped"
            onselectedindexchanged="gridClientes_SelectedIndexChanged">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="Nif" DataNavigateUrlFormatString="~/Proveedores/EditProveedor?nif={0}" Text="Editar" > </asp:HyperLinkField>
                <asp:HyperLinkField DataNavigateUrlFields="Nif" DataNavigateUrlFormatString="~/Proveedores/BorrarProveedor?nif={0}" Text="Borrar"> </asp:HyperLinkField>
            </Columns>
        </asp:GridView>
    </form>

</asp:Content>
