using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using quezemasterNew.CommonFunctional;
using quezemasterNew.Models;
using quezemasterNew.Models.Class9;
using quezemasterNew.Models.ViewModel;
using quezemasterNew.Models.ViewModel.Test;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace quezemasterNew.BussinesLogic
{
    public class Class10Helper
    {
        CommonFunctions _CommonFunction = new CommonFunctions(); 
        internal async Task FillQuestionPaperClaass10Details(QuestionPepar10ViewModel Class10PaperDetails,  int PrimaryId)
        {
            try
            {
                if (PrimaryId > 0)
                {

                    using(SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("GetQuestionPaperClass10DetailsById", conn);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@PrimaryId", PrimaryId);
                        SqlDataReader reader = await sql_cmnd.ExecuteReaderAsync();
                        if (reader.HasRows)
                        {
                            while (await reader.ReadAsync())
                            {
                                Class10PaperDetails.Id = Convert.ToInt32(reader["Id"]);
                                Class10PaperDetails.QuestionNo = reader["QuestionNo"].ToString();
                                Class10PaperDetails.AnswerA = reader["AnswerA"].ToString();
                                Class10PaperDetails.AnswerB = reader["AnswerB"].ToString();
                                Class10PaperDetails.CurrectAnswer = reader["CurrectAnswer"].ToString();
                                Class10PaperDetails.AnswerD = reader["AnswerD"].ToString();
                                Class10PaperDetails.AnswerC = reader["AnswerC"].ToString();
                                Class10PaperDetails.ConnectedQuestion = _CommonFunction.MapIntegerValue(reader["ConnectedQuestion"],defaultValue:0);
                                Class10PaperDetails.PrimaryId = _CommonFunction.MapIntegerValue(reader["Id"], defaultValue:0);
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

        internal async Task<List<Class9ViewModel>> GetClass10QuiezDetailsBySubjectId(List<Class9ViewModel> LsClass10QuiezDetails, string Subject)
        {

            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString.Connection);

                var selcectdata = $"select * from Tbl_QuezIndexClass10Details Where SubjectName = '{Subject}'";
                SqlCommand command = new SqlCommand(selcectdata, connection);
                command.CommandType = System.Data.CommandType.Text;
                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Class9ViewModel lsdata = new Class9ViewModel();
                    lsdata.Id = Convert.ToInt32(reader["Id"]);
                    lsdata.QuezName = reader["QuezName"].ToString();
                    lsdata.ClassName = reader["ClassName"].ToString();
                    lsdata.SubjectName = reader["SubjectName"].ToString();
                    lsdata.Remark = reader["Remark"].ToString();
                    LsClass10QuiezDetails.Add(lsdata);
                }
               await connection.CloseAsync();
            }
            catch (Exception ex)
            {

            }
            return LsClass10QuiezDetails;
        }

        internal async Task InsertClass10QuiezDetails(Class9ViewModel Clas10QuizDetails)
        {
            try
            {
                if (Clas10QuizDetails != null)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {

                        await  conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("InserTblquizeIndeClass10Details", conn);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;

                        sql_cmnd.Parameters.AddWithValue("@QuezName", Clas10QuizDetails.QuezName);
                        sql_cmnd.Parameters.AddWithValue("@ClassName", Clas10QuizDetails.ClassName);
                        sql_cmnd.Parameters.AddWithValue("@SubjectName", Clas10QuizDetails.SubjectName);
                        sql_cmnd.Parameters.AddWithValue("@Remark", Clas10QuizDetails.Remark);
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

            }
        }



        internal async Task<List<QuestionPepar10ViewModel>> FillQuestionpaperClass10DetailsById(List<QuestionPepar10ViewModel> LsQuestionDetais, int Id)
        {

                try
                {
                    if (Id > 0)
                    {

                        using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                        {
                            await conn.OpenAsync();
                            SqlCommand sql_cmnd = new SqlCommand("GetQuestionPaperClass10DetailsByConnectedQuestion", conn);
                            sql_cmnd.CommandType = CommandType.StoredProcedure;
                            sql_cmnd.Parameters.AddWithValue("@ConnectedQuestion", Id);
                            SqlDataReader reader = await sql_cmnd.ExecuteReaderAsync();
                            if (reader.HasRows)
                            {
                                while (await reader.ReadAsync())
                                {
                                    QuestionPepar10ViewModel Class10PaperDetails= new QuestionPepar10ViewModel();
                                    Class10PaperDetails.Id = Convert.ToInt32(reader["Id"]);
                                    Class10PaperDetails.QuestionNo = reader["QuestionNo"].ToString();
                                    Class10PaperDetails.AnswerA = reader["AnswerA"].ToString();
                                    Class10PaperDetails.AnswerB = reader["AnswerB"].ToString();
                                    Class10PaperDetails.CurrectAnswer = reader["CurrectAnswer"].ToString();
                                    Class10PaperDetails.AnswerD = reader["AnswerD"].ToString();
                                    Class10PaperDetails.AnswerC = reader["AnswerC"].ToString();
                                    Class10PaperDetails.ConnectedQuestion = _CommonFunction.MapIntegerValue(reader["ConnectedQuestion"], defaultValue: 0);
                      
                                LsQuestionDetais.Add(Class10PaperDetails);
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

        internal async Task SavetblQuestionPeparEnglishClass10Details(QuestionPepar10ViewModel QuestionDetails)
        {
            try
            {


                if (QuestionDetails != null)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("InsertQuestionPaperEnglishClass10Details", conn);
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

        internal async Task UpdatetblQuestionPeparEnglishClass10Details(int PrimaryId, QuestionPepar10ViewModel QuestionDetails)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("UpdateQuestionPaperEnglishClass10DetailsById", conn))
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
            catch(Exception ex)
            {

            }
        }

        internal async Task DeletetblQuestionPeparEnglishClass10Details(int PrimaryId)
        {
            try
            {
                if(PrimaryId > 0)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("DeleteQuestionPaperEnglishClass10Details", conn);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@PrimaryId", PrimaryId);
                        await sql_cmnd.ExecuteNonQueryAsync();
                        await conn.CloseAsync();
                    }
                }
            }
            catch(Exception ex)
            {
                // Log the exception or handle it as needed
            }
        }

        internal List<Class9QuestionSetViewModel> GetClass10QuestionSetDetailsBySubjectName(List<Class9QuestionSetViewModel> lsClass10Details, string SubjectName)
        {
            try
            {

                var Selectdata = $"Select * from Tbl_QuezIndexClass10Details Where SubjectName = '{SubjectName}'";

                SqlConnection connection = new SqlConnection(ConnectionString.Connection);
                connection.Open();
                SqlCommand command = new SqlCommand(Selectdata, connection);

                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Class9QuestionSetViewModel lsdata1 = new Class9QuestionSetViewModel();
                    lsdata1.QuestionSetName = reader["QuezName"].ToString() ?? "";
                    lsdata1.id = _CommonFunction.MapIntegerValue(reader["Id"]);

                    lsClass10Details.Add(lsdata1);
                }
                connection.Close();
            }
            catch (Exception ex)
            {


            }
            return lsClass10Details;    
        }

        internal async Task<List<ResultDetailsViewModel>> GetClass10EnglishTestFinalResultDetails(List<ResultDetailsViewModel> LsClass10EnglishTestResult, string Id)
        {
            try
            {


                if(!string.IsNullOrEmpty(Id))
                {
                    int i = 1;

                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();

                        using (SqlCommand cmd = new SqlCommand("GetClass10TestSeriesDetails", conn))
                        {

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@TestIndexId", Id);
                            await conn.OpenAsync();

                            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                            {
                            while (await reader.ReadAsync())
                            {
                                ResultDetailsViewModel lsadat = new ResultDetailsViewModel
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

                                LsClass10EnglishTestResult.Add(lsadat);
                            }
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return LsClass10EnglishTestResult;
        }

        internal async Task SavetblClass10EnglisgTestFinalDetails(TblClass10EnglisgTestFinalDetail finalResute)
        {
            try
            {

                using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                {


                    await sqlCon.OpenAsync();
                    SqlCommand sql_cmnd = new SqlCommand("spTbl_Class10EnglishTestFinalDetails", sqlCon);
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
            catch(Exception ex)
            {

            }
        }

        internal async Task<List<TblClass10EnglisgTestFinalDetail>> GetClass10EnglishTest20Details(List<TblClass10EnglisgTestFinalDetail> LsClass10EnglisgTestFinalDetails)
        {

            try
            {
                string SelectQuery = "SELECT TOP (20) * FROM Tbl_Class10EnglisgTestFinalDetails ORDER BY DatetimeStamp DESC";
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                {
                    await sqlCon.OpenAsync();
                    SqlCommand sql_cmnd = new SqlCommand(SelectQuery, sqlCon);
                    sql_cmnd.CommandType = CommandType.Text;

                    using (SqlDataReader reader = await sql_cmnd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            TblClass10EnglisgTestFinalDetail BPSCEnglishTestDetails = new TblClass10EnglisgTestFinalDetail
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
                            LsClass10EnglisgTestFinalDetails.Add(BPSCEnglishTestDetails);
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return LsClass10EnglisgTestFinalDetails;
        }

        internal async Task<string> SaveTestSeriesClass10Details(Test10DetailsViewModel Class10TestSeriesDetails)
        {
            string TestIndexId = "";
            try
            {
                if (Class10TestSeriesDetails != null)
                {
                    TestIndexId = Guid.NewGuid().ToString();
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                        sqlCon.Open();
                        SqlCommand sql_cmnd = new SqlCommand("sp_SaveTestSiriseClass10Details", sqlCon);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;

                        sql_cmnd.Parameters.AddWithValue("@TestIndexId", TestIndexId);
                        sql_cmnd.Parameters.AddWithValue("@TestSerisId", Class10TestSeriesDetails.TestId);
                        sql_cmnd.Parameters.AddWithValue("@TestName", Class10TestSeriesDetails.QuizName);
                        sql_cmnd.Parameters.AddWithValue("@QuestionConnectionId", Class10TestSeriesDetails.ConnectionQuestion);
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

        internal async Task UpdateBPSCClassEnlishFinalTestDetails(string TestIndexId, List<TblClass10EnglisgTestFinalDetail> LsClass10EnglisgTestFinalDetails)
        {
            try
            {
                if (LsClass10EnglisgTestFinalDetails.Count() > 0)
                {
                    List<string> TestIdList = new List<string>();

                    TestIdList = LsClass10EnglisgTestFinalDetails.Select(x => x.TestId.ToString()).ToList();
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                        sqlCon.Open();
                        SqlCommand sql_cmnd = new SqlCommand("sp_UpdateClass10EnglishTestFinalDetais", sqlCon);
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

        internal async Task<List<TblQuestionPeparEnglishClass10Detail>> GetClass10QuestionDetailsByConnectedQuestion(int ConnectedQuestion)
        {
            List<TblQuestionPeparEnglishClass10Detail> LsBPSCDetails = new List<TblQuestionPeparEnglishClass10Detail>();
            try
            {
                if (ConnectedQuestion > 0)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString: ConnectionString.Connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_GetClass10EnglishQuestionsDetails", conn))
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
                                        TblQuestionPeparEnglishClass10Detail BPSCPaperModel = new TblQuestionPeparEnglishClass10Detail();
                                        BPSCPaperModel.QuezIndexId = _CommonFunction.MapIntegerValue(Reader["QuezIndexId"], defaultValue: 0);
                                        BPSCPaperModel.Id = _CommonFunction.MapIntegerValue(Reader["Id"], defaultValue: 0);
                                        BPSCPaperModel.AnswerA = Reader["AnswerA"].ToString() ?? "";
                                        BPSCPaperModel.AnswerB = Reader["AnswerB"].ToString() ?? "";
                                        BPSCPaperModel.AnswerC = Reader["AnswerC"].ToString() ?? "";
                                        BPSCPaperModel.AnswerD = Reader["AnswerD"].ToString() ?? "";
                                        BPSCPaperModel.CurrectAnswer = Reader["CurrectAnswer"].ToString() ?? "";
                                        BPSCPaperModel.QuestionNo = Reader["QuestionNo"].ToString() ?? "";
                                        BPSCPaperModel.Remark = Reader["Remark"].ToString() ?? "";
                                        BPSCPaperModel.QuezName = Reader["QuezName"].ToString() ?? "";
                                        BPSCPaperModel.ConnectedQuestion = _CommonFunction.MapIntegerValue(Reader["ConnectedQuestion"], defaultValue: 0);
                                        LsBPSCDetails.Add(BPSCPaperModel);

                                    }
                                }
                                return LsBPSCDetails;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return LsBPSCDetails;
        }
    }
}
