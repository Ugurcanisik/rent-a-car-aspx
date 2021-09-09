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
    
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblkarsilama.Text = "";

            lnkbtnadmnekle.Visible = false;
            lnkbtnaracekle.Visible = false;
            lnkaracguncelle.Visible = false;
            lnkbtnuyeguncelle.Visible = false;
            lnkbtnarackirala.Visible = false;
            lnkbtnkiraladıgınaraclar.Visible = false;
            lnkbtnsatislar.Visible = false;
            lnkbtnkirasuresiuzat.Visible = false;
            lnkbtnmusaitaraclar.Visible = false;
            lnkbtnmusteriler.Visible = false;
            lnkbtnkiradaolanarac.Visible = false;

            if (Session["kullanicigiris"] != null)
            {
                pnlgiris.Visible = false;
                pnlcikis.Visible = true;
                lnkbtnuyeguncelle.Visible = true;
                lnkbtnarackirala.Visible = true;
                lnkbtnkiraladıgınaraclar.Visible = true;
                lnkbtnkirasuresiuzat.Visible = true;
                lnkbtnmusaitaraclar.Visible = true;
                lblkarsilama.Text = "Hoşgeldin  " + Session["kullanicigiris"];



            }
            else if(Session["admingiris"]!=null)
            {
                lnkbtnuyeguncelle.Text = "Admin Guncelle";
                pnlgiris.Visible = false;
                pnlcikis.Visible = true;
                lnkbtnadmnekle.Visible = true;
                lnkbtnaracekle.Visible = true;
                lnkbtnsatislar.Visible = true;
                lnkaracguncelle.Visible = true;
                lnkbtnuyeguncelle.Visible = true;
                lnkbtnmusteriler.Visible = true;
                lnkbtnkiradaolanarac.Visible = true;
                lblkarsilama.Text = "Hoşgeldin Admin  " + Session["admingiris"];
            }
            else
            {
                pnlgiris.Visible = true;
                pnlcikis.Visible = false;
                lblkarsilama.Text = "giriş yapınız";
            }
        }

        
       
        protected void btnuye_Click(object sender, EventArgs e)
        {

            

            Response.Redirect("UyeOl2.aspx");



            

        }

    

        protected void btngiris_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=THEODOREIV\\SQLEXPRESS;Initial Catalog=ASPOAKO;Integrated Security=True");
            baglanti.Open();

            SqlCommand giris = new SqlCommand("select Eposta,Parola from Musteriler where Eposta=@Eposta and Parola=@Parola", baglanti);
            giris.Parameters.AddWithValue("@Eposta", txtepsadres.Text);
            giris.Parameters.AddWithValue("@Parola", txtparola.Text);
            SqlDataReader girisoku = giris.ExecuteReader();

            SqlCommand admin = new SqlCommand("select Eposta,Parola,Yonetici from Musteriler where Eposta=@Eposta and Parola=@Parola and Yonetici='True'", baglanti);
            admin.Parameters.AddWithValue("@Eposta", txtepsadres.Text);
            admin.Parameters.AddWithValue("@Parola", txtparola.Text);
            admin.Parameters.AddWithValue("@Yonetici", "True");
           

            if (txtepsadres.Text!="" && txtparola.Text!="")
            {
                if(girisoku.Read())
                {
                    girisoku.Close();
                    SqlDataReader adminoku = admin.ExecuteReader();
                    if (adminoku.Read())
                    {
                        Session.Add("admingiris", txtepsadres.Text);                     
                        Response.Redirect("Default.aspx");
                        Session.Timeout = 10;
                    }
                    else
                    {
                        Session.Add("kullanicigiris", txtepsadres.Text);
                        Response.Redirect("Default.aspx");
                        Session.Timeout = 10;
                    }
                }            
                else
                {
                    lblkarsilama.Text = "Kullanıcı adi veya şifre hatalı";
                }
            }
            else
            {
                lblkarsilama.Text = "Boş Alanları Doldurunuz";
            }
            baglanti.Close();             
            
        }

        protected void btncikis_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");        
        }

        protected void lnkbtnadmnekle_Click(object sender, EventArgs e)
        {
           

            Response.Redirect("UyeEkleAdmin.aspx");
        }
    }
}