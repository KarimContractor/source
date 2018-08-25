<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:100%; height:200px; border:solid 20px darkblue">
            <h1>Header</h1>
        </div>
        <div style="width:100%; height:auto; border:solid 10px darkgreen">
            <asp:Menu ID="Menu1" runat="server" BackColor="#B5C7DE" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" Orientation="Horizontal" StaticSubMenuIndent="20px" OnMenuItemClick="Menu1_MenuItemClick">
                <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
                <DynamicMenuItemStyle Height="50px" HorizontalPadding="40px" VerticalPadding="2px" />
                <DynamicMenuStyle BackColor="#B5C7DE" HorizontalPadding="40px" />
                <DynamicSelectedStyle BackColor="#507CD1" />
                <Items>
                    <asp:MenuItem Text="Country" Value="Country"></asp:MenuItem>
                    <asp:MenuItem Text="State" Value="State"></asp:MenuItem>
                    <asp:MenuItem Text="City" Value="City"></asp:MenuItem>
                    <asp:MenuItem Text="Account" Value="Account"></asp:MenuItem>
                    <asp:MenuItem Text="Login Account" Value="Login Account"></asp:MenuItem>
                </Items>
                <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
                <StaticMenuItemStyle Font-Size="20px" HorizontalPadding="40px" VerticalPadding="2px" />
                <StaticSelectedStyle BackColor="#507CD1" />
            </asp:Menu>
        </div>
        <div style="width:100%; height:auto; border:solid 20px darkred">
            <asp:MultiView ID="MultiView1" runat="server">

                <asp:View ID="View1" runat="server">

                    <fieldset>
                        <legend>Country</legend>
                        <table>
                            <tr>
                                <td>Name</td>
                                <td><asp:TextBox ID="txtCname" runat="server" ></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td><asp:Button ID="btncountry" Text="Create Country"  runat="server" OnClick="btncountry_Click"/></td>
                            </tr>
                        </table>
                    </fieldset>
                </asp:View>
                <asp:View ID="View2" runat="server">

                    <fieldset>
                        <legend>State</legend>
                        <table>
                            <tr>
                               <td>Country</td>
                                <td><asp:DropDownList ID="ddlcountry" runat="server"></asp:DropDownList></td>

                            </tr>
                            <tr>
                                <td>Name</td>
                                <td><asp:TextBox ID="TxtSname" runat="server" ></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td><asp:Button ID="Createstate" Text="Create State"  runat="server"/></td>
                            </tr>
                        </table>
                    </fieldset>
                </asp:View>
                <asp:View ID="View3" runat="server">

                    <fieldset>
                        <legend>City</legend>
                        <table>
                            <tr>
                               <td>Country</td>
                                <td><asp:DropDownList ID="ddlcount" runat="server"></asp:DropDownList></td>

                            </tr><tr>
                               <td>State</td>
                                <td><asp:DropDownList ID="ddlstate" runat="server"></asp:DropDownList></td>

                            </tr>
                            <tr>
                                <td>CityName</td>
                                <td><asp:TextBox ID="Txtcityname" runat="server" ></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td><asp:Button ID="btncity" Text="Create city"  runat="server"/></td>
                            </tr>
                        </table>
                    </fieldset>
                </asp:View>

            </asp:MultiView>
            

        </div>
    </form>
</body>
</html>
