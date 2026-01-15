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
    public class Class11Helper
    {
        CommonFunctions _CommonFunction = new CommonFunctions();

        internal async Task DeletetblQuestionPeparEnglishClass11Details(int PrimaryId)
        {
            try
            {
                if (PrimaryId > 0)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("DeleteQuestionPaperEnglishClass11Details", conn);
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

        internal async Task<List<Class9ViewModel>> FillClass11QuizDetaisBySubject(List<Class9ViewModel> LsClass11QuezDetsils, string SubjectName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                {
                    string Selcectdata = $"select * from Tbl_QuezIndexClass11Details Where SubjectName = '{SubjectName}'";
                    SqlCommand command = new SqlCommand(Selcectdata, conn);
                    command.CommandType = System.Data.CommandType.Text;
                    await conn.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        Class9ViewModel lsdata = new Class9ViewModel();
                        lsdata.Id = _CommonFunction.MapIntegerValue(reader["Id"]);
                        lsdata.QuezName = reader["QuezName"].ToString();
                        lsdata.ClassName = reader["ClassName"].ToString();
                        lsdata.SubjectName = reader["SubjectName"].ToString();
                        lsdata.Remark = reader["Remark"].ToString();
                        LsClass11QuezDetsils.Add(lsdata);
                    }

                    await conn.CloseAsync();

                }
            }
            catch (Exception ex)
            {

            }
            return LsClass11QuezDetsils;
        }

        internal async Task FillQuestionPaperClaass11Details(QuestionPepar10ViewModel Class11PaperDetails, int PrimaryId)
        {
            try
            {
                if (PrimaryId > 0)
                {

                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("GetQuestionPaperClass11DetailsById", conn);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@PrimaryId", PrimaryId);
                        SqlDataReader reader = await sql_cmnd.ExecuteReaderAsync();
                        if (reader.HasRows)
                        {
                            while (await reader.ReadAsync())
                            {
                                Class11PaperDetails.Id = Convert.ToInt32(reader["Id"]);
                                Class11PaperDetails.QuestionNo = reader["QuestionNo"].ToString();
                                Class11PaperDetails.AnswerA = reader["AnswerA"].ToString();
                                Class11PaperDetails.AnswerB = reader["AnswerB"].ToString();
                                Class11PaperDetails.CurrectAnswer = reader["CurrectAnswer"].ToString();
                                Class11PaperDetails.AnswerD = reader["AnswerD"].ToString();
                                Class11PaperDetails.AnswerC = reader["AnswerC"].ToString();
                                Class11PaperDetails.ConnectedQuestion = _CommonFunction.MapIntegerValue(reader["ConnectedQuestion"], defaultValue: 0);
                                Class11PaperDetails.PrimaryId = _CommonFunction.MapIntegerValue(reader["Id"], defaultValue: 0);
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

        internal async Task<List<QuestionPepar10ViewModel>> FillQuestionpaperClass11DetailsById(List<QuestionPepar10ViewModel> LsQuestionDetais, int Id)
        {
            try
            {
                if (Id > 0)
                {

                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("GetQuestionPaperClass11DetailsByConnectedQuestion", conn);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@ConnectedQuestion", Id);
                        SqlDataReader reader = await sql_cmnd.ExecuteReaderAsync();
                        if (reader.HasRows)
                        {
                            while (await reader.ReadAsync())
                            {
                                QuestionPepar10ViewModel Class11PaperDetails = new QuestionPepar10ViewModel();
                                Class11PaperDetails.Id = Convert.ToInt32(reader["Id"]);
                                Class11PaperDetails.QuestionNo = reader["QuestionNo"].ToString();
                                Class11PaperDetails.AnswerA = reader["AnswerA"].ToString();
                                Class11PaperDetails.AnswerB = reader["AnswerB"].ToString();
                                Class11PaperDetails.CurrectAnswer = reader["CurrectAnswer"].ToString();
                                Class11PaperDetails.AnswerD = reader["AnswerD"].ToString();
                                Class11PaperDetails.AnswerC = reader["AnswerC"].ToString();
                                Class11PaperDetails.ConnectedQuestion = _CommonFunction.MapIntegerValue(reader["ConnectedQuestion"], defaultValue: 0);

                                LsQuestionDetais.Add(Class11PaperDetails);
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

        internal async Task<List<TblClass11EnglisgTestFinalDetail>> GetClass11EnglishTest20Details(List<TblClass11EnglisgTestFinalDetail> LsClass11EnglisgTestFinalDetails)
        {

            try
            {
                string SelectQuery = "SELECT TOP (20) * FROM Tbl_Class11EnglisgTestFinalDetails ORDER BY DatetimeStamp DESC";
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                {
                    await sqlCon.OpenAsync();
                    SqlCommand sql_cmnd = new SqlCommand(SelectQuery, sqlCon);
                    sql_cmnd.CommandType = CommandType.Text;

                    using (SqlDataReader reader = await sql_cmnd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            TblClass11EnglisgTestFinalDetail Class11nglishTestDetails = new TblClass11EnglisgTestFinalDetail
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
                            LsClass11EnglisgTestFinalDetails.Add(Class11nglishTestDetails);
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return LsClass11EnglisgTestFinalDetails;
        }

        internal async Task<List<ResultDetailsViewModel>> GetClass11EnglishTestFinalResultDetails(List<ResultDetailsViewModel> LsClass11EnglishTestResult, string Id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString: ConnectionString.Connection))
                {
                    using (SqlCommand cmd = new SqlCommand("GetClass11TestSeriesDetails", conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TestIndexId", Id);
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

                                LsClass11EnglishTestResult.Add(lsadata);
                            }
                        }
                    }
                    await conn.CloseAsync();
                }
            }
            catch (Exception ex)
            {

            }
            return LsClass11EnglishTestResult;
        }

        internal async Task<List<TblQuestionPeparEnglishClass11Detail>> GetClass11QuestionDetailsByConnectedQuestion(int ConnectedQuestion)
        {
            List<TblQuestionPeparEnglishClass11Detail> LsClass11Details = new List<TblQuestionPeparEnglishClass11Detail>();
            try
            {
                if (ConnectedQuestion > 0)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString: ConnectionString.Connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_GetClass11EnglishQuestionsDetails", conn))
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
                                        TblQuestionPeparEnglishClass11Detail Class11PaperModel = new TblQuestionPeparEnglishClass11Detail();
                                        Class11PaperModel.QuezIndexId = _CommonFunction.MapIntegerValue(Reader["QuezIndexId"], defaultValue: 0);
                                        Class11PaperModel.Id = _CommonFunction.MapIntegerValue(Reader["Id"], defaultValue: 0);
                                        Class11PaperModel.AnswerA = Reader["AnswerA"].ToString() ?? "";
                                        Class11PaperModel.AnswerB = Reader["AnswerB"].ToString() ?? "";
                                        Class11PaperModel.AnswerC = Reader["AnswerC"].ToString() ?? "";
                                        Class11PaperModel.AnswerD = Reader["AnswerD"].ToString() ?? "";
                                        Class11PaperModel.CurrectAnswer = Reader["CurrectAnswer"].ToString() ?? "";
                                        Class11PaperModel.QuestionNo = Reader["QuestionNo"].ToString() ?? "";
                                        Class11PaperModel.Remark = Reader["Remark"].ToString() ?? "";
                                        Class11PaperModel.QuezName = Reader["QuezName"].ToString() ?? "";
                                        Class11PaperModel.ConnectedQuestion = _CommonFunction.MapIntegerValue(Reader["ConnectedQuestion"], defaultValue: 0);
                                        LsClass11Details.Add(Class11PaperModel);

                                    }
                                }
                                return LsClass11Details;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return LsClass11Details;
        }

        internal async Task<List<Class9QuestionSetViewModel>> GetClass11QuestionSetDetailsBySubjectName(List<Class9QuestionSetViewModel> LsClass11Details, string SubjectName)
        {
            try
            {
                string Selectdata = $"Select * from Tbl_QuezIndexClass11Details Where SubjectName = '{SubjectName}'";

                SqlConnection connection = new SqlConnection(ConnectionString.Connection);
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(Selectdata, connection);

                await command.ExecuteNonQueryAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Class9QuestionSetViewModel lsdata1 = new Class9QuestionSetViewModel();
                    lsdata1.QuestionSetName = reader["QuezName"].ToString() ?? "";
                    lsdata1.id =  _CommonFunction.MapIntegerValue(reader["Id"]);

                    LsClass11Details.Add(lsdata1);
                }
                await connection.CloseAsync();
            }
            catch(Exception ex)
            {

            }

            return LsClass11Details;
        }

        internal async Task SaveClass11QuizDetails(Class9ViewModel QuizDetais)
        {
            try
            {
                if (QuizDetais != null)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {

                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("InserTblquizeIndeClass11Details", conn);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;

                        sql_cmnd.Parameters.AddWithValue("@QuezName", QuizDetais.QuezName);
                        sql_cmnd.Parameters.AddWithValue("@ClassName", QuizDetais.ClassName);
                        sql_cmnd.Parameters.AddWithValue("@SubjectName", QuizDetais.SubjectName);
                        sql_cmnd.Parameters.AddWithValue("@Remark", QuizDetais.Remark);
    
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
                // Handle exception
            }
        }

        internal async Task SavetblClass11EnglisgTestFinalDetails(TblClass11EnglisgTestFinalDetail finalResute)
        {
            try
            {

              if(finalResute !=null)
                {
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {


                        await sqlCon.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("spTbl_Class11EnglishTestFinalDetails", sqlCon);
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
                        await sqlCon.CloseAsync();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        internal async Task SavetblQuestionPeparEnglishClass11Details(QuestionPepar10ViewModel QuestionDetails)
        {
            try
            {


                if (QuestionDetails != null)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("InsertQuestionPaperEnglishClass11Details", conn);
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

        internal async Task<string> SaveTestSeriesClass11Details(Test10DetailsViewModel Class11TestSeriesDetails)
        {
            string TestIndexId = "";
            try
            {
                if (Class11TestSeriesDetails != null)
                {
                    TestIndexId = Guid.NewGuid().ToString();
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                        sqlCon.Open();
                        SqlCommand sql_cmnd = new SqlCommand("sp_SaveTestSiriseClass11Details", sqlCon);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;

                        sql_cmnd.Parameters.AddWithValue("@TestIndexId", TestIndexId);
                        sql_cmnd.Parameters.AddWithValue("@TestSerisId", Class11TestSeriesDetails.TestId);
                        sql_cmnd.Parameters.AddWithValue("@TestName", Class11TestSeriesDetails.QuizName);
                        sql_cmnd.Parameters.AddWithValue("@QuestionConnectionId", Class11TestSeriesDetails.ConnectionQuestion);
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

        internal async Task UpdateClass11EnlishFinalTestDetails(string TestIndexId, List<TblClass11EnglisgTestFinalDetail> LsClass11EnglisgTestFinalDetails)
        {

            try
            {
                if (LsClass11EnglisgTestFinalDetails.Count() > 0)
                {
                    List<string> TestIdList = new List<string>();

                    TestIdList = LsClass11EnglisgTestFinalDetails.Select(x => x.TestId.ToString()).ToList();
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                        sqlCon.Open();
                        SqlCommand sql_cmnd = new SqlCommand("sp_UpdateClass11EnglishTestFinalDetais", sqlCon);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;

                        sql_cmnd.Parameters.AddWithValue("@TestSerise", TestIndexId);
                        sql_cmnd.Parameters.AddWithValue("@TestIds", string.Join(",", TestIdList));

                        sql_cmnd.ExecuteNonQuery();
                        sqlCon.Close();
                    }
                }



            }
            catch (Exception ex)
            {
                // Handle exception
            }
        }

        internal async Task UpdatetblQuestionPeparEnglishClass11Details(int PrimaryId, QuestionPepar10ViewModel QuestionDetails)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("UpdateQuestionPaperEnglishClass11DetailsById", conn))
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
