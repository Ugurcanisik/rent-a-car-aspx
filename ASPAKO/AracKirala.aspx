<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AracKirala.aspx.cs" Inherits="ASPAKO.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style14 {
            width: 1041px;
        }
        .auto-style15 {
            width: 572px;
            height: 197px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     
    
   <div>
    <div class="container" >&nbsp;<table>
        <tr>
            <td class="auto-style14" style="text-align:center">Araç Kiralama Sayfası</td>
        </tr>
    </table>
    <table class="auto-style15">
        <tr>
            
            <td>Plaka</td>
            <td> <asp:DropDownList ID="drpdwlstPlaka" runat="server" AutoPostBack="True" Width="128px">
                <asp:ListItem Value="---Araçlar---">---Araçlar---</asp:ListItem>
                </asp:DropDownList></td>
                        <td>KM</td>
            <td> <asp:TextBox ID="txtkm" runat="server" onkeypress="return SayiGirme(event)" Enabled="False"></asp:TextBox></td>
        
            </tr>
        <tr>
            <td>Marka</td>
            <td> <asp:TextBox ID="txtmarka" runat="server" Enabled="False"></asp:TextBox></td>
             <td>Renk</td>
            <td> <asp:TextBox ID="txtrenk" runat="server" CssClass="buyukharf" Enabled="False"></asp:TextBox></td>

            
        </tr>
        <tr>
            <td>Seri</td>
            <td> <asp:TextBox ID="txtseri" runat="server" Enabled="False"></asp:TextBox></td>
                        <td>Günlük</td>
            <td> <asp:TextBox ID="txtgunluk" runat="server" onkeypress="return SayiGirme(event)" Enabled="False"></asp:TextBox></td>
            </tr>
            <tr>
            <td>Model</td>
            <td> <asp:TextBox ID="txtmodel" runat="server" MaxLength="4" onkeypress="return SayiGirme(event)" Enabled="False"></asp:TextBox></td>
                 <td>Haftalık</td>
            <td> <asp:TextBox ID="txthaftalık" runat="server" onkeypress="return SayiGirme(event)" Enabled="False"></asp:TextBox></td>
            </tr>
        <tr>
                <td>Vites Tipi</td>
            <td> <asp:TextBox ID="txtvites" runat="server" Enabled="False"></asp:TextBox></td>
             <td>Aylık</td>
            <td> <asp:TextBox ID="txtaylık" runat="server" onkeypress="return SayiGirme(event)" Enabled="False"></asp:TextBox></td>
          </tr>
        <tr>
            <td>Yakit Tipi</td>
            <td> <asp:TextBox ID="txtyakit" runat="server" Enabled="False"></asp:TextBox></td>
           
            </tr>
        </table>
        <table>
            <tr>
                 <td> Kiralama Şekli</td>
           <td> <asp:DropDownList ID="drpdwnkiralasekli" runat="server" Width="156px" Height="16px" OnSelectedIndexChanged="drpdwnkiralasekli_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem>Seçiniz</asp:ListItem>
                <asp:ListItem>Gunluk</asp:ListItem>
                <asp:ListItem>Haftalık</asp:ListItem>
                <asp:ListItem>Aylık</asp:ListItem>
                </asp:DropDownList></td>
            </tr>
            <tr>
                            <td>Alış Tarihi</td>
            <td> <asp:Calendar ID="alıstarihi" runat="server"></asp:Calendar>
            </td>
                <td>Teslim Tarihi</td>
                <td> <asp:Calendar ID="teslimtarihi" runat="server" OnSelectionChanged="teslimtarihi_SelectionChanged"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td>Toplam Gün</td>
                <td> <asp:TextBox ID="txttoplamgun" runat="server" Enabled="False"></asp:TextBox></td>
                <td>Kira Ucreti</td>
                <td> <asp:TextBox ID="txtkiraucreti" runat="server" Enabled="False"></asp:TextBox></td>
                <td>Toplam Tutar</td>
                <td> <asp:TextBox ID="txttoplamtutar" runat="server" Enabled="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td> <asp:Button ID="btnhesap" runat="server" Text="Hesapla" OnClick="btnhesap_Click" /></td>
            </tr>

        </table>
        <asp:Button ID="btnkirala" runat="server" Text="Kirala" OnClick="btnkirala_Click"   />
        <asp:Button ID="btntemizle" runat="server" Text="Temizle" OnClick="btntemizle_Click"   />
        <br />
        <br />
        <asp:Label ID="lbluyari" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <br />
        <br />

        
        </div>
    </div>



















</asp:Content>
