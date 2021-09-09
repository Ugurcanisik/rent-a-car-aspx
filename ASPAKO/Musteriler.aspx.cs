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
    public partial class Musteriler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = "";
            musterilistele();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=THEODOREIV\\SQLEXPRESS;Initial Catalog=ASPOAKO;Integrated Security=True");
        public void musterilistele()
        {

            baglanti.Open();
            SqlCommand aracgetir = new SqlCommand("select TC,Adi,Soyadi,TelefonNumarasi,Eposta,Adres from Musteriler where Yonetici='False' and Silindimi='False'", baglanti);
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
            txttc.Text= row.Cells[1].Text;
        }

        protected void btnsil_Click(object sender, EventArgs e)
        {
            if(GridView1.Rows.Count==0)
            {
                Label2.Text = "Musteri Ekleyiniz";
            }
            else
            { 
            if(txttc.Text!="")
            {
                baglanti.Open();

                SqlCommand musterisil = new SqlCommand("update Musteriler set Silindimi=@Silindimi where TC=@TC", baglanti);
                musterisil.Parameters.AddWithValue("@Silindimi", "True");
                musterisil.Parameters.AddWithValue("@TC", txttc.Text);

                musterisil.ExecuteNonQuery();
                Label2.Text = "Musteri silindi";
                
                baglanti.Close();
                musterilistele();
                txttc.Text = "";
            }
            else
            {
                Label2.Text = "Müşteri Seçiniz";
            }
            }
        }

    }
}