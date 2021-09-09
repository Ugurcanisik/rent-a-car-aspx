using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ASPAKO
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection("Data Source=THEODOREIV\\SQLEXPRESS;Initial Catalog=ASPOAKO;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                araclistele();
            }

            txtaracdoldur();

            if(drpdwlstPlaka.SelectedIndex==0)
            {
                temizle();
            }
            
            alıstarihi.SelectedDate = DateTime.Today;
        }

        private void araclistele()
        {
            baglanti.Open();

            SqlCommand aralistele = new SqlCommand("select Plaka from Araclar where Durumu='Musait' and Silindimi='False'", baglanti);

            SqlDataReader aracoku = aralistele.ExecuteReader();

            while(aracoku.Read())
            {
                drpdwlstPlaka.Items.Add(aracoku["Plaka"].ToString());
            }

            
            baglanti.Close();
        }

        private void txtaracdoldur()
        {
            baglanti.Open();

            SqlCommand plaka = new SqlCommand("select Marka,Seri,Model,VitesTipi,YakitTipi,KM,Renk,FiyatiG,FiyatiH,FiyatiA from Araclar where Plaka=@Plaka", baglanti);
            plaka.Parameters.AddWithValue("@Plaka", drpdwlstPlaka.SelectedItem.ToString());



            SqlDataReader plakaoku = plaka.ExecuteReader();

            if(plakaoku.Read())
            {
                txtmarka.Text = plakaoku["Marka"].ToString();
                txtseri.Text = plakaoku["Seri"].ToString();
                txtmodel.Text = plakaoku["Model"].ToString();
                txtvites.Text = plakaoku["VitesTipi"].ToString();
                txtyakit.Text = plakaoku["YakitTipi"].ToString();
                txtkm.Text = plakaoku["KM"].ToString();
                txtrenk.Text = plakaoku["Renk"].ToString();
                txtgunluk.Text = plakaoku["FiyatiG"].ToString();
                txthaftalık.Text = plakaoku["FiyatiH"].ToString();
                txtaylık.Text = plakaoku["FiyatiA"].ToString();      
            }         
            baglanti.Close();
            
        }

        protected void drpdwseri_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        protected void drpdwnkiralasekli_SelectedIndexChanged(object sender, EventArgs e)
        {
            int kira;

            kira = drpdwnkiralasekli.SelectedIndex;

            switch(kira)
            {
                case 1:
                    {
                        txtkiraucreti.Text = txtgunluk.Text;
                        break;
                    }
                case 2:
                    {
                        txtkiraucreti.Text = txthaftalık.Text;
                        break;
                    }
                case 3:
                    {
                        txtkiraucreti.Text = txtaylık.Text;
                        break;
                    }
            }
        }

        protected void teslimtarihi_SelectionChanged(object sender, EventArgs e)
        {
            if (teslimtarihi.SelectedDate >= alıstarihi.SelectedDate)
            {
                DateTime bTarih = Convert.ToDateTime(alıstarihi.SelectedDate);
                DateTime kTarih = Convert.ToDateTime(teslimtarihi.SelectedDate);
                TimeSpan Sonuc = kTarih - bTarih;
                txttoplamgun.Text = Sonuc.TotalDays.ToString();
            }
            else
            {
                txttoplamgun.Text = "";
                lbluyari.Text="Teslim Tarihi Aliş Tarihinden Önce Olamaz!!";

                alıstarihi.SelectedDate = DateTime.Today;
                teslimtarihi.SelectedDate = DateTime.Today;
            }
            if (txttoplamgun.Text == "0")
                txttoplamgun.Text = "";






        }

        protected void btnhesap_Click(object sender, EventArgs e)
        {
            if (txttoplamgun.Text != "" && txtkiraucreti.Text != "")
                txttoplamtutar.Text = ((Convert.ToInt32(txttoplamgun.Text)) * (Convert.ToInt32(txtkiraucreti.Text))).ToString();
            else
            {
                lbluyari.Text = "Ödeme Alanlarını Doldurunuz!";
            }




        }

        protected void btnkirala_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            string AlisTarihi = alıstarihi.SelectedDate.ToShortDateString();
            string TeslimTarihi = teslimtarihi.SelectedDate.ToShortDateString();

            SqlCommand musterigetir = new SqlCommand("select TC,Adi,Soyadi,TelefonNumarasi,Eposta,Adres from Musteriler where Eposta=@Eposta", baglanti);
            musterigetir.Parameters.AddWithValue("Eposta", Session["kullanicigiris"].ToString());

            SqlDataReader musterioku = musterigetir.ExecuteReader();

            if (musterioku.Read())
            {
                string tc = musterioku["TC"].ToString();
                string adi = musterioku["Adi"].ToString();
                string soyadi = musterioku["Soyadi"].ToString();
                string telno = musterioku["TelefonNumarasi"].ToString();
                string eposta = musterioku["Eposta"].ToString();

                musterioku.Close();

                SqlCommand stsekle = new SqlCommand("SozlesmeEkle", baglanti);
                stsekle.CommandType = CommandType.StoredProcedure;
                stsekle.Parameters.AddWithValue("@Plaka", drpdwlstPlaka.SelectedItem.ToString());
                stsekle.Parameters.AddWithValue("@Marka", txtmarka.Text);
                stsekle.Parameters.AddWithValue("@Seri", txtseri.Text);
                stsekle.Parameters.AddWithValue("@Model", txtmodel.Text);
                stsekle.Parameters.AddWithValue("@VitesTipi", txtvites.Text);
                stsekle.Parameters.AddWithValue("@YakitTipi", txtyakit.Text);
                stsekle.Parameters.AddWithValue("@KM", txtkm.Text);
                stsekle.Parameters.AddWithValue("@Renk", txtrenk.Text);
                stsekle.Parameters.AddWithValue("@FiyatiG", txtgunluk.Text);
                stsekle.Parameters.AddWithValue("@FiyatiH", txthaftalık.Text);
                stsekle.Parameters.AddWithValue("@FiyatiA", txtaylık.Text);
                stsekle.Parameters.AddWithValue("@TC", tc);
                stsekle.Parameters.AddWithValue("@Adi", adi);
                stsekle.Parameters.AddWithValue("@Soyadi", soyadi);
                stsekle.Parameters.AddWithValue("@TelefonNumarasi", telno);
                stsekle.Parameters.AddWithValue("@Eposta", eposta);
                stsekle.Parameters.AddWithValue("@KiralamaSekli", drpdwnkiralasekli.SelectedItem.ToString());
                stsekle.Parameters.AddWithValue("@AlisTarihi", AlisTarihi);
                stsekle.Parameters.AddWithValue("@TeslimTarihi", TeslimTarihi);
                stsekle.Parameters.AddWithValue("@ToplamGun", txttoplamgun.Text);
                stsekle.Parameters.AddWithValue("@KiraUcreti", txtkiraucreti.Text);
                stsekle.Parameters.AddWithValue("@ToplamTutar", txttoplamtutar.Text);
                stsekle.Parameters.AddWithValue("Silindimi", "False");

                if (drpdwlstPlaka.SelectedIndex > 0 && drpdwnkiralasekli.SelectedIndex > 0)
                {

                    if (teslimtarihi.SelectedDate > alıstarihi.SelectedDate)
                    {
                        if (txttoplamgun.Text != "" && txtkiraucreti.Text != "" && txttoplamtutar.Text == "")
                        {
                            lbluyari.Text = "Ödeme Alanlarını Kontrol Ediniz!!";
                        }
                        else
                        {


                            SqlCommand durumbilgisi = new SqlCommand("Update Araclar set Durumu=@Durumu where Plaka=@Plaka", baglanti);
                            durumbilgisi.Parameters.AddWithValue("@Plaka", drpdwlstPlaka.SelectedItem.ToString());
                            durumbilgisi.Parameters.AddWithValue("@Durumu", "Kirada");
                            durumbilgisi.ExecuteNonQuery();
                            stsekle.ExecuteNonQuery();
                            baglanti.Close();


                            drpdwlstPlaka.Items.Clear();
                            drpdwlstPlaka.Items.Add("---Araçlar---");
                            drpdwlstPlaka.SelectedIndex = 0;                        
                            araclistele();
                            temizle();
                            lbluyari.Text = "Kiralama Gerçekleşti!!";
                        }
                    }
                    else
                    {
                        lbluyari.Text = "Teslim Tarihini Düzenleyiniz!!";
                    }
                }
                else
                {
                    lbluyari.Text = "Kiralama İşlemi İçin gerekli alanların seçimini yapınız!!";
                }
                
            }
                      
        }

        private void temizle()
        {
            drpdwlstPlaka.SelectedIndex = 0;
            txtmarka.Text = "";
            txtseri.Text = "";
            txtmodel.Text = "";
            txtvites.Text = "";
            txtyakit.Text = "";
            txtkm.Text = "";
            txtrenk.Text = "";
            txtgunluk.Text = "";
            txthaftalık.Text = "";
            txtaylık.Text = "";
        }

        protected void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}