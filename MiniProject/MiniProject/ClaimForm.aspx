<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClaimForm.aspx.cs" Inherits="MiniProject.ClaimForm" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc3" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

       <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
      
    <title></title>
     <style type="text/css">
        body { font-family: Arial; font-size: 10pt; }

        table { border: 1px solid #ccc; }

        table th { background-color: #F7F7F7; color: #333; font-weight: bold; }

        table th, table td { padding: 5px; border-color: #ccc; }

    .modalBackground
    {
        background-color: Black;
        filter: alpha(opacity=90);
        opacity: 0.8;
    }
    .modalPopup
    {
        background-color: #FFFFFF;
        border-width: 3px;
        border-style: solid;
        border-color: black;
        padding-top: 10px;
        padding-left: 10px;
        width: 360px;
        height: 460px;
    }

    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div>
           
            <table style="width:100%">
                <tr><td></td><td>
                <table style="width:50%">
                <tr><td>
                    <asp:Label ID="Label11" runat="server" Text="Employee"></asp:Label>
                    </td><td></td><td>
                    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                    </td>
                    <td><asp:Label ID="Label14" runat="server" Text="Claim Date"></asp:Label>
                    </td><td></td><td>
                    <asp:TextBox ID="txtClaimDate" runat="server"></asp:TextBox>
                          <asp:Image ID="imgClaimDate" runat="server" 
                                        ImageUrl="~/Images/calendar.gif" />
                        <cc2:CalendarExtender ID="CalendarExtender" runat="server"
                                        TargetControlID="txtClaimDate" PopupButtonID="imgClaimDate" Format="dd-MMM-yyyy">
                                    </cc2:CalendarExtender>
                    </td></tr>
                <tr><td>
                    <asp:Label ID="lblBankCode" runat="server" Text="Bank Code"></asp:Label>
                    </td><td></td><td>
                    <asp:TextBox ID="txtBankCode" runat="server"></asp:TextBox>
                    </td>
                    <td>
                     <asp:Label ID="lblAccountCode" runat="server" Text="Account Code"></asp:Label>
                    </td><td></td>
                    <td>
                    <asp:TextBox ID="txtAccountCode" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr><td>
                    <asp:Label ID="lblBranch" runat="server" Text="Branch Code"></asp:Label>
                    </td><td></td><td>
                    <asp:TextBox ID="txtBranchCode" runat="server"></asp:TextBox>
                    </td>
                    <td></td><td></td><td>
                    
                    </td>
                </tr>
                    <tr><td></td><td></td><td></td><td></td><td></td><td>
                        <asp:Button ID="btnUpdateClaim" runat="server" Text="Update" OnClick="btnUpdateClaim_Click" /></td></tr>
                </table>

                </td><td></td></tr>

                <tr><td></td><td style="align-content:center; align-items:center;">
                    <panel id="pnlExpenses">
         <asp:ScriptManager ID="ScriptManager1" runat="Server" />
            <asp:UpdatePanel runat="server" id="upData">
                 <ContentTemplate>
                        <asp:GridView ID="gw_ForEdit" runat="server" OnRowCommand="gw_ForEdit_RowCommand" AutoGenerateColumns="False" OnRowDeleted="gw_ForEdit_RowDeleted" OnSelectedIndexChanged="gw_ForEdit_SelectedIndexChanged" OnRowDeleting="gw_ForEdit_RowDeleting">
                            <Columns>
                            <asp:TemplateField HeaderStyle-Width="50">
                                <ItemTemplate>
                                    <asp:HiddenField ID="IndexEdit" runat="server" Value='<%# Eval("ID") %>' />
                                    <asp:LinkButton ID="lnkEdit" Text="Edit" runat="server" OnClick="lnkEdit_Click" />
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
                                <asp:TemplateField HeaderText="Index">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Index") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Index") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DateofTransaction") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("DateofTransaction", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cost Center ">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("CostCenter") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("CostCenter") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="GL Code">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("GLCode") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("GLCode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Currency (RM)">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Currency") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Currency") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Amount") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="GST">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("GST") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("GST") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ExchangeRate">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("ExchangeRate") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("ExchangeRate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TotalAmount">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("TotalAmount") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("TotalAmount") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>

                   
                            </Columns>
                        </asp:GridView>
                     
                       <asp:Button ID="btnAddExpenses" runat="server" Text="Add Expenses" OnClick="btnAddExpenses_Click" />
                    <cc1:ModalPopupExtender ID ="mp1" runat="server" PopupControlID="pnlAddEdit" TargetControlID="btnAddExpenses"
                    CancelControlID="btnCancel" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
                     <asp:Panel ID="pnlAddEdit" runat="server" CssClass="modalPopup" style = "display:none; align-self:center; align-content:center">
                         <h3>Transaction Details</h3>
                         <table>
                         <tr><td><asp:Label ID="Label10" runat="server" Text="ID"></asp:Label></td> : <td></td><td><asp:TextBox ID="txtID" runat="server" Width="194px"></asp:TextBox></td></tr>
                         <tr><td><asp:Label ID="Label1" runat="server" Text="Date"></asp:Label></td> : <td></td><td><asp:TextBox ID="txtDate" runat="server" Width="194px"></asp:TextBox><asp:Image ID="imgClaimDetailDate" runat="server" 
                                        ImageUrl="~/Images/calendar.gif" />
                        <cc3:CalendarExtender ID="CalendarExtender2" runat="server"
                                        TargetControlID="txtDate" PopupButtonID="imgClaimDetailDate" Format="dd-MMM-yyyy">
                                    </cc3:CalendarExtender></td></tr>
                         <tr><td><asp:Label ID="Label2" runat="server" Text="Cost Center"></asp:Label></td> : <td></td><td><asp:TextBox ID="txtCostCenter" runat="server" Width="194px"></asp:TextBox></td></tr>
                         <tr><td><asp:Label ID="Label3" runat="server" Text="GL Code"></asp:Label></td> : <td></td><td><asp:TextBox ID="txtGLCode" runat="server" Width="194px"></asp:TextBox></td></tr>
                         <tr><td><asp:Label ID="Label4" runat="server" Text="Description"></asp:Label></td> : <td></td><td><asp:TextBox ID="txtDescription" runat="server" Width="194px"></asp:TextBox></td></tr>
                         <tr><td><asp:Label ID="Label5" runat="server" Text="Currency"></asp:Label></td> : <td></td><td><asp:TextBox ID="txtCurrency" runat="server" Width="194px"></asp:TextBox></td></tr>
                         <tr><td><asp:Label ID="Label6" runat="server" Text="Amount"></asp:Label></td> : <td></td><td><asp:TextBox ID="txtAmount" runat="server" Width="194px"></asp:TextBox></td></tr>
                         <tr><td><asp:Label ID="Label7" runat="server" Text="GST"></asp:Label></td> : <td></td><td><asp:TextBox ID="txtGST" runat="server" Width="194px"></asp:TextBox></td></tr>
                         <tr><td><asp:Label ID="Label8" runat="server" Text="Exchange Rate"></asp:Label></td> : <td></td><td><asp:TextBox ID="txtExchangeRate" runat="server" Width="194px"></asp:TextBox></td></tr>
                         <tr><td><asp:Label ID="Label9" runat="server" Text="Tota Amount"></asp:Label></td> : <td></td><td><asp:TextBox ID="txtTotalAmount" runat="server" Width="194px"></asp:TextBox></td></tr>
                         <tr><td></td><td></td><td></td></tr>
                         <tr><td></td><td></td><td>
                    <table><tr><td><asp:Button ID="btnSave" runat="server" Text="Save" Width="56px" OnClick="btnSave_Click" /></td><td><asp:Button ID="btnReset" runat="server" Text="Reset" Width="56px" OnClick="btnReset_Click" /></td><td><asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="56px" OnClick="btnCancel_Click" /></td></tr></table>
                    
                    </td></tr>
            </table>
                     </asp:Panel>

                     
                     </ContentTemplate>
                </asp:UpdatePanel>
                        </panel>
       </td><td></td></tr></table>
        </div>
    </form>
</body>
</html>
