using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Dashboard : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection("Server=DESKTOP-VKTSVTO; database=testing; user id=sa; password=123");
    protected void Page_Load(object sender, EventArgs e)
    {

      var a= Session["Userid"];
        DataTable dt = new DataTable();
        SqlDataAdapter ad = new SqlDataAdapter("Select * from logins where id="+Convert.ToInt32(a)+"", con);
        ad.Fill(dt);
       String ro= dt.Rows[0][3].ToString();
        if (ro == "Admin")
        {
            btnAdmin.Visible = true;
            btnEmp.Visible = true;
            btnv.Visible = true;
        }
        else if (ro == "Employee")
        {
            btnAdmin.Visible = false;
            btnEmp.Visible = true;
            btnv.Visible = true;
        }
        else if (ro == "Visitor")
        {
            btnAdmin.Visible = false;
            btnEmp.Visible = false;
            btnv.Visible = true;
        }



    }
}