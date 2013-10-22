<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Faculty.aspx.cs" Inherits="Faculty" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .newStyle1
        {
            position: absolute;
        }
        .newStyle2
        {
            position: absolute;
        }
        .newStyle3
        {
            position: absolute;
        }
        .newStyle4
        {
            position: absolute;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" dir="ltr" 
    style="vertical-align: middle; text-align: left; white-space: normal; word-spacing: normal; letter-spacing: normal;">
    <div>
    
    </div>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" BackColor="#CCCCCC" Font-Bold="True" 
            Font-Overline="False" Font-Size="Larger" Text="CSE  DEPT  Faculty  Page"></asp:Label>
    </p>
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Image ID="PhotoBox" runat="server" Height="210px" ImageAlign="Left" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Size="Small" 
        Text="Faculty Name"></asp:Label>
&nbsp;
    <asp:DropDownList ID="ComboName" runat="server" Width="140px">
    </asp:DropDownList>
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Size="Small" 
        Text="Faculty ID"></asp:Label>
&nbsp;
    <asp:TextBox ID="txtID" runat="server" style="margin-left: 0px" Width="140px"></asp:TextBox>
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label11" runat="server" Font-Bold="False" Font-Size="Small" 
        Text="Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtName" runat="server" Width="140px"></asp:TextBox>
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label5" runat="server" Font-Bold="False" Font-Size="Small" 
        Text="Title"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtTitle" runat="server" style="text-align: left" 
        Width="140px"></asp:TextBox>
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label10" runat="server" Font-Bold="False" Font-Size="Small" 
        Text="Office"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtOffice" runat="server" 
        style="text-align: left; margin-left: 0px" Width="140px"></asp:TextBox>
&nbsp;
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label7" runat="server" Font-Bold="False" Font-Size="Small" 
        Text="Phone"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtPhone" runat="server" 
        style="text-align: left; margin-left: 0px" Width="140px"></asp:TextBox>
&nbsp;&nbsp;
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label8" runat="server" Font-Bold="False" Font-Size="Small" 
        Text="College"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtCollege" runat="server" style="text-align: left" 
        Width="140px"></asp:TextBox>
&nbsp;&nbsp;
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label9" runat="server" Font-Bold="False" Font-Size="Small" 
        Text="Email"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtEmail" runat="server" 
        style="text-align: left; margin-left: 0px" Width="140px"></asp:TextBox>
&nbsp;&nbsp;
    <br />
    <br />
    <asp:Button ID="cmdSelect" runat="server" Font-Bold="True" Font-Size="Small" 
        Height="22px" onclick="cmdSelect_Click" Text="Select" Width="66px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="cmdInsert" runat="server" Font-Bold="True" Font-Size="Small" 
        Height="22px" Text="Insert" Width="66px" onclick="cmdInsert_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="cmdUpdate" runat="server" Font-Bold="True" Font-Size="Small" 
        Height="22px" Text="Update" Width="66px" onclick="cmdUpdate_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="cmdDelete" runat="server" Font-Bold="True" Font-Size="Small" 
        Height="22px" Text="Delete" Width="66px" onclick="cmdDelete_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="cmdBack" runat="server" Font-Bold="True" Font-Size="Small" 
        Height="22px" onclick="cmdBack_Click" Text="Back" Width="66px" />
    <br />
    <br />
    <br />
    <br />
    <asp:Panel ID="Panel1" runat="server">
    </asp:Panel>
    <br />
    <br />
    <br />
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <br />
    <asp:Panel ID="Panel3" runat="server">
    </asp:Panel>
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:Panel ID="Panel2" runat="server">
    </asp:Panel>
    </form>
</body>
</html>
