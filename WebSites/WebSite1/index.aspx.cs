using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class index : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Server=DESKTOP-VKTSVTO; database=societydata; user id=sa; password=123");
    protected void Page_Load(object sender, EventArgs e)
    {
           }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("select * from usermst where username='"+txtuser.Text+"'and password='"+txtpass.Text+"'",con);
        con.Open();
       SqlDataReader RD= cmd.ExecuteReader();
        
        if (RD.HasRows)
        {
            
            System.Threading.Thread.Sleep(5000);
            Response.Redirect("abc.aspx");
        }
    }

    
}