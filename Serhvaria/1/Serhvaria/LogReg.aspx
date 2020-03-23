<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogReg.aspx.cs" Inherits="LogReg" MasterPageFile="~/serMaster.master" %>

<asp:Content ID="contentLogReg" ContentPlaceHolderID="mainBody" Runat="Server">
<table width="1200">

<tr><td colspan="2" align="center">Warning !!!</td></tr>
<tr>

<td width="600" align="center">
    <form method="post" id="loginForm" action="LogReg.aspx">
    <table>
        <tr>
            <td dir="rtl">Username</td>
            <td><input name="luname" type="text" maxlength="30" size="30" /></td>
        </tr>
        <tr>
            <td dir="rtl">Password</td>
            <td><input name="lpass" type="password" maxlength="40" size="30" /></td>
        </tr>
        <tr><td colspan="2" align="center"><input name="sendInfo" type="submit" value="Login" /></td></tr>
    </table>
    <br /><span ID="logMsg" runat="server" visible="False">Login message report</span>
    </form>
</td>

<td width="600" align="center">
    <form method="post" id="registerForm" action="LogReg.aspx">
    <table>
        <tr>
            <td dir="rtl">First Name</td>
            <td><input name="rfname" type="text" maxlength="15" size="30" /></td>
        </tr>
        <tr>
            <td dir="rtl">Last Name</td>
            <td><input name="rlname" type="text" maxlength="15" size="30" /></td>
        </tr>
        <tr>
            <td dir="rtl">Username</td>
            <td><input name="runame" type="text" maxlength="30" size="30" /></td>
        </tr>
        <tr>
            <td dir="rtl">Password</td>
            <td><input name="rpass" type="password" maxlength="40" size="30" /></td>
        </tr>
        <tr>
            <td dir="rtl">Confirm</td>
            <td><input name="rcpass" type="password" maxlength="40" size="30" /></td>
        </tr>
        <tr>
            <td dir="rtl">Email</td>
            <td><input name="rmail" type="text" maxlength="30" size="30" /></td>
        </tr>
        <tr>
            <td dir="rtl">Security Question</td>
            <td><input name="rsecq" type="text" maxlength="100" size="30" /></td>
        </tr>
        <tr>
            <td dir="rtl">Security Answer</td>
            <td><input name="rseca" type="text" maxlength="20" size="30" /></td>
        </tr>
        <tr><td colspan="2" align="center"><input name="sendInfo" type="submit" value="Register" /></td></tr>
    </table>
    <br /><span ID="regMsg" runat="server" visible="False">Register message report</span>
    </form>
</td>

</tr>
</table>
</asp:Content>