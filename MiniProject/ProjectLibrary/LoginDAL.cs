using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace ProjectLibrary
{
    public partial class SystemLogin
    {
        public class LoginDAL
        {
            public List<User> GetAllUser()
            {
                ArrayList parameters = new ArrayList();

                using (DataAccess db = new DataAccess(DataAccess.SourceType.Master1))
                {
                    return _GenerateUsers(db.ExecuteReaderBySP("GetAllUsers", parameters));
                }
            }

            public List<Claim> GetAllClaim()
            {
                ArrayList parameters = new ArrayList();

                using (DataAccess db = new DataAccess(DataAccess.SourceType.Master1))
                {
                    return _GenerateClaims(db.ExecuteReaderBySP("GetAllClaims", parameters));
                }
            }

            public List<Expenses> GetExpensesByClaimID(int Id)
            {
                ArrayList parameters = new ArrayList();
                parameters.Add(new SqlParameter("@ClaimID", Id));
                using (DataAccess db = new DataAccess(DataAccess.SourceType.Master1))
                {
                    return _GenerateExpenses(db.ExecuteReaderBySP("GetExpensesByClaimID", parameters));
                }
            }

            private List<User> _GenerateUsers(SqlDataReader sqlDR)
            {
                List<User> list = new List<User>();
                if (sqlDR != null)
                {
                    while (sqlDR.Read())
                    {
                        User user = new User();
                        user.EmployeeID = (string)Common.NoNull(sqlDR["employeeid"], string.Empty);
                        user.Address = (string)Common.NoNull(sqlDR["street_address"], string.Empty);
                        user.DOB = (string)Common.NoNull(sqlDR["bdate"], string.Empty);
                        user.FirstName = (string)Common.NoNull(sqlDR["fname"], string.Empty);
                        user.LastName = (string)Common.NoNull(sqlDR["lname"], string.Empty);
                        user.MiddleName = (string)Common.NoNull(sqlDR["minit"], string.Empty);
                        user.Password = (string)Common.NoNull(sqlDR["pwd"], string.Empty);
                        user.Salary = (double)Common.NoNull(sqlDR["salary"], string.Empty);
                        user.UserName = (string)Common.NoNull(sqlDR["username"], string.Empty);

                        list.Add(user);
                    }

                    sqlDR.Close();
                    sqlDR.Dispose();
                }

                return list;
            }

            private List<Claim> _GenerateClaims(SqlDataReader sqlDR)
            {
                List<Claim> list = new List<Claim>();
                if (sqlDR != null)
                {
                    while (sqlDR.Read())
                    {
                        Claim claim = new Claim();
                        claim.ID = (int)Common.NoNull(sqlDR["ID"], 0);
                        claim.AccountNo = (string)Common.NoNull(sqlDR["AccountNo"], string.Empty);
                        claim.BankCode = (string)Common.NoNull(sqlDR["BankCode"], string.Empty);
                        claim.BranchCode = (string)Common.NoNull(sqlDR["BranchCode"], string.Empty);
                        claim.ClaimDate = (DateTime)Common.NoNull(sqlDR["ClaimDate"], string.Empty);
                        claim.User = (string)Common.NoNull(sqlDR["User"], string.Empty);
                        claim.Expenses = GetExpensesByClaimID(claim.ID);

                        list.Add(claim);
                    }

                    sqlDR.Close();
                    sqlDR.Dispose();
                }

                return list;
            }

            private List<Expenses> _GenerateExpenses(SqlDataReader sqlDR)
            {
                List<Expenses> list = new List<Expenses>();
                if (sqlDR != null)
                {
                    while (sqlDR.Read())
                    {
                        Expenses expenses = new Expenses();
                        expenses.Id = (int)Common.NoNull(sqlDR["ID"], 0);
                        expenses.GLCode = (string)Common.NoNull(sqlDR["GLCode"], string.Empty);
                        expenses.Description = (string)Common.NoNull(sqlDR["Description"], string.Empty);
                        expenses.Currency = (string)Common.NoNull(sqlDR["Currency"], string.Empty);
                        expenses.Amount = (decimal)Common.NoNull(sqlDR["Amount"], string.Empty);
                        expenses.GST = (decimal)Common.NoNull(sqlDR["GST"], 0.0);
                        expenses.ExchangeRate = (decimal)Common.NoNull(sqlDR["ExchangeRate"], 0.0);
                        expenses.TotalAmount = (decimal)Common.NoNull(sqlDR["TotalAmount"], 0.0);
                        expenses.ClaimID = (int)Common.NoNull(sqlDR["ClaimsID"], string.Empty);
                        expenses.DateofExpenses = (DateTime)Common.NoNull(sqlDR["ExpensesDate"], string.Empty);
                        expenses.User = (string)Common.NoNull(sqlDR["User"], string.Empty);

                    }

                    sqlDR.Close();
                    sqlDR.Dispose();
                }

                return list;
            }
        }
    }
}
