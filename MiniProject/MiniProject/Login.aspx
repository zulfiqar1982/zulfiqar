<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="shortcut icon" href="Images/imgPageLogo.ico" />
    <title>SmartGST- Login</title>
    <link rel="stylesheet" href="CSS/disclaimer.css" type="text/css" />
     <script type="text/javascript" language="javascript">
         var newWin = null;
         function popUp(strURL, strType, strHeight, strWidth) {
             if (newWin != null && !newWin.closed)
                 newWin.close();
             var strOptions = "";
             if (strType == "console")
                 strOptions = "resizable,scrollbars,height=" + strHeight + ",width=" + strWidth;
             if (strType == "fixed")
                 strOptions = "status,height=" + strHeight + ",width=" + strWidth;
             if (strType == "elastic")
                 strOptions = "toolbar,menubar,scrollbars,resizable,location,height=" + strHeight + ",width=" + strWidth;
             newWin = window.open(strURL, 'newWin', strOptions);
             newWin.focus();
         }
    </script>
    <style type="text/css">
        .auto-style1 {
            font-family: Verdana;
            font-size: 11px;
            text-align: left;
            margin-left: 100px;
            width: 547px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="wrapper">
        <div id="main">
            <div id="section_left_login">
                <div id="loginbox" style="align-content:center">
                    <table cellspacing="0" cellpadding="5">
                        <tr>
                            <td colspan="2">
                                <h3 class="login_t">
                                    Login (User Name)</h3>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="login_c">
                                Please enter your user name and password to sign in.
                            </td>
                        </tr>
                         <tr>
                            <td class="login_l">
                                Login: </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="tbx_username" runat="server" MaxLength="20" Width="160px" TabIndex="1" CausesValidation="True"></asp:TextBox>
                                <a onclick="popUp(this.href,'console',450,650);return false;" href="ADUsername.aspx"
                                    target="_blank">
                                  
                                    <img src="Images/icon_help.gif" alt="Help" border="0" /></a>
                            </td>
                        </tr>
                     <tr>
                            <td class="login_l">
                                Password:
                            </td>
                            <td class="auto-style1">
                                <asp:TextBox ID="tbx_password" runat="server" TextMode="Password" MaxLength="50" Width="160px"
                                    TabIndex="2"></asp:TextBox>
                            </td>
                        </tr>
                       
                        <tr>
                            <td>
                            </td>
                            <td class="auto-style1">
                                <asp:Button ID="buttonSignIn" onclick="btn_signIn_Click" runat="server" Text="Sign In" Width="80px" TabIndex="3" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="login_error_msg">
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                </div>
               
            </div>
          
        </div>
    </div>    
    </div>
    </form>
</body>
</html>
