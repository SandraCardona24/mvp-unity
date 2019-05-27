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
        <asp:Button ID="ButtonMostrar" runat="server" OnClick="Button1_Click" Text="MostrarTabla" />
    </p>
    <p>
        <asp:Label ID="LabelMensaje" runat="server" Text="Label"></asp:Label>
    </p>
</asp:Content>
