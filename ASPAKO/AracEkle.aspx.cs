using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls.Adapters;
using System.Web.UI.WebControls.Expressions;
using System.Web.UI.WebControls.WebParts;


namespace ASPAKO
{
  
    public partial class AracEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txttarih.Text = DateTime.Now.ToShortDateString();
            lbluyari.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
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
            txtsasenumarasi.Text = "";
        }

        protected void btnekle_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=THEODOREIV\\SQLEXPRESS;Initial Catalog=ASPOAKO;Integrated Security=True");
            baglanti.Open();

            SqlCommand aracekle = new SqlCommand("AracEkle", baglanti);
            aracekle.CommandType = CommandType.StoredProcedure;

            aracekle.Parameters.AddWithValue("@Plaka", txtplaka.Text);
            aracekle.Parameters.AddWithValue("@Marka",txtmarka.Text);
            aracekle.Parameters.AddWithValue("@Seri", txtseri.Text);
            aracekle.Parameters.AddWithValue("@Model", txtmodel.Text);
            aracekle.Parameters.AddWithValue("@VitesTipi", drplstvites.SelectedItem.ToString());
            aracekle.Parameters.AddWithValue("@YakitTipi", drplstyakit.SelectedItem.ToString());
            aracekle.Parameters.AddWithValue("@KM", txtkm.Text);
            aracekle.Parameters.AddWithValue("@Renk", txtrenk.Text);
            aracekle.Parameters.AddWithValue("@FiyatiG", txtgunluk.Text);
            aracekle.Parameters.AddWithValue("@FiyatiH", txthaftalık.Text);
            aracekle.Parameters.AddWithValue("@FiyatiA", txtaylık.Text);
            aracekle.Parameters.AddWithValue("@EklemeTarihi", txttarih.Text);
            aracekle.Parameters.AddWithValue("@Durumu", "Musait");
            aracekle.Parameters.AddWithValue("@SaseNumarasi",txtsasenumarasi.Text);
            aracekle.Parameters.AddWithValue("@Silindimi", "False");

            SqlCommand arackontrol = new SqlCommand("Select Plaka from Araclar where Plaka=@Plaka", baglanti);
            arackontrol.Parameters.AddWithValue("@Plaka", txtplaka.Text);
            SqlDataReader aracoku = arackontrol.ExecuteReader();

            if (txtplaka.Text!="" && txtmarka.Text !="" && txtseri.Text !="" && txtseri.Text !="" && txtmodel.Text !="" && drplstvites.SelectedIndex>0 && drplstyakit.SelectedIndex>0 &&
                txtkm.Text != "" && txtrenk.Text != "" && txtgunluk.Text != "" && txthaftalık.Text != "" && txtaylık.Text != "" && txttarih.Text != "" )
            {
                if(txtplaka.Text.Count()==7 || txtplaka.Text.Count() == 8)
                {
                    if(txtmodel.Text.Count()==4)
                    {
                        if(txtsasenumarasi.Text.Count()==17)
                        {
                            if (aracoku.Read())
                            {
                                lbluyari.Text = "Araç Zaten Kayıtlı";
                            }
                            else
                            {
                                aracoku.Close();
                                aracekle.ExecuteNonQuery();
                                lbluyari.Text = "Araç Eklendi";
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
                lbluyari.Text = "Alanların Hepsini Doldurunuz";
            }

            baglanti.Close();

            
        }
    }
}