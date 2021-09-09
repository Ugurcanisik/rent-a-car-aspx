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
    public partial class AracGuncelle : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection("Data Source=THEODOREIV\\SQLEXPRESS;Initial Catalog=ASPOAKO;Integrated Security=True");

        public void araclistele()
        {

            baglanti.Open();
            SqlCommand aracgetir = new SqlCommand("select Plaka,Marka,Seri,Model,VitesTipi,YakitTipi,KM,Renk,FiyatiG,FiyatiH,FiyatiA,SaseNumarasi,Durumu from Araclar where Silindimi='False'", baglanti);
            SqlDataAdapter araclistele = new SqlDataAdapter(aracgetir);
            DataSet ds = new DataSet();
            araclistele.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            baglanti.Close();
        }

        


        protected void Page_Load(object sender, EventArgs e)
        {
            araclistele();
            Label2.Text = "";
            lbluyari.Text = "";
        }

        protected void btnguncelle_Click(object sender, EventArgs e)
        {
     

            baglanti.Open();

            SqlCommand aracguncelle = new SqlCommand("AracGuncelle", baglanti);
            aracguncelle.CommandType = CommandType.StoredProcedure;

            aracguncelle.Parameters.AddWithValue("@Plaka", txtplaka.Text);
            aracguncelle.Parameters.AddWithValue("@Marka", txtmarka.Text);
            aracguncelle.Parameters.AddWithValue("@Seri", txtseri.Text);
            aracguncelle.Parameters.AddWithValue("@Model", txtmodel.Text);
            aracguncelle.Parameters.AddWithValue("@VitesTipi", drplstvites.SelectedItem.ToString());
            aracguncelle.Parameters.AddWithValue("@YakitTipi", drplstyakit.SelectedItem.ToString());
            aracguncelle.Parameters.AddWithValue("@KM", txtkm.Text);
            aracguncelle.Parameters.AddWithValue("@Renk", txtrenk.Text);
            aracguncelle.Parameters.AddWithValue("@FiyatiG", txtgunluk.Text);
            aracguncelle.Parameters.AddWithValue("@FiyatiH", txthaftalık.Text);
            aracguncelle.Parameters.AddWithValue("@FiyatiA", txtaylık.Text);
            aracguncelle.Parameters.AddWithValue("@SaseNumarasi", txtsase.Text);

            if (txtplaka.Text != "" && txtmarka.Text != "" && txtseri.Text != "" && txtseri.Text != "" && txtmodel.Text != "" && drplstvites.SelectedIndex > 0 && drplstyakit.SelectedIndex > 0 &&
               txtkm.Text != "" && txtrenk.Text != "" && txtgunluk.Text != "" && txthaftalık.Text != "" && txtaylık.Text != "" && txtsase.Text != "")
            {
                if (txtplaka.Text.Count() == 7 || txtplaka.Text.Count() == 8)
                {
                    if (txtmodel.Text.Count() == 4)
                    {
                        if (txtsase.Text.Count() == 17)
                        {
                            int secili;
                            secili = GridView1.SelectedIndex;
                            GridViewRow row = GridView1.Rows[secili];
                            if (txtplaka.Text == row.Cells[1].Text)
                            {
                                Label2.Text = "Plaka Aynı";
                                aracguncelle.ExecuteNonQuery();
                                lbluyari.Text = "Araç Guncellendi";
                            }
                            else if (txtsase.Text == row.Cells[12].Text)
                            {
                                Label2.Text = "Sase Aynı";
                                SqlCommand aracplakaguncelle = new SqlCommand("AracplkGuncelle", baglanti);
                                aracplakaguncelle.CommandType = CommandType.StoredProcedure;

                                aracplakaguncelle.Parameters.AddWithValue("@Plaka", txtplaka.Text);
                                aracplakaguncelle.Parameters.AddWithValue("@Marka", txtmarka.Text);
                                aracplakaguncelle.Parameters.AddWithValue("@Seri", txtseri.Text);
                                aracplakaguncelle.Parameters.AddWithValue("@Model", txtmodel.Text);
                                aracplakaguncelle.Parameters.AddWithValue("@VitesTipi", drplstvites.SelectedItem.ToString());
                                aracplakaguncelle.Parameters.AddWithValue("@YakitTipi", drplstyakit.SelectedItem.ToString());
                                aracplakaguncelle.Parameters.AddWithValue("@KM", txtkm.Text);
                                aracplakaguncelle.Parameters.AddWithValue("@Renk", txtrenk.Text);
                                aracplakaguncelle.Parameters.AddWithValue("@FiyatiG", txtgunluk.Text);
                                aracplakaguncelle.Parameters.AddWithValue("@FiyatiH", txthaftalık.Text);
                                aracplakaguncelle.Parameters.AddWithValue("@FiyatiA", txtaylık.Text);
                                aracplakaguncelle.Parameters.AddWithValue("@SaseNumarasi", txtsase.Text);

                                aracplakaguncelle.ExecuteNonQuery();

                            }
                            else
                            {
                                lbluyari.Text = "Seri Aynı değil";
                            }
                        }
                        else
                        {
                            lbluyari.Text = "Sase Numarası 17 hanede oluşmalıdır";
                        }
                    }
                    else
                    {
                        lbluyari.Text = "Model 4 hanede oluşmalıdır";
                    }
                }
                else
                {
                    lbluyari.Text = "Plaka 7 veya 8 hanede oluşmalıdır";
                }
            }
            else
            {
                lbluyari.Text = "Araç Seçimi Yapınız";
            }
            
            baglanti.Close();
            araclistele();
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
            drplstvites.SelectedValue = row.Cells[5].Text;
            drplstyakit.SelectedValue = row.Cells[6].Text;
            txtkm.Text = row.Cells[7].Text;
            txtrenk.Text = row.Cells[8].Text;
            txtgunluk.Text = row.Cells[9].Text;
            txthaftalık.Text = row.Cells[10].Text;
            txtaylık.Text = row.Cells[11].Text;
            txtsase.Text = row.Cells[12].Text;

        }

        private void temizle()
        {
            txtplaka.Text = "";
            txtmarka.Text = "";
            txtseri.Text = "";
            txtmodel.Text = "";
            txtkm.Text = "";
            txtrenk.Text = "";
            txtgunluk.Text = "";
            txthaftalık.Text = "";
            txtaylık.Text = "";
            drplstvites.SelectedIndex = 0;
            drplstyakit.SelectedIndex = 0;
            txtsase.Text = "";
        }

        protected void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        protected void btnlistele_Click(object sender, EventArgs e)
        {
            araclistele();
        }

        protected void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand aracsil = new SqlCommand("update Araclar set Silindimi=@Silindimi where Plaka=@Plaka", baglanti);
            aracsil.Parameters.AddWithValue("@Silindimi","True");
            aracsil.Parameters.AddWithValue("@Plaka", txtplaka.Text);


            aracsil.ExecuteNonQuery();
            lbluyari.Text = "Arac Silindi";
            baglanti.Close();
            araclistele();
            temizle();
        }
    }
}