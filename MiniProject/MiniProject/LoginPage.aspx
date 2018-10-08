<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="MiniProject.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" style="text-align: center">
                Input<br /> <br />

                <table style="align-content:center">
                <tr>
                    <td><asp:Label ID="lblLoginName" runat="server" Text="Login Name : "></asp:Label></td>
                    <td><asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox></td>
                </tr>
                <tr><td></td><td></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblPassword" runat="server" Text="Password : "></asp:Label></td>
                    <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                 <tr><td></td><td></td>
                  <tr><td></td><td>
                      <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /></td>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
