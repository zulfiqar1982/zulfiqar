using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProjectLibrary
{
    public partial class Transaction
    {
        public string Index { get; set; }
        public DateTime DateofTransaction { get; set; }
        public string CostCenter { get; set; }
        public string GLCode { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public float GST { get; set; }
        public float ExchangeRate { get; set; }
        public decimal TotalAmount { get; set; }

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
