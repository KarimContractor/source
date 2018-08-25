using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Library
{
    public partial class Home : System.Web.UI.Page
    {
        ELibraryEntities eL = new ELibraryEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var a = (from abc in eL.Admins where abc.UserName.Equals(TXTUSER.Text) && abc.Password.Equals(TXTPASS.Text) && abc.status.Equals("Active") select abc).FirstOrDefault();
            var b = (from abc in eL.memberinfoes where abc.UserName.Equals(TXTUSER.Text) && abc.Password.Equals(TXTPASS.Text) && abc.status.Equals("Active") select abc).FirstOrDefault();
            if (a != null)
            {
                Response.Redirect("Adminpage.aspx?userid=" + a.UserName);

            }
            else if (b != null)
            {
                Response.Redirect("Memberpage.aspx?userid=" + b.UserName);
            }
            else
            {
                Response.Write("Error");
            }
        }
    }
}