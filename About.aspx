<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="MvpPractica.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
    <p>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </p>
    <p>
        <asp:Button ID="ButtonEmpleados" runat="server" OnClick="ButtonEmpleados_Click" Text="MostrarEmpleados" />
        <asp:Button ID="ButtonEmpresas" runat="server" OnClick="ButtonEmpresas_Click" Text="MostrarEmpresas" />
    </p>
    <p>
        <asp:Label ID="LabelMensaje" runat="server" Text="Label"></asp:Label>
    </p>
</asp:Content>
