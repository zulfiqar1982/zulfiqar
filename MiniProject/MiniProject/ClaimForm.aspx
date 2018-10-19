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

         .auto-style1 {
             width: 1132px;
         }

         .auto-style2 {
             border: 3px solid black;
             background-color: #FFFFFF;
             padding-top: 10px;
             padding-left: 10px;
         }
         
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div>
           
            <asp:HiddenField ID="HFClaimID" runat="server" />
           
            <table style="width:100%">
                <tr><td></td><td class="auto-style1"><h3>Claim Details</h3></td><td>
                    <asp:LinkButton ID="lnkClaim" Text="Claim List" runat="server" OnClick="lnkClaim_Click"   />
&nbsp;
                    <asp:LinkButton ID="lnkLogout" Text="Logout" runat="server" OnClick="lnkLogout_Click"   />
                    </td></tr>
                <tr><td></td><td class="auto-style1">
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

                <tr><td></td><td style="align-content:center; align-items:center;" class="auto-style1">
                    <%--<panel id="pnlExpenses">--%>
                      <asp:ScriptManager ID="ScriptManager1" runat="Server" />
           <asp:UpdatePanel runat="server" id="upData">
                 <ContentTemplate>
                        <asp:GridView ID="gw_ForEdit" runat="server" OnRowCommand="gw_ForEdit_RowCommand" AutoGenerateColumns="False" OnRowDeleted="gw_ForEdit_RowDeleted" OnSelectedIndexChanged="gw_ForEdit_SelectedIndexChanged" OnRowDeleting="gw_ForEdit_RowDeleting" ShowHeaderWhenEmpty="True" ShowFooter="True" OnRowCreated="gw_ForEdit_RowCreated" OnRowEditing="gw_ForEdit_RowEditing">
                            <Columns>
                            <asp:TemplateField HeaderStyle-Width="50">
                                <ItemTemplate>
                                    <asp:HiddenField ID="IndexEdit" runat="server" Value='<%# Eval("ID") %>' />
                                    <asp:LinkButton ID="lnkEdit" Text="Edit" runat="server"  CommandName="Edit" 
                                                        CommandArgument='<%# Eval ("ID")%>' OnClick="lnkEdit_Click1" />
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
                               
                   
                                <asp:BoundField DataField="DateofExpenses" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="Date" >                   
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="CostCenter" HeaderText="Cost Center" >                   
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="GLCode" HeaderText="GL Code" >                   
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="Description" HeaderText="Description" >                   
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>                                 
                                <asp:BoundField DataField="Currency" HeaderText="Currency" >                   
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>                                 
                                <asp:BoundField DataField="Amount" HeaderText="Amount" >                   
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>                                 
                                <asp:BoundField DataField="GST" HeaderText="GST" >                   
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>                                 
                                <asp:BoundField DataField="ExchangeRate" HeaderText="ExchangeRate" >                   
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField> 
                                 <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" >                   
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>                                

                   
                            </Columns>
                        </asp:GridView>
                             
                       <asp:Button ID="btnAddExpenses" runat="server" Text="Add Expenses" OnClick="btnAddExpenses_Click" />
                    <cc1:ModalPopupExtender ID ="mp1" runat="server" PopupControlID="pnlAddEdit" TargetControlID="btnAddExpenses"
                    CancelControlID="btnCancel" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
                     <asp:Panel ID="pnlAddEdit" runat="server" CssClass="auto-style2" style = "display:grid; align-self:center; align-content:center" Width="565px">
                         <h3>Expenses Details</h3>
                         <table>
                         <tr><td><asp:Label ID="Label10" runat="server" Text="ID"></asp:Label></td>                                
                                 <td>:</td>
                                 <td>
                                     <asp:Label ID="lblID" runat="server" Text=""></asp:Label>
                                 </td>
                                 <td></td>

                             </tr>
                         <tr><td><asp:Label ID="Label1" runat="server" Text="Date"></asp:Label></td> 
                                 <td>:</td>
                                 <td>
                                     <asp:TextBox ID="txtDate" runat="server" Width="194px"></asp:TextBox>
                                     <asp:Image ID="imgClaimDetailDate" runat="server" ImageUrl="~/Images/calendar.gif" />
                                     <cc3:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgClaimDetailDate" TargetControlID="txtDate" />
                                 </td>
                                 <td><asp:Label ID="lblDate" runat="server" Text="Please fill in date" ForeColor="Red" Visible="false"></asp:Label></td>
                             </tr>
                         <tr><td><asp:Label ID="Label2" runat="server" Text="Cost Center" ></asp:Label></td>                              
                                 <td>:</td>
                                 <td>
                                     <asp:TextBox ID="txtCostCenter" runat="server" Width="194px"></asp:TextBox>
                                 </td>
                             </tr>
                         <tr><td><asp:Label ID="Label3" runat="server" Text="GL Code"></asp:Label></td> 
                                 <td>:</td>
                                 <td>
                                     <asp:TextBox ID="txtGLCode" runat="server" Width="194px"></asp:TextBox>
                                 </td>
                                 <td><asp:Label ID="lblGLCode" runat="server" Text="Please fill in GL Code" Visible="false" ForeColor="Red"></asp:Label></td>
                             </tr>
                         
                         <tr><td><asp:Label ID="Label4" runat="server" Text="Description"></asp:Label></td> 
                                 <td>:</td>
                                 <td>
                                     <asp:TextBox ID="txtDescription" runat="server" Width="194px"></asp:TextBox>
                                 </td>
                             </tr>
                         <tr><td><asp:Label ID="Label5" runat="server" Text="Currency"></asp:Label></td> 
                                 <td>:</td>
                                 <td>
                                     <asp:TextBox ID="txtCurrency" runat="server" Width="194px"></asp:TextBox>
                                 </td>
                                 <td></td>
                             </tr>
                         <tr><td><asp:Label ID="Label6" runat="server" Text="Amount"></asp:Label></td> 
                                 <td>:</td>
                                 <td>
                                     <asp:TextBox ID="txtAmount" runat="server" Width="194px"></asp:TextBox>
                                 </td>
                                   <td><asp:Label ID="lblAmount" runat="server" Text="Please fill in amount" Visible="false" ForeColor="Red"></asp:Label></td>
                             </tr>
                         <tr><td><asp:Label ID="Label7" runat="server" Text="GST"></asp:Label></td> 
                                 <td>:</td>
                                 <td>
                                     <asp:TextBox ID="txtGST" runat="server" Width="194px"></asp:TextBox>
                                 </td>
                                 <td><asp:Label ID="lblGST" runat="server" Text="Please fill in GST" Visible="false" ForeColor="Red"></asp:Label></td>
                             </tr>
                         <tr><td><asp:Label ID="Label8" runat="server" Text="Exchange Rate"></asp:Label></td> 
                                 <td>:</td>
                                 <td>
                                     <asp:TextBox ID="txtExchangeRate" runat="server" Width="194px"></asp:TextBox>
                                 </td>
                                   <td><asp:Label ID="lblExchangeRate" runat="server" Text="Please fill in Exchange Rate" Visible="false" ForeColor="Red"></asp:Label></td>
                             </tr>
                         <tr><td><asp:Label ID="Label9" runat="server" Text="Tota Amount"></asp:Label></td> 

                                 <td>:</td>
                                 <td>
                                     <asp:TextBox ID="txtTotalAmount" runat="server" Width="194px"></asp:TextBox>
                                 </td>
                                   <td><asp:Label ID="lblTotalAmount" runat="server" Text="Please fill in Total Amount" Visible="false" ForeColor="Red"></asp:Label></td>
                             </tr>
                         <tr><td></td><td></td><td></td></tr>
                         <tr><td></td><td></td><td>
                    <table><tr><td><asp:Button ID="btnSave" runat="server" Text="Save" Width="56px" OnClick="btnSave_Click" /></td><td></td><td><asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="56px" OnClick="btnCancel_Click" /></td></tr></table>
                    
                    </td></tr>
            </table>
                     </asp:Panel>

                     
                     </ContentTemplate>
                </asp:UpdatePanel>
                        <%--</panel>--%>
       </td><td></td></tr></table>
        </div>
    </form>
</body>
</html>
