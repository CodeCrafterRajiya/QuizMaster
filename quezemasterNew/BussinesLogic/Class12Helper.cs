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
    public class Class12Helper
    {

        CommonFunctions _CommonFunction = new CommonFunctions();

        internal async Task DeletetblQuestionPeparEnglishClass12Details(int PrimaryId)
        {
            try
            {
                if (PrimaryId > 0)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("DeleteQuestionPaperEnglishClass12Details", conn);
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

        internal async Task DeletetblQuezIndexClass12Details(int PrimaryId)
        {
            try
            {
                if (PrimaryId > 0)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("DeleteQuezIndexClass12Details", conn);
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

        internal async Task<List<Class9QuestionSetViewModel>> FillClass12QuestionSetDetailsBySubjectName(List<Class9QuestionSetViewModel> LsClass12Details, string SubjectName)
        {
            try
            {

                string Selectdata = $"Select * from Tbl_QuezIndexClass12Details Where SubjectName = '{SubjectName}'";

                SqlConnection connection = new SqlConnection(ConnectionString.Connection);
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(Selectdata, connection);

                await command.ExecuteNonQueryAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Class9QuestionSetViewModel lsdata1 = new Class9QuestionSetViewModel();
                    lsdata1.QuestionSetName = reader["QuezName"].ToString() ?? "";
                    lsdata1.id = _CommonFunction.MapIntegerValue(reader["Id"]);

                    LsClass12Details.Add(lsdata1);
                }
                await connection.CloseAsync();
            }
            catch (Exception ex)
            {


            }
            return LsClass12Details;
        }

        internal async Task<List<Class9ViewModel>> FillClass12QuizDetailsBySubjectName(List<Class9ViewModel> LsClass12Details, string Subject)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString.Connection);

                var selcectdata = $"select * from Tbl_QuezIndexClass12Details Where SubjectName = '{Subject}'";
                SqlCommand command = new SqlCommand(selcectdata, connection);
                command.CommandType = System.Data.CommandType.Text;
                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Class9ViewModel lsdata = new Class9ViewModel();
                    lsdata.Id = _CommonFunction.MapIntegerValue(reader["Id"]);
                    lsdata.QuezName = reader["QuezName"].ToString();
                    lsdata.ClassName = reader["ClassName"].ToString();
                    lsdata.SubjectName = reader["SubjectName"].ToString();
                    lsdata.Remark = reader["Remark"].ToString();
                    LsClass12Details.Add(lsdata);
                }
                await  connection.CloseAsync();
            }
            catch (Exception ex)
            {

            }
            return LsClass12Details;
        }

        internal async Task FillQuestionPaperClaass12Details(QuestionPepar10ViewModel Class12PaperDetails, int PrimaryId)
        {
            try
            {
                if (PrimaryId > 0)
                {

                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("GetQuestionPaperClass12DetailsById", conn);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@PrimaryId", PrimaryId);
                        SqlDataReader reader = await sql_cmnd.ExecuteReaderAsync();
                        if (reader.HasRows)
                        {
                            while (await reader.ReadAsync())
                            {
                                Class12PaperDetails.Id = Convert.ToInt32(reader["Id"]);
                                Class12PaperDetails.QuestionNo = reader["QuestionNo"].ToString();
                                Class12PaperDetails.AnswerA = reader["AnswerA"].ToString();
                                Class12PaperDetails.AnswerB = reader["AnswerB"].ToString();
                                Class12PaperDetails.CurrectAnswer = reader["CurrectAnswer"].ToString();
                                Class12PaperDetails.AnswerD = reader["AnswerD"].ToString();
                                Class12PaperDetails.AnswerC = reader["AnswerC"].ToString();
                                Class12PaperDetails.ConnectedQuestion = _CommonFunction.MapIntegerValue(reader["ConnectedQuestion"], defaultValue: 0);
                                Class12PaperDetails.PrimaryId = _CommonFunction.MapIntegerValue(reader["Id"], defaultValue: 0);
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

        internal async Task<List<QuestionPepar10ViewModel>> FillQuestionpaperClass12DetailsById(List<QuestionPepar10ViewModel> LsQuestionDetais, int Id)
        {
            try
            {
                if (Id > 0)
                {

                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("GetQuestionPaperClass12DetailsByConnectedQuestion", conn);
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

        internal async Task<List<TblClass12EnglisgTestFinalDetail>> GetClass12EnglishTest20Details(List<TblClass12EnglisgTestFinalDetail> LsClass12EnglisgTestFinalDetails)
        {
            try
            {
                string SelectQuery = "SELECT TOP (20) * FROM Tbl_Class12EnglisgTestFinalDetails ORDER BY DatetimeStamp DESC";
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                {
                    await sqlCon.OpenAsync();
                    SqlCommand sql_cmnd = new SqlCommand(SelectQuery, sqlCon);
                    sql_cmnd.CommandType = CommandType.Text;

                    using (SqlDataReader reader = await sql_cmnd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            TblClass12EnglisgTestFinalDetail Class12EnglishTestDetails = new TblClass12EnglisgTestFinalDetail
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
                            LsClass12EnglisgTestFinalDetails.Add(Class12EnglishTestDetails);
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return LsClass12EnglisgTestFinalDetails;
        
        }

        internal async Task<List<ResultDetailsViewModel>> GetClass12EnglishTestFinalResultDetails(List<ResultDetailsViewModel> LsClass12EnglishTestResult, string Id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString: ConnectionString.Connection))
                {
                    using (SqlCommand cmd = new SqlCommand("GetClass12TestSeriesDetails", conn))
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

                                LsClass12EnglishTestResult.Add(lsadata);
                            }
                        }
                    }
                    await conn.CloseAsync();
                }
            }
            catch (Exception ex)
            {

            }
            return LsClass12EnglishTestResult;
        }

        internal async Task<List<TblQuestionPeparEnglishClass12Detail>> GetClass12QuestionDetailsByConnectedQuestion(int ConnectedQuestion)
        {
            List<TblQuestionPeparEnglishClass12Detail> LsClass12Details = new List<TblQuestionPeparEnglishClass12Detail>();
            try
            {
                if (ConnectedQuestion > 0)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString: ConnectionString.Connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_GetClass12EnglishQuestionsDetails", conn))
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
                                        TblQuestionPeparEnglishClass12Detail Class12PaperModel = new TblQuestionPeparEnglishClass12Detail();
                                        Class12PaperModel.QuezIndexId = _CommonFunction.MapIntegerValue(Reader["QuezIndexId"], defaultValue: 0);
                                        Class12PaperModel.Id = _CommonFunction.MapIntegerValue(Reader["Id"], defaultValue: 0);
                                        Class12PaperModel.AnswerA = Reader["AnswerA"].ToString() ?? "";
                                        Class12PaperModel.AnswerB = Reader["AnswerB"].ToString() ?? "";
                                        Class12PaperModel.AnswerC = Reader["AnswerC"].ToString() ?? "";
                                        Class12PaperModel.AnswerD = Reader["AnswerD"].ToString() ?? "";
                                        Class12PaperModel.CurrectAnswer = Reader["CurrectAnswer"].ToString() ?? "";
                                        Class12PaperModel.QuestionNo = Reader["QuestionNo"].ToString() ?? "";
                                        Class12PaperModel.Remark = Reader["Remark"].ToString() ?? "";
                                        Class12PaperModel.QuezName = Reader["QuezName"].ToString() ?? "";
                                        Class12PaperModel.ConnectedQuestion = _CommonFunction.MapIntegerValue(Reader["ConnectedQuestion"], defaultValue: 0);
                                        LsClass12Details.Add(Class12PaperModel);

                                    }
                                }
                                return LsClass12Details;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return LsClass12Details;
        }

        internal async Task SaveClass12QuizDetails(Class9ViewModel data)
        {
            if (data != null)
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                {

                    await sqlCon.OpenAsync();
                    SqlCommand sql_cmnd = new SqlCommand("InserTblquizeIndeClass12Details", sqlCon);
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

        internal async Task SavetblClass12EnglisgTestFinalDetails(TblClass12EnglisgTestFinalDetail finalResute)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                {

                    sqlCon.Open();
                    SqlCommand sql_cmnd = new SqlCommand("spTbl_Class12EnglishTestFinalDetails", sqlCon);
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
            catch(Exception ex)
            {
                // Log the exception or handle it as needed
            }
        }

        internal async Task SavetblQuestionPeparEnglishClass12Details(QuestionPepar10ViewModel QuestionDetails)
        {
            try
            {


                if (QuestionDetails != null)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("InsertQuestionPaperEnglishClass12Details", conn);
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

        internal async Task<string> SaveTestSeriesClass12Details(Test10DetailsViewModel Class12TestSeriesDetails)
        {
            string TestIndexId = "";
            try
            {
                if (Class12TestSeriesDetails != null)
                {
                    TestIndexId = Guid.NewGuid().ToString();
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                        sqlCon.Open();
                        SqlCommand sql_cmnd = new SqlCommand("sp_SaveTestSiriseClass12Details", sqlCon);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;

                        sql_cmnd.Parameters.AddWithValue("@TestIndexId", TestIndexId);
                        sql_cmnd.Parameters.AddWithValue("@TestSerisId", Class12TestSeriesDetails.TestId);
                        sql_cmnd.Parameters.AddWithValue("@TestName", Class12TestSeriesDetails.QuizName);
                        sql_cmnd.Parameters.AddWithValue("@QuestionConnectionId", Class12TestSeriesDetails.ConnectionQuestion);
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

        internal async Task UpdateClass12EnlishFinalTestDetails(string TestIndexId, List<TblClass12EnglisgTestFinalDetail> LsClass12EnglisgTestFinalDetails)
        {
            try
            {
                if (LsClass12EnglisgTestFinalDetails.Count() > 0)
                {
                    List<string> TestIdList = new List<string>();

                    TestIdList = LsClass12EnglisgTestFinalDetails.Select(x => x.TestId.ToString()).ToList();
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                        await sqlCon.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("sp_UpdateClass12EnglishTestFinalDetais", sqlCon);
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

        internal async Task UpdatetblQuestionPeparEnglishClass12Details(int PrimaryId, QuestionPepar10ViewModel QuestionDetails)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("UpdateQuestionPaperEnglishClass12DetailsById", conn))
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
