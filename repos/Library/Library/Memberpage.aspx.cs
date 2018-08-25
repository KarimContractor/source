using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Library;


namespace Library
{
    public partial class Memberpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //FileStream fs = new FileStream("Books/",FileMode.Open,FileAccess.Read);

            var ts=Directory.GetFiles("Books/");
            // DropDownList1.Items.Add(ts.ToString());
            Label1.Text = ts.ToString();
            foreach(var ar in ts)
            {
                DropDownList1.Items.Add(ar);

            }
            
               
        }
    }
}