using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using gclass;

public partial class GCrProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] == null)
            Response.Redirect("LogReg.aspx");
        else if (Session["playerid"] != null)
            Response.Redirect("Game.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (tbpname.Text.Length == 0)
            throw new Exception("Player Name is Required !");
        if (tbzname.Text.Length == 0)
            throw new Exception("Starting Zone Name is Required !");

        if (CT.serConn.State == ConnectionState.Closed)
            CT.serConn.Open();

        SqlCommand cm = new SqlCommand("SELECT idz FROM zones WHERE idp IS NULL", CT.serConn);
        SqlDataReader dr = cm.ExecuteReader();
        if (!dr.HasRows)
            throw new Exception("There are no unclaimed zones on the map !");
        cm = new SqlCommand("SELECT idp FROM players WHERE name=" + tbpname.Text, CT.serConn);
        if (cm.ExecuteScalar() != null)
            throw new Exception("Name already exists !");

        List<int> idzu = new List<int>();
        while (dr.Read())
            idzu.Add(Convert.ToInt32(dr["idz"]));
        dr.Close();
        int idz = idzu[new Random().Next(idzu.Count)];

        cm = new SqlCommand("INSERT INTO players(idp, name, exp) VALUES(" + Session["userid"] + ",'" + tbpname.Text + "',0)", CT.serConn);
        cm.ExecuteNonQuery();
        Session["playerid"]=Session["userid"];

        cm = new SqlCommand("INSERT INTO ulists VALUES(0,0,0,0,0,0)", CT.serConn);
        cm.ExecuteNonQuery();

        cm = new SqlCommand("SELECT @@IDENTITY", CT.serConn);
        int idl=Convert.ToInt32(cm.ExecuteScalar());
        cm = new SqlCommand("UPDATE zones SET idp=" + Session["playerid"] + ", name='" + tbzname.Text + "', hp=100, idl=" + idl + " WHERE idz=" + idz, CT.serConn);
        cm.ExecuteNonQuery();

        Response.Redirect("Game.aspx");
    }
}