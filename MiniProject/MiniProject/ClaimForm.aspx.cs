using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ProjectLibrary;

namespace MiniProject
{
    public partial class ClaimForm : System.Web.UI.Page
    {
        //public List<Expenses> Expenses;
        public Claim ClaimDetail;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["User"] == null)
                {
                    Server.Transfer("LoginPage.aspx", true);
                }

                ClaimDetail = (Claim)Session["Claim"];

                SystemLogin sl = new SystemLogin();
                foreach(Claim cl in sl.GetAllClaim())
                {
                    if(cl.ID == ClaimDetail.ID)
                    {
                        ClaimDetail = cl;
                    }
                }

                HFClaimID.Value = ClaimDetail.ID.ToString();
                ViewState["Claim"] = ClaimDetail;
                _PopulateClaimDetails();
                if (ClaimDetail.Expenses == null)
                {
                    ClaimDetail.Expenses = new List<Expenses>();
                    ClaimDetail.Expenses.Sort();

                    ViewState["Expenses"] = ClaimDetail.Expenses;
                }

                _GridViewBind();
                _PopulateDetails(new Expenses());

                btnAddExpenses.Enabled = ClaimDetail.ID > 0;

            }
        }

        protected void gw_ForEdit_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            switch (e.CommandName.ToUpper())
            {               
                case "DELETE" :
                    _DeleteRow(Convert.ToInt32(id));
                    _GridViewBind();
                    break;
                case "EDIT":

                    mp1.Show();
                    _PopulateDetails(_GetExpenses(Convert.ToInt32(id)));
                    break;
            }
        }

        protected void gw_ForEdit_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }


        protected void btnAddExpenses_Click(object sender, EventArgs e)
        {

            if (ClaimDetail == null)
            {
                ClaimDetail = (Claim)ViewState["Claim"];
            }

            if(ClaimDetail.Expenses == null)
            {
                ClaimDetail.Expenses = new List<Expenses>();
            }

            Expenses expense = new Expenses();
            ClaimDetail.Expenses.Add(expense);
            _PopulateDetails(expense);

            _GridViewBind();
        }

     

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton lnkbtn = sender as LinkButton;
            //getting particular row linkbutton
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            //getting userid of particular row
            int userid = Convert.ToInt32(gw_ForEdit.DataKeys[gvrow.RowIndex].Value.ToString());
        }

        protected void gw_ForEdit_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //string id = gw_ForEdit.DataKeys[e.RowIndex][0].ToString();
        }

        private void _DeleteRow(int id)
        {
            ClaimDetail = (Claim)ViewState["Claim"];
            if(ClaimDetail.Expenses.Count > 0)
            {
                foreach(Expenses t in ClaimDetail.Expenses)
                {
                    if(t.Id == id)
                    {
                        t.Delete();
                        ClaimDetail.Expenses.Remove(t);
                        break;
                    }
                }

               Session["Expenses"] = ClaimDetail.Expenses;
            }
        }

        private Expenses _GetExpenses(int id)
        {
            Expenses tran = new Expenses();
            ClaimDetail = (Claim)ViewState["Claim"];
            if(ClaimDetail.ID == 0)
            {
                ClaimDetail = new Claim();
            }

            if (ClaimDetail.Expenses.Count > 0)
            {
                foreach (Expenses t in ClaimDetail.Expenses)
                {
                    if (t.Id == id)
                    {
                        tran = t;
                        break;
                    }
                }
            }

            return tran;

        }

       

        protected void gw_ForEdit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ClaimDetail = (Claim)ViewState["Claim"];           

            if (lblID.Text == "0")
            {
                Expenses expenses = new Expenses();
                expenses.ClaimID = ClaimDetail.ID;
                expenses.User = ClaimDetail.User;
                _AssignData(expenses);
            }
            else
            {

                foreach (Expenses expenses in ClaimDetail.Expenses)
                {
                    if (expenses.Id.ToString() == lblID.Text)
                    {

                        _AssignData(expenses);
                        //expenses.Id = Convert.ToInt32(txtID.Text);

                        break;
                    }
                }
            }

            SystemLogin sl = new SystemLogin();
            foreach (Claim cl in sl.GetAllClaim())
            {
                if (ClaimDetail.ID == cl.ID)
                {
                    ClaimDetail = cl;
                }
            }

            ViewState["Claim"] = ClaimDetail;
            mp1.Hide();
            _GridViewBind();
            Response.Redirect("ClaimForm.aspx");
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

       

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            //mp1.Show();
        }

        protected void btnUpdateClaim_Click(object sender, EventArgs e)
        {
            ClaimDetail = (Claim)ViewState["Claim"];
            ClaimDetail.User = txtUser.Text;
            ClaimDetail.ClaimDate = Common.ConvertToDateTime(txtClaimDate.Text, "dd-MMM-yyyy hh:mm:ss tt");
            ClaimDetail.AccountNo = txtAccountCode.Text;
            ClaimDetail.BankCode = txtBankCode.Text;
            ClaimDetail.BranchCode = txtBranchCode.Text;
            ClaimDetail.Save();
            HFClaimID.Value = ClaimDetail.ID.ToString();
            Session["Claim"] = ClaimDetail;

            Response.Redirect("ClaimForm.aspx");
        }

        private void _GridViewBind()
        {
            ClaimDetail = (Claim)ViewState["Claim"];
            if(ClaimDetail.Expenses == null)
            {
                SystemLogin sl = new SystemLogin();
                foreach (Claim cl in sl.GetAllClaim())
                {
                    if (cl.ID == Convert.ToInt32(HFClaimID.Value))
                    {
                        ClaimDetail = cl;
                    }
                }
            }
            else if(ClaimDetail.Expenses !=null)
            {
                if(ClaimDetail.Expenses.Count == 0)
                {
                   // ClaimDetail.Expenses.Add(new Expenses());
                }

                this.pnlAddEdit.Visible = true;
                gw_ForEdit.DataSource = ClaimDetail.Expenses;
                gw_ForEdit.DataBind();
            }
            else
            {
                this.pnlAddEdit.Visible = false;
            }
        }

        private void _PopulateDetails(Expenses trans)
        {
            lblID.Text = trans.Id.ToString();
            txtAmount.Text = trans.Amount.ToString();
            txtCostCenter.Text = trans.CostCenter;
            txtCurrency.Text = trans.Currency;
            txtDate.Text = trans.DateofExpenses.ToString("dd-MMM-yyyy");
            txtDescription.Text = trans.Description;
            txtExchangeRate.Text = trans.ExchangeRate.ToString();
            txtGLCode.Text = trans.GLCode;
            txtGST.Text = trans.GST.ToString();
            txtTotalAmount.Text = trans.TotalAmount.ToString();
        }

        private void _PopulateClaimDetails()
        {
            txtUser.Text = ClaimDetail.User;
            txtClaimDate.Text = ClaimDetail.ClaimDate.ToString("dd-MMM-yyyy");
            txtAccountCode.Text = ClaimDetail.AccountNo;
            txtBankCode.Text = ClaimDetail.BankCode;
            txtBranchCode.Text = ClaimDetail.BranchCode;
        }

        protected void lnkEdit_Click1(object sender, EventArgs e)
        {
            //string expensesID = ((System.Web.UI.WebControls.LinkButton)sender).CommandArgument.ToString();
            
            //_PopulateDetails(_GetExpenses(Convert.ToInt32(expensesID)));
            //mp1.Show();
        }

      

        protected void lnkClaim_Click(object sender, EventArgs e)
        {
            Server.Transfer("ClaimList.aspx", true);
        }

        private void _AssignData(Expenses expenses)
        {
            bool check = true;
            if (txtAmount.Text != string.Empty)
            {
                expenses.Amount = Convert.ToDecimal(txtAmount.Text);
            }
            else
            {
                lblAmount.Visible = true;
                check = false;
            }

            if (txtCostCenter.Text != string.Empty)
            {
                expenses.CostCenter = txtCostCenter.Text;
            }

            if (txtCurrency.Text != string.Empty)
            {
                expenses.Currency = txtCurrency.Text;
            }

            if (txtDate.Text != string.Empty)
            {
                expenses.DateofExpenses = Convert.ToDateTime(txtDate.Text);
            }
            else
            {
                lblDate.Visible = true;
                check = false;
            }

            if (txtDescription.Text != string.Empty)
            {
                expenses.Description = txtDescription.Text;
            }

            if (txtExchangeRate.Text != string.Empty)
            {
                expenses.ExchangeRate = Convert.ToDecimal(txtExchangeRate.Text);
            }
            else
            {
                lblExchangeRate.Visible = true;
                check = false;
            }

            if (txtGLCode.Text != string.Empty)
            {
                expenses.GLCode = txtGLCode.Text;
            }
            else
            {
                lblGLCode.Visible = true;
                check = false;
            }

            if (txtGST.Text != string.Empty)
            {
                expenses.GST = Convert.ToDecimal(txtGST.Text);
            }
            else
            {
                lblGST.Visible = true;
                check = false;
            }


            if (txtTotalAmount.Text != string.Empty)
            {
                expenses.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text);
            }
            else
            {
                lblTotalAmount.Visible = true;
                check = false;
            }

            if (check)
            {
                expenses.User = ClaimDetail.User;
                expenses.Save(ClaimDetail.ID);
            }
        }

        protected void gw_ForEdit_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gw_ForEdit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //gw_ForEdit.EditIndex = -1;

        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Server.Transfer("LoginPage.aspx", true);
            Session["User"] = null;
        }
    }
}