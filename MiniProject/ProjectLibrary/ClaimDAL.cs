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
                    SqlDataReader result = db.ExecuteReaderBySP("Claim_Save", parameters);
                    if (result != null)
                    {
                        while (result.Read())
                        {
                            claimID = (int)Common.NoNull(result["ID"], "0");
                        }

                        result.Close();
                        result.Dispose();
                    }
                }

                if (claimID > 0)
                { claim.ID = claimID; }

                return claimID > 0;
            }

            public void Delete(int ID)
            {
                ArrayList parameters = new ArrayList();
                parameters.Add(new SqlParameter("@Id",ID));
           

                using (DataAccess db = new DataAccess(DataAccess.SourceType.Master1))
                {
                    db.ExecuteReaderBySP("Claim_Delete", parameters);
                }

            }

            public Claim GetClaimByID(int Id)
            {
                ArrayList parameters = new ArrayList();
                parameters.Add(new SqlParameter("@Id", Id));

                using (DataAccess db = new DataAccess(DataAccess.SourceType.Master1))
                {
                    return _GenerateClaims(db.ExecuteReaderBySP("GetClaimByID", parameters));
                }
            }

            private Claim _GenerateClaims(SqlDataReader sqlDR)
            {
                Claim claim = new Claim();
                if (sqlDR != null)
                {
                    while (sqlDR.Read())
                    {
                        claim.ID = (int)Common.NoNull(sqlDR["ID"], 0);
                        claim.AccountNo = (string)Common.NoNull(sqlDR["AccountNo"], string.Empty);
                        claim.BankCode = (string)Common.NoNull(sqlDR["BankCode"], string.Empty);
                        claim.BranchCode = (string)Common.NoNull(sqlDR["BranchCode"], string.Empty);
                        claim.ClaimDate = (DateTime)Common.NoNull(sqlDR["ClaimDate"], string.Empty);
                        claim.User = (string)Common.NoNull(sqlDR["User"], string.Empty);
                        SystemLogin log = new SystemLogin();
                        claim.Expenses = log.GetExpensesByClaimID(claim.ID);

                    }

                    sqlDR.Close();
                    sqlDR.Dispose();
                }

                return claim;
            }


        }
    }
}
