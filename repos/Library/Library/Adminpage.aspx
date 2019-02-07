<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Adminpage.aspx.cs" Inherits="Library.Adminpage" %>
<%@ OutputCache Duration="30" VaryByParam="none" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="width: 963px; margin-left: 240px; margin-right: 149px; margin-top: 148px; margin-bottom: 162px">
    <form id="form1" runat="server">
        <div style="text-align:center; width:100%;height:auto;">
            <asp:Label ID="Label5" runat="server" Font-Size="XX-Large" Text="Member Info and Creation Page"></asp:Label>
            <br />
            <table style="width:427px; height:202px; align-self:center; align-items:center; margin-left: 288px; margin-bottom: 0px;">
                <tr><td></td><td>
                    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" OnTextChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList></td><td></td></tr>
                <tr><td>
                    <asp:Label ID="Label1" runat="server" Text="Member Name"></asp:Label></td><td>
                        <asp:TextBox ID="TXTNAME" runat="server"></asp:TextBox></td><td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TXTNAME"></asp:RequiredFieldValidator></td></tr>
                <tr><td>
                    <asp:Label ID="Label2" runat="server" Text="UserName"></asp:Label></td><td>
                        <asp:TextBox ID="TXTUSERNAME" runat="server"></asp:TextBox></td><td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TXTUSERNAME"></asp:RequiredFieldValidator></td></tr>
                <tr><td>
                    <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label></td><td>
                        <asp:TextBox ID="TXTPASSWORD" runat="server"></asp:TextBox></td><td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TXTPASSWORD"></asp:RequiredFieldValidator></td></tr>
                <tr><td>
                    <asp:Label ID="Label4" runat="server" Text="STATUS"></asp:Label></td><td>
                        <asp:TextBox ID="TXTSTATUS" runat="server"></asp:TextBox></td><td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TXTSTATUS"></asp:RequiredFieldValidator></td></tr>
                <tr><td>
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Delete" />
                    </td><td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="CREATE" />
                    </td><td>
                        <asp:Button ID="Button2" runat="server" Text="UPDATE" OnClick="Button2_Click" />
                    </td></tr>
            </table>
        </div>
        <asp:GridView ID="GridView1" runat="server" Height="229px" Width="959px">
        </asp:GridView>
    </form>
    <asp:label ID="lbltime" runat="server"></asp:label>
</body>
</html>
