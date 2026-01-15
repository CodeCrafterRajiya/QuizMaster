using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlTypes;
using quezemasterNew.CommonFunctional;
using quezemasterNew.Models;
using quezemasterNew.Models.Class9;
using quezemasterNew.Models.ViewModel;
using quezemasterNew.Models.ViewModel.Test;
using System.Data;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace quezemasterNew.BussinesLogic
{
    public class Class9Helper
    {
        CommonFunctions _CommonFunction = new CommonFunctions();

        internal async Task DeletetblQuestionPeparEnglishClass9Details(int PrimaryId)
        {
            try
            {
                if (PrimaryId > 0)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("DeleteQuestionPaperEnglishClass9Details", conn);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@PrimaryId", PrimaryId);
                        await sql_cmnd.ExecuteNonQueryAsync();
                        await conn.CloseAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
            }
        }

        internal async Task<List<Class9QuestionSetViewModel>> FillClass9QuestionSetDetailsBySubjectName(List<Class9QuestionSetViewModel> LsClass9Details, string SubjectName)
        {
            try
            {

                var Selectdata = $"Select * from Tbl_QuezIndexClass9Details Where SubjectName = '{SubjectName}'";

                SqlConnection connection = new SqlConnection(ConnectionString.Connection);
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(Selectdata, connection);

                await command.ExecuteNonQueryAsync();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Class9QuestionSetViewModel lsdata1 = new Class9QuestionSetViewModel();
                    lsdata1.QuestionSetName = reader["QuezName"].ToString();
                    lsdata1.id = Convert.ToInt32(reader["Id"]);

                    LsClass9Details.Add(lsdata1);
                }
                connection.Close();
            }
            catch (Exception ex)
            {


            }
            return LsClass9Details;
        }

        internal async Task<List<Class9ViewModel>> FillClass9QuizDetailsBySubjectName(List<Class9ViewModel> LsClass9QuezDetails, string Subject)
        {
            try
            {

                SqlConnection connection = new SqlConnection(ConnectionString.Connection);

                var selcectdata = $"select * from Tbl_QuezIndexClass9Details Where SubjectName = '{Subject}'";
                SqlCommand command = new SqlCommand(selcectdata, connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Class9ViewModel lsdata = new Class9ViewModel();
                    lsdata.Id = _CommonFunction.MapIntegerValue(reader["Id"]);
                    lsdata.QuezName = reader["QuezName"].ToString();
                    lsdata.ClassName = reader["ClassName"].ToString();
                    lsdata.SubjectName = reader["SubjectName"].ToString();
                    lsdata.Remark = reader["Remark"].ToString();
                    LsClass9QuezDetails.Add(lsdata);
                }
               await  connection.CloseAsync();
            }
            catch (Exception ex)
            {

            }
            return LsClass9QuezDetails;
        }

        internal async Task FillQuestionPaperClaass9Details(QuestionPepar10ViewModel Class9PaperDetails, int PrimaryId)
        {
            try
            {
                if (PrimaryId > 0)
                {

                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("GetQuestionPaperClass9DetailsById", conn);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@PrimaryId", PrimaryId);
                        SqlDataReader reader = await sql_cmnd.ExecuteReaderAsync();
                        if (reader.HasRows)
                        {
                            while (await reader.ReadAsync())
                            {
                                Class9PaperDetails.Id = _CommonFunction.MapIntegerValue(reader["Id"]);
                                Class9PaperDetails.QuestionNo = reader["QuestionNo"].ToString();
                                Class9PaperDetails.AnswerA = reader["AnswerA"].ToString();
                                Class9PaperDetails.AnswerB = reader["AnswerB"].ToString();
                                Class9PaperDetails.CurrectAnswer = reader["CurrectAnswer"].ToString();
                                Class9PaperDetails.AnswerD = reader["AnswerD"].ToString();
                                Class9PaperDetails.AnswerC = reader["AnswerC"].ToString();
                                Class9PaperDetails.ConnectedQuestion = _CommonFunction.MapIntegerValue(reader["ConnectedQuestion"], defaultValue: 0);
                                Class9PaperDetails.PrimaryId = _CommonFunction.MapIntegerValue(reader["Id"], defaultValue: 0);
                            }
                        }
                        await conn.CloseAsync();
                    }

                }

            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
            }
        }

        internal async Task<List<QuestionPepar10ViewModel>> FillQuestionpaperClass9DetailsById(List<QuestionPepar10ViewModel> LsQuestionDetais, int Id)
        {
            try
            {
                if (Id > 0)
                {

                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("GetQuestionPaperClass9DetailsByConnectedQuestion", conn);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@ConnectedQuestion", Id);
                        SqlDataReader reader = await sql_cmnd.ExecuteReaderAsync();
                        if (reader.HasRows)
                        {
                            while (await reader.ReadAsync())
                            {
                                QuestionPepar10ViewModel Class9PaperDetails = new QuestionPepar10ViewModel();
                                Class9PaperDetails.Id = Convert.ToInt32(reader["Id"]);
                                Class9PaperDetails.QuestionNo = reader["QuestionNo"].ToString();
                                Class9PaperDetails.AnswerA = reader["AnswerA"].ToString();
                                Class9PaperDetails.AnswerB = reader["AnswerB"].ToString();
                                Class9PaperDetails.CurrectAnswer = reader["CurrectAnswer"].ToString();
                                Class9PaperDetails.AnswerD = reader["AnswerD"].ToString();
                                Class9PaperDetails.AnswerC = reader["AnswerC"].ToString();
                                Class9PaperDetails.ConnectedQuestion = _CommonFunction.MapIntegerValue(reader["ConnectedQuestion"], defaultValue: 0);

                                LsQuestionDetais.Add(Class9PaperDetails);
                            }
                        }
                        await conn.CloseAsync();
                    }

                }

            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
            }

            return LsQuestionDetais;
        }

        internal async Task<List<TblClass9EnglisgTestFinalDetail>> GetClass9EnglishTest20Details(List<TblClass9EnglisgTestFinalDetail> LsClass9EnglisgTestFinalDetails)
        {
            try
            {
                string SelectQuery = "SELECT TOP (20) * FROM Tbl_Class9EnglisgTestFinalDetails ORDER BY DatetimeStamp DESC";
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                {
                    await sqlCon.OpenAsync();
                    SqlCommand sql_cmnd = new SqlCommand(SelectQuery, sqlCon);
                    sql_cmnd.CommandType = CommandType.Text;

                    using (SqlDataReader reader = await sql_cmnd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            TblClass9EnglisgTestFinalDetail Class9EnglishTestDetails = new TblClass9EnglisgTestFinalDetail
                            {
                                TestId = _CommonFunction.MapIntegerValue(reader["TestId"], defaultValue: 0),
                                QuestionNo = reader["QuestionNo"].ToString() ?? "",
                                AnswerA = reader["AnswerA"].ToString() ?? "",
                                AnswerB = reader["AnswerB"].ToString() ?? "",
                                AnswerC = reader["AnswerC"].ToString() ?? "",
                                AnswerD = reader["AnswerD"].ToString() ?? "",
                                CurrectAnswer = reader["CurrectAnswer"].ToString() ?? "",
                                ConnectedQuestion = _CommonFunction.MapIntegerValue(reader["ConnectedQuestion"], defaultValue: 0),
                                TestQuestionId = _CommonFunction.MapIntegerValue(reader["TestQuestionId"], defaultValue: 0),
                                CurrentUser = reader["CurrentUser"].ToString() ?? "",
                                Remark = reader["Remark"].ToString() ?? "",
                                Remark1 = reader["Remark1"].ToString() ?? "",
                                Remark2 = reader["Remark2"].ToString() ?? "",
                                Remark3 = reader["Remark3"].ToString() ?? "",
                                Remark4 = reader["Remark4"].ToString() ?? "",
                                DatetimeStamp = _CommonFunction.MapDateTimeValue(reader["DatetimeStamp"], defaultValue: new DateTime(1900, 01, 01)),
                                TestSerise = reader["TestSerise"].ToString() ?? ""
                            };
                            LsClass9EnglisgTestFinalDetails.Add(Class9EnglishTestDetails);
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return LsClass9EnglisgTestFinalDetails;
        }

        internal async Task<List<ResultDetailsViewModel>> GetClass9EnglishTestFinalResultDetails(List<ResultDetailsViewModel> LsClass9EnglishTestResult, string id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString: ConnectionString.Connection))
                {
                    using (SqlCommand cmd = new SqlCommand("GetClass9TestSeriesDetails", conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TestIndexId", id);
                        await conn.OpenAsync();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            int i = 1;
                            while (await reader.ReadAsync())
                            {
                                ResultDetailsViewModel lsadata = new ResultDetailsViewModel
                                {
                                    SRNumber = i++,
                                    Question = reader["QuestionNo"].ToString() ?? "",
                                    AnsswerA = reader["AnswerA"].ToString() ?? "",
                                    AnsswerB = reader["AnswerB"].ToString() ?? "",
                                    AnsswerC = reader["AnswerC"].ToString() ?? "",
                                    AnsswerD = reader["AnswerD"].ToString() ?? "",
                                    AnsswerE = reader["AnswerE"].ToString() ?? "",
                                    CurrectAnsawer = reader["CurrectAnswer"].ToString() ?? "",
                                    TotalCurrectAnswer = _CommonFunction.MapIntegerValue(reader["TotalCorrectAnswers"])
                                };

                                LsClass9EnglishTestResult.Add(lsadata);
                            }
                        }
                    }
                    await conn.CloseAsync();
                }
            }
            catch (Exception ex)
            {

            }
            return LsClass9EnglishTestResult;
        }

        internal async Task<List<TblQuestionPeparEnglishClass9Detail>> GetClass9QuestionDetailsByConnectedQuestion(int ConnectedQuestion)
        {
            List<TblQuestionPeparEnglishClass9Detail> LsClass9Details = new List<TblQuestionPeparEnglishClass9Detail>();
            try
            {
                if (ConnectedQuestion > 0)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString: ConnectionString.Connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_GetClass9EnglishQuestionsDetails", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@QuizId", ConnectedQuestion);
                            await conn.OpenAsync();
                            using (SqlDataReader Reader = await cmd.ExecuteReaderAsync())
                            {

                                if (Reader != null)
                                {
                                    while (await Reader.ReadAsync())
                                    {
                                        TblQuestionPeparEnglishClass9Detail Class7PaperModel = new TblQuestionPeparEnglishClass9Detail();
                                        Class7PaperModel.QuezIndexId = _CommonFunction.MapIntegerValue(Reader["QuezIndexId"], defaultValue: 0);
                                        Class7PaperModel.Id = _CommonFunction.MapIntegerValue(Reader["Id"], defaultValue: 0);
                                        Class7PaperModel.AnswerA = Reader["AnswerA"].ToString() ?? "";
                                        Class7PaperModel.AnswerB = Reader["AnswerB"].ToString() ?? "";
                                        Class7PaperModel.AnswerC = Reader["AnswerC"].ToString() ?? "";
                                        Class7PaperModel.AnswerD = Reader["AnswerD"].ToString() ?? "";
                                        Class7PaperModel.CurrectAnswer = Reader["CurrectAnswer"].ToString() ?? "";
                                        Class7PaperModel.QuestionNo = Reader["QuestionNo"].ToString() ?? "";
                                        Class7PaperModel.Remark = Reader["Remark"].ToString() ?? "";
                                        Class7PaperModel.QuezName = Reader["QuezName"].ToString() ?? "";
                                        Class7PaperModel.ConnectedQuestion = _CommonFunction.MapIntegerValue(Reader["ConnectedQuestion"], defaultValue: 0);
                                        LsClass9Details.Add(Class7PaperModel);

                                    }
                                }
                                return LsClass9Details;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return LsClass9Details;
        }

        internal async Task SaveClass9QuestionDetails(Class9ViewModel Class9Details)
        {
            try
            {
                if (Class9Details != null)
                {
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                        await sqlCon.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("InserTblquizeIndeClass9Details", sqlCon);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;

                        sql_cmnd.Parameters.AddWithValue("@QuezName", Class9Details.QuezName);
                        sql_cmnd.Parameters.AddWithValue("@ClassName", Class9Details.ClassName);
                        sql_cmnd.Parameters.AddWithValue("@SubjectName", Class9Details.SubjectName);
                        sql_cmnd.Parameters.AddWithValue("@Remark", Class9Details.Remark);
                   
                        sql_cmnd.Parameters.AddWithValue("@Remark2", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark3", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark4", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark5", "");
                        sql_cmnd.Parameters.AddWithValue("@DatetimeStamp", DateTime.Now);

                        await  sql_cmnd.ExecuteNonQueryAsync();
                        await sqlCon.CloseAsync();
                    }
                }
            }
            catch (Exception ex)
            {


            }
        }

        internal async Task SavetblClass9EnglisgTestFinalDetails(TblClass9EnglisgTestFinalDetail finalResute)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                {
                    sqlCon.Open();
                    SqlCommand sql_cmnd = new SqlCommand("spTbl_Class9EnglishTestFinalDetails", sqlCon);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;

                    sql_cmnd.Parameters.AddWithValue("@QuestionNo", finalResute.QuestionNo);
                    sql_cmnd.Parameters.AddWithValue("@AnswerA", finalResute.AnswerA);
                    sql_cmnd.Parameters.AddWithValue("@AnswerB", finalResute.AnswerB);
                    sql_cmnd.Parameters.AddWithValue("@AnswerC", finalResute.AnswerC);
                    sql_cmnd.Parameters.AddWithValue("@AnswerD", finalResute.AnswerD);
                    sql_cmnd.Parameters.AddWithValue("@CurrectAnswer", finalResute.CurrectAnswer);
                    sql_cmnd.Parameters.AddWithValue("@ConnectedQuestion", finalResute.ConnectedQuestion);
                    sql_cmnd.Parameters.AddWithValue("@TestQuestionId", finalResute.TestQuestionId);
                    sql_cmnd.Parameters.AddWithValue("@CurrentUser", finalResute.CurrentUser);
                    sql_cmnd.Parameters.AddWithValue("@Remark", finalResute.Remark);
                    sql_cmnd.Parameters.AddWithValue("@Remark1", finalResute.Remark1);
                    sql_cmnd.Parameters.AddWithValue("@Remark2", finalResute.Remark2);
                    sql_cmnd.Parameters.AddWithValue("@Remark3", finalResute.Remark3);
                    sql_cmnd.Parameters.AddWithValue("@Remark4", finalResute.Remark4);
                    sql_cmnd.Parameters.AddWithValue("@DatetimeStamp", finalResute.DatetimeStamp);
                    sql_cmnd.Parameters.AddWithValue("@TestSerise", finalResute.TestSerise);

                    sql_cmnd.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
            }
        }

        internal async Task SavetblQuestionPeparEnglishClass9Details(QuestionPepar10ViewModel QuestionDetails)
        {
            try
            {


                if (QuestionDetails != null)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("InsertQuestionPaperEnglishClass9Details", conn);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@QuestionNo", QuestionDetails.QuestionNo);
                        sql_cmnd.Parameters.AddWithValue("@AnswerA", QuestionDetails.AnswerA);
                        sql_cmnd.Parameters.AddWithValue("@AnswerB", QuestionDetails.AnswerB);
                        sql_cmnd.Parameters.AddWithValue("@AnswerC", QuestionDetails.AnswerC);
                        sql_cmnd.Parameters.AddWithValue("@AnswerD", QuestionDetails.AnswerD);
                        sql_cmnd.Parameters.AddWithValue("@CurrectAnswer", QuestionDetails.CurrectAnswer);
                        sql_cmnd.Parameters.AddWithValue("@ConnectedQuestion", QuestionDetails.ConnectedQuestion);
                        sql_cmnd.Parameters.AddWithValue("@Remark", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark1", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark2", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark3", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark4", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark5", "");
                        sql_cmnd.Parameters.AddWithValue("@DatetimeStamp", DateTime.Now);
                        await sql_cmnd.ExecuteNonQueryAsync();
                        await conn.CloseAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
            }
        }

        internal async Task<string> SaveTestSeriesClass9Details(Test10DetailsViewModel Class9TestSeriesDetails)
        {
            string TestIndexId = "";
            try
            {
                if (Class9TestSeriesDetails != null)
                {
                    TestIndexId = Guid.NewGuid().ToString();
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                        sqlCon.Open();
                        SqlCommand sql_cmnd = new SqlCommand("sp_SaveTestSiriseClass9Details", sqlCon);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;

                        sql_cmnd.Parameters.AddWithValue("@TestIndexId", TestIndexId);
                        sql_cmnd.Parameters.AddWithValue("@TestSerisId", Class9TestSeriesDetails.TestId);
                        sql_cmnd.Parameters.AddWithValue("@TestName", Class9TestSeriesDetails.QuizName);
                        sql_cmnd.Parameters.AddWithValue("@QuestionConnectionId", Class9TestSeriesDetails.ConnectionQuestion);
                        sql_cmnd.Parameters.AddWithValue("@DateTimeStamp", DateTime.Now);
                        sql_cmnd.Parameters.AddWithValue("@Remark", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark1", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark2", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark3", "");

                        sql_cmnd.ExecuteNonQuery();
                        sqlCon.Close();
                    }
                }



            }
            catch (Exception ex)
            {
                // Handle exception
            }

            return TestIndexId;
        }

        internal async Task UpdateClass9EnlishFinalTestDetails(string TestIndexId, List<TblClass9EnglisgTestFinalDetail> LsClass9EnglisgTestFinalDetails)
        {
            try
            {
                if (LsClass9EnglisgTestFinalDetails.Count() > 0)
                {
                    List<string> TestIdList = new List<string>();

                    TestIdList = LsClass9EnglisgTestFinalDetails.Select(x => x.TestId.ToString()).ToList();
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                        await sqlCon.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("sp_UpdateClass9EnglishTestFinalDetais", sqlCon);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;

                        sql_cmnd.Parameters.AddWithValue("@TestSerise", TestIndexId);
                        sql_cmnd.Parameters.AddWithValue("@TestIds", string.Join(",", TestIdList));

                        await sql_cmnd.ExecuteNonQueryAsync();
                        await sqlCon.CloseAsync();
                    }
                }



            }
            catch (Exception ex)
            {
                // Handle exception
            }
        }

        internal async Task UpdatetblQuestionPeparEnglishClass9Details(int PrimaryId, QuestionPepar10ViewModel QuestionDetails)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("UpdateQuestionPaperEnglishClass9DetailsById", conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", PrimaryId);
                        cmd.Parameters.AddWithValue("@QuestionNo", QuestionDetails.QuestionNo);
                        cmd.Parameters.AddWithValue("@AnswerA", QuestionDetails.AnswerA);
                        cmd.Parameters.AddWithValue("@AnswerB", QuestionDetails.AnswerB);
                        cmd.Parameters.AddWithValue("@AnswerC", QuestionDetails.AnswerC);
                        cmd.Parameters.AddWithValue("@AnswerD", QuestionDetails.AnswerD);
                        cmd.Parameters.AddWithValue("@CurrectAnswer", QuestionDetails.CurrectAnswer);
                        cmd.Parameters.AddWithValue("@Remark", QuestionDetails.Remark);
                        cmd.Parameters.AddWithValue("@Remark1", QuestionDetails.Remark1);
                        cmd.Parameters.AddWithValue("@Remark2", QuestionDetails.Remark2);
                        cmd.Parameters.AddWithValue("@Remark3", QuestionDetails.Remark3);
                        cmd.Parameters.AddWithValue("@Remark4", QuestionDetails.Remark4);
                        cmd.Parameters.AddWithValue("@Remark5", QuestionDetails.Remark5);
                        cmd.Parameters.AddWithValue("@ConnectedQuestion", QuestionDetails.ConnectedQuestion);

                        await cmd.ExecuteNonQueryAsync();
                    }
                    await conn.CloseAsync();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
