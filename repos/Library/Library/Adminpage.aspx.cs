using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;


namespace Library
{
    public partial class Adminpage : System.Web.UI.Page
    {
        
        ELibraryEntities el = new ELibraryEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            lbltime.Text = System.DateTime.Now.ToString();
            
           var a= Request.QueryString["userid"];
            if (a == null)
            {
                Response.Redirect("Home.aspx");

            } 
            else
            {
                SqlConnection con = new SqlConnection(@"Server=DESKTOP-VKTSVTO; database=ELibrary; user id=sa; password=123");
                con.Open();
                
                SqlDataAdapter ad = new SqlDataAdapter("select * from memberinfo",con);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                ad.Fill(ds);
                ad.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                //GridView1.Columns
                if (!IsPostBack)
                {
                    DropDownList1.DataSource = ds.Tables[0];
                    DropDownList1.DataTextField = "Name";
                    DropDownList1.DataValueField = "Name";
                   
                    DropDownList1.DataBind();
                }
            }
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {

            memberinfo msm = new memberinfo()
            {

                Name = TXTNAME.Text,
                UserName = TXTUSERNAME.Text,
                Password = TXTPASSWORD.Text,
                status = TXTSTATUS.Text
                
            };
            el.memberinfoes.Add(msm);
            el.SaveChanges();
            Page_Load(sender, e);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           
                var a = (from li in el.memberinfoes where li.Name.Equals((DropDownList1.SelectedValue)) select li).FirstOrDefault();
                if (a != null)
                {
                TXTNAME.Text = TXTPASSWORD.Text = TXTSTATUS.Text = TXTUSERNAME.Text = "";
                    TXTNAME.Text = a.Name;
                    TXTPASSWORD.Text = a.Password;
                    TXTUSERNAME.Text = a.UserName;
                    TXTSTATUS.Text = a.status;
                }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var a = (from li in el.memberinfoes where li.Name.Equals(DropDownList1.SelectedValue) select li).FirstOrDefault();
            if (a != null)
            {
                a.Name = TXTNAME.Text;
                a.UserName = TXTUSERNAME.Text;
                a.Password = TXTPASSWORD.Text;
                a.status = TXTSTATUS.Text;
                
                
            }
            
            el.SaveChanges();
            Page_Load( sender, e);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            var a = (from li in el.memberinfoes where li.Name.Equals(DropDownList1.SelectedValue) select li).FirstOrDefault();
            if (a != null)
            {
                el.memberinfoes.Remove(a);
                

            }

            el.SaveChanges();
            Page_Load(sender, e);
        }
    }
}