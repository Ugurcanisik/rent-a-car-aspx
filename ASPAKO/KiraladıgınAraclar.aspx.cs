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
    public partial class KiraladıgınAraclar : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection("Data Source=THEODOREIV\\SQLEXPRESS;Initial Catalog=ASPOAKO;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {                
            lbluyari.Text = "";
            araclistele();
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

            alacak_verecek();



        }
        private void alacak_verecek()
        {

            string teslimtarihi = txtteslimtarihi.Text;
            string kiraucreti = txtkiraucreti.Text;


                DateTime bugun = DateTime.Parse(DateTime.Now.ToShortDateString());
                DateTime donus = DateTime.Parse(teslimtarihi);
                int tutar = Convert.ToInt32(kiraucreti);
                TimeSpan gunfarki = bugun - donus;
                int _gunfarki = gunfarki.Days;
                int ucretfarki = _gunfarki * tutar;

                txtalckvrckdrm.Text = ucretfarki.ToString();

          


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
        }

        protected void btnteslimet_Click(object sender, EventArgs e)
        {
            //lbluyari.Text = teslimtarihi.SelectedDate.ToShortDateString();

            if (GridView1.Rows.Count == 0)
            {
                lbluyari.Text = "Sözleşme Ekleyiniz";
            }
            else
            {
                if(txtplaka.Text!="")
                {
                    string bugun = DateTime.Today.ToShortDateString();
                    DateTime teslim = Convert.ToDateTime(bugun);
                    DateTime alis = Convert.ToDateTime(txtalistarihi.Text);
                    TimeSpan Sonuc = teslim - alis;
                    int tplmgn = Convert.ToInt32(Sonuc.TotalDays);
                    int tutar = Convert.ToInt32(txtkiraucreti.Text);
                    int tplmtutar = tutar * tplmgn;

                    baglanti.Open();
                    SqlCommand musterigetir = new SqlCommand("select TC,Adi,Soyadi from Musteriler where Eposta=@Eposta", baglanti);
                    musterigetir.Parameters.AddWithValue("Eposta", Session["kullanicigiris"].ToString());

                    SqlDataReader musterioku = musterigetir.ExecuteReader();

                    if (musterioku.Read())
                    {
                        string tc = musterioku["TC"].ToString();
                        string adi = musterioku["Adi"].ToString();
                        string soyadi = musterioku["Soyadi"].ToString();

                        musterioku.Close();

                        SqlCommand satslrekle = new SqlCommand("SatisEkle", baglanti);
                        satslrekle.CommandType = CommandType.StoredProcedure;
                        satslrekle.Parameters.AddWithValue("@TC", tc);
                        satslrekle.Parameters.AddWithValue("@Adi", adi);
                        satslrekle.Parameters.AddWithValue("@Soyadi", soyadi);
                        satslrekle.Parameters.AddWithValue("@Plaka", txtplaka.Text);
                        satslrekle.Parameters.AddWithValue("@Marka", txtmarka.Text);
                        satslrekle.Parameters.AddWithValue("@Seri", txtseri.Text);
                        satslrekle.Parameters.AddWithValue("@Model", txtmodel.Text);
                        satslrekle.Parameters.AddWithValue("@Renk", txtrenk.Text);
                        satslrekle.Parameters.AddWithValue("@Gun", tplmgn);
                        satslrekle.Parameters.AddWithValue("@Fiyat", txtkiraucreti.Text);
                        satslrekle.Parameters.AddWithValue("@ToplamTutar", tplmtutar);
                        satslrekle.Parameters.AddWithValue("@AlisTarihi", txtalistarihi.Text);
                        satslrekle.Parameters.AddWithValue("@TeslimTarihi", bugun);

                        satslrekle.ExecuteNonQuery();

                        SqlCommand sozlesmesilidnimi = new SqlCommand("Update Sozlesmeler Set Silindimi='True' Where Plaka=@Plaka", baglanti);
                        sozlesmesilidnimi.Parameters.AddWithValue("@Plaka", txtplaka.Text);
                        SqlCommand aracdurumu = new SqlCommand("Update Araclar Set Durumu='Musait' where Plaka=@Plaka", baglanti);
                        aracdurumu.Parameters.AddWithValue("@Plaka", txtplaka.Text);
                        aracdurumu.ExecuteNonQuery();
                        sozlesmesilidnimi.ExecuteNonQuery();
                        baglanti.Close();
                        temizle();
                        araclistele();
                        lbluyari.Text = "Araç Teslim Alındı";
                        txtalckvrckdrm.Text = "";

                    }
                }
                else
                {
                    lbluyari.Text = "Araç Seçiniz";
                }

                

            }
        }
    }

    }
