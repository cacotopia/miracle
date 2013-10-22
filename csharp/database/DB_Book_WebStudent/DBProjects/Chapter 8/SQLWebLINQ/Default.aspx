<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Faculty Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label10" runat="server" BackColor="#C0C0FF" Font-Bold="True" 
            Font-Size="Large" Text="CSE DEPT Faculty Page"></asp:Label>
    </p>
    <p style="line-height: 5px">
        &nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Smaller" 
            style="text-align: left; font-size: smaller" Text="Faculty Photo"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Smaller" 
            style="text-align: left; font-size: smaller" Text="Faculty Name"></asp:Label>
    </p>
    <p style="line-height: 3px">
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Image ID="PhotoBox" runat="server" Height="168px" 
            style="top: 137px; left: 15px; position: absolute" Width="149px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        &nbsp;<asp:DropDownList ID="ComboName" runat="server" 
            style="top: 91px; left: 310px; position: absolute; height: 22px; width: 151px">
        </asp:DropDownList>
&nbsp;
    </p>
    <p style="line-height: 3px">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p style="line-height: 3px">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Smaller" 
            style="text-align: left" Text="Faculty ID"></asp:Label>
    </p>
    <p style="line-height: 5px">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Smaller" 
            style="text-align: left" Text="Name"></asp:Label>
&nbsp;
    </p>
    <p style="line-height: 5px">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        &nbsp;<asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Smaller" 
            style="text-align: left" Text="Title"></asp:Label>
    </p>
    <p style="line-height: 6px">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Smaller" 
            style="text-align: left" Text="Office"></asp:Label>
    </p>
    <p style="line-height: 3px">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Smaller" 
            style="text-align: left" Text="Phone"></asp:Label>
    </p>
    <p style="line-height: 3px">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        &nbsp;<asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Smaller" 
            style="text-align: left" Text="College"></asp:Label>
    </p>
    <p style="line-height: 3px">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Smaller" 
            style="text-align: left" Text="Email"></asp:Label>
    </p>
    <p style="line-height: 5px; position: absolute">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        &nbsp;</p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        &nbsp;<asp:TextBox ID="txtID" runat="server" 
            style="top: 124px; left: 328px; position: absolute; height: 22px; width: 145px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtTitle" runat="server" 
            style="top: 173px; left: 328px; position: absolute; height: 22px; width: 145px; right: 498px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCollege" runat="server" 
            style="top: 242px; left: 328px; position: absolute; height: 22px; width: 145px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtOffice" runat="server" 
            style="top: 196px; left: 328px; position: absolute; height: 22px; width: 145px; bottom: 472px"></asp:TextBox>
    </p>
    <p>
        &nbsp;&nbsp;<asp:Button ID="cmdSelect" runat="server" Font-Bold="True" 
            onclick="cmdSelect_Click" 
            style="top: 316px; left: 9px; position: absolute; height: 26px; right: 884px" 
            Text="Select" Width="78px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        &nbsp;<asp:TextBox ID="txtPhoto" runat="server" 
            style="top: 93px; position: absolute; height: 22px; width: 128px; left: 19px"></asp:TextBox>
    </p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="cmdUpdate" runat="server" 
            Font-Bold="True" onclick="cmdUpdate_Click" 
            style="top: 317px; left: 203px; position: absolute; height: 26px; right: 697px" 
            Text="Update" Width="71px" />
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="cmdDelete" runat="server" 
            Font-Bold="True" onclick="cmdDelete_Click" 
            style="top: 317px; left: 297px; position: absolute; height: 26px" Text="Delete" 
            Width="71px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button 
            ID="cmdExit" runat="server" Font-Bold="True" onclick="cmdExit_Click" 
            style="top: 317px; left: 389px; position: absolute; height: 26px" Text="Exit" 
            Width="70px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="cmdInsert" runat="server" onclick="cmdInsert_Click" 
            Text="Insert" Font-Bold="True" 
            style="top: 317px; position: absolute; height: 26px; left: 106px; width: 75px" />
    </p>
    <p>
        <asp:TextBox ID="txtName" runat="server" 
            style="top: 148px; left: 328px; position: absolute; height: 22px; width: 145px"></asp:TextBox>
    </p>
        <asp:TextBox ID="txtPhone" runat="server" 
        style="top: 219px; left: 328px; position: absolute; height: 22px; width: 145px"></asp:TextBox>
    <p>
        <asp:TextBox ID="txtEmail" runat="server" 
            style="top: 265px; left: 328px; position: absolute; height: 22px; width: 145px"></asp:TextBox>
    </p>
    </form>
</body>
</html>
