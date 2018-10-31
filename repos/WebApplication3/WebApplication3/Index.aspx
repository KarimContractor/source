<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApplication3.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="NameofCustomer" HeaderText="NameofCustomer" SortExpression="NameofCustomer" />
                <asp:BoundField DataField="ContactNo" HeaderText="ContactNo" SortExpression="ContactNo" />
                <asp:BoundField DataField="NumberOFPersons" HeaderText="NumberOFPersons" SortExpression="NumberOFPersons" />
                <asp:BoundField DataField="Pickdate" HeaderText="Pickdate" SortExpression="Pickdate" />
                <asp:BoundField DataField="Picktime" HeaderText="Picktime" SortExpression="Picktime" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TungaDBConnectionString %>" SelectCommand="SELECT * FROM [TableBookings] WHERE ([Id] = @Id)">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox1" Name="Id" PropertyName="Text" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
