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
    public class Class7Helper
    {
        CommonFunctions _CommonFunction= new CommonFunctions();

        internal async Task DeletetblQuestionPeparEnglishClass7Details(int PrimaryId)
        {
            try
            {
                if (PrimaryId > 0)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("DeleteQuestionPaperEnglishClass7Details", conn);
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

        internal async Task<List<Class9QuestionSetViewModel>> FillClass7QuestionSetDetailsBySubjectName(List<Class9QuestionSetViewModel> LsClass7Details, string SubjectName)
        {
            try
            {
                string Selectdata = $"Select * from Tbl_QuezIndexClass7Details";

                using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
                {
                   await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand(Selectdata, connection))
                    {
                        SqlDataReader reader = await command.ExecuteReaderAsync();

                        while (await reader.ReadAsync())
                        {
                            Class9QuestionSetViewModel lsdata1 = new Class9QuestionSetViewModel();
                            lsdata1.QuestionSetName = reader["QuezName"].ToString() ?? "";
                            lsdata1.id = _CommonFunction.MapIntegerValue(reader["Id"]);

                            LsClass7Details.Add(lsdata1);
                        }
                    }
                   await connection.CloseAsync();
                }
               
            }
            catch(Exception ex)
            {

            }
            return LsClass7Details;
        }

        internal async Task<List<Class9ViewModel>> FillClass7QuizDetailsBySubjectName(List<Class9ViewModel> LsClass7QuezDetails, string Subject)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
                {

                    var selcectdata = $"select * from Tbl_QuezIndexClass7Details";
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
                        LsClass7QuezDetails.Add(lsdata);
                    }
                    connection.Close();
                }

            }
            catch (Exception ex)
            {

            }
            return LsClass7QuezDetails;

        }

        internal async Task FillQuestionPaperClaass7Details(QuestionPepar10ViewModel Class7PaperDetails, int PrimaryId)
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
                                Class7PaperDetails.Id = Convert.ToInt32(reader["Id"]);
                                Class7PaperDetails.QuestionNo = reader["QuestionNo"].ToString();
                                Class7PaperDetails.AnswerA = reader["AnswerA"].ToString();
                                Class7PaperDetails.AnswerB = reader["AnswerB"].ToString();
                                Class7PaperDetails.CurrectAnswer = reader["CurrectAnswer"].ToString();
                                Class7PaperDetails.AnswerD = reader["AnswerD"].ToString();
                                Class7PaperDetails.AnswerC = reader["AnswerC"].ToString();
                                Class7PaperDetails.ConnectedQuestion = _CommonFunction.MapIntegerValue(reader["ConnectedQuestion"], defaultValue: 0);
                                Class7PaperDetails.PrimaryId = _CommonFunction.MapIntegerValue(reader["Id"], defaultValue: 0);
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

        internal async Task<List<QuestionPepar10ViewModel>> FillQuestionpaperClass7DetailsById(List<QuestionPepar10ViewModel> LsQuestionDetais, int Id)
        {
            try
            {
                if (Id > 0)
                {

                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("GetQuestionPaperClass7DetailsByConnectedQuestion", conn);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@ConnectedQuestion", Id);
                        SqlDataReader reader = await sql_cmnd.ExecuteReaderAsync();
                        if (reader.HasRows)
                        {
                            while (await reader.ReadAsync())
                            {
                                QuestionPepar10ViewModel Class7PaperDetails = new QuestionPepar10ViewModel();
                                Class7PaperDetails.Id = Convert.ToInt32(reader["Id"]);
                                Class7PaperDetails.QuestionNo = reader["QuestionNo"].ToString();
                                Class7PaperDetails.AnswerA = reader["AnswerA"].ToString();
                                Class7PaperDetails.AnswerB = reader["AnswerB"].ToString();
                                Class7PaperDetails.CurrectAnswer = reader["CurrectAnswer"].ToString();
                                Class7PaperDetails.AnswerD = reader["AnswerD"].ToString();
                                Class7PaperDetails.AnswerC = reader["AnswerC"].ToString();
                                Class7PaperDetails.ConnectedQuestion = _CommonFunction.MapIntegerValue(reader["ConnectedQuestion"], defaultValue: 0);

                                LsQuestionDetais.Add(Class7PaperDetails);
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

        internal async Task<List<TblClass7EnglisgTestFinalDetail>> GetClass7EnglishTest20Details(List<TblClass7EnglisgTestFinalDetail> LsClass7EnglisgTestFinalDetails)
        {
            try
            {
                string SelectQuery = "SELECT TOP (20) * FROM Tbl_Class7EnglisgTestFinalDetails ORDER BY DatetimeStamp DESC";
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                {
                    await sqlCon.OpenAsync();
                    SqlCommand sql_cmnd = new SqlCommand(SelectQuery, sqlCon);
                    sql_cmnd.CommandType = CommandType.Text;

                    using (SqlDataReader reader = await sql_cmnd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            TblClass7EnglisgTestFinalDetail Class6EnglishTestDetails = new TblClass7EnglisgTestFinalDetail
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
                            LsClass7EnglisgTestFinalDetails.Add(Class6EnglishTestDetails);
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return LsClass7EnglisgTestFinalDetails;
        }

        internal async Task<List<ResultDetailsViewModel>> GetClass7EnglishTestFinalResultDetails(List<ResultDetailsViewModel> LsClass7EnglishTestResult, string id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString: ConnectionString.Connection))
                {
                    using (SqlCommand cmd = new SqlCommand("GetClass7TestSeriesDetails", conn))
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

                                LsClass7EnglishTestResult.Add(lsadata);
                            }
                        }
                    }
                    await conn.CloseAsync();
                }
            }
            catch (Exception ex)
            {

            }
            return LsClass7EnglishTestResult;
        }

        internal async Task<List<TblQuestionPeparEnglishClass7Detail>> GetClass7QuestionDetailsByConnectedQuestion(int ConnectedQuestion)
        {
            List<TblQuestionPeparEnglishClass7Detail> LsClass7Details = new List<TblQuestionPeparEnglishClass7Detail>();
            try
            {
                if (ConnectedQuestion > 0)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString: ConnectionString.Connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_GetClass7EnglishQuestionsDetails", conn))
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
                                        TblQuestionPeparEnglishClass7Detail Class7PaperModel = new TblQuestionPeparEnglishClass7Detail();
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
                                        LsClass7Details.Add(Class7PaperModel);

                                    }
                                }
                                return LsClass7Details;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return LsClass7Details;
        }

        internal async Task SaveClass7QuestionDetails(Class9ViewModel Class7Details)
        {
            try
            {
                if (Class7Details != null)
                {
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                         await sqlCon.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("InserTblquizeIndeClass7Details", sqlCon);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;

                        sql_cmnd.Parameters.AddWithValue("@QuezName", Class7Details.QuezName);
                        sql_cmnd.Parameters.AddWithValue("@ClassName", Class7Details.ClassName);
                        sql_cmnd.Parameters.AddWithValue("@SubjectName", Class7Details.SubjectName);
                        sql_cmnd.Parameters.AddWithValue("@Remark", Class7Details.Remark);
                   
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

        internal async Task SavetblClass7EnglisgTestFinalDetails(TblClass7EnglisgTestFinalDetail finalResute)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                {

                    await sqlCon.OpenAsync();
                    SqlCommand sql_cmnd = new SqlCommand("spTbl_Class7EnglishTestFinalDetails", sqlCon);
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
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
            }
        }

        internal async Task SavetblQuestionPeparEnglishClass7Details(QuestionPepar10ViewModel QuestionDetails)
        {
            try
            {


                if (QuestionDetails != null)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("InsertQuestionPaperEnglishClass7Details", conn);
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

        internal async Task<string> SaveTestSeriesClass7Details(Test10DetailsViewModel Class7TestSeriesDetails)
        {
            string TestIndexId = "";
            try
            {
                if (Class7TestSeriesDetails != null)
                {
                    TestIndexId = Guid.NewGuid().ToString();
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                        sqlCon.Open();
                        SqlCommand sql_cmnd = new SqlCommand("sp_SaveTestSiriseClass7Details", sqlCon);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;

                        sql_cmnd.Parameters.AddWithValue("@TestIndexId", TestIndexId);
                        sql_cmnd.Parameters.AddWithValue("@TestSerisId", Class7TestSeriesDetails.TestId);
                        sql_cmnd.Parameters.AddWithValue("@TestName", Class7TestSeriesDetails.QuizName);
                        sql_cmnd.Parameters.AddWithValue("@QuestionConnectionId", Class7TestSeriesDetails.ConnectionQuestion);
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

        internal async Task UpdateClass7EnlishFinalTestDetails(string TestIndexId, List<TblClass7EnglisgTestFinalDetail> LsClass7EnglisgTestFinalDetails)
        {
            try
            {
                if (LsClass7EnglisgTestFinalDetails.Count() > 0)
                {
                    List<string> TestIdList = new List<string>();

                    TestIdList = LsClass7EnglisgTestFinalDetails.Select(x => x.TestId.ToString()).ToList();
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                        await sqlCon.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("sp_UpdateClass7EnglishTestFinalDetais", sqlCon);
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

        internal async Task UpdatetblQuestionPeparEnglishClass7Details(int PrimaryId, QuestionPepar10ViewModel QuestionDetails)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("UpdateQuestionPaperEnglishClass7DetailsById", conn))
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
