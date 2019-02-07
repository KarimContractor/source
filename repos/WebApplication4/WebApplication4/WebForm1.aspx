<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication4.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"/>
                <asp:UpdatePanel ID="updpan" runat="server">
                    <ContentTemplate>
                        <asp:Button runat="server" ID="btn1" Text="Button" />
                        <asp:Label runat="server" ID="lbl1" Text="Label"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
            
            <asp:Button runat="server" ID="btn2" Text="Button" />
                <asp:Label runat="server" ID="lbl2" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
