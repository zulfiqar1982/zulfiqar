﻿using System;
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
                    SqlDataReader result = db.ExecuteReaderBySP("Expenses_Save", parameters);
                    if (result != null)
                    {
                        while (result.Read())
                        {
                            expenses.Id = (int)Common.NoNull(result["ID"], "0");
                        }

                        result.Close();
                        result.Dispose();
                    }
                }
            }

            public void Delete(int ID)
            {
                ArrayList parameters = new ArrayList();
                parameters.Add(new SqlParameter("@Id", ID));


                using (DataAccess db = new DataAccess(DataAccess.SourceType.Master1))
                {
                    db.ExecuteReaderBySP("Expense_Delete", parameters);
                }

            }

        }
    }
}
