<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CS.aspx.cs" Inherits="CS" %>

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
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="CustomerId" HeaderText="Id" HeaderStyle-Width="30" />
                <asp:BoundField DataField="Name" HeaderText="Name" HeaderStyle-Width="150" />
                <asp:BoundField DataField="Country" HeaderText="Country" HeaderStyle-Width="150" />
                <asp:TemplateField HeaderStyle-Width="50">
                    <ItemTemplate>
                        <asp:HiddenField ID="hfCustomerId" runat="server" Value='<%# Eval("CustomerId") %>' />
                        <asp:LinkButton ID="lnkDelete" Text="Delete" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <script type="text/javascript">
            $(function () {
                $("[id*=GridView1] [id*=lnkDelete]").click(function () {
                    if (confirm("Do you want to delete this Customer?")) {
                        //Determine the GridView row within whose LinkButton was clicked.
                        var row = $(this).closest("tr");

                        //Look for the Hidden Field and fetch the CustomerId.
                        var customerId = parseInt(row.find("[id*=hfCustomerId]").val());

                        //Make an AJAX call to server side and pass the fetched CustomerId.
                        $.ajax({
                            type: "POST",
                            url: "CS.aspx/DeleteCustomer",
                            data: '{customerId: ' + customerId + '}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (r) {
                                if (r.d) {
                                    //Remove the row from the GridView.
                                    row.remove();
                                    //If the GridView has no records then display no records message.
                                    if ($("[id*=GridView1] td").length == 0) {
                                        $("[id*=GridView1] tbody").append("<tr><td colspan = '4' align = 'center'>No records found.</td></tr>")
                                    }
                                    alert("Customer record has been deleted.");
                                }
                            }
                        });
                    }
                    return false;
                });
            });
        </script>
    </form>
</body>
</html>
