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
    public partial class UyeEkleAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";
            lbluyari.Text = "";
        }
        SqlConnection baglanti = new SqlConnection("Data Source=THEODOREIV\\SQLEXPRESS;Initial Catalog=ASPOAKO;Integrated Security=True");
        protected void btnkayıtol_Click(object sender, EventArgs e)
        {
            baglanti.Open();


            SqlCommand musteriekle = new SqlCommand("AdminEkle", baglanti);
            musteriekle.CommandType = CommandType.StoredProcedure;
            musteriekle.Parameters.AddWithValue("@TC", txttc.Text);
            musteriekle.Parameters.AddWithValue("@Adi", txtad.Text);
            musteriekle.Parameters.AddWithValue("@Soyadi", txtsoyad.Text);
            musteriekle.Parameters.AddWithValue("@TelefonNumarasi", txttelno.Text);
            musteriekle.Parameters.AddWithValue("@Email", txteposta.Text);
            musteriekle.Parameters.AddWithValue("@Adres", txtadres.Text);
            musteriekle.Parameters.AddWithValue("@Parola", txtparola.Text);
            musteriekle.Parameters.AddWithValue("@Yonetici", "True");
            musteriekle.Parameters.AddWithValue("@Silindimi", "False");




            SqlCommand karsilastir = new SqlCommand("select TC from Musteriler where TC=@TC", baglanti);

            karsilastir.Parameters.AddWithValue("@TC", txttc.Text);

            SqlDataReader karsilastiroku = karsilastir.ExecuteReader();

            if (txtad.Text != "" && txtsoyad.Text != "" && txttelno.Text != "" && txteposta.Text != "" && txtadres.Text != "" && txttc.Text != "" && txtparola.Text != "" && txtparolatekrar.Text != "")
            {

                if (txtparola.Text == txtparolatekrar.Text)
                {
                    if (karsilastiroku.Read())
                    {
                        lbluyari.Text = "Bu Admin Kaydı Sistemde Var!!";
                    }
                    else
                    {
                        karsilastiroku.Close();
                        musteriekle.ExecuteNonQuery();

                        lbluyari.Text = "Admin Kaydı Başarılı!";

                    }
                }
                else
                {
                    lbluyari.Text = "Girilen Parolalar Ayni Değil";
                }
            }
            else
            {
                lbluyari.Text = "Bütün Alanları Doldurunuuz";
            }


            baglanti.Close();
        }
    }
}