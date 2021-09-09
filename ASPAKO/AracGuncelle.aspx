<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AracGuncelle.aspx.cs" Inherits="ASPAKO.AracGuncelle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style14 {
            width: 587px;
        }
        .buyukharf{
           text-transform:uppercase;
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
    <div class="container" >&nbsp;<table>
        <tr>
            <td class="auto-style14" style="text-align:center">Araç Güncelleme Sayfası</td>
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
                       <td> Şase Numarası</td>
            <td> <asp:TextBox ID="txtsase" runat="server" MaxLength="17" TabIndex="4"></asp:TextBox></td>
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
        <asp:Button ID="btnguncelle" runat="server" Text="Guncelle" OnClick="btnguncelle_Click" TabIndex="12"  />
        <asp:Button ID="btntemizle" runat="server" Text="Temizle" OnClick="btntemizle_Click" TabIndex="13"  />
        <asp:Button ID="btnlistele" runat="server" Text="Listele" OnClick="btnlistele_Click" TabIndex="14" />
        <br />
        <br />
        <asp:Label ID="lbluyari" runat="server" Text=""></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnsil" runat="server" Text="Arac Sil" OnClick="btnsil_Click" Width="84px" />
        <br />
        <br />

        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:ButtonField CommandName="Select" Text="Seç" />
            </Columns>
        </asp:GridView>

        </div>
    </div>
</asp:Content>
