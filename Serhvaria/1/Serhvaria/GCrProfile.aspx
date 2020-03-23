<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GCrProfile.aspx.cs" Inherits="GCrProfile" MasterPageFile="~/serMaster.master" %>

<asp:Content ID="contentGCrProfile" ContentPlaceHolderID="mainBody" Runat="Server">
<form id="form1" runat="server">

    <asp:Label ID="gcrWarning" runat="server" 
        Text="WARNING: Once you choose these values you Cannot change them !"></asp:Label><br /><br />

    <table>
        <tr>
            <td><asp:Label runat="server" Text="Player Name"></asp:Label></td>
            <td><asp:TextBox ID="tbpname" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label runat="server" Text="Zone Name"></asp:Label></td>
            <td><asp:TextBox ID="tbzname" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="Button1" runat="server" Text="Create Game Profile" 
                    onclick="Button1_Click" /></td>
        </tr>
    </table>

</form>
</asp:Content>