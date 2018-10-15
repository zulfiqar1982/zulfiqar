using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjectLibrary
{
    public partial class Claim
    {
        public class ClaimDAL
        {            

           

            public bool Save(Claim claim)
            {
                int claimID = 0;
                ArrayList parameters = new ArrayList();
                parameters.Add(new SqlParameter("@Id", claim.ID));
                parameters.Add(new SqlParameter("@BankCode", claim.BankCode));
                parameters.Add(new SqlParameter("@AccountNo", Common.NoNull(claim.AccountNo, DBNull.Value)));
                parameters.Add(new SqlParameter("@BranchCode", Common.NoNull(claim.BranchCode, DBNull.Value)));
                parameters.Add(new SqlParameter("@User", Common.NoNull(claim.User, DBNull.Value)));
                parameters.Add(new SqlParameter("@ClaimDate", claim.ClaimDate));

                using (DataAccess db = new DataAccess(DataAccess.SourceType.Master1))
                {
                    claimID = Convert.ToInt32(db.ExecuteScalarBySP("Claim_Save", parameters));
                }

                return claimID > 0;
            }

          
        }
    }
}
