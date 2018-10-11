using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace ProjectLibrary
{
    public partial class Transaction
    {
        public class TransactionDAL
        {
            public List<User> GetAllUser()
            {
                ArrayList parameters = new ArrayList();

                using (DataAccess db = new DataAccess(DataAccess.SourceType.Master1))
                {
                    return _GenerateUsers(db.ExecuteReaderBySP("GetAllUsers", parameters));
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
        }
    }
}
