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
    public partial class Kiralamalar : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection("Data Source=THEODOREIV\\SQLEXPRESS;Initial Catalog=ASPOAKO;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            araclistele();
            ststpltutar();
            
        }

        void ststpltutar()
        {
            baglanti.Open();
            SqlCommand tplmtutar = new SqlCommand("select sum(ToplamTutar) from Satislar", baglanti);

            Label1.Text = "" + tplmtutar.ExecuteScalar();
            baglanti.Close();

        }
        public void araclistele()
        {

            baglanti.Open();
            SqlCommand aracgetir = new SqlCommand("select * from Satislar", baglanti);
            SqlDataAdapter araclistele = new SqlDataAdapter(aracgetir);
            DataSet ds = new DataSet();
            araclistele.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            baglanti.Close();
        }

    }
}