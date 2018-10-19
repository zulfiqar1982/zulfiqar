<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClaimList.aspx.cs" Inherits="MiniProject.ClaimList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css">
        body { font-family: Arial; font-size: 10pt; }

        table { border: 1px solid #ccc; }

        table th { background-color: #F7F7F7; color: #333; font-weight: bold; }

        table th, table td { padding: 5px; border-color: #ccc; }
        </style>

</head>
<body>
    <form id="claimListForm" runat="server">

        <h2>Claim List</h2>
        <div>
            <table style="width: 100%">
                <tr><td></td><td>
                    <asp:Button ID="btnAddClaim" runat="server" Text="Create Claim" OnClick="btnAddClaim_Click" /></td><td>
                    <asp:LinkButton ID="lnkLogout" Text="Logout" runat="server" OnClick="lnkLogout_Click"   />
                    </td></tr>
                <tr><td></td><td>
                     <asp:GridView ID="gw_ForEdit" runat="server" OnRowCommand="gw_ForEdit_RowCommand" AutoGenerateColumns="False" Width="100%" OnRowCreated="gw_ForEdit_RowCreated" OnRowDeleting="gw_ForEdit_RowDeleting" OnRowUpdating="gw_ForEdit_RowUpdating" >
                            <Columns>
                            <asp:TemplateField HeaderStyle-Width="50">
                                <ItemTemplate>
                                    <asp:HiddenField ID="IndexEdit" runat="server" Value='<%# Eval("ID") %>' />
                                    <asp:LinkButton ID="lnkEdit" Text="Edit" runat="server" CommandName="Edit" CommandArgument='<%# Eval ("ID")%>'/>
                                </ItemTemplate>
                                <HeaderStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="50">
                                <ItemTemplate>
                                    <asp:HiddenField ID="IndexDelete" runat="server" Value='<%# Eval("ID") %>' />
                                    <asp:LinkButton ID="lnkDelete" Text="Delete" runat="server" CommandName="Delete" 
                                                        CommandArgument='<%# Eval ("ID")%>'/>
                                </ItemTemplate>
                                <HeaderStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("User") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("User") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Claim Date">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ClaimDate") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("ClaimDate", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Branch Code">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("BranchCode") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("BranchCode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bank Code">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("BankCode") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("BankCode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Account No">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("AccountNo") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("AccountNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                               
                   
                            </Columns>
                        </asp:GridView>
                    </td><td></td></tr>
            </table>
        </div>
    </form>
</body>
</html>
