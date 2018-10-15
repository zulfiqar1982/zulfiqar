using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectLibrary
{
    public partial class SystemLogin
    {
        public List<User> GetAllUser()
        {
            try
            {
                LoginDAL DAL = new LoginDAL();
                return DAL.GetAllUser();
            }
            catch(Exception ex)
            {
                throw new Exception("GetAllUser Error") ;
            }
        }

        public List<Claim> GetAllClaim()
        {
            try
            {
                LoginDAL DAL = new LoginDAL();
                return DAL.GetAllClaim();
            }
            catch (Exception ex)
            {
                throw new Exception("GetAllClaim Error");
            }
        }
    }
}
