using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using gclass;

public partial class Game : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] == null)
            Response.Redirect("LogReg.aspx");
        else if (Session["playerid"] == null)
            Response.Redirect("GCrProfile.aspx");
        if (!IsPostBack)
        {
            Session["selzoneid"] = labelAll.Text;
            Session["view"] = "p-0";

            outMoveSource.SelectCommand = "SELECT m.idm, zs.name as zsname, m.iatk, zd.name as zdname, m.edate-GETDATE() as edate FROM movements m, zones zs, zones zd WHERE m.idzs=zs.idz AND m.idzd=zd.idz AND zs.idp=" + Session["playerid"];
            inMoveSource.SelectCommand = "SELECT m.idm, zs.name as zsname, m.iatk, zd.name as zdname, m.edate-GETDATE() as edate FROM movements m, zones zs, zones zd WHERE m.idzs=zs.idz AND m.idzd=zd.idz AND zd.idp=" + Session["playerid"];
            trainSource.SelectCommand = "SELECT t.idt, z.name, t.unit, t.edate-GETDATE() as edate FROM trainings t, zones z WHERE t.idz=z.idz AND z.idp=" + Session["playerid"];
            pDisplay("0");
        }
    }

    protected void zoneSelect(object sender, EventArgs e)
    {
        foreach (GridViewRow gr in zoneControl.Rows)
        {
            if (gr.Cells[2].Controls[0] == sender)
                Session["selzoneid"] = (gr.Cells[2].Controls[1] as Label).Text;
            (gr.Cells[2].Controls[0] as RadioButton).Checked = false;
        }
        if (sender == radioAll)
        {
            radioAll.Checked = true;
            Session["selzoneid"] = labelAll.Text;
            outMoveSource.SelectCommand = "SELECT m.idm, zs.name as zsname, m.iatk, zd.name as zdname, m.edate-GETDATE() as edate FROM movements m, zones zs, zones zd WHERE m.idzs=zs.idz AND m.idzd=zd.idz AND zs.idp=" + Session["playerid"];
            inMoveSource.SelectCommand = "SELECT m.idm, zs.name as zsname, m.iatk, zd.name as zdname, m.edate-GETDATE() as edate FROM movements m, zones zs, zones zd WHERE m.idzs=zs.idz AND m.idzd=zd.idz AND zd.idp=" + Session["playerid"];
            trainSource.SelectCommand = "SELECT t.idt, z.name, t.unit, t.edate-GETDATE() as edate FROM trainings t, zones z WHERE t.idz=z.idz AND z.idp=" + Session["playerid"];

            lp.Text = "?";
            lw.Text = "?";
            ld.Text = "?";
            lb.Text = "?";
            lc.Text = "?";
            ls.Text = "?";
            bSend.Enabled = false;
        }
        else
        {
            radioAll.Checked = false;
            (sender as RadioButton).Checked = true;

            if (CT.serConn.State == ConnectionState.Closed)
                CT.serConn.Open();

            SqlCommand cm = new SqlCommand("SELECT z.idp, l.nrp, l.nrw, l.nrd, l.nrb, l.nrc, l.nrs FROM ulists l, zones z WHERE z.idz=" + Session["selzoneid"] + " AND z.idl=l.idl", CT.serConn);
            SqlDataReader dr = cm.ExecuteReader();
            dr.Read();
            lp.Text = "" + dr["nrp"];
            lw.Text = "" + dr["nrw"];
            ld.Text = "" + dr["nrd"];
            lb.Text = "" + dr["nrb"];
            lc.Text = "" + dr["nrc"];
            ls.Text = "" + dr["nrs"];
            bSend.Enabled = true;

            dr.Close();
        }
    }

    protected void zoneDisplay(object sender, EventArgs e)
    {
        if (CT.serConn.State == ConnectionState.Closed)
            CT.serConn.Open();

        SqlCommand cm = new SqlCommand("SELECT name, x, y, idp, idl, hp FROM zones WHERE idz=" + (sender as LinkButton).CommandArgument, CT.serConn);
        SqlDataReader dr = cm.ExecuteReader();
        dr.Read();
        viewImg.ImageUrl = "~/Images/ztown.jpeg";
        lTitle1.Text = "(" + dr["x"] + "," + dr["y"] + ") " + dr["name"];
        lTitle2.Text = "Health: " + dr["hp"];
        ulistSource.SelectCommand += " WHERE idl=" + ((dr["idl"] == DBNull.Value) ? "19" : dr["idl"]);
        if (dr["idp"] == System.DBNull.Value)
        {
            lOwner.Text = "Neutral";
            dr.Close();
        }
        else
        {
            lOwner.CommandArgument = dr["idp"].ToString();
            cm = new SqlCommand("SELECT name FROM players WHERE idp=" + dr["idp"], CT.serConn);
            dr.Close();
            lOwner.Text = "Owner: " + cm.ExecuteScalar();
        }

        Session["view"]="z-"+(sender as LinkButton).CommandArgument;
        setCommands();
    }

    protected void moveDisplay(object sender, EventArgs e)
    {
        if (CT.serConn.State == ConnectionState.Closed)
            CT.serConn.Open();

        SqlCommand cm = new SqlCommand("SELECT iatk, edate, zs.name as zsname, zs.x as zsx, zs.y as zsy, zd.name as zdname, zd.x as zdx, zd.y as zdy, m.idl as idl  FROM movements m, zones zs, zones zd WHERE idzs=zs.idz AND idzd=zd.idz AND idm=" + (sender as LinkButton).CommandArgument, CT.serConn);
        SqlDataReader dr = cm.ExecuteReader();
        dr.Read();
        if(Convert.ToBoolean(dr["iatk"])==true)
            viewImg.ImageUrl = "~/Images/atack.png";
        else
            viewImg.ImageUrl = "~/Images/support.png";
        lTitle1.Text = "(" + dr["zsx"] + "," + dr["zsy"] + ") " + dr["zsname"];
        lTitle2.Text = "(" + dr["zdx"] + "," + dr["zdy"] + ") " + dr["zdname"];
        //date
        ulistSource.SelectCommand += " WHERE idl=" + dr["idl"];
        dr.Close();

        Session["view"] = "m-" + (sender as LinkButton).CommandArgument;
        setCommands();
    }

    protected void profileDisplay(object sender, EventArgs e)
    {
        pDisplay((sender as LinkButton).CommandArgument);
    }
    private void pDisplay(string idp)
    {
        if (CT.serConn.State == ConnectionState.Closed)
            CT.serConn.Open();

        SqlCommand cm = new SqlCommand("SELECT p.name, p.exp, COUNT(z.idz) as zonenr FROM players p, zones z WHERE z.idp=p.idp AND p.idp=" + (idp == "0" ? Session["playerid"].ToString() : idp) + " GROUP BY p.name, p.exp", CT.serConn);
        SqlDataReader dr = cm.ExecuteReader();
        dr.Read();
        viewImg.ImageUrl = "~/Images/defavatar.png";
        lTitle1.Text = "Experience: "+ dr["exp"];
        lTitle2.Text = "Zones owned: " + dr["zonenr"];
        lOwner.Text = (string)dr["name"];
        ulistSource.SelectCommand = "SELECT z.idp as idl, SUM(l.nrp) as nrp, SUM(l.nrw) as nrw, SUM(l.nrd) as nrd, SUM(l.nrb) as nrb, SUM(l.nrc) as nrc, SUM(l.nrs) as nrs FROM ulists l, zones z WHERE z.idl=l.idl AND z.idp=" + (idp == "0" ? Session["playerid"].ToString() : idp) + " GROUP BY z.idp";
        dr.Close();

        Session["view"] = "p-" + idp;
        setCommands();
    }

    protected void rowManage(object sender, GridViewRowEventArgs e)
    {
        if (sender == outMoveControl)
            foreach (GridViewRow gr in outMoveControl.Rows)
                if ((gr.Cells[1].Controls[0] as Image).AlternateText == "False")
                    (gr.Cells[1].Controls[0] as Image).ImageUrl = "~/Images/drgreen.png";

        if (sender == inMoveControl)
            foreach (GridViewRow gr in inMoveControl.Rows)
                if ((gr.Cells[1].Controls[0] as Image).AlternateText == "False")
                    (gr.Cells[1].Controls[0] as Image).ImageUrl = "~/Images/stgreen.png";
    }

    private void setCommands()
    {
        switch (((string)Session["view"]).Split('-')[0])
        {
            case "z":
                tdeclare.Visible = false;
                tsend.Visible = true;
                if (lOwner.CommandArgument == Session["playerid"].ToString())
                    bSend.Text = "Support";
                else
                    bSend.Text = "Atack";
                break;
            case "p":
                tdeclare.Visible = true;
                tsend.Visible = false;
                break;
            default:
                tdeclare.Visible = false;
                tsend.Visible = false;
                break;
        }
    }

    protected void pl_viewZone(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(pl_tbx.Text) < 1 || Convert.ToInt32(pl_tbx.Text) > CT.mapX)
                throw new Exception("Invalid X coord !");
            if (Convert.ToInt32(pl_tby.Text) < 1 || Convert.ToInt32(pl_tby.Text) > CT.mapX)
                throw new Exception("Invalid X coord !");

            if (CT.serConn.State == ConnectionState.Closed)
                CT.serConn.Open();

            SqlCommand cm = new SqlCommand("SELECT idz FROM zones WHERE x=" + pl_tbx.Text + " AND y=" + pl_tby.Text, CT.serConn);
            string idz = Convert.ToString(cm.ExecuteScalar());
            if (idz == "")
                throw new Exception("Zone not found!");
            (sender as LinkButton).CommandArgument = idz;

            zoneDisplay(sender, e);
        }
        catch (Exception ex)
        {
            pl_selmsg.Text = ex.Message;
        }
    }
    protected void pl_viewPlayer(object sender, EventArgs e)
    {
        try
        {
            if (pl_tbname.Text.Length < 1 || pl_tbname.Text.Length > 30)
                throw new Exception("Invalid player name !");

            if (CT.serConn.State == ConnectionState.Closed)
                CT.serConn.Open();

            SqlCommand cm = new SqlCommand("SELECT idp FROM players WHERE name='" + pl_tbname.Text + "'", CT.serConn);
            string idp = Convert.ToString(cm.ExecuteScalar());
            if (idp == "")
                throw new Exception("Player not found!");

            pDisplay(idp);
        }
        catch (Exception ex)
        {
            pl_selmsg.Text = ex.Message;
        }
    }
    protected void sendTroops(object sender, EventArgs e)
    {
        if (CT.serConn.State == ConnectionState.Closed)
            CT.serConn.Open();

        int np=Convert.ToInt32(tbp.Text);
        if (Convert.ToInt32(lp.Text) < np || np < 0)
            throw new Exception("Unit number out of range !");
        int nw = Convert.ToInt32(tbw.Text);
        if (Convert.ToInt32(lw.Text) < nw || nw < 0)
            throw new Exception("Unit number out of range !");
        int nd = Convert.ToInt32(tbd.Text);
        if (Convert.ToInt32(ld.Text) < nd || nd < 0)
            throw new Exception("Unit number out of range !");
        int nb = Convert.ToInt32(tbb.Text);
        if (Convert.ToInt32(lb.Text) < nb || nb < 0)
            throw new Exception("Unit number out of range !");
        int nc = Convert.ToInt32(tbc.Text);
        if (Convert.ToInt32(lc.Text) < nc || nc < 0)
            throw new Exception("Unit number out of range !");
        int ns = Convert.ToInt32(tbs.Text);
        if (Convert.ToInt32(ls.Text) < ns || ns < 0)
            throw new Exception("Unit number out of range !");
        if (np + nw + nd + nb + nc + ns == 0)
            throw new Exception("No units selected !");

        SqlCommand cm = new SqlCommand("INSERT INTO ulists VALUES(" + np + ", " + nw + ", " + nd + ", " + nb + ", " + nc + ", " + ns + ")", CT.serConn);
        cm.ExecuteNonQuery();
        cm = new SqlCommand("SELECT @@IDENTITY", CT.serConn);
        int idl = Convert.ToInt32(cm.ExecuteScalar());

        cm = new SqlCommand("UPDATE ulists SET nrp=nrp-" + np + ", nrw=nrw-" + nw + ", nrd=nrd-" + nd + ", nrb=nrb-" + nb + ", nrc=nrc-" + nc + ", nrs=nrs-" + ns + " WHERE idl=(SELECT idl FROM zones WHERE idz=" + Session["selzoneid"] + ")", CT.serConn);
        cm.ExecuteNonQuery();
    }
}