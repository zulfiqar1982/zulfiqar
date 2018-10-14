using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlTypes;

namespace ProjectLibrary
{
    [Serializable]
    public class Client
    {
        public string CompanyCode { get; set; }
        public string BankCode { get; set; }
        public string AccountNo { get; set; }
        public int TransactionID { get; set; }

    }
}
