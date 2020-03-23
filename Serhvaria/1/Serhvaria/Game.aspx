<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Game.aspx.cs" Inherits="Game" MasterPageFile="~/serMaster.master" %>

<asp:Content ID="contentGame" ContentPlaceHolderID="mainBody" Runat="Server">
    <form id="form1" runat="server">

    <table id="pl_tselect">
    <tr>
        <td>
            View Zone-->X:<asp:TextBox ID="pl_tbx" runat="server" Width="70px" MaxLength="2"></asp:TextBox>, Y<asp:TextBox ID="pl_tby" runat="server" Width="70px" MaxLength="2"></asp:TextBox>
            <asp:LinkButton OnClick="pl_viewZone" ID="pl_bselz" runat="server" Text="View" CommandArgument="0" /><br />
        </td>
    </tr>
    <tr>
        <td>
            View Player-->Name:<asp:TextBox ID="pl_tbname" runat="server" MaxLength="30"></asp:TextBox>
            <asp:LinkButton OnClick="pl_viewPlayer" ID="pl_bselp" runat="server" Text="View" CommandArgument="0" />
        </td>
    </tr>
    <tr><td><asp:Label id="pl_selmsg" runat="server" Text="" /></td></tr>
    </table>

<table style="width: 1200px; height:700px">

<tr style="height: 350px">

<td style="width: 300px">
    <div id="dAll">
        <asp:RadioButton id="radioAll" AutoPostBack="true" runat="server" Text="All" OnCheckedChanged ="zoneSelect" Checked="true" />
        <asp:Label Visible="false" id="labelAll" runat="server" Text="0" />
        <asp:LinkButton OnClick="profileDisplay" runat="server" Text="View Profile" CommandArgument="0" />
    </div>

    <asp:GridView ID="zoneControl" AutoGenerateColumns="False" DataSourceID="zoneSource" runat="server" DataKeyNames="idz">
        <Columns>
            <asp:BoundField DataField="x" HeaderText="X" />
            <asp:BoundField DataField="y" HeaderText="Y" />
            <asp:TemplateField HeaderText="Select"><ItemTemplate><asp:RadioButton AutoPostBack="true" runat="server" Text='<%# Eval("name") %>' OnCheckedChanged ="zoneSelect" /><asp:Label runat="server" Text='<%# Eval("idz") %>' Visible="false" /></ItemTemplate></asp:TemplateField>
            <asp:TemplateField HeaderText="Display"><ItemTemplate><asp:LinkButton OnClick="zoneDisplay" runat="server" Text="View" CommandArgument='<%# Eval("idz") %>'/></ItemTemplate></asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="zoneSource" runat="server" ConnectionString="<%$ ConnectionStrings:serConn %>"
        SelectCommand="SELECT idz, x, y, name FROM zones WHERE idp = @idsp">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="" Name="idsp" SessionField="playerid" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
</td>

<td style="width: 300px" rowspan="2">
    <asp:Label ID="lTitle1" runat="server" Text="Title 1"></asp:Label><br />
    <asp:Image ID="viewImg" runat="server" ImageUrl="" AlternateText="Image not found" Height="250" Width="250"/><br />
    <asp:Label ID="lTitle2" runat="server" Text="Title 2"></asp:Label><br />
</td>

<td style="width: 300px" rowspan="2">
    <asp:LinkButton OnClick="profileDisplay" ID="lOwner" runat="server" Text="Owner" CommandArgument="0"></asp:LinkButton>

    <asp:DetailsView ID="ulistControl" runat="server" AutoGenerateRows="False" DataKeyNames="idl" DataSourceID="ulistSource">
        <Fields>
            <asp:BoundField DataField="nrp" HeaderText="Peasants"/>
            <asp:BoundField DataField="nrw" HeaderText="Warriors"/>
            <asp:BoundField DataField="nrd" HeaderText="Defenders"/>
            <asp:BoundField DataField="nrb" HeaderText="Berserkers"/>
            <asp:BoundField DataField="nrc" HeaderText="Cavalry"/>
            <asp:BoundField DataField="nrs" HeaderText="Savages"/>
        </Fields>
    </asp:DetailsView>

    <asp:SqlDataSource ID="ulistSource" runat="server"
        ConnectionString="<%$ ConnectionStrings:serConn %>" 
        SelectCommand="SELECT * FROM ulists"></asp:SqlDataSource>
</td>

<td style="width: 300px">
    <asp:GridView ID="outMoveControl" runat="server" AutoGenerateColumns="False" DataKeyNames="idm" DataSourceID="outMoveSource" onrowcreated="rowManage">
        <Columns>
            <asp:BoundField DataField="zsname" HeaderText="From" />
            <asp:TemplateField><ItemTemplate><asp:Image runat="server" AlternateText='<%# Eval("iatk") %>' ImageUrl="~/Images/drred.png" /></ItemTemplate></asp:TemplateField>
            <asp:BoundField DataField="zdname" HeaderText="To" />
            <asp:BoundField DataField="edate" HeaderText="Date" DataFormatString="{0:hh:mm:ss}" />
            <asp:TemplateField HeaderText="Display"><ItemTemplate><asp:LinkButton runat="server" Text="View" OnClick="moveDisplay" CommandArgument='<%# Eval("idm") %>' /></ItemTemplate></asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            No outgoing movements.
        </EmptyDataTemplate>
    </asp:GridView>

    <asp:SqlDataSource ID="outMoveSource" runat="server" ConnectionString="<%$ ConnectionStrings:serConn %>"
        SelectCommand="SELECT m.idm, zs.name as zsname , m.iatk, zd.name as zdname, m.edate-GETDATE() as edate FROM movements m, zones zs, zones zd WHERE m.idzs=zs.idz AND m.idzd=zd.idz AND m.idzs = @idsz">
        <SelectParameters>
            <asp:SessionParameter Name="idsz" SessionField="selzoneid" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
</td>

</tr>
<tr style="height: 175px">

<td style="width: 300px" rowspan="2">
    <asp:GridView ID="trainControl" runat="server" AutoGenerateColumns="False" DataKeyNames="idt" DataSourceID="trainSource">
        <Columns>
            <asp:BoundField DataField="name" HeaderText="Zone" />
            <asp:BoundField DataField="unit" HeaderText="Unit" />
            <asp:BoundField DataField="edate" HeaderText="Date" DataFormatString="{0:hh:mm:ss}" />
        </Columns>
        <EmptyDataTemplate>
            No trainings in progress.
        </EmptyDataTemplate>
    </asp:GridView>

    <asp:SqlDataSource ID="trainSource" runat="server" ConnectionString="<%$ ConnectionStrings:serConn %>"
        SelectCommand="SELECT t.idt, z.name, t.unit, t.edate-GETDATE() as edate FROM trainings t, zones z WHERE t.idz=z.idz AND t.idz=@idsz">
        <SelectParameters>
            <asp:SessionParameter Name="idsz" SessionField="selzoneid" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
</td>

<td style="width: 300px" rowspan="2">
<asp:GridView ID="inMoveControl" runat="server" AutoGenerateColumns="False" DataKeyNames="idm" DataSourceID="inMoveSource" OnRowCreated="rowManage">
    <Columns>
        <asp:BoundField DataField="zdname" HeaderText="To" />
        <asp:TemplateField><ItemTemplate><asp:Image ID="Image1" runat="server" AlternateText='<%# Eval("iatk") %>' ImageUrl="~/Images/stred.png" /></ItemTemplate></asp:TemplateField>
        <asp:BoundField DataField="zsname" HeaderText="From" />
        <asp:BoundField DataField="edate" HeaderText="Date" DataFormatString="{0:hh:mm:ss}" />
        <asp:TemplateField HeaderText="Display"><ItemTemplate><asp:LinkButton runat="server" Text="View" OnClick="moveDisplay" CommandArgument='<%# Eval("idm") %>' /></ItemTemplate></asp:TemplateField>
    </Columns>
    <EmptyDataTemplate>
        No incoming movements.
    </EmptyDataTemplate>
</asp:GridView>

<asp:SqlDataSource ID="inMoveSource" runat="server" ConnectionString="<%$ ConnectionStrings:serConn %>"
    SelectCommand="SELECT m.idm, zs.name as zsname , m.iatk, zd.name as zdname, m.edate-GETDATE() as edate FROM movements m, zones zs, zones zd WHERE m.idzs=zs.idz AND m.idzd=zd.idz AND m.idzd = @iddz">
    <SelectParameters>
        <asp:SessionParameter Name="iddz" SessionField="selzoneid" Type="Decimal" />
    </SelectParameters>
</asp:SqlDataSource>
</td>

</tr>
<tr style="height: 175px">

<td style="width: 600px" colspan="2">
    <asp:Panel Visible="false" ID="viewCommands" runat="server"></asp:Panel>

    <table visible="false" id="tsend" width="500px" runat="server">
    <tr>
        <td>Peasants</td>
        <td>Warriors</td>
        <td>Defenders</td>
        <td>Berserkers</td>
        <td>Cavalry</td>
        <td>Savage</td>
        <td rowspan="2" width="100"><asp:Button ID="bSend" runat="server" Text="Atk/Sup" 
                onclick="sendTroops" /></td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="tbp" runat="server" Text="0" MaxLength="3" Width="40px" />
            <asp:Label ID="lp" runat="server" Text="/X" Width="40px" />
        </td>
        <td>
            <asp:TextBox ID="tbw" runat="server" Text="0" MaxLength="3" Width="40px" />
            <asp:Label ID="lw" runat="server" Text="/X" Width="40px" />
        </td>
        <td>
            <asp:TextBox ID="tbd" runat="server" Text="0" MaxLength="3" Width="40px" />
            <asp:Label ID="ld" runat="server" Text="/X" Width="40px" />
        </td>
        <td>
            <asp:TextBox ID="tbb" runat="server" Text="0" MaxLength="3" Width="40px" />
            <asp:Label ID="lb" runat="server" Text="/X" Width="40px" />
        </td>
        <td>
            <asp:TextBox ID="tbc" runat="server" Text="0" MaxLength="3" Width="40px" />
            <asp:Label ID="lc" runat="server" Text="/X" Width="40px" />
        </td>
        <td>
            <asp:TextBox ID="tbs" runat="server" Text="0" MaxLength="3" Width="40px" />
            <asp:Label ID="ls" runat="server" Text="/X" Width="40px" />
        </td>
    </tr>
    </table>

    <table visible="false" id="tdeclare" width="500px" runat="server">
        <tr>
            <td>
                <asp:TextBox style="resize:none;" ID="tbdeclare" runat="server" MaxLength="5" Text="I hereby declare !" Height="80px" Width="350px" TextMode="MultiLine" />
                <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbdeclare" ErrorMessage="Exceeding 250 characters" ValidationExpression="^[\s\S]{0,250}$" />
            </td>
            <td><asp:Button ID="bdeclare" Text="War/Alliance" runat="server" /></td>
        </tr>
    </table>

</td>

</tr>

</table>
</form>
</asp:Content>