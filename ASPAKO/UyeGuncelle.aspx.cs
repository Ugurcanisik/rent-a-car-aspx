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
    public partial class UyeGuncelle : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection("Data Source=THEODOREIV\\SQLEXPRESS;Initial Catalog=ASPOAKO;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            lbluyari.Text = "";
            
            if (!Page.IsPostBack)
            { 
                mustericek();
            }
        }
        string tc, adi, soyadi, telefon, eposta, adres, parola;
        private void mustericek()
        {
            if (Session["kullanicigiris"] != null)
            {
                baglanti.Open();

                SqlCommand musterigetir = new SqlCommand("select * from Musteriler where Eposta=@Eposta", baglanti);
                musterigetir.Parameters.AddWithValue("Eposta", Session["kullanicigiris"].ToString());

                SqlDataReader musterioku = musterigetir.ExecuteReader();

                if (musterioku.Read())
                {
                    txttc.Text = musterioku["TC"].ToString();                   
                    txtad.Text = musterioku["Adi"].ToString();                   
                    txtsoyad.Text = musterioku["Soyadi"].ToString();                  
                    txttelno.Text = musterioku["TelefonNumarasi"].ToString();                  
                    txteposta.Text = musterioku["Eposta"].ToString();                 
                    txtadres.Text = musterioku["Adres"].ToString();                 
                    txtparola.Text = musterioku["Parola"].ToString();                
                    txtparolatekrar.Text = txtparola.Text;

                    tc = txttc.Text;
                    adi = txtad.Text;
                    soyadi = txtsoyad.Text;
                    telefon = txttelno.Text;
                    eposta = txteposta.Text;
                    adres = txtadres.Text;
                    parola = txtparola.Text;
                }
                baglanti.Close();

                
            }
            else
            {
                if(Session["admingiris"] != null)
                {
                    baglanti.Open();

                    SqlCommand musterigetir = new SqlCommand("select * from Musteriler where Eposta=@Eposta", baglanti);
                    musterigetir.Parameters.AddWithValue("Eposta", Session["admingiris"].ToString());

                    SqlDataReader musterioku = musterigetir.ExecuteReader();

                    if (musterioku.Read())
                    {
                        txttc.Text = musterioku["TC"].ToString();                    
                        txtad.Text = musterioku["Adi"].ToString();                       
                        txtsoyad.Text = musterioku["Soyadi"].ToString();                      
                        txttelno.Text = musterioku["TelefonNumarasi"].ToString();                     
                        txteposta.Text = musterioku["Eposta"].ToString();                      
                        txtadres.Text = musterioku["Adres"].ToString();                     
                        txtparola.Text = musterioku["Parola"].ToString();                      
                        txtparolatekrar.Text = txtparola.Text;
                    }
                    baglanti.Close();

                    tc = txttc.Text;
                    adi = txtad.Text;
                    soyadi = txtsoyad.Text;
                    telefon = txttelno.Text;
                    eposta = txteposta.Text;
                    adres = txtadres.Text;
                    parola = txtparola.Text;

                }
                else
                {
                    lbluyari.Text = "GirişYapınız";
                }
            }
                
        }

        
        protected void btngucenlle_Click(object sender, EventArgs e)
        {
            if(Session["kullanicigiri"]!=null)
            {
                baglanti.Open();

                SqlCommand bilgial = new SqlCommand("select TC,TelefonNumarasi from Musteriler where Eposta=@Eposta", baglanti);
                bilgial.Parameters.AddWithValue("Eposta", Session["kullanicigiris"].ToString());

                SqlDataReader bilgioku = bilgial.ExecuteReader();
                if (txttc.Text != "" && txtad.Text != "" && txtsoyad.Text != "" && txttelno.Text != "" && txteposta.Text != "" && txtadres.Text != "" && txtparola.Text != "" && txtparolatekrar.Text != "")
                {
                    if (txttc.Text == tc && txtad.Text == adi && txtsoyad.Text == soyadi && txttelno.Text == telefon && txteposta.Text == eposta && txtadres.Text == adres && txtparola.Text == parola)
                    {
                        lbluyari.Text = "Bütün Veriler Aynı";
                    }
                    else
                    {
                        if (txttc.Text.Count() == 11)
                        {
                            if (txttelno.Text.Count() == 11)
                            {
                                if (txtparola.Text == txtparolatekrar.Text)
                                {
                                    if (bilgioku.Read())
                                    {
                                        if (txttc.Text == bilgioku["TC"].ToString())
                                        {
                                            bilgioku.Close();
                                            lbluyari.Text = "TC ler Aynı";
                                            SqlCommand uyeguncelle = new SqlCommand("MusteriGuncelle", baglanti);
                                            uyeguncelle.CommandType = CommandType.StoredProcedure;
                                            uyeguncelle.Parameters.AddWithValue("@TC", txttc.Text);
                                            uyeguncelle.Parameters.AddWithValue("@Adi", txtad.Text);
                                            uyeguncelle.Parameters.AddWithValue("@Soyadi", txtsoyad.Text);
                                            uyeguncelle.Parameters.AddWithValue("@TelefonNumarasi", txttelno.Text);
                                            uyeguncelle.Parameters.AddWithValue("@Eposta", txteposta.Text);
                                            uyeguncelle.Parameters.AddWithValue("@Adres", txtadres.Text);
                                            uyeguncelle.Parameters.AddWithValue("@Parola", txtparola.Text);

                                            uyeguncelle.ExecuteNonQuery();
                                            lbluyari.Text = "Güncelleme Başarılı";

                                        }
                                        else if (txttelno.Text == bilgioku["TelefonNumarasi"].ToString())
                                        {

                                            bilgioku.Close();
                                            lbluyari.Text = "Telefon Numarasi Aynı";
                                            SqlCommand uyeguncelle = new SqlCommand("MusteritcGuncelle", baglanti);
                                            uyeguncelle.CommandType = CommandType.StoredProcedure;
                                            uyeguncelle.Parameters.AddWithValue("@TC", txttc.Text);
                                            uyeguncelle.Parameters.AddWithValue("@Adi", txtad.Text);
                                            uyeguncelle.Parameters.AddWithValue("@Soyadi", txtsoyad.Text);
                                            uyeguncelle.Parameters.AddWithValue("@TelefonNumarasi", txttelno.Text);
                                            uyeguncelle.Parameters.AddWithValue("@Eposta", txteposta.Text);
                                            uyeguncelle.Parameters.AddWithValue("@Adres", txtadres.Text);
                                            uyeguncelle.Parameters.AddWithValue("@Parola", txtparola.Text);
                                            uyeguncelle.ExecuteNonQuery();
                                            lbluyari.Text = "Güncelleme Başarılı";

                                        }
                                    }
                                }
                                else
                                {
                                    lbluyari.Text = "Parolalar Aynı değil";
                                }
                            }
                            else
                            {
                                lbluyari.Text = "Telefon Numarası 11 hane olmalıdır";
                            }
                        }
                        else
                        {
                            lbluyari.Text = "TC 11 Hane Olmalıdır";
                        }
                    }
                }
                else
                {
                    lbluyari.Text = "bütün alanları doldurunuz";
                }
                baglanti.Close();
            }
            else if(Session["admingiris"]!=null)
            {
                baglanti.Open();

                SqlCommand bilgial = new SqlCommand("select TC,TelefonNumarasi from Musteriler where Eposta=@Eposta", baglanti);
                bilgial.Parameters.AddWithValue("Eposta", Session["admingiris"].ToString());

                SqlDataReader bilgioku = bilgial.ExecuteReader();
                if (txttc.Text != "" && txtad.Text != "" && txtsoyad.Text != "" && txttelno.Text != "" && txteposta.Text != "" && txtadres.Text != "" && txtparola.Text != "" && txtparolatekrar.Text != "")
                {
                    if (txttc.Text == tc && txtad.Text == adi && txtsoyad.Text == soyadi && txttelno.Text == telefon && txteposta.Text == eposta && txtadres.Text == adres && txtparola.Text == parola)
                    {
                        lbluyari.Text = "Bütün Veriler Aynı";
                    }
                    else
                    {
                        if (txttc.Text.Count() == 11)
                        {
                            if (txttelno.Text.Count() == 11)
                            {
                                if (txtparola.Text == txtparolatekrar.Text)
                                {
                                    if (bilgioku.Read())
                                    {
                                        if (txttc.Text == bilgioku["TC"].ToString())
                                        {
                                            bilgioku.Close();
                                            lbluyari.Text = "TC ler Aynı";
                                            SqlCommand uyeguncelle = new SqlCommand("MusteriGuncelle", baglanti);
                                            uyeguncelle.CommandType = CommandType.StoredProcedure;
                                            uyeguncelle.Parameters.AddWithValue("@TC", txttc.Text);
                                            uyeguncelle.Parameters.AddWithValue("@Adi", txtad.Text);
                                            uyeguncelle.Parameters.AddWithValue("@Soyadi", txtsoyad.Text);
                                            uyeguncelle.Parameters.AddWithValue("@TelefonNumarasi", txttelno.Text);
                                            uyeguncelle.Parameters.AddWithValue("@Eposta", txteposta.Text);
                                            uyeguncelle.Parameters.AddWithValue("@Adres", txtadres.Text);
                                            uyeguncelle.Parameters.AddWithValue("@Parola", txtparola.Text);

                                            uyeguncelle.ExecuteNonQuery();
                                            lbluyari.Text = "Güncelleme Başarılı";

                                        }
                                        else if (txttelno.Text == bilgioku["TelefonNumarasi"].ToString())
                                        {

                                            bilgioku.Close();
                                            lbluyari.Text = "Telefon Numarasi Aynı";
                                            SqlCommand uyeguncelle = new SqlCommand("MusteritcGuncelle", baglanti);
                                            uyeguncelle.CommandType = CommandType.StoredProcedure;
                                            uyeguncelle.Parameters.AddWithValue("@TC", txttc.Text);
                                            uyeguncelle.Parameters.AddWithValue("@Adi", txtad.Text);
                                            uyeguncelle.Parameters.AddWithValue("@Soyadi", txtsoyad.Text);
                                            uyeguncelle.Parameters.AddWithValue("@TelefonNumarasi", txttelno.Text);
                                            uyeguncelle.Parameters.AddWithValue("@Eposta", txteposta.Text);
                                            uyeguncelle.Parameters.AddWithValue("@Adres", txtadres.Text);
                                            uyeguncelle.Parameters.AddWithValue("@Parola", txtparola.Text);
                                            uyeguncelle.ExecuteNonQuery();
                                            lbluyari.Text = "Güncelleme Başarılı";

                                        }
                                    }
                                }
                                else
                                {
                                    lbluyari.Text = "Parolalar Aynı değil";
                                }
                            }
                            else
                            {
                                lbluyari.Text = "Telefon Numarası 11 hane olmalıdır";
                            }
                        }
                        else
                        {
                            lbluyari.Text = "TC 11 Hane Olmalıdır";
                        }
                    }
                }
                else
                {
                    lbluyari.Text = "bütün alanları doldurunuz";
                }
                baglanti.Close();
            }          
        }




        


























    }
}