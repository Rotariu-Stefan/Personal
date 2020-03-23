using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class serMaster : System.Web.UI.MasterPage
{
    public static string output;

    protected void Page_Load(object sender, EventArgs e)
    {
        lOut.Text = output;
        if (Session["userid"] == null)
        {
            userName.InnerText = "Guest";
            userState.Value = "(Login/Register)";
        }
        else
        {
            userName.InnerText = (string)Session["username"];
            userState.Value = "(Logout)";
        }
    }

    protected void logStateChange(Object sender, EventArgs e)
    {
        if (Session["userid"] != null)
            Session["userid"] = null;
        Response.Redirect("LogReg.aspx");
    }
}
