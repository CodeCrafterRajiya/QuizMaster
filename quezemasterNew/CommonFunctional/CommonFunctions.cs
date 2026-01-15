using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using quezemasterNew.Models;
using quezemasterNew.Models.ViewModel.Test;
using System.Globalization;
using System.Security.Claims;
using System.Security.Cryptography.Xml;

namespace quezemasterNew.CommonFunctional
{
    public class CommonFunctions
    {

        public string GetUserName(ClaimsPrincipal user)
        {
            QuizeMasterNewContext _context = new QuizeMasterNewContext();

            var abc = _context.AspNetUsers.Where(x => x.UserName.Equals(user.Identity.Name));

            if (abc.Any())
            {
                if (abc != null)
                {
                    return abc.FirstOrDefault().Name1;
                }


            }

            return "";

        }

        public static string GetRole(ClaimsPrincipal user)
        {
            QuizeMasterNewContext _context = new QuizeMasterNewContext();
            var sbb = user.Identity.Name;
            if (string.IsNullOrEmpty(sbb) == false)
            {
                var abc = _context.AspNetUsers.Where(x => x.UserName == sbb).FirstOrDefault();
                if (abc != null)
                {
                    var role = _context.AspNetRoles.Where(x => x.Name.Equals(abc.FormalRoleName)).ToList();
                    if (role.Count() > 0)
                    {
                        if (role != null)
                        {
                            if (String.IsNullOrEmpty(role.FirstOrDefault().Name) == false)
                            {
                                return role.FirstOrDefault().Name;

                            }
                            else
                            {
                                return role.FirstOrDefault().Name;

                            }
                        }
                        else
                        {
                            return "NA";
                        }
                    }
                }
            }



            return "NA";

        }

        internal List<AllTestResultViewModel> SeeAllResult(List<AllTestResultViewModel> LsList, string? currentUser, string Role)
        {
            try
            {

                var selcectdata = "";
                var selcectdata9 = "";
                var selcectdata10 = "";
                var selcectdata12 = "";
                var selcectdata11 = "";
                var selcectdataPGT = "";
                var selcectdataLt = "";
                var selcectdataGK = "";
                var selcectdataBPSC = "";
                var selcectdata6 = "";
                var selcectdata7 = "";
                var selcectdata8 = "";


                if (Role.Equals("Admin"))
                {
                    selcectdata = $"SELECT T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser, SUM(CASE WHEN T2.CurrectAnswer IS NOT NULL AND T2.CurrectAnswer <> '' THEN 1 ELSE 0 END) AS CorrectAnswerCount FROM Tbl_TestSiriseDetails T1 INNER JOIN Tbl_TGTENglisgTestFinalDetails T2 ON T1.TestIndexId = T2.TestSerise GROUP BY T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser";

                    selcectdata9 = $"SELECT T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser, SUM(CASE WHEN T2.CurrectAnswer IS NOT NULL AND T2.CurrectAnswer <> '' THEN 1 ELSE 0 END) AS CorrectAnswerCount FROM Tbl_TestSiriseClass9Details T1 INNER JOIN Tbl_Class9EnglisgTestFinalDetails T2 ON T1.TestIndexId = T2.TestSerise GROUP BY T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser";

                    selcectdata10 = $"SELECT T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser, SUM(CASE WHEN T2.CurrectAnswer IS NOT NULL AND T2.CurrectAnswer <> '' THEN 1 ELSE 0 END) AS CorrectAnswerCount FROM Tbl_TestSiriseClass10Details T1 INNER JOIN Tbl_Class10EnglisgTestFinalDetails T2 ON T1.TestIndexId = T2.TestSerise GROUP BY T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser";


                    selcectdata12 = $"SELECT T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser, SUM(CASE WHEN T2.CurrectAnswer IS NOT NULL AND T2.CurrectAnswer <> '' THEN 1 ELSE 0 END) AS CorrectAnswerCount FROM Tbl_TestSiriseClass12Details T1 INNER JOIN Tbl_Class12EnglisgTestFinalDetails T2 ON T1.TestIndexId = T2.TestSerise GROUP BY T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser";

                    selcectdata11 = $"SELECT T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser, SUM(CASE WHEN T2.CurrectAnswer IS NOT NULL AND T2.CurrectAnswer <> '' THEN 1 ELSE 0 END) AS CorrectAnswerCount FROM Tbl_TestSiriseClass11Details T1 INNER JOIN Tbl_Class11EnglisgTestFinalDetails T2 ON T1.TestIndexId = T2.TestSerise GROUP BY T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser";

                    selcectdata8 = $"SELECT T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser, SUM(CASE WHEN T2.CurrectAnswer IS NOT NULL AND T2.CurrectAnswer <> '' THEN 1 ELSE 0 END) AS CorrectAnswerCount FROM Tbl_TestSiriseClass8Details T1 INNER JOIN Tbl_Class8EnglisgTestFinalDetails T2 ON T1.TestIndexId = T2.TestSerise GROUP BY T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser";

                    selcectdata7 = $"SELECT T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser, SUM(CASE WHEN T2.CurrectAnswer IS NOT NULL AND T2.CurrectAnswer <> '' THEN 1 ELSE 0 END) AS CorrectAnswerCount FROM Tbl_TestSiriseClass7Details T1 INNER JOIN Tbl_Class7EnglisgTestFinalDetails T2 ON T1.TestIndexId = T2.TestSerise GROUP BY T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser";


                    selcectdata6 = $"SELECT T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser, SUM(CASE WHEN T2.CurrectAnswer IS NOT NULL AND T2.CurrectAnswer <> '' THEN 1 ELSE 0 END) AS CorrectAnswerCount FROM Tbl_TestSiriseClass6Details T1 INNER JOIN Tbl_Class6EnglisgTestFinalDetails T2 ON T1.TestIndexId = T2.TestSerise GROUP BY T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser";


                    selcectdataBPSC = $"SELECT T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser, SUM(CASE WHEN T2.CurrectAnswer IS NOT NULL AND T2.CurrectAnswer <> '' THEN 1 ELSE 0 END) AS CorrectAnswerCount FROM Tbl_TestSiriseClassBPSCDetails T1 INNER JOIN Tbl_ClassBPSCEnglisgTestFinalDetails T2 ON T1.TestIndexId = T2.TestSerise GROUP BY T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser";

                    selcectdataGK = $"SELECT T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser, SUM(CASE WHEN T2.CurrectAnswer IS NOT NULL AND T2.CurrectAnswer <> '' THEN 1 ELSE 0 END) AS CorrectAnswerCount FROM Tbl_TestSiriseClassGKDetails T1 INNER JOIN Tbl_ClassGKEnglisgTestFinalDetails T2 ON T1.TestIndexId = T2.TestSerise GROUP BY T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser";

                    //selcectdataLt = $"SELECT  CurrentUser, CurrectAnswer, TestSerise, TestIndexId,TestName, Tbl_QuezIndexLTDetails.DateTimeStamp  FROM  " +
                    //$"Tbl_LTEnglisgTestFinalDetails LEFT JOIN Tbl_QuezIndexLTDetails  ON Tbl_LTEnglisgTestFinalDetails.TestSerise = Tbl_QuezIndexLTDetails.TestIndexId";

                    //selcectdataPGT = $"SELECT  CurrentUser, CurrectAnswer, TestSerise, TestIndexId,TestName, Tbl_QuezIndexPGTDetails.DateTimeStamp  FROM  " +
                    // $"Tbl_PGTENglisgTestFinalDetails LEFT JOIN Tbl_QuezIndexPGTDetails  ON Tbl_PGTENglisgTestFinalDetails.TestSerise = Tbl_QuezIndexPGTDetails.TestIndexId";
                }
                else
                {

                    selcectdata = $"SELECT T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser, SUM(CASE WHEN T2.CurrectAnswer IS NOT NULL AND T2.CurrectAnswer <> '' THEN 1 ELSE 0 END) AS CorrectAnswerCount FROM Tbl_TestSiriseDetails T1 INNER JOIN Tbl_TGTENglisgTestFinalDetails T2 ON T1.TestIndexId = T2.TestSerise Where T2.CurrentUser = '{currentUser}' GROUP BY T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser";

                    selcectdata9 = $"SELECT T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser, SUM(CASE WHEN T2.CurrectAnswer IS NOT NULL AND T2.CurrectAnswer <> '' THEN 1 ELSE 0 END) AS CorrectAnswerCount FROM Tbl_TestSiriseClass9Details T1 INNER JOIN Tbl_Class9EnglisgTestFinalDetails T2 ON T1.TestIndexId = T2.TestSerise Where T2.CurrentUser = '{currentUser}' GROUP BY T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser";

                    selcectdata10 = $"SELECT T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser, SUM(CASE WHEN T2.CurrectAnswer IS NOT NULL AND T2.CurrectAnswer <> '' THEN 1 ELSE 0 END) AS CorrectAnswerCount FROM Tbl_TestSiriseClass10Details T1 INNER JOIN Tbl_Class10EnglisgTestFinalDetails T2 ON T1.TestIndexId = T2.TestSerise Where T2.CurrentUser = '{currentUser}' GROUP BY T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser";


                    selcectdata12 = $"SELECT T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser, SUM(CASE WHEN T2.CurrectAnswer IS NOT NULL AND T2.CurrectAnswer <> '' THEN 1 ELSE 0 END) AS CorrectAnswerCount FROM Tbl_TestSiriseClass12Details T1 INNER JOIN Tbl_Class12EnglisgTestFinalDetails T2 ON T1.TestIndexId = T2.TestSerise Where T2.CurrentUser = '{currentUser}' GROUP BY T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser";

                    selcectdata11 = $"SELECT T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser, SUM(CASE WHEN T2.CurrectAnswer IS NOT NULL AND T2.CurrectAnswer <> '' THEN 1 ELSE 0 END) AS CorrectAnswerCount FROM Tbl_TestSiriseClass11Details T1 INNER JOIN Tbl_Class11EnglisgTestFinalDetails T2 ON T1.TestIndexId = T2.TestSerise Where T2.CurrentUser = '{currentUser}' GROUP BY T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser";

                    selcectdata8 = $"SELECT T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser, SUM(CASE WHEN T2.CurrectAnswer IS NOT NULL AND T2.CurrectAnswer <> '' THEN 1 ELSE 0 END) AS CorrectAnswerCount FROM Tbl_TestSiriseClass8Details T1 INNER JOIN Tbl_Class8EnglisgTestFinalDetails T2 ON T1.TestIndexId = T2.TestSerise Where T2.CurrentUser = '{currentUser}' GROUP BY T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser";

                    selcectdata7 = $"SELECT T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser, SUM(CASE WHEN T2.CurrectAnswer IS NOT NULL AND T2.CurrectAnswer <> '' THEN 1 ELSE 0 END) AS CorrectAnswerCount FROM Tbl_TestSiriseClass7Details T1 INNER JOIN Tbl_Class7EnglisgTestFinalDetails T2 ON T1.TestIndexId = T2.TestSerise Where T2.CurrentUser = '{currentUser}' GROUP BY T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser";


                    selcectdata6 = $"SELECT T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser, SUM(CASE WHEN T2.CurrectAnswer IS NOT NULL AND T2.CurrectAnswer <> '' THEN 1 ELSE 0 END) AS CorrectAnswerCount FROM Tbl_TestSiriseClass6Details T1 INNER JOIN Tbl_Class6EnglisgTestFinalDetails T2 ON T1.TestIndexId = T2.TestSerise Where T2.CurrentUser = '{currentUser}' GROUP BY T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser";


                    selcectdataBPSC = $"SELECT T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser, SUM(CASE WHEN T2.CurrectAnswer IS NOT NULL AND T2.CurrectAnswer <> '' THEN 1 ELSE 0 END) AS CorrectAnswerCount FROM Tbl_TestSiriseClassBPSCDetails T1 INNER JOIN Tbl_ClassBPSCEnglisgTestFinalDetails T2 ON T1.TestIndexId = T2.TestSerise Where T2.CurrentUser = '{currentUser}' GROUP BY T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser";

                    selcectdataGK = $"SELECT T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser, SUM(CASE WHEN T2.CurrectAnswer IS NOT NULL AND T2.CurrectAnswer <> '' THEN 1 ELSE 0 END) AS CorrectAnswerCount FROM Tbl_TestSiriseClassGKDetails T1 INNER JOIN Tbl_ClassGKEnglisgTestFinalDetails T2 ON T1.TestIndexId = T2.TestSerise Where T2.CurrentUser = '{currentUser}' GROUP BY T1.TestIndexId, T1.TestName, T1.DateTimeStamp, T2.CurrentUser";


                }

                try
                {
                    SqlConnection connection = new SqlConnection(ConnectionString.Connection);


                    SqlCommand command = new SqlCommand(selcectdata, connection);
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    LsList = GetData(reader, LsList, "TGT");
                    connection.Close();



                    SqlCommand command9 = new SqlCommand(selcectdata9, connection);
                    command9.CommandType = System.Data.CommandType.Text;
                    connection.Open();
                    SqlDataReader reader9 = command9.ExecuteReader();
                    LsList = GetData(reader9, LsList, "Class 9");
                    connection.Close();



                    SqlCommand command10 = new SqlCommand(selcectdata10, connection);
                    command10.CommandType = System.Data.CommandType.Text;
                    connection.Open();
                    SqlDataReader reader10 = command10.ExecuteReader();
                    LsList = GetData(reader10, LsList, "Class 10");
                    connection.Close();



                    SqlCommand command11 = new SqlCommand(selcectdata11, connection);
                    command11.CommandType = System.Data.CommandType.Text;
                    connection.Open();
                    SqlDataReader reader11 = command11.ExecuteReader();
                    LsList = GetData(reader11, LsList, "Class 11");
                    connection.Close();



                    SqlCommand command12 = new SqlCommand(selcectdata12, connection);
                    command12.CommandType = System.Data.CommandType.Text;
                    connection.Open();
                    SqlDataReader reader12 = command12.ExecuteReader();
                    LsList = GetData(reader12, LsList, "Class 12");
                    connection.Close();

                    //SqlCommand readerPGT = new SqlCommand(selcectdataPGT, connection);
                    //readerPGT.CommandType = System.Data.CommandType.Text;
                    //connection.Open();
                    //SqlDataReader reade1rPGT = readerPGT.ExecuteReader();
                    //LsList = GetData(reade1rPGT, LsList);
                    //connection.Close();

                    SqlCommand Commond8 = new SqlCommand(selcectdata8, connection);
                    Commond8.CommandType = System.Data.CommandType.Text;
                    connection.Open();
                    SqlDataReader reader8 = Commond8.ExecuteReader();
                    LsList = GetData(reader8, LsList, "Class 8");
                    connection.Close();

                    SqlCommand command7 = new SqlCommand(selcectdata7, connection);
                    command7.CommandType = System.Data.CommandType.Text;
                    connection.Open();
                    SqlDataReader reader7 = command7.ExecuteReader();
                    LsList = GetData(reader7, LsList, "Class 7");
                    connection.Close();

                    SqlCommand command6 = new SqlCommand(selcectdata6, connection);
                    command6.CommandType = System.Data.CommandType.Text;
                    connection.Open();
                    SqlDataReader reader6 = command6.ExecuteReader();
                    LsList = GetData(reader6, LsList, "Class 6");
                    connection.Close();

                    SqlCommand commandBPSC = new SqlCommand(selcectdataBPSC, connection);
                    commandBPSC.CommandType = System.Data.CommandType.Text;
                    connection.Open();
                    SqlDataReader readerBPSC = commandBPSC.ExecuteReader();
                    LsList = GetData(readerBPSC, LsList, "BPSC");
                    connection.Close();

                    SqlCommand commandGK = new SqlCommand(selcectdataGK, connection);
                    commandGK.CommandType = System.Data.CommandType.Text;
                    connection.Open();
                    SqlDataReader readerGK = commandGK.ExecuteReader();
                    LsList = GetData(readerGK, LsList, "GK");
                    connection.Close();

                    //SqlCommand commandLT = new SqlCommand(selcectdataLt, connection);
                    //commandLT.CommandType = System.Data.CommandType.Text;
                    //connection.Open();
                    //SqlDataReader readerLT = commandLT.ExecuteReader();
                    //LsList = GetData(readerLT, LsList);
                    //connection.Close();




                }
                catch (Exception ex)
                {

                }
            }
            catch (Exception)
            {


            }

            return LsList;
        }


        private List<AllTestResultViewModel> GetData(dynamic reader, List<AllTestResultViewModel> lsList, string ClassName)
        {
            try
            {
                while (reader.Read())
                {
                    AllTestResultViewModel lsdata = new AllTestResultViewModel();
                    lsdata.TestId = reader["TestIndexId"].ToString();
                    lsdata.TestName = reader["TestName"].ToString();
                    lsdata.UserName = reader["CurrentUser"].ToString();
                    lsdata.ClassName = ClassName;
                    var CurrectAnsa = reader["CorrectAnswerCount"].ToString();
                    if (string.IsNullOrEmpty(CurrectAnsa) == false)
                    {
                        lsdata.CurrectAnswer = Convert.ToInt32(CurrectAnsa);
                    }
                    var date = reader["DateTimeStamp"].ToString();
                    if (date != null)
                    {
                        lsdata.Date = Convert.ToDateTime(date);
                    }


                    lsList.Add(lsdata);
                }
            }
            catch (Exception ex)
            {

            }


            return lsList;
        }


        //Map DateTime value if table datetime value is empty then map default values
        internal DateTime MapDateTimeValue(object value, DateTime defaultValue)
        {
            // Check if the value is not DBNull and is not null
            if (value != DBNull.Value && value != null)
            {
                // Try parsing the value to a DateTime and return it if valid
                DateTime dateTimeValue;
                if (DateTime.TryParse(value.ToString(), out dateTimeValue))
                {
                    return dateTimeValue;
                }
            }

            // If the value is invalid, return the default DateTime value
            return defaultValue;
        }



        // Map DateOnly value if table date value is empty, then map default value
        internal DateTime MapDateValue(object value, DateTime defaultValue)
        {
            // Check if the value is not DBNull and is not null
            if (value != DBNull.Value && value != null)
            {
                // Try parsing the value to a DateTime and return only the date part if valid
                DateTime dateTimeValue;
                if (DateTime.TryParse(value.ToString(), out dateTimeValue))
                {
                    // Return only the date part (ignoring the time part)
                    return dateTimeValue.Date;
                }
            }

            // If the value is invalid, return the default DateTime value
            return defaultValue.Date;
        }



        // Map DateOnly? value if the table date value is empty, then map default value
        internal DateOnly MapNullableDateOnlyValue(object value, DateOnly defaultValue)
        {
            // Check if the value is not DBNull and is not null
            if (value != DBNull.Value && value != null)
            {
                // Try parsing the value to a DateTime and return only the date part as DateOnly if valid
                DateTime dateTimeValue;
                if (DateTime.TryParse(value.ToString(), out dateTimeValue))
                {
                    // Return a nullable DateOnly object, converting the DateTime to DateOnly
                    return DateOnly.FromDateTime(dateTimeValue);
                }
            }

            // If the value is invalid or null, return the default nullable DateOnly value
            return defaultValue;
        }





        // Map TimeOnly value if table time value is empty, then map default value
        internal TimeOnly MapTimeOnlyValue(object value, TimeOnly defaultValue)
        {
            // Check if the value is not DBNull and is not null
            if (value != DBNull.Value && value != null)
            {
                // Try parsing the value to a DateTime and return only the time part as TimeOnly if valid
                DateTime dateTimeValue;
                if (DateTime.TryParse(value.ToString(), out dateTimeValue))
                {
                    // Return only the time part as a TimeOnly object
                    //  return TimeOnly.FromDateTime(dateTimeValue);
                    // Explicitly create the TimeOnly to include hours, minutes, and seconds
                    return new TimeOnly(dateTimeValue.Hour, dateTimeValue.Minute, dateTimeValue.Second);
                }
            }

            // If the value is invalid, return the default TimeOnly value
            return defaultValue;
        }



        //Map DateTime value if table datetime value is empty then map default values
        internal string MapDateTimeValueToString(object value, string defaultValue)
        {
            // Check if the value is not DBNull and is not null
            if (value != DBNull.Value && value != null)
            {
                // Try parsing the value to a DateTime and return it if valid
                DateTime dateTimeValue;
                if (DateTime.TryParse(value.ToString(), out dateTimeValue))
                {
                    return Convert.ToDateTime(dateTimeValue).ToString("dd-MM-yyyy");
                }
            }

            // If the value is invalid, return the default DateTime value
            return defaultValue;
        }

        //Map Integer value if table int value is empty then map default values
        internal int MapIntegerValue(object value, int defaultValue = 0)
        {
            // Check if the value is not DBNull and is not null
            if (value != DBNull.Value && value != null)
            {
                int intValue;
                // Try parsing the value to an integer and return the value if it's valid
                if (int.TryParse(value.ToString(), out intValue))
                {
                    return intValue;
                }
            }

            // If the value is invalid, return the default value
            return defaultValue;
        }


        internal double MapDoubleValue(object value, double defaultValue = 0.0)
        {
            // Check if the value is not DBNull and is not null
            if (value != DBNull.Value && value != null)
            {
                double doubleValue;
                // Try parsing the value to a double and return the value if it's valid
                if (double.TryParse(value.ToString(), out doubleValue))
                {
                    return doubleValue;
                }
            }

            // If the value is invalid, return the default value
            return defaultValue;
        }




        internal long MapLongValue(object value, long defaultValue = 0)
        {
            // Check if the value is not DBNull and is not null
            if (value != DBNull.Value && value != null)
            {
                long longValue;
                // Try parsing the value to a double and return the value if it's valid
                if (long.TryParse(value.ToString(), out longValue))
                {
                    return longValue;
                }
            }

            // If the value is invalid, return the default value
            return defaultValue;
        }




        internal decimal MapDecimalValue(object value, decimal defaultValue = 0)
        {
            // Check if the value is not DBNull and not null
            if (value != DBNull.Value && value != null)
            {
                decimal decimalValue;
                // Try parsing the value to decimal
                if (decimal.TryParse(value.ToString(), out decimalValue))
                {
                    return decimalValue;
                }
            }

            // If invalid or null, return the default value (e.g., 0m)
            return defaultValue;
        }


        // Method to map a string to a boolean value, with a default if invalid
        internal bool MapBooleanValue(object value, bool defaultValue)
        {
            // Check if the value is not DBNull and is not null
            if (value != DBNull.Value && value != null)
            {
                string stringValue = value.ToString().Trim().ToLower();

                // Attempt to map common string representations of true/false to bool values
                if (stringValue == "true" || stringValue == "1")
                {
                    return true;
                }
                else if (stringValue == "false" || stringValue == "0")
                {
                    return false;
                }
            }

            // If the value is invalid or unrecognized, return the default boolean value
            return defaultValue;
        }



        //check date  and time format
        public DateTime CheckDateAndTime(string DateRecords)
        {

            CultureInfo enUS = new CultureInfo("en-US");
            string dateString;
            DateTime dateValue;

            if (string.IsNullOrEmpty(DateRecords))
            {
                return new DateTime(2001, 1, 1);
            }
            else
            {
                try
                {
                    if (DateTime.TryParseExact(DateRecords, "ddMMyyyy_HHmmss", CultureInfo.InvariantCulture,
                                 DateTimeStyles.None, out dateValue))
                    {
                        return dateValue;
                    }
                    else
                    {

                        return new DateTime(2001, 1, 1);

                    }


                }
                catch (Exception ex1)
                {
                    return new DateTime(2001, 1, 1);
                }
            }

        }

    }
}
