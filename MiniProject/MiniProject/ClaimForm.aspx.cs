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
                ClaimDetail = (Claim)Session["Claim"];
                _PopulateClaimDetails();
                if (ClaimDetail.Expenses == null)
                {
                    ClaimDetail.Expenses = new List<Expenses>();
                    ClaimDetail.Expenses.Add(new Expenses());
                    ClaimDetail.Expenses.Sort();

                    Session["Expenses"] = ClaimDetail.Expenses;
                }

                _GridViewBind();
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
                    _PopulateDetails(_GetExpenses(Convert.ToInt32(id)));
                    mp1.Show();
                    _GridViewBind();
                    break;
            }
        }

        protected void gw_ForEdit_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }


        protected void btnAddExpenses_Click(object sender, EventArgs e)
        {
            //Server.Transfer("ExpensesDetails.aspx", true);
            ClaimDetail.Expenses.Add(new Expenses());
            gw_ForEdit.DataSource = ClaimDetail.Expenses;
            gw_ForEdit.DataBind();
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
            ClaimDetail.Expenses = (List<Expenses>)Session["Expenses"];
            if(ClaimDetail.Expenses.Count > 0)
            {
                foreach(Expenses t in ClaimDetail.Expenses)
                {
                    if(t.Id == id)
                    {
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
            ClaimDetail.Expenses = (List<Expenses>)Session["Expenses"];
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

                Session["Expenses"] = ClaimDetail.Expenses;
            }

            return tran;

        }

       

        protected void gw_ForEdit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            foreach (Expenses expenses in ClaimDetail.Expenses)
            {
                if (expenses.Id.ToString() == txtID.Text)
                {
                    expenses.Id = Convert.ToInt32(txtID.Text);
                    if (txtAmount.Text != string.Empty)
                    {
                        expenses.Amount = Convert.ToDecimal(txtAmount.Text);
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

                    if (txtDescription.Text != string.Empty)
                    {
                        expenses.Description = txtDescription.Text;
                    }

                    if (txtExchangeRate.Text != string.Empty)
                    {
                        expenses.ExchangeRate = Convert.ToDecimal(txtExchangeRate.Text);
                    }

                    if (txtGLCode.Text != string.Empty)
                    {
                        expenses.GLCode = txtGLCode.Text;
                    }

                    if (txtGST.Text != string.Empty)
                    {
                        expenses.GST = Convert.ToDecimal(txtGST.Text);
                    }


                    if (txtTotalAmount.Text != string.Empty)
                    {
                        expenses.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text);
                    }

                    expenses.Save(ClaimDetail.ID);
                }
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

       

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            mp1.Show();
        }

        protected void btnUpdateClaim_Click(object sender, EventArgs e)
        {
            ClaimDetail = (Claim)Session["Claim"];
            ClaimDetail.User = txtUser.Text;
            ClaimDetail.ClaimDate = Convert.ToDateTime(txtClaimDate.Text);
            ClaimDetail.AccountNo = txtAccountCode.Text;
            ClaimDetail.BankCode = txtBankCode.Text;
            ClaimDetail.BranchCode = txtBranchCode.Text;
            ClaimDetail.Save();
            Session["Claim"] = ClaimDetail;
        }

        private void _GridViewBind()
        {
            
            if (ClaimDetail.Expenses !=null && ClaimDetail.Expenses.Count > 0)
            {
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
            txtID.Text = trans.Id.ToString();
            txtAmount.Text = trans.Amount.ToString();
            txtCostCenter.Text = trans.CostCenter;
            txtCurrency.Text = trans.Currency;
            txtDate.Text = trans.DateofExpenses.ToString();
            txtDescription.Text = trans.Description;
            txtExchangeRate.Text = trans.ExchangeRate.ToString();
            txtGLCode.Text = trans.GLCode;
            txtGST.Text = trans.GST.ToString();
            txtTotalAmount.Text = trans.TotalAmount.ToString();
        }

        private void _PopulateClaimDetails()
        {
            txtUser.Text = ClaimDetail.User;
            txtClaimDate.Text = ClaimDetail.ClaimDate.ToString("dd MMMM yyyy");
            txtAccountCode.Text = ClaimDetail.AccountNo;
            txtBankCode.Text = ClaimDetail.BankCode;
            txtBranchCode.Text = ClaimDetail.BranchCode;
        }


    }
}