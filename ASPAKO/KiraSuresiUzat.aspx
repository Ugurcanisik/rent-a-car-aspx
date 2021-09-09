<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="KiraSuresiUzat.aspx.cs" Inherits="ASPAKO.KiraSuresiUzat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style14 {
            height: 26px;
        }
        .auto-style15 {
            width: 894px;
        }
        .auto-style16 {
            margin-left: 302px;
        }
        .auto-style21 {
            width: 907px;
            margin: 0 auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

  <div class="auto-style26">
    <div class="auto-style21" >&nbsp;<table>
        <tr>
            <td class="auto-style15" style="text-align:center">Kira Süresi Uzatma Sayfası</td>
        </tr>
    </table>   
        <table>
            <tr>
                <td>Plaka</td>
                <td> <asp:TextBox ID="txtplaka" runat="server" Enabled="False"></asp:TextBox></td>  
                <td>Renk</td>
                <td> <asp:TextBox ID="txtrenk" runat="server" Enabled="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Marka</td>
                <td> <asp:TextBox ID="txtmarka" runat="server" Enabled="False"></asp:TextBox></td>
                <td>Kiralama Şekli</td>
                <td> <asp:TextBox ID="txtkiralamasekli" runat="server" Enabled="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Seri</td>
                <td> <asp:TextBox ID="txtseri" runat="server" Enabled="False"></asp:TextBox></td>
                <td>Aliş Tarihi</td>
                <td> <asp:TextBox ID="txtalistarihi" runat="server" Enabled="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="auto-style14">Model</td>
                <td class="auto-style14"> <asp:TextBox ID="txtmodel" runat="server" Enabled="False"></asp:TextBox></td>
                <td class="auto-style14">Teslim Tarihi</td>
                <td class="auto-style14"> <asp:TextBox ID="txtteslimtarihi" runat="server" Enabled="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Vites Tipi</td>
                <td> <asp:TextBox ID="txtvitestipi" runat="server" Enabled="False"></asp:TextBox></td>
                <td>Toplam Gün</td>
                <td> <asp:TextBox ID="txttoplamgun" runat="server" Enabled="False"></asp:TextBox></td>
            </tr>
            <tr> 
                <td>Yakıt Tipi</td>
                <td> <asp:TextBox ID="txtyakittipi" runat="server" Enabled="False"></asp:TextBox></td>
                <td>Kira Ücreti</td>
                <td> <asp:TextBox ID="txtkiraucreti" runat="server" Enabled="False"></asp:TextBox></td>
            </tr>
            <tr> 
                <td>KM</td>
                <td> <asp:TextBox ID="txtkm" runat="server" Enabled="False"></asp:TextBox></td>
                <td>Toplam Tutar</td>
                <td> <asp:TextBox ID="txttoplamtutar" runat="server" Enabled="False"></asp:TextBox></td>
            </tr>
        </table>




    <table>
        
            </tr>
            <tr>
                            <td>Alış Tarihi</td>
            <td> <asp:Calendar ID="alıstarihi" runat="server"></asp:Calendar>
            </td>
                <td class="auto-style17">Teslim Tarihi</td>
                <td> <asp:Calendar ID="teslimtarihi" runat="server" OnSelectionChanged="teslimtarihi_SelectionChanged"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td>Toplam Gün</td>
                <td> <asp:TextBox ID="txttplmgn" runat="server" Enabled="False"></asp:TextBox></td>
                <td class="auto-style17">Kira Ucreti</td>
                <td> <asp:TextBox ID="txtkraucrt" runat="server" Enabled="False"></asp:TextBox></td>
                <td>Toplam Tutar</td>
                <td> <asp:TextBox ID="txttplmtutr" runat="server" Enabled="False"></asp:TextBox></td>
            </tr>
    </table>
        <asp:Button ID="btnhesap" runat="server" Text="Hesapla" OnClick="btnhesap_Click" Width="98px" CssClass="auto-style16" />
    <br />
    <br />
        <asp:Label ID="lbluyari" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Button ID="btnuzat" runat="server" Text="Süre Uzat" OnClick="btnuzat_Click" /><br />

    <br />
 

    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:ButtonField CommandName="Select" Text="Seç" />
        </Columns>
    </asp:GridView>


</asp:Content>
