using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary
{
    [Serializable]
    public partial class Claim
    {
        private int id;
        private string user;
        private DateTime claimDate;
        private string bankCode;
        private string accountNo;
        private string branchCode;
        private List<Expenses> expenses;

        public int ID { get { return this.id; } set { this.id = value; } } 
        public string User { get { return this.user; } set { this.user = value; } }
        public DateTime ClaimDate { get { return this.claimDate; } set { this.claimDate = value; } }
        public string BankCode { get { return this.bankCode; } set { this.bankCode = value; } }
        public string AccountNo { get { return this.accountNo; } set { this.accountNo = value; } }
        public string BranchCode { get { return this.branchCode; } set { this.branchCode = value; } }
        public List<Expenses> Expenses { get { return this.expenses; } set { this.expenses = value; } }

        public Claim()
        {
            ID = 0;
            user = string.Empty;
            ClaimDate = DateTime.Today;
            BankCode = string.Empty;
            AccountNo = string.Empty;
            BranchCode = string.Empty;
            Expenses = new List<Expenses>();
        }

        public void Save()
        {
            ClaimDAL DAL = new ClaimDAL();
            DAL.Save(this);
        }

        public void Delete()
        {
            ClaimDAL DAL = new ClaimDAL();
            DAL.Delete(this.ID);
        }

    }
}
