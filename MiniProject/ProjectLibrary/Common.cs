using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Data;
using System.Security.Cryptography;
using System.Web;



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

        public static DateTime ConvertToDateTime(string dateTimeInString,
            string dateFormat)
        {
            if (dateTimeInString == null || dateTimeInString.Trim() == string.Empty)
            {
                return DateTime.MinValue;
            }
            else
            {
                if (IsValidDate(dateTimeInString.Trim()) == true)
                {
                    string[] dateFormats = new string[5];
                    dateFormats[0] = "dd/MM/yyyy";
                    dateFormats[1] = "dd/MMM/yyyy";
                    dateFormats[2] = "d/M/yyyy";
                    dateFormats[3] = "d/M/yy";
                    dateFormats[4] = "dd-MMM-yyyy";

                    return DateTime.ParseExact(dateTimeInString.Trim(),
                        dateFormats, null,0);

                }
                else
                {
                    return new DateTime();
                }
            }

        }

        public static bool IsValidDate(string dateString)
        {
            DateTime dummy = new DateTime();
            bool valid = false;
            string[] dateFormats = new string[5];
            dateFormats[0] = "dd/MM/yyyy";
            dateFormats[1] = "dd/MMM/yyyy";
            dateFormats[2] = "d/M/yyyy";
            dateFormats[3] = "d/M/yy";
            dateFormats[4] = "dd-MMM-yyyy";


            //Accept date format 31/1/2007, 31/01/2007
            valid = DateTime.TryParseExact(dateString, dateFormats,
                null, System.Globalization.DateTimeStyles.None, out dummy);

            if (valid == true)
            {
                //SqlDateTime only accept range: 1/1/1753 - 12/31/9999
                if ((dummy.CompareTo(new DateTime(1753, 1, 1)) < 0) ||
                    (dummy.CompareTo(new DateTime(9999, 12, 31)) > 0))
                {
                    return false;
                }
                else
                {
                    return valid;
                }
            }
            else
            {
                return valid;
            }


        }

        #endregion

        #endregion

    }
}
