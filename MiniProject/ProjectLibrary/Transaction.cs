using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary
{
    [Serializable]
    public partial class Transaction
    {

        private string index;
        private DateTime dateofTransaction;
        private string costCenter;
        private string gLCode;
        private string description;
        private string currency;
        private decimal amount;
        private float gST;
        private float eExchangeRate;
        private decimal totalAmount;
        private int iD;

        public string Index { get { return this.index; } set { this.index = value; } }
        public DateTime DateofTransaction { get { return this.dateofTransaction; } set { this.dateofTransaction = value; } }
        public string CostCenter { get { return this.costCenter; } set { this.costCenter = value; } }
        public string GLCode { get { return this.gLCode; } set { this.gLCode = value; } }
        public string Description { get { return this.description; } set { this.description = value; } }
        public string Currency { get { return this.currency; } set { this.currency = value; } }
        public decimal Amount { get { return this.amount; } set { this.amount = value; } }
        public float GST { get { return this.gST; } set { this.gST = value; } }
        public float ExchangeRate { get { return this.eExchangeRate; } set { this.eExchangeRate = value; } }
        public decimal TotalAmount { get { return this.totalAmount; } set { this.totalAmount = value; } }
        public int Id{ get { return this.iD; } set { this.iD = value; } }


        public Transaction()
        {
            index = "0";
            dateofTransaction = new DateTime(2018, 10, 2);
            costCenter = "1";
            gLCode = "4321";
            description = "Mobile";
            currency = "RM";
            amount = new decimal(20.0);
            gST = 2;
            eExchangeRate = 1;
            totalAmount = (Amount + (decimal)GST) * 1 ;

        }

        public void Save()
        {

        }

        public Transaction GetTransactionDetails(int id)
        {
            Transaction trans = new Transaction();

            return trans;

        }

        
    }
}
