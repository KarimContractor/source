using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class abc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-VKTSVTO; database=societydata; user id=sa; password=123");
        SqlDataAdapter ad = new SqlDataAdapter("select *from usermst ",con);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
       
    }
}