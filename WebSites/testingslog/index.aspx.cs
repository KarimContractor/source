using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class index : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Server=DESKTOP-VKTSVTO; database=testing; user id=sa; password=123");
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        DataTable dt = new DataTable();
        SqlDataAdapter ad=new SqlDataAdapter("Select * from logins where Username='"+txtuser.Text+"' and password='"+txtpass.Text+"' ",con);
        ad.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Session["Userid"] = dt.Rows[0][0];
            Response.Redirect("Dashboard.aspx");
        }
        else
        {
            Response.Write("Invalid Login Information");
        }
    }
}