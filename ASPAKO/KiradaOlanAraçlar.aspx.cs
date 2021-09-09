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
    public partial class KiradaOlanAraçlar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            kiradaolanarac();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=THEODOREIV\\SQLEXPRESS;Initial Catalog=ASPOAKO;Integrated Security=True");

        public void kiradaolanarac()
        {

            baglanti.Open();
            SqlCommand aracgetir = new SqlCommand("select Plaka,Marka,Model,Seri,TC,Adi,Soyadi,Eposta,TelefonNumarasi,AlisTarihi,TeslimTarihi,ToplamTutar,ToplamGun from Sozlesmeler where  Silindimi='False'", baglanti);
            SqlDataAdapter araclistele = new SqlDataAdapter(aracgetir);
            DataSet ds = new DataSet();
            araclistele.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            baglanti.Close();
        }


    }
}