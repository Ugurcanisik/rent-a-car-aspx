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
    public partial class MusaitAraclar : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection("Data Source=THEODOREIV\\SQLEXPRESS;Initial Catalog=ASPOAKO;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            araclistele();
        }


        public void araclistele()
        {

            baglanti.Open();
            SqlCommand aracgetir = new SqlCommand("select Plaka,Marka,Seri,Model,VitesTipi,YakitTipi,KM,Renk,FiyatiG,FiyatiH,FiyatiA,Durumu from Araclar where Silindimi='False' and Durumu='Musait'", baglanti);
            SqlDataAdapter araclistele = new SqlDataAdapter(aracgetir);
            DataSet ds = new DataSet();
            araclistele.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            baglanti.Close();
        }

    }



   

}