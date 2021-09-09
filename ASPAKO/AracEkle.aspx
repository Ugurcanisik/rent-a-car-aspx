 <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AracEkle.aspx.cs" Inherits="ASPAKO.AracEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style14 {
            width: 606px;
        }
        .buyukharf{
           text-transform:uppercase;
        }
        .auto-style15 {
            width: 611px;
            height: 520px;
            margin: 0 auto;
        }
        .auto-style16 {
            width: 97px;
        }
    </style>
    <script type="text/javascript" >
 function SayiGirme(degisken) {
 degisken = (degisken) ? degisken : window.event;
 var charCode = (degisken.which) ? degisken.which : degisken.keyCode;
 if (charCode > 31 && (charCode < 48 || charCode > 57)) {
 return false;
}
return true;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div>
    <div class="auto-style15">&nbsp;<table>
        <tr>
            <td class="auto-style14" style="text-align:center">Araç Ekleme Sayfası</td>
        </tr>
    </table>
    <table>
        <tr>
            
            <td>Plaka</td>
            <td> <asp:TextBox ID="txtplaka" runat="server" CssClass="buyukharf" MaxLength="8"></asp:TextBox></td>
                        <td>KM</td>
            <td> <asp:TextBox ID="txtkm" runat="server" onkeypress="return SayiGirme(event)" TabIndex="7"></asp:TextBox></td>
           
            </tr>
        <tr>
            <td>Marka</td>
            <td> <asp:TextBox ID="txtmarka" runat="server" CssClass="buyukharf" TabIndex="1"></asp:TextBox></td>
             <td>Renk</td>
            <td> <asp:TextBox ID="txtrenk" runat="server" CssClass="buyukharf" TabIndex="8"></asp:TextBox></td>
            
        </tr>
        <tr>
            <td>Seri</td>
            <td> <asp:TextBox ID="txtseri" runat="server" CssClass="buyukharf" TabIndex="2"></asp:TextBox></td>
                        <td>Günlük</td>
            <td> <asp:TextBox ID="txtgunluk" runat="server" onkeypress="return SayiGirme(event)" TabIndex="9"></asp:TextBox></td>
            </tr>
            <tr>
            <td>Model</td>
            <td> <asp:TextBox ID="txtmodel" runat="server" MaxLength="4" onkeypress="return SayiGirme(event)" TabIndex="3"></asp:TextBox></td>
                 <td>Haftalık</td>
            <td> <asp:TextBox ID="txthaftalık" runat="server" onkeypress="return SayiGirme(event)" TabIndex="10"></asp:TextBox></td>
            </tr>
        <tr>
             <td class="auto-style16"> Sase Numarasi</td>
            <td> <asp:TextBox ID="txtsasenumarasi" runat="server" MaxLength="17" Width="119px" TabIndex="4"></asp:TextBox></td>
             <td>Aylık</td>
            <td> <asp:TextBox ID="txtaylık" runat="server" onkeypress="return SayiGirme(event)" TabIndex="11"></asp:TextBox></td>
        </tr>
        <tr>
                <td>Vites Tipi</td>
            <td> <asp:DropDownList ID="drplstvites" runat="server" TabIndex="5">
                <asp:ListItem>---Vites---</asp:ListItem>
                <asp:ListItem>Otomatik</asp:ListItem>
                <asp:ListItem>Manuel</asp:ListItem>
                </asp:DropDownList></td>
            <td>Tarih</td>
            <td> <asp:TextBox ID="txttarih" runat="server" Enabled="False" TabIndex="12"></asp:TextBox></td>
            
          </tr>
        <tr>
            <td>Yakit Tipi</td>
            <td> <asp:DropDownList ID="drplstyakit" runat="server" TabIndex="6">
                <asp:ListItem>---Yakıt---</asp:ListItem>
                <asp:ListItem>Benzin</asp:ListItem>
                <asp:ListItem>Dizel</asp:ListItem>
                </asp:DropDownList></td>
            
            </tr>
        </table>
        <asp:Button ID="btnekle" runat="server" Text="Ekle" OnClick="btnekle_Click" TabIndex="13" />
        <asp:Button ID="btntemizle" runat="server" Text="Temizle" OnClick="Button2_Click" TabIndex="14" />
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
