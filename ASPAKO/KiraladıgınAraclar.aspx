<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="KiraladıgınAraclar.aspx.cs" Inherits="ASPAKO.KiraladıgınAraclar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style16 {
            width: 890px;
            margin-left: 485px;
        }
        .auto-style26 {
            width: 920px;
        }
        .auto-style27 {
            margin-left: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="auto-style26">
    <div class="container" >&nbsp;
        <table>
        <tr>
            <td class="auto-style16" style="text-align:center">Araç Teslim Sayfası</td>
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
                <td>Model</td>
                <td> <asp:TextBox ID="txtmodel" runat="server" Enabled="False"></asp:TextBox></td>
                <td>Teslim Tarihi</td>
                <td> <asp:TextBox ID="txtteslimtarihi" runat="server" Enabled="False"></asp:TextBox></td>
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
   
      <br />
        <asp:Label ID="lblakacak" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="txtalckvrckdrm" runat="server" CssClass="auto-style27"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnteslimet" runat="server" Text="Arac Teslim" OnClick="btnteslimet_Click" />
        <br />
        <br />
        
        <asp:Label ID="lbluyari" runat="server" Text="Label"></asp:Label>
        
        <br />
      

        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:ButtonField CommandName="Select" Text="Seç" />
            </Columns>
        </asp:GridView>
        </div>
    </div>


    





</asp:Content>
