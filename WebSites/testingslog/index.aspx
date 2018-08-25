<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:500px; height:auto; margin:auto">
            <div style="width:100%; height:auto; margin:auto">
                <table>
                    <tr>
                        <td>UserName</td>
                        <td><asp:TextBox ID="txtuser" runat="server"></asp:TextBox></td>

                    </tr>
                    <tr>
                        <td>Password</td>
                        <td><asp:TextBox ID="txtpass" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td style="margin-left: 40px"><asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" /></td>

                    </tr>

                </table>

            </div>
        </div>
    </form>
</body>
</html>
