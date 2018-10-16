using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLibrary;

namespace MiniProject
{
    public partial class ClaimList : System.Web.UI.Page
    {

        public List<Claim> Claims;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SystemLogin logs = new SystemLogin();
                Claims = logs.GetAllClaim();
                Session["Claims"] = Claims;
                _GridViewBind();
            }

        }

        protected void btnAddClaim_Click(object sender, EventArgs e)
        {
            Claim claim = new Claim();
            Session["Claim"] = claim;
            Response.Redirect("ClaimForm.aspx");

        }

        protected void gw_ForEdit_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            switch (e.CommandName.ToUpper())
            {
                case "DELETE":
                    _DeleteRow(Convert.ToInt32(id));
                    _GridViewBind();
                    break;
                case "EDIT":
                    Session["Claim"] = _GetClaim(Convert.ToInt32(id));
                    Server.Transfer("ClaimForm.aspx", true);
                    break;
            }
        }

        private void _GridViewBind()
        {
            Claims = (List<Claim>)Session["Claims"];
            gw_ForEdit.DataSource = Claims;
            gw_ForEdit.DataBind();
        }

        private Claim _GetClaim(int ID)
        {
            Claim claim = new Claim();
            foreach(Claim c in Claims)
            {
                if (c.ID == ID)
                {
                    claim = c;
                }
            }

            return claim;
        }

        private void _DeleteRow(int id)
        {
            Claims = (List<Claim>)Session["Claims"];
            if (Claims.Count > 0)
            {
                foreach (Claim t in Claims)
                {
                    if (t.ID == id)
                    {
                        Claims.Remove(t);
                        break;
                    }
                }

                Session["Transaction"] = Claims;
            }
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {

        }
    }
}