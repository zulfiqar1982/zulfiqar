using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary
{
    [Serializable]
    public class Claim
    {
        private int id;
        private int userId;
        private DateTime claimDate;
        private string bankCode;
        private string accountNo;
        private string branchCode;
        private List<Transaction> transactions;

        public int ID { get { return this.id; } set { this.id = value; } } 
        public int UserId { get { return this.userId; } set { this.userId = value; } }
        public DateTime ClaimDate { get { return this.claimDate; } set { this.claimDate = value; } }
        public string BankCode { get { return this.bankCode; } set { this.bankCode = value; } }
        public string AccountNo { get { return this.accountNo; } set { this.accountNo = value; } }
        public string BranchCode { get { return this.branchCode; } set { this.branchCode = value; } }
        public List<Transaction> Transactions { get { return this.transactions; } set { this.transactions = value; } }

        public Claim()
        {
            ID = 0;
            UserId = 0;
            ClaimDate = DateTime.Today;
            BankCode = string.Empty;
            AccountNo = string.Empty;
            BranchCode = string.Empty;
            Transactions = new List<Transaction>();
        }

        public List<Transaction> GetTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();
            return transactions;
        }

    }
}
