<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UyeGuncelle.aspx.cs" Inherits="ASPAKO.UyeGuncelle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style14 {
            width: 516px;
            text-align:center;
        }
        .auto-style15 {
            margin-left: 199px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

     <div >
            <div class="container" style="width:520px; height:520px">
                <table>
                    <tr>
                        <td class="auto-style14">Kişisel Veri Güncelleme Sayfası</td>
                    </tr>
                    <tr>
                        
                    </tr>
                </table>
                <table>
                    <tr>
                        <td class="auto-style2">TC:</td>
                        <td><asp:TextBox ID="txttc" runat="server" Width="386px" MaxLength="11"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Adı:</td>
                        <td><asp:TextBox ID="txtad" runat="server" Width="386px" TabIndex="1"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Soyadı:</td>
                        <td><asp:TextBox ID="txtsoyad" runat="server" Width="386px" TabIndex="2"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td class="auto-style2">Telefon Numara</td>
                        <td><asp:TextBox ID="txttelno" runat="server" Width="386px" MaxLength="11" TabIndex="3"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">E-Posta</td>
                        <td><asp:TextBox ID="txteposta" runat="server" Width="386px" TabIndex="4"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Adres:</td>
                        <td><asp:TextBox ID="txtadres" runat="server" Width="386px" TabIndex="5"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Parola:</td>
                        <td><asp:TextBox ID="txtparola" runat="server" Width="386px" TabIndex="6"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Parola Tekrar:</td>
                        <td><asp:TextBox ID="txtparolatekrar" runat="server" Width="386px" TabIndex="7"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    </table>
                <table>
                    <tr>
                        <td class="auto-style3"></td>
                        <td>
                            <asp:Button ID="btngucenlle" runat="server" Text="Guncelle" Width="182px" OnClick="btngucenlle_Click" CssClass="auto-style15" TabIndex="8"   />
                        </td> 
                    </tr>
                </table>
                <br />
                <asp:Label ID="lbluyari" runat="server" Text="Label"></asp:Label>
                <br />
                <br />
                <br />
                <br />
                <br />


            </div>
        </div>












</asp:Content>
