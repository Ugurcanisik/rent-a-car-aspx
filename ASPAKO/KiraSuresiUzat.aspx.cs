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
    public partial class KiraSuresiUzat : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection("Data Source=THEODOREIV\\SQLEXPRESS;Initial Catalog=ASPOAKO;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            araclistele();

            alıstarihi.SelectedDate = DateTime.Today;


            lbluyari.Text = "";

        }


        public void araclistele()
        {

            baglanti.Open();
            SqlCommand aracgetir = new SqlCommand("select Plaka,Marka,Seri,Model,VitesTipi,YakitTipi,KM,Renk,KiralamaSekli,AlisTarihi,TeslimTarihi,ToplamGun,KiraUcreti,ToplamTutar from Sozlesmeler where Eposta=@Eposta and Silindimi='False'", baglanti);
            aracgetir.Parameters.AddWithValue("@Eposta", Session["kullanicigiris"].ToString());
            SqlDataAdapter araclistele = new SqlDataAdapter(aracgetir);
            DataSet ds = new DataSet();
            araclistele.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            baglanti.Close();
        }

        protected void teslimtarihi_SelectionChanged(object sender, EventArgs e)
        {
            if (teslimtarihi.SelectedDate >= alıstarihi.SelectedDate)
            {
                DateTime bTarih = Convert.ToDateTime(alıstarihi.SelectedDate);
                DateTime kTarih = Convert.ToDateTime(teslimtarihi.SelectedDate);
                TimeSpan Sonuc = kTarih - bTarih;
                txttplmgn.Text = Sonuc.TotalDays.ToString();
            }
            else
            {
                txttplmgn.Text = "";
                lbluyari.Text = "Teslim Tarihi Aliş Tarihinden Önce Olamaz!!";

                alıstarihi.SelectedDate = DateTime.Today;
                teslimtarihi.SelectedDate = DateTime.Today;
            }
            if (txttplmgn.Text == "0")
            {
                txttplmgn.Text = "";

            }
        }

        protected void btnhesap_Click(object sender, EventArgs e)
        {
            if (txttplmgn.Text != "" && txtkraucrt.Text != "")
                txttplmtutr.Text = ((Convert.ToInt32(txttplmgn.Text)) * (Convert.ToInt32(txtkraucrt.Text))).ToString();
            else
            {
                lbluyari.Text = "Ödeme Alanlarını Doldurunuz!";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int secili;
            secili = GridView1.SelectedIndex;
            GridViewRow row = GridView1.Rows[secili];
            txtplaka.Text = row.Cells[1].Text;
            txtmarka.Text = row.Cells[2].Text;
            txtseri.Text = row.Cells[3].Text;
            txtmodel.Text = row.Cells[4].Text;
            txtvitestipi.Text = row.Cells[5].Text;
            txtyakittipi.Text = row.Cells[6].Text;
            txtkm.Text = row.Cells[7].Text;
            txtrenk.Text = row.Cells[8].Text;
            txtkiralamasekli.Text = row.Cells[9].Text;
            txtalistarihi.Text = row.Cells[10].Text;
            txtteslimtarihi.Text = row.Cells[11].Text;
            txttoplamgun.Text = row.Cells[12].Text;
            txtkiraucreti.Text = row.Cells[13].Text;
            txttoplamtutar.Text = row.Cells[14].Text;


            txtkraucrt.Text = txtkiraucreti.Text;

            teslimtarihi.SelectedDate = Convert.ToDateTime( txtteslimtarihi.Text);

        }
        private void temizle()
        {
            txtplaka.Text = "";
            txtmarka.Text = "";
            txtseri.Text = "";
            txtmodel.Text = "";
            txtvitestipi.Text = "";
            txtyakittipi.Text = "";
            txtkm.Text = "";
            txtrenk.Text = "";
            txtkiralamasekli.Text = "";
            txtalistarihi.Text = "";
            txtteslimtarihi.Text = "";
            txttoplamgun.Text = "";
            txttoplamtutar.Text = "";
            txtkiraucreti.Text = "";
            txttplmtutr.Text = "";
            txtkraucrt.Text = "";
            txttplmgn.Text = "";
            alıstarihi.SelectedDate = DateTime.Today;
            teslimtarihi.SelectedDate = DateTime.Today;
        }

        protected void btnuzat_Click(object sender, EventArgs e)
        {
            string TeslimTarihi = teslimtarihi.SelectedDate.ToShortDateString();

            if (txtplaka.Text != "")
            {   
                        if (txtteslimtarihi.Text == TeslimTarihi)
                        {
                            lbluyari.Text = "Teslim Tarihleri Ayni farklı Bir tarih Seçiniz";
                        }
                        else if (txttoplamgun.Text != "" && txtkiraucreti.Text != "")
                        {
                            
 
                    baglanti.Open();
                    SqlCommand sureuzat = new SqlCommand("update Sozlesmeler set TeslimTarihi=@TeslimTarihi,ToplamGun=@ToplamGun,KiraUcreti=@KiraUcreti,ToplamTutar=@ToplamTutar where Plaka=@Plaka", baglanti);
                            sureuzat.Parameters.AddWithValue("@Plaka", txtplaka.Text);
                            sureuzat.Parameters.AddWithValue("@TeslimTarihi", TeslimTarihi);
                            sureuzat.Parameters.AddWithValue("@ToplamGun", txttplmgn.Text);
                            sureuzat.Parameters.AddWithValue("@KiraUcreti", txtkiraucreti.Text);
                            sureuzat.Parameters.AddWithValue("@ToplamTutar", txttplmtutr.Text);
                            sureuzat.ExecuteNonQuery();
                            lbluyari.Text = "Sure Uzatıldı";
                            baglanti.Close();
                    temizle();
                            araclistele();


                        }
                        else
                        {
                            lbluyari.Text = "Toplam Tutarı Hesaplayınız";
                        }    
                
            }
            else
            {
                lbluyari.Text = "Araç Seçimi Yapınız";
            }
            baglanti.Close();









        }
    }
}