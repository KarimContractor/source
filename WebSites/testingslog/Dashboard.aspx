<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:400px; height:400px; margin:auto; background-color:aqua;">
            Dashboard
            <asp:Button ID="btnAdmin" Text="Admin" runat="server"/>
            <asp:Button ID="btnEmp" Text="Employee" runat="server"/>
            <asp:Button ID="btnv" Text="Visiter" runat="server"/>
        </div>
    </form>
</body>
</html>
