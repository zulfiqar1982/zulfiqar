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
        public List<Transaction> Transactions;

        protected void Page_Load(object sender, EventArgs e)
        {
            Transactions = (List<Transaction>)Session["Transaction"];
            if (Transactions == null)
            {
                Transactions = new List<Transaction>();
                Transactions.Add(new Transaction());
                Transactions.Sort();

                Session["Transaction"] = Transactions;
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
                    TransactionDetails edit = new TransactionDetails(Convert.ToInt32(id));
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
            Transactions.Add(new Transaction());
            gw_ForEdit.DataSource = Transactions;
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
            Transactions = (List<Transaction>)Session["Transaction"];
            if(Transactions.Count > 0)
            {
                foreach(Transaction t in Transactions)
                {
                    if(t.Id == id)
                    {
                        Transactions.Remove(t);
                        break;
                    }
                }

               Session["Transaction"] = Transactions;
            }
        }

        private void _GridViewBind()
        {
            Transactions = (List<Transaction>)Session["Transaction"];
            gw_ForEdit.DataSource = Transactions;
            gw_ForEdit.DataBind();
        }

        protected void gw_ForEdit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

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

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            mp1.Show();
        }
    }
}