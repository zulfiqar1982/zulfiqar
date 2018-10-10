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

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtLoginName.Text == "zulfiqar" && txtPassword.Text == "zulfiqar")
            {
                SystemLogin logs = new SystemLogin();
                List<User> users = logs.GetAllUser();
                Server.Transfer("Default.aspx", true);
            }
        }
    }
}