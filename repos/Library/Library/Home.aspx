<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Library.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 415px;
        }
        .auto-style2 {
            width: 250px;
        }
    </style>
</head>
<body style="width: 963px; margin-left: 240px; margin-right: 149px; margin-top: 148px; margin-bottom: 162px">
    <form id="form1" runat="server">
    <div style="text-align:center; width:100%;height:auto;">
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="USER LOGIN"></asp:Label>
        <table style="width:427px; height:202px; align-self:center; align-items:center; margin-left: 288px; margin-bottom: 0px;">
     
          
     <tr><td class="auto-style2">
         <asp:Label ID="Label1" runat="server" Text="USERNAME"></asp:Label></td><td class="auto-style1">
             <asp:TextBox ID="TXTUSER" runat="server"></asp:TextBox></td><td>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TXTUSER"></asp:RequiredFieldValidator></td></tr> 
        <tr><td class="auto-style2">
            <asp:Label ID="Label2" runat="server" Text="PASSWORD"></asp:Label></td><td class="auto-style1">
                <asp:TextBox ID="TXTPASS" runat="server" TextMode="Password"></asp:TextBox></td><td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TXTPASS"></asp:RequiredFieldValidator></td></tr>
        <tr><td class="auto-style2">
            &nbsp;</td><td class="auto-style1">
                <asp:Button ID="Button1" runat="server" Text="LOGIN" OnClick="Button1_Click" />
            </td><td>
                    &nbsp;</td></tr>

    
        </table>
      </div>
    </form>
</body>
</html>
