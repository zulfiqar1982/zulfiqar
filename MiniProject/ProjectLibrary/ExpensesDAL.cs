using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace ProjectLibrary
{

    public partial class Expenses
    {
        public class ExpensesDAL
        {
            public void Save(Expenses expenses)
            {
                ArrayList parameters = new ArrayList();
                parameters.Add(new SqlParameter("@ID", expenses.Id));
                parameters.Add(new SqlParameter("@GLCode", Common.NoNull(expenses.GLCode, DBNull.Value)));
                parameters.Add(new SqlParameter("@Description", Common.NoNull(expenses.Description, DBNull.Value)));
                parameters.Add(new SqlParameter("@Currency", Common.NoNull(expenses.Currency, DBNull.Value)));
                parameters.Add(new SqlParameter("@Amount", Common.NoNull(expenses.Amount, DBNull.Value)));
                parameters.Add(new SqlParameter("@GST", Common.NoNull(expenses.GST, DBNull.Value)));
                parameters.Add(new SqlParameter("@ExchangeRate", Common.NoNull(expenses.ExchangeRate, DBNull.Value)));
                parameters.Add(new SqlParameter("@TotalAmount", Common.NoNull(expenses.TotalAmount, DBNull.Value)));
                parameters.Add(new SqlParameter("@ClaimID", Common.NoNull(expenses.ClaimID, DBNull.Value)));
                parameters.Add(new SqlParameter("@ExpensesDate", Common.NoNull(expenses.DateofExpenses, DBNull.Value)));
                parameters.Add(new SqlParameter("@User", Common.NoNull(expenses.User, DBNull.Value)));
               

                using (DataAccess db = new DataAccess(DataAccess.SourceType.Master1))
                {
                    db.ExecuteScalarBySP("Expenses_Save", parameters);
                }
            }

        }
    }
}
