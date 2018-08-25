using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        if (Menu1.SelectedValue == "Country")
        {
            MultiView1.ActiveViewIndex = 0;
        }
        else if (Menu1.SelectedValue == "State")
        {
            MultiView1.ActiveViewIndex = 1;
        }
        else if (Menu1.SelectedValue == "City")
        {
            MultiView1.ActiveViewIndex = 2;
        }
        else if (Menu1.SelectedValue == "Account")
        {
            MultiView1.ActiveViewIndex = 3;
        }

    }

    protected void btncountry_Click(object sender, EventArgs e)
    {

    }
}