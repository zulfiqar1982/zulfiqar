using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLibrary;

namespace MiniProject
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
        }

        protected void btn_signIn_Click(object sender, EventArgs e)
        {
            SystemLogin logs = new SystemLogin();
            List<User> users = logs.GetAllUser();

            foreach (User user in users)
            {
                if (user.UserName.Equals(txt_username.Text))
                {
                    if (user.Password.Equals(txt_password.Text))
                    {
                        Session["User"] = user;
                        Server.Transfer("ClaimList.aspx", true);
                       
                    }
                    else
                    {
                        lblError.Text = "Wrong Password";
                        
                    }

                    break;
                }
                else
                {
                    lblError.Text = "Username is not exists";
                }
            }
        }
    }
}