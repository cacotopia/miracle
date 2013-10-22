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
        &nbsp;<asp:Label ID="Label7" runat="server" 
            style="font-size: small; font-weight: 400" Text="Method"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ComboMethod" runat="server" 
            style="top: 67px; left: 80px; position: absolute; height: 22px" Width="131px">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" 
            style="text-align: left; font-size: small; font-weight: 400;" 
            Text="Faculty Name"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ComboName" runat="server" 
            
            style="top: 67px; left: 334px; position: absolute; height: 22px; width: 146px;">
        </asp:DropDownList>
        &nbsp;&nbsp;
    </asp:Panel>
    <p style="line-height: 3px">
        <asp:ListBox ID="CourseList" runat="server" AutoPostBack="True" 
            Font-Bold="True" Font-Size="Medium" 
            onselectedindexchanged="CourseList_SelectedIndexChanged" 
            style="top: 111px; left: 8px; position: absolute; height: 177px;" 
            Width="135px">
        </asp:ListBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <asp:Panel ID="Panel3" runat="server" BackColor="#C0C0FF" Font-Size="XX-Small" 
        style="top: 112px; left: 158px; position: absolute; height: 182px; width: 352px; font-size: xx-small;" 
        Width="352px">
        &nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
            Text="Course ID" style="font-weight: 400"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtEnroll" runat="server" Font-Bold="True" 
            Font-Size="Medium" 
            
            style="font-size: small; top: 152px; left: 111px; position: absolute; height: 22px; width: 200px; "></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" 
            Text="Course Title" style="font-weight: 400"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" 
            style="font-weight: 400" Text="Schedule"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;
        <br />
        &nbsp;&nbsp;
        <asp:TextBox ID="txtCourseName" runat="server" Font-Bold="True" 
            Font-Size="Medium" 
            
            style="font-size: small; top: 40px; left: 111px; position: absolute; height: 22px; width: 200px; "></asp:TextBox>
        <asp:TextBox ID="txtCourseID" runat="server" Font-Bold="True" Font-Size="Medium" 
            
            style="font-size: small; top: 12px; left: 111px; position: absolute; height: 22px; width: 200px; " 
            AutoPostBack="True" ></asp:TextBox>
        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" 
            Text="Classroom" style="font-weight: 400"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;
        <asp:TextBox ID="txtSchedule" runat="server" Font-Bold="True" 
            Font-Size="Medium" 
            
            style="font-size: small; top: 68px; left: 111px; position: absolute; height: 22px; width: 200px; "></asp:TextBox>
        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Small" 
            Text="Credit" style="font-weight: 400"></asp:Label>
        &nbsp;&nbsp;&nbsp;<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtClassRoom" runat="server" Font-Bold="True" Font-Size="Medium" 
            
            style="font-size: small; top: 96px; left: 111px; position: absolute; height: 22px; width: 200px; "></asp:TextBox>
        <br />
        &nbsp;&nbsp;
        <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Small" 
            style="font-weight: 400" Text="Enrollment"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCredits" runat="server" Font-Bold="True" Font-Size="Medium" 
            style="font-size: small; top: 124px; left: 111px; position: absolute; height: 22px; width: 200px; "></asp:TextBox>
    </asp:Panel>
    <p style="line-height: 2px">
        &nbsp;</p>
    <p style="line-height: 3px">
        &nbsp;</p>
    <p style="line-height: 3px">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="cmdSelect" runat="server" Font-Bold="True" Font-Size="Small" 
            Height="25px" Text="Select" Width="71px" onclick="cmdSelect_Click" 
            style="top: 306px; left: 23px; position: absolute" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="cmdDelete" runat="server" Font-Bold="True" Font-Size="Small" 
            Height="25px" Text="Delete" Width="71px" 
            style="top: 308px; left: 288px; position: absolute" 
            onclick="cmdDelete_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="cmdBack" runat="server" Font-Bold="True" Font-Size="Small" 
            Height="25px" onclick="cmdBack_Click" Text="Back" Width="71px" 
            style="top: 308px; left: 418px; position: absolute" />
    </p>
    <p>
        <asp:Button ID="cmdUpdate" runat="server" Font-Bold="True" Font-Size="Small" 
            Height="25px" Text="Update" Width="71px" 
        style="top: 307px; left: 152px; position: absolute" 
        onclick="cmdUpdate_Click" />
    </p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    
    </form>
</body>
</html>
