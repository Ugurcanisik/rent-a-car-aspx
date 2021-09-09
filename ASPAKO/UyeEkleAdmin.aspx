<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UyeEkleAdmin.aspx.cs" Inherits="ASPAKO.UyeEkleAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
        .container{
            margin:0 auto;
        }
        .auto-style1 {
            width: 526px;
            text-align:center;
        }
        .auto-style2 {
            width: 114px;
        }
        .auto-style3 {
            width: 150px;
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
                        <td class="auto-style1">Admin Sayfası</td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td class="auto-style2">TC:</td>
                        <td><asp:TextBox ID="txttc" runat="server" Width="386px" MaxLength="11"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Adı:</td>
                        <td><asp:TextBox ID="txtad" runat="server" Width="386px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Soyadı:</td>
                        <td><asp:TextBox ID="txtsoyad" runat="server" Width="386px"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td class="auto-style2">Telefon Numara</td>
                        <td><asp:TextBox ID="txttelno" runat="server" Width="386px" MaxLength="11"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">E-Posta</td>
                        <td><asp:TextBox ID="txteposta" runat="server" Width="386px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Adres:</td>
                        <td><asp:TextBox ID="txtadres" runat="server" Width="386px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Parola:</td>
                        <td><asp:TextBox ID="txtparola" runat="server" Width="386px" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Parola Tekrar:</td>
                        <td><asp:TextBox ID="txtparolatekrar" runat="server" Width="386px" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    </table>
                <table>
                    <tr>
                        <td class="auto-style3"></td>
                        <td><asp:Button ID="btnanasayfa" runat="server" PostBackUrl="~/Default.aspx" Text="Anasayfa" Width="171px"  />
                            <asp:Button ID="btnkayıtol" runat="server" Text="Kayıt Ol" Width="182px" OnClick="btnkayıtol_Click"   />

                        </td> 
                    </tr>
                </table>
                <br />
                <asp:Label ID="lbluyari" runat="server" Text="Label"></asp:Label>

                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
</asp:Content>
