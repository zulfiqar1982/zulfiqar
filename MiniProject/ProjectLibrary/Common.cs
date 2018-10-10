using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Data;
using System.Security.Cryptography;


namespace ProjectLibrary
{

    public class Common
    {

        #region Public

        #region Methods

        public static string ConvertToMonth(int monthValue)
        {
            System.Globalization.DateTimeFormatInfo dtfi = new System.Globalization.DateTimeFormatInfo();
            try
            {
                return dtfi.GetMonthName(monthValue);
            }
            catch (ArgumentOutOfRangeException)
            {
                return "Unknown";
            }
        }

        public static object CheckNull(object data)
        {
            if (data == null)
            {
                return DBNull.Value;
            }
            return data;
        }

        public static object NoNull(object Data, object ReturnValue)
        {
            if (Data == DBNull.Value || Data == null)
                return ReturnValue;
            else
                return Data;
        }

        public static object NoNull(object Data)
        {
            if (Data == DBNull.Value || Data == null)
                return string.Empty;
            else
                return Data;
        }

        public static object NoEmptyString(object Data, object ReturnValue)
        {
            if (Data == DBNull.Value || Data == null || (string)Data == string.Empty)
                return ReturnValue;
            else
                return Data;
        }

        public static object NoEmptyString(object Data)
        {
            if (Data == DBNull.Value || Data == null || (string)Data == string.Empty)
                return null;
            else
                return Data;
        }

        public static decimal? CheckNullDecimal(object data)
        {
            decimal? returnValue;

            if (data == DBNull.Value || data == null)
            {
                return null;
            }
            else
            {
                try
                {
                    returnValue = Convert.ToDecimal(data);
                }
                catch
                {
                    returnValue = null;
                }

                return returnValue;
            }

        }

        #endregion

        #endregion

    }
}
