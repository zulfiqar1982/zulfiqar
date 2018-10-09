<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportFiles.aspx.cs" Inherits="MiniProject.ImportFiles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:FileUpload ID="fileUpload" runat="server" />
            &nbsp;<asp:Label ID="StatusLabel" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
            <br />
            <br />
            <br />
            <asp:TextBox ID="txtExtract" runat="server" AutoPostBack="True" Height="218px" TextMode="MultiLine" Width="840px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnLoad" runat="server" Text="Load text" OnClick="btnLoad_Click" />          
            &nbsp;          
            <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear text" />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
