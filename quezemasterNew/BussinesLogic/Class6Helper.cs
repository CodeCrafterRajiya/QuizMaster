using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlTypes;
using quezemasterNew.CommonFunctional;
using quezemasterNew.Models;
using quezemasterNew.Models.Class9;
using quezemasterNew.Models.ViewModel;
using quezemasterNew.Models.ViewModel.Test;
using System.Data;
using System.Xml.Linq;

namespace quezemasterNew.BussinesLogic
{
    public class Class6Helper
    {
        CommonFunctions _CommonFunction = new CommonFunctions();

        internal async Task DeletetblQuestionPeparEnglishClass6Details(int PrimaryId)
        {
            try
            {
                if (PrimaryId > 0)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("DeleteQuestionPaperEnglishClass6Details", conn);
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

        internal async Task<List<Class9QuestionSetViewModel>> FillClass6QuestionSetDetailsBySubjectName(List<Class9QuestionSetViewModel> LsClass6Details, string SubjectName)
        {
            try
            {

                var Selectdata = $"Select * from Tbl_QuezIndexClass6Details";

                SqlConnection connection = new SqlConnection(ConnectionString.Connection);
                connection.Open();
                SqlCommand command = new SqlCommand(Selectdata, connection);

                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Class9QuestionSetViewModel lsdata1 = new Class9QuestionSetViewModel();
                    lsdata1.QuestionSetName = reader["QuezName"].ToString()??"";
                    lsdata1.id = _CommonFunction.MapIntegerValue(reader["Id"]);

                    LsClass6Details.Add(lsdata1);
                }
                connection.Close();
            }
            catch (Exception ex)
            {


            }
            return LsClass6Details;

        }

        internal async Task<List<Class9ViewModel>> FillClass6QuizDetailsBySubjectName(List<Class9ViewModel> LsClass6QuezDetails, string Subject)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString.Connection);

                var selcectdata = $"select * from Tbl_QuezIndexClass6Details";
                SqlCommand command = new SqlCommand(selcectdata, connection);
                command.CommandType = System.Data.CommandType.Text;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Class9ViewModel lsdata = new Class9ViewModel();
                    lsdata.Id = Convert.ToInt32(reader["Id"]);
                    lsdata.QuezName = reader["QuezName"].ToString();
                    lsdata.ClassName = reader["ClassName"].ToString();
                    lsdata.SubjectName = reader["SubjectName"].ToString();
                    lsdata.Remark = reader["Remark"].ToString();
                    LsClass6QuezDetails.Add(lsdata);
                }
                connection.Close();
            }
            catch (Exception ex)
            {

            }
            return LsClass6QuezDetails;
        }

        internal async Task FillQuestionPaperClaass6Details(QuestionPepar10ViewModel Class6PaperDetails, int PrimaryId)
        {
            try
            {
                if (PrimaryId > 0)
                {

                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("GetQuestionPaperClass6DetailsById", conn);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@PrimaryId", PrimaryId);
                        SqlDataReader reader = await sql_cmnd.ExecuteReaderAsync();
                        if (reader.HasRows)
                        {
                            while (await reader.ReadAsync())
                            {
                                Class6PaperDetails.Id = Convert.ToInt32(reader["Id"]);
                                Class6PaperDetails.QuestionNo = reader["QuestionNo"].ToString();
                                Class6PaperDetails.AnswerA = reader["AnswerA"].ToString();
                                Class6PaperDetails.AnswerB = reader["AnswerB"].ToString();
                                Class6PaperDetails.CurrectAnswer = reader["CurrectAnswer"].ToString();
                                Class6PaperDetails.AnswerD = reader["AnswerD"].ToString();
                                Class6PaperDetails.AnswerC = reader["AnswerC"].ToString();
                                Class6PaperDetails.ConnectedQuestion = _CommonFunction.MapIntegerValue(reader["ConnectedQuestion"], defaultValue: 0);
                                Class6PaperDetails.PrimaryId = _CommonFunction.MapIntegerValue(reader["Id"], defaultValue: 0);
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

        internal async Task<List<QuestionPepar10ViewModel>> FillQuestionpaperClass6DetailsById(List<QuestionPepar10ViewModel> LsQuestionDetais, int Id)
        {
            try
            {
                if (Id > 0)
                {

                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("GetQuestionPaperClass6DetailsByConnectedQuestion", conn);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@ConnectedQuestion", Id);
                        SqlDataReader reader = await sql_cmnd.ExecuteReaderAsync();
                        if (reader.HasRows)
                        {
                            while (await reader.ReadAsync())
                            {
                                QuestionPepar10ViewModel Class6PaperDetails = new QuestionPepar10ViewModel();
                                Class6PaperDetails.Id = Convert.ToInt32(reader["Id"]);
                                Class6PaperDetails.QuestionNo = reader["QuestionNo"].ToString();
                                Class6PaperDetails.AnswerA = reader["AnswerA"].ToString();
                                Class6PaperDetails.AnswerB = reader["AnswerB"].ToString();
                                Class6PaperDetails.CurrectAnswer = reader["CurrectAnswer"].ToString();
                                Class6PaperDetails.AnswerD = reader["AnswerD"].ToString();
                                Class6PaperDetails.AnswerC = reader["AnswerC"].ToString();
                                Class6PaperDetails.ConnectedQuestion = _CommonFunction.MapIntegerValue(reader["ConnectedQuestion"], defaultValue: 0);

                                LsQuestionDetais.Add(Class6PaperDetails);
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

        internal async Task<List<TblClass6EnglisgTestFinalDetail>> GetClass6EnglishTest20Details(List<TblClass6EnglisgTestFinalDetail> LsClass6EnglisgTestFinalDetails)
        {
            try
            {
                string SelectQuery = "SELECT TOP (20) * FROM Tbl_Class6EnglisgTestFinalDetails ORDER BY DatetimeStamp DESC";
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                {
                    await sqlCon.OpenAsync();
                    SqlCommand sql_cmnd = new SqlCommand(SelectQuery, sqlCon);
                    sql_cmnd.CommandType = CommandType.Text;

                    using (SqlDataReader reader = await sql_cmnd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            TblClass6EnglisgTestFinalDetail Class6EnglishTestDetails = new TblClass6EnglisgTestFinalDetail
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
                            LsClass6EnglisgTestFinalDetails.Add(Class6EnglishTestDetails);
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return LsClass6EnglisgTestFinalDetails;
        }

        internal async Task<List<ResultDetailsViewModel>> GetClass6EnglishTestFinalResultDetails(List<ResultDetailsViewModel> LsClass6EnglishTestResult, string id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString: ConnectionString.Connection))
                {
                    using (SqlCommand cmd = new SqlCommand("GetClass6TestSeriesDetails", conn))
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

                                LsClass6EnglishTestResult.Add(lsadata);
                            }
                        }
                    }
                    await conn.CloseAsync();
                }
            }
            catch (Exception ex)
            {

            }
            return LsClass6EnglishTestResult;
        }

        internal async Task<List<TblQuestionPeparEnglishClass6Detail>> GetClass6QuestionDetailsByConnectedQuestion(int ConnectedQuestion)
        {
            List<TblQuestionPeparEnglishClass6Detail> LsClass6Details = new List<TblQuestionPeparEnglishClass6Detail>();
            try
            {
                if (ConnectedQuestion > 0)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString: ConnectionString.Connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_GetClass6EnglishQuestionsDetails", conn))
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
                                        TblQuestionPeparEnglishClass6Detail Class6PaperModel = new TblQuestionPeparEnglishClass6Detail();
                                        Class6PaperModel.QuezIndexId = _CommonFunction.MapIntegerValue(Reader["QuezIndexId"], defaultValue: 0);
                                        Class6PaperModel.Id = _CommonFunction.MapIntegerValue(Reader["Id"], defaultValue: 0);
                                        Class6PaperModel.AnswerA = Reader["AnswerA"].ToString() ?? "";
                                        Class6PaperModel.AnswerB = Reader["AnswerB"].ToString() ?? "";
                                        Class6PaperModel.AnswerC = Reader["AnswerC"].ToString() ?? "";
                                        Class6PaperModel.AnswerD = Reader["AnswerD"].ToString() ?? "";
                                        Class6PaperModel.CurrectAnswer = Reader["CurrectAnswer"].ToString() ?? "";
                                        Class6PaperModel.QuestionNo = Reader["QuestionNo"].ToString() ?? "";
                                        Class6PaperModel.Remark = Reader["Remark"].ToString() ?? "";
                                        Class6PaperModel.QuezName = Reader["QuezName"].ToString() ?? "";
                                        Class6PaperModel.ConnectedQuestion = _CommonFunction.MapIntegerValue(Reader["ConnectedQuestion"], defaultValue: 0);
                                        LsClass6Details.Add(Class6PaperModel);

                                    }
                                }
                                return LsClass6Details;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return LsClass6Details;
        }

        internal async Task SaveClass6QuizDetails(Class9ViewModel data)
        {
            try
            {
                if (data != null)
                {
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                        await sqlCon.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("InserTblquizeIndeClass6Details", sqlCon);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;

                        sql_cmnd.Parameters.AddWithValue("@QuezName", data.QuezName);
                        sql_cmnd.Parameters.AddWithValue("@ClassName", data.ClassName);
                        sql_cmnd.Parameters.AddWithValue("@SubjectName", data.SubjectName);
                        sql_cmnd.Parameters.AddWithValue("@Remark", data.Remark);
                     
                        sql_cmnd.Parameters.AddWithValue("@Remark2", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark3", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark4", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark5", "");
                        sql_cmnd.Parameters.AddWithValue("@DatetimeStamp", DateTime.Now);

                        await sql_cmnd.ExecuteNonQueryAsync();
                        await sqlCon.CloseAsync();
                    }
                }
            }
            catch (Exception ex)
            {


            }
        }

        internal async Task SavetblClass6EnglisgTestFinalDetails(TblClass6EnglisgTestFinalDetail finalResute)
        {
            try
            {

                using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                {
              
                    await sqlCon.OpenAsync();
                    using (SqlCommand sql_cmnd = new SqlCommand("spTbl_Class6EnglishTestFinalDetails", sqlCon))
                    {


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

                        await sql_cmnd.ExecuteNonQueryAsync();
                        await sqlCon.CloseAsync();
                    }
                }
            }
            catch(Exception ex)
            {
                // Log the exception or handle it as needed
            }
        }

        internal async Task SavetblQuestionPeparEnglishClass6Details(QuestionPepar10ViewModel QuestionDetails)
        {
            try
            {


                if (QuestionDetails != null)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("InsertQuestionPaperEnglishClass6Details", conn);
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

        internal async Task<string> SaveTestSeriesClass6Details(Test10DetailsViewModel Class6TestSeriesDetails)
        {
            string TestIndexId = "";
            try
            {
                if (Class6TestSeriesDetails != null)
                {
                    TestIndexId = Guid.NewGuid().ToString();
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                        sqlCon.Open();
                        SqlCommand sql_cmnd = new SqlCommand("sp_SaveTestSiriseClass6Details", sqlCon);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;

                        sql_cmnd.Parameters.AddWithValue("@TestIndexId", TestIndexId);
                        sql_cmnd.Parameters.AddWithValue("@TestSerisId", Class6TestSeriesDetails.TestId);
                        sql_cmnd.Parameters.AddWithValue("@TestName", Class6TestSeriesDetails.QuizName);
                        sql_cmnd.Parameters.AddWithValue("@QuestionConnectionId", Class6TestSeriesDetails.ConnectionQuestion);
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

        internal async Task UpdateClass6EnlishFinalTestDetails(string TestIndexId, List<TblClass6EnglisgTestFinalDetail> LsClass6EnglisgTestFinalDetails)
        {
            try
            {
                if (LsClass6EnglisgTestFinalDetails.Count() > 0)
                {
                    List<string> TestIdList = new List<string>();

                    TestIdList = LsClass6EnglisgTestFinalDetails.Select(x => x.TestId.ToString()).ToList();
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                        await sqlCon.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("sp_UpdateClass6EnglishTestFinalDetais", sqlCon);
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

        internal async Task UpdatetblQuestionPeparEnglishClass6Details(int PrimaryId, QuestionPepar10ViewModel QuestionDetails)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("UpdateQuestionPaperEnglishClass6DetailsById", conn))
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
