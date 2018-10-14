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
        //public List<Transaction> Transactions;
        public Claim ClaimDetail;


        protected void Page_Load(object sender, EventArgs e)
        {
            ClaimDetail = (Claim)Session["Claim"];
            if (ClaimDetail.Transactions == null)
            {
                ClaimDetail.Transactions = new List<Transaction>();
                ClaimDetail.Transactions.Add(new Transaction());
                ClaimDetail.Transactions.Sort();

                Session["Transaction"] = ClaimDetail.Transactions;
            }

            _GridViewBind();
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
                    _PopulateDetails(_GetTransaction(Convert.ToInt32(id)));
                    mp1.Show();
                    _GridViewBind();
                    break;
            }
        }

        protected void gw_ForEdit_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        [WebMethod]
        public static void DeleteTransaction(int index)
        {
            ClaimForm claim = new ClaimForm();
            List<Transaction> Transactions = (List<Transaction>)claim.Session["Transaction"];
            foreach(Transaction tr in Transactions)
            {
                if (tr.Id == index)
                {
                    Transactions.Remove(tr);
                    break;
                }
            }

            claim.Session["Transaction"] = Transactions;
            
        }

        protected void btnAddTransaction_Click(object sender, EventArgs e)
        {
            //Server.Transfer("TransactionDetails.aspx", true);
            ClaimDetail.Transactions.Add(new Transaction());
            gw_ForEdit.DataSource = ClaimDetail.Transactions;
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
            ClaimDetail.Transactions = (List<Transaction>)Session["Transaction"];
            if(ClaimDetail.Transactions.Count > 0)
            {
                foreach(Transaction t in ClaimDetail.Transactions)
                {
                    if(t.Id == id)
                    {
                        ClaimDetail.Transactions.Remove(t);
                        break;
                    }
                }

               Session["Transaction"] = ClaimDetail.Transactions;
            }
        }

        private Transaction _GetTransaction(int id)
        {
            Transaction tran = new Transaction();
            ClaimDetail.Transactions = (List<Transaction>)Session["Transaction"];
            if (ClaimDetail.Transactions.Count > 0)
            {
                foreach (Transaction t in ClaimDetail.Transactions)
                {
                    if (t.Id == id)
                    {
                        tran = t;
                        break;
                    }
                }

                Session["Transaction"] = ClaimDetail.Transactions;
            }

            return tran;

        }

       

        protected void gw_ForEdit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            foreach (Transaction trans in ClaimDetail.Transactions)
            {
                if (trans.Id.ToString() == txtID.Text)
                {
                    trans.Id = Convert.ToInt32(txtID.Text);
                    trans.Amount = Convert.ToDecimal(txtAmount.Text);
                    trans.CostCenter = txtCostCenter.Text;
                    trans.Currency = txtCurrency.Text;
                    trans.DateofTransaction = Convert.ToDateTime(txtDate.Text);
                    trans.Description = txtDescription.Text;
                    trans.ExchangeRate = float.Parse(txtExchangeRate.Text);
                    trans.GLCode = txtGLCode.Text;
                    trans.GST = float.Parse(txtGST.Text) ;
                    txtTotalAmount.Text = trans.TotalAmount.ToString();

                    trans.Save(ClaimDetail.ID);
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

        }

        private void _GridViewBind()
        {
            ClaimDetail.Transactions = (List<Transaction>)Session["Transaction"];
            gw_ForEdit.DataSource = ClaimDetail.Transactions;
            gw_ForEdit.DataBind();
        }

        private void _PopulateDetails(Transaction trans)
        {
            txtID.Text = trans.Id.ToString();
            txtAmount.Text = trans.Amount.ToString();
            txtCostCenter.Text = trans.CostCenter;
            txtCurrency.Text = trans.Currency;
            txtDate.Text = trans.DateofTransaction.ToString();
            txtDescription.Text = trans.Description;
            txtExchangeRate.Text = trans.ExchangeRate.ToString();
            txtGLCode.Text = trans.GLCode;
            txtGST.Text = trans.GST.ToString();
            txtTotalAmount.Text = trans.TotalAmount.ToString();
        }


    }
}