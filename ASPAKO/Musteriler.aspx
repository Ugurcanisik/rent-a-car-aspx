<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Musteriler.aspx.cs" Inherits="ASPAKO.Musteriler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style23 {
            margin-left: 7px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:ButtonField CommandName="Select" Text="Seç" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="Label3" runat="server" Text="TC No"></asp:Label>
    <asp:TextBox ID="txttc" runat="server" CssClass="auto-style23"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btnsil" runat="server" Text="Muşteri Sil" OnClick="btnsil_Click" />

</asp:Content>
