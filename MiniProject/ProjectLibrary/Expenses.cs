using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary
{
    [Serializable]
    public partial class Expenses
    {

        private string index;
        private DateTime dateofExpenses;
        private string costCenter;
        private string gLCode;
        private string description;
        private string currency;
        private decimal amount;
        private decimal gST;
        private decimal eExchangeRate;
        private decimal totalAmount;
        private int iD;
        private string user;
        private int claimId;

        public string Index { get { return this.index; } set { this.index = value; } }
        public DateTime DateofExpenses { get { return this.dateofExpenses; } set { this.dateofExpenses = value; } }
        public string CostCenter { get { return this.costCenter; } set { this.costCenter = value; } }
        public string GLCode { get { return this.gLCode; } set { this.gLCode = value; } }
        public string Description { get { return this.description; } set { this.description = value; } }
        public string Currency { get { return this.currency; } set { this.currency = value; } }
        public decimal Amount { get { return this.amount; } set { this.amount = value; } }
        public decimal GST { get { return this.gST; } set { this.gST = value; } }
        public decimal ExchangeRate { get { return this.eExchangeRate; } set { this.eExchangeRate = value; } }
        public decimal TotalAmount { get { return this.totalAmount; } set { this.totalAmount = value; } }
        public int Id{ get { return this.iD; } set { this.iD = value; } }
        public string User { get { return this.user; } set { this.user = value; } }
        public int ClaimID { get { return this.claimId; } set { this.claimId = value; } }


        public Expenses()
        {
            index = "0";
            dateofExpenses = DateTime.Today;
            costCenter = string.Empty;
            gLCode = string.Empty;
            description = string.Empty;
            currency = "RM";
            amount = new decimal(0.0);
            gST = 0;
            eExchangeRate = 1;
            totalAmount = (Amount + (decimal)GST) * 1 ;
            user = string.Empty;
            claimId = 0;
            Id = 0;

        }

        public void Save(int ClaimId)
        {
            this.ClaimID = ClaimId;
            ExpensesDAL DAL = new ExpensesDAL();
            DAL.Save(this);

        }

        public void Delete()
        {
            ExpensesDAL DAL = new ExpensesDAL();
            DAL.Delete(this.iD);
        }
        
    }
}
