using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using gclass;

public partial class LogReg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] != null)
            if (Request.Form["ctl00$userState"] == "(Logout)")
            {
                Session["userid"] = null;
                Session["playerid"] = null;
                Session["username"] = null;
            }
            else
                Response.Redirect("Uprofile.aspx");

        if (Request.Form["sendInfo"] == "Login")
        {
            try
            {
                int idp=login();
                logMsg.InnerText = "Login Successful, Welcome !";
                logMsg.Visible = true;
                Session["userid"] = idp;
                Session["username"] = Request.Form["luname"];
                Response.AppendHeader("Refresh", "1; url=Uprofile.aspx");
            }
            catch (Exception ex)
            {
                logMsg.InnerText = ex.Message;
                logMsg.Visible = true;
            }
        }
        if (Request.Form["sendInfo"] == "Register")
        {
            try
            {
                register();
                regMsg.InnerText = "Register Successful !";
                regMsg.Visible = true;
            }
            catch (Exception ex)
            {
                regMsg.InnerText = ex.Message;
                regMsg.Visible = true;
            }
        }
    }

    private void register()
    {
        if (Request.Form["rfname"].Length == 0)
            throw new Exception("First name is Required !");
        if (Request.Form["rlname"].Length == 0)
            throw new Exception("Last name is Required !");
        if (Request.Form["runame"].Length == 0)
            throw new Exception("Username is Required !");
        if (Request.Form["rpass"].Length < 6 || Request.Form["rpass"].Length >40)
            throw new Exception("Password must be 6-40 characters long !");
        if (Request.Form["rpass"] != Request.Form["rcpass"])
            throw new Exception("Password and Cofirm must match !");
        if (Request.Form["rmail"].Length == 0)
            throw new Exception("E-mail is Required !");
        if(validMail(Request.Form["rmail"])==false)
            throw new Exception("Invalid E-mail !");
        if (Request.Form["rsecq"].Length == 0)
            throw new Exception("Security question is Required !");
        if (Request.Form["rseca"].Length == 0)
            throw new Exception("Security answer is Required !");

        if(CT.serConn.State==ConnectionState.Closed)
            CT.serConn.Open();

        SqlCommand ntest = new SqlCommand("SELECT idp FROM users WHERE uname='" + Request.Form["runame"] + "'", CT.serConn);
        SqlDataReader rntest = ntest.ExecuteReader();
        if (rntest.HasRows)
        {
            rntest.Close();
            throw new Exception("User already exists !");
        }
        rntest.Close();

        SqlCommand reg = new SqlCommand("INSERT INTO users (uname, pass, fname, lname, email, secq, seca) VALUES ('" +
            Request.Form["runame"] + "','" + Request.Form["rpass"] + "','" + Request.Form["rfname"] + "','" + Request.Form["rlname"] + "','" + Request.Form["rmail"] + "','" + Request.Form["rsecq"] + "','" + Request.Form["rseca"] + "')", CT.serConn);
        reg.ExecuteNonQuery();
    }

    private int login()
    {
        if (Request.Form["luname"].Length == 0)
            throw new Exception("Username is Required !");
        if (Request.Form["lpass"].Length == 0)
            throw new Exception("Password is Required !");

        if (CT.serConn.State == ConnectionState.Closed)
            CT.serConn.Open();

        SqlCommand log = new SqlCommand("SELECT idp, pass FROM users WHERE uname='" + Request.Form["luname"] + "'", CT.serConn);
        SqlDataReader rlog = log.ExecuteReader();
        if (rlog.HasRows == false)
        {
            rlog.Close();
            throw new Exception("User does not exist !");
        }
        rlog.Read();
        if ((string)rlog["pass"] != Request.Form["lpass"])
        {
            rlog.Close();
            throw new Exception("Invalid password !");
        }
        int r = Convert.ToInt32(rlog["idp"]);
        rlog.Close();

        log = new SqlCommand("SELECT idp FROM players WHERE idp=" + r, CT.serConn);
        if (log.ExecuteScalar() != null)
            Session["playerid"] = r;

        return r;
    }

    private bool validMail(string emailaddress)
    {
        try
        {
            System.Net.Mail.MailAddress m = new System.Net.Mail.MailAddress(emailaddress);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
}