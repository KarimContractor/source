<%@ Page Language="C#" AutoEventWireup="true" CodeFile="abc.aspx.cs" Inherits="abc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>New Page</h1>
            <p>
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
            </p>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
                    </asp:Timer>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <p>
            </p>
            <p>&nbsp;</p>
        </div>
    </form>
</body>
</html>
