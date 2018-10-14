<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClaimForm.aspx.cs" Inherits="MiniProject.ClaimForm" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

       <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <script type="text/javascript">
            //$(function () {
            //    $("[id*=gw_ForEdit] [id*=lnkDelete]").click(function () {
            //        if (confirm("Do you want to delete this Transaction?")) {
            //            //Determine the GridView row within whose LinkButton was clicked.
            //            var row = $(this).closest("tr");

            //            //Look for the Hidden Field and fetch the CustomerId.
            //            var index = parseInt(row.find("[id*=IndexDelete]").val());

            //            //Make an AJAX call to server side and pass the fetched CustomerId.
            //            $.ajax({
            //                type: "POST",
            //                url: "ClaimForm.aspx/DeleteTransaction",
            //                data: '{index: ' + index + '}',
            //                contentType: "application/json; charset=utf-8",
            //                dataType: "json",
            //                success: function RemoveRow(item) {
            //                    var table = document.getElementById('gw_ForEdit');
            //                    table.deleteRow(item.parentNode.parentNode.rowIndex);
            //                    return false;
            //                }
                            
            //            });
            //        }
            //        return false;
            //    });
            //});
        </script>
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
        width: 340px;
        height: 460px;
    }

    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div>
           
            <table>
                <tr><td></td><td>
                    <table style="">
                <tr><td>
                    <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                    </td><td>:</td><td>
                    <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                    </td></tr>
                <tr><td>
                    <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                    </td><td>:</td><td>
                    <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                    </td></tr>
                <tr><<td>
                    <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                    </td><td>:</td><td>
                    <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                    </td></tr></table>

                </td><td></td></tr>
                <tr><td></td><td></td><td></td></tr>
                <tr><td></td><td></td><td></td></tr>
                <tr><td></td><td></td><td></td></tr>
                <tr><td></td><td style="align-content:center; align-items:center;">
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
                     
                       <asp:Button ID="btnAddTransaction" runat="server" Text="Add Claim Transaction" OnClick="btnAddTransaction_Click" />
                    <cc1:ModalPopupExtender ID ="mp1" runat="server" PopupControlID="pnlAddEdit" TargetControlID="btnAddTransaction"
                    CancelControlID="btnCancel" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
                     <asp:Panel ID="pnlAddEdit" runat="server" CssClass="modalPopup" style = "display:None; align-self:center; align-content:center">
                         <h3>Transaction Details</h3>
                         <table>
                         <tr><td><asp:Label ID="Label10" runat="server" Text="ID"></asp:Label></td> : <td></td><td><asp:TextBox ID="txtID" runat="server" Width="194px"></asp:TextBox></td></tr>
                         <tr><td><asp:Label ID="Label1" runat="server" Text="Date"></asp:Label></td> : <td></td><td><asp:TextBox ID="txtDate" runat="server" Width="194px"></asp:TextBox></td></tr>
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
       </td><td></td></tr></table>
        </div>
    </form>
</body>
</html>
