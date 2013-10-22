<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Course.aspx.cs" Inherits="Course" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <p>
        &nbsp;</p>
    <asp:Panel ID="Panel1" runat="server" BackColor="#00CCFF" BorderColor="#0099FF" 
        ForeColor="#00CCFF">
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" BackColor="#C0C0FF" Font-Size="X-Small" 
        Height="40px" Width="500px">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" 
            style="text-align: left" Text="Faculty Name"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ComboName" runat="server" 
            style="top: 67px; left: 201px; position: absolute; height: 22px; width: 201px;">
        </asp:DropDownList>
    </asp:Panel>
    <p>
        <asp:ListBox ID="CourseList" runat="server" AutoPostBack="True" 
            Font-Bold="True" Font-Size="Medium" Height="151px" 
            onselectedindexchanged="CourseList_SelectedIndexChanged" 
            style="top: 111px; left: 8px; position: absolute" Width="135px">
        </asp:ListBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <asp:Panel ID="Panel3" runat="server" BackColor="#C0C0FF" Font-Size="XX-Small" 
        Height="148px" 
        style="top: 115px; left: 158px; position: absolute; height: 148px; width: 352px" 
        Width="352px">
        &nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
            Text="Course Title"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtEnrollment" runat="server" Font-Bold="True" 
            Font-Size="Medium" 
            style="font-size: small; top: 116px; left: 110px; position: absolute; height: 22px; width: 200px; background-color: #C0C0FF"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" 
            Text="Schedule"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        &nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" 
            Text="Classroom"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        &nbsp;&nbsp;
        <asp:TextBox ID="txtSchedule" runat="server" Font-Bold="True" 
            Font-Size="Medium" 
            style="font-size: small; top: 39px; left: 111px; position: absolute; height: 22px; width: 200px; background-color: #C0C0FF"></asp:TextBox>
        <asp:TextBox ID="txtCourse" runat="server" Font-Bold="True" Font-Size="Medium" 
            style="font-size: small; top: 12px; left: 111px; position: absolute; height: 22px; width: 200px; background-color: #C0C0FF"></asp:TextBox>
        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" 
            Text="Credit"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        &nbsp;&nbsp;
        <asp:TextBox ID="txtClassroom" runat="server" Font-Bold="True" 
            Font-Size="Medium" 
            style="font-size: small; top: 64px; left: 111px; position: absolute; height: 22px; width: 200px; background-color: #C0C0FF"></asp:TextBox>
        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Small" 
            Text="Enrollment"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCredit" runat="server" Font-Bold="True" Font-Size="Medium" 
            style="font-size: small; top: 90px; left: 110px; position: absolute; height: 22px; width: 200px; background-color: #C0C0FF"></asp:TextBox>
    </asp:Panel>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p style="line-height: 2px">
        &nbsp;</p>
    <p>
        <asp:Button ID="cmdSelect" runat="server" Font-Bold="True" Font-Size="Small" 
            Height="25px" onclick="cmdSelect_Click" Text="Select" Width="71px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="cmdInsert" runat="server" Font-Bold="True" Font-Size="Small" 
            Height="25px" Text="Insert" Width="71px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="cmdUpdate" runat="server" Font-Bold="True" Font-Size="Small" 
            Height="25px" Text="Update" Width="71px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="cmdDelete" runat="server" Font-Bold="True" Font-Size="Small" 
            Height="25px" Text="Delete" Width="71px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="cmdBack" runat="server" Font-Bold="True" Font-Size="Small" 
            Height="25px" onclick="cmdBack_Click" Text="Back" Width="71px" />
    </p>
    <p>
        &nbsp;</p>
    </form>
</body>
</html>
