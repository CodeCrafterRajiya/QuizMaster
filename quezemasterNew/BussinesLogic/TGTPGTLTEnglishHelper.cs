using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlTypes;
using quezemasterNew.CommonFunctional;
using quezemasterNew.Models;
using quezemasterNew.Models.Class9;
using quezemasterNew.Models.TGTPGTLT;
using quezemasterNew.Models.ViewModel;
using quezemasterNew.Models.ViewModel.Test;
using System;
using System.Data;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace quezemasterNew.BussinesLogic
{
    public class TGTPGTLTEnglishHelper
    {
        CommonFunctions _CommonFunction = new CommonFunctions();

        internal async Task DeletetblQuestionPeparEnglishClassTGTDetails(int PrimaryId)
        {
            try
            {
                if (PrimaryId > 0)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("DeleteQuestionPaperEnglishClassTGTDetails", conn);
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

        internal async Task<List<TGTPGTLTViewModel>> FillClassPGTLQuizDetails(List<TGTPGTLTViewModel> lsQuezDetsils)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString.Connection);

                SqlCommand command = new SqlCommand("SelectTblQuizeIndexPGTdetails", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TGTPGTLTViewModel lsdata = new TGTPGTLTViewModel();
                    lsdata.Id = Convert.ToInt32(reader["Id"]);
                    lsdata.QuezName = reader["QuezName"].ToString();
                    lsdata.ClassName = reader["ClassName"].ToString();
                    lsdata.SubjectName = reader["SubjectName"].ToString();
                    lsdata.Remark = reader["Remark"].ToString();
                    lsQuezDetsils.Add(lsdata);
                }
                connection.Close();
            }
            catch (Exception ex)
            {

            }
            return lsQuezDetsils;
        }

        internal async Task<List<TGTPGTLTViewModel>> FillClassTGTLQuizDetails(List<TGTPGTLTViewModel> lsQuezDetsils)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString.Connection);

                SqlCommand command = new SqlCommand("SelectTblQuizeIndeTGTdetails", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TGTPGTLTViewModel lsdata = new TGTPGTLTViewModel();
                    lsdata.Id = Convert.ToInt32(reader["Id"]);
                    lsdata.QuezName = reader["QuezName"].ToString();
                    lsdata.ClassName = reader["ClassName"].ToString();
                    lsdata.SubjectName = reader["SubjectName"].ToString();
                    lsdata.Remark = reader["Remark"].ToString();
                    lsQuezDetsils.Add(lsdata);
                }
                connection.Close();
            }
            catch (Exception ex)
            {

            }
            return lsQuezDetsils;
        }

        internal async Task<List<TGTQuestionSetViewModel>> FillClassTGTQuestionSetDetailsBySubjectName(List<TGTQuestionSetViewModel> LsTGTDetails)
        {

            try
            {

                var Selectdata = $"Select * from Tbl_QuezIndexTGTDetails";

                SqlConnection connection = new SqlConnection(ConnectionString.Connection);
                connection.Open();
                SqlCommand command = new SqlCommand(Selectdata, connection);

                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TGTQuestionSetViewModel lsdata1 = new TGTQuestionSetViewModel();
                    lsdata1.QuestionSetName = reader["QuezName"].ToString();
                    lsdata1.id = Convert.ToInt32(reader["Id"]);

                    LsTGTDetails.Add(lsdata1);
                }
                connection.Close();
            }
            catch (Exception ex)
            {


            }
            return LsTGTDetails;

        }

        internal async Task FillQuestionPaperClassPGTDetails(QuestionPepar10ViewModel ClassPGTDetails, int PrimaryId)
        {
            try
            {
                if (PrimaryId > 0)
                {

                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("GetQuestionPaperClassPGTDetailsById", conn);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@PrimaryId", PrimaryId);
                        SqlDataReader reader = await sql_cmnd.ExecuteReaderAsync();
                        if (reader.HasRows)
                        {
                            while (await reader.ReadAsync())
                            {
                                ClassPGTDetails.Id = _CommonFunction.MapIntegerValue(reader["Id"]);
                                ClassPGTDetails.QuestionNo = reader["QuestionNo"].ToString();
                                ClassPGTDetails.AnswerA = reader["AnswerA"].ToString();
                                ClassPGTDetails.AnswerB = reader["AnswerB"].ToString();
                                ClassPGTDetails.CurrectAnswer = reader["CurrectAnswer"].ToString();
                                ClassPGTDetails.AnswerD = reader["AnswerD"].ToString();
                                ClassPGTDetails.AnswerC = reader["AnswerC"].ToString();
                                ClassPGTDetails.ConnectedQuestion = _CommonFunction.MapIntegerValue(reader["ConnectedQuestion"], defaultValue: 0);
                                ClassPGTDetails.PrimaryId = _CommonFunction.MapIntegerValue(reader["Id"], defaultValue: 0);
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

        internal async Task FillQuestionPaperClaassTGTPaperDetails(QuestionPepar10ViewModel ClassTGTPaperDetails, int PrimaryId)
        {
            try
            {
                if (PrimaryId > 0)
                {

                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("GetQuestionPaperClassTGTDetailsById", conn);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@PrimaryId", PrimaryId);
                        SqlDataReader reader = await sql_cmnd.ExecuteReaderAsync();
                        if (reader.HasRows)
                        {
                            while (await reader.ReadAsync())
                            {
                                ClassTGTPaperDetails.Id = _CommonFunction.MapIntegerValue(reader["Id"]);
                                ClassTGTPaperDetails.QuestionNo = reader["QuestionNo"].ToString();
                                ClassTGTPaperDetails.AnswerA = reader["AnswerA"].ToString();
                                ClassTGTPaperDetails.AnswerB = reader["AnswerB"].ToString();
                                ClassTGTPaperDetails.CurrectAnswer = reader["CurrectAnswer"].ToString();
                                ClassTGTPaperDetails.AnswerD = reader["AnswerD"].ToString();
                                ClassTGTPaperDetails.AnswerC = reader["AnswerC"].ToString();
                                ClassTGTPaperDetails.ConnectedQuestion = _CommonFunction.MapIntegerValue(reader["ConnectedQuestion"], defaultValue: 0);
                                ClassTGTPaperDetails.PrimaryId = _CommonFunction.MapIntegerValue(reader["Id"], defaultValue: 0);
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

        internal async Task<List<QuestionPepar10ViewModel>> FillQuestionpaperClassPGTDetailsById(List<QuestionPepar10ViewModel> LsQuestionDetais, int Id)
        {
            try
            {
                if (Id > 0)
                {

                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("GetQuestionPaperClassPGTDetailsByConnectedQuestion", conn);
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

        internal async Task<List<QuestionPepar10ViewModel>> FillQuestionpaperClassTGTPaperDetailsById(List<QuestionPepar10ViewModel> LsQuestionDetais, int Id)
        {
            try
            {
                if (Id > 0)
                {

                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("GetQuestionPaperClassTGTDetailsByConnectedQuestion", conn);
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

        internal async Task<List<TblTgtenglisgTestFinalDetail>> GetClassTGTEnglishTest20Details(List<TblTgtenglisgTestFinalDetail> LsClassTGTDetails)
        {
            try
            {
                string SelectQuery = "SELECT TOP (20) * FROM Tbl_TGTENglisgTestFinalDetails ORDER BY DatetimeStamp DESC";
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                {
                    await sqlCon.OpenAsync();
                    SqlCommand sql_cmnd = new SqlCommand(SelectQuery, sqlCon);
                    sql_cmnd.CommandType = CommandType.Text;

                    using (SqlDataReader reader = await sql_cmnd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            TblTgtenglisgTestFinalDetail ClassTGTEnglishTestDetails = new TblTgtenglisgTestFinalDetail
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
                            LsClassTGTDetails.Add(ClassTGTEnglishTestDetails);
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return LsClassTGTDetails;
        }

        internal async Task<List<ResultDetailsViewModel>> GetClassTGTEnglishTestFinalResultDetails(List<ResultDetailsViewModel> LsClassTGTEnglishTestResult, string id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString: ConnectionString.Connection))
                {
                    using (SqlCommand cmd = new SqlCommand("GetClassTGTTestSeriesDetails", conn))
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

                                LsClassTGTEnglishTestResult.Add(lsadata);
                            }
                        }
                    }
                    await conn.CloseAsync();
                }
            }
            catch (Exception ex)
            {

            }
            return LsClassTGTEnglishTestResult;
        }

        internal async Task<List<TblQuestionPeparEnglishTgtdetail>> GetClassTGTQuestionDetailsByConnectedQuestion(int ConnectedQuestion)
        {
            List<TblQuestionPeparEnglishTgtdetail> LsClassTGTDetails = new List<TblQuestionPeparEnglishTgtdetail>();
            try
            {
                if (ConnectedQuestion > 0)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString: ConnectionString.Connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_GetClassTGTEnglishQuestionsDetails", conn))
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
                                        TblQuestionPeparEnglishTgtdetail ClassTGTPaperModel = new TblQuestionPeparEnglishTgtdetail();
                                        ClassTGTPaperModel.QuezIndexId = _CommonFunction.MapIntegerValue(Reader["QuezIndexId"], defaultValue: 0);
                                        ClassTGTPaperModel.Id = _CommonFunction.MapIntegerValue(Reader["Id"], defaultValue: 0);
                                        ClassTGTPaperModel.AnswerA = Reader["AnswerA"].ToString() ?? "";
                                        ClassTGTPaperModel.AnswerB = Reader["AnswerB"].ToString() ?? "";
                                        ClassTGTPaperModel.AnswerC = Reader["AnswerC"].ToString() ?? "";
                                        ClassTGTPaperModel.AnswerD = Reader["AnswerD"].ToString() ?? "";
                                        ClassTGTPaperModel.CurrectAnswer = Reader["CurrectAnswer"].ToString() ?? "";
                                        ClassTGTPaperModel.QuestionNo = Reader["QuestionNo"].ToString() ?? "";
                                        ClassTGTPaperModel.Remark = Reader["Remark"].ToString() ?? "";
                                        ClassTGTPaperModel.QuezName = Reader["QuezName"].ToString() ?? "";
                                        ClassTGTPaperModel.ConnectedQuestion = _CommonFunction.MapIntegerValue(Reader["ConnectedQuestion"], defaultValue: 0);
                                        LsClassTGTDetails.Add(ClassTGTPaperModel);

                                    }
                                }
                                return LsClassTGTDetails;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return LsClassTGTDetails;
        }

        internal async Task<bool> InsertTGTQuizDetails(TGTPGTLTViewModel data)
        {
            try
            {
                if (data != null)
                {
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                        sqlCon.Open();
                        SqlCommand sql_cmnd = new SqlCommand("InserTblquizeIndeTGTDetails", sqlCon);
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

                        sql_cmnd.ExecuteNonQuery();
                        sqlCon.Close();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
            }
            return false;
        }

        internal async Task<bool> InsertPGTQuizDetails(TGTPGTLTViewModel ClassPGTDetails)
        {
            try
            {
                if (ClassPGTDetails != null)
                {
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                        await sqlCon.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("InserTblquizeIndexPGTDetails", sqlCon);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;

                        sql_cmnd.Parameters.AddWithValue("@QuezName", ClassPGTDetails.QuezName);
                        sql_cmnd.Parameters.AddWithValue("@ClassName", ClassPGTDetails.ClassName);
                        sql_cmnd.Parameters.AddWithValue("@SubjectName", ClassPGTDetails.SubjectName);
                        sql_cmnd.Parameters.AddWithValue("@Remark", ClassPGTDetails.Remark);
                        //sql_cmnd.Parameters.AddWithValue("@Remark1", data.Remark1);
                        sql_cmnd.Parameters.AddWithValue("@Remark2", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark3", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark4", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark5", "");
                        sql_cmnd.Parameters.AddWithValue("@DatetimeStamp", DateTime.Now);

                        await sql_cmnd.ExecuteNonQueryAsync();
                        await sqlCon.CloseAsync();
                        return true;
                    }
                }

            }
            catch (Exception ex)
            {


            }
            return false;
        }

        internal async Task SavetblClassTGTEnglisgTestFinalDetails(TblTgtenglisgTestFinalDetail finalResute)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                {


                    sqlCon.Open();
                    SqlCommand sql_cmnd = new SqlCommand("spTbl_TGTEnglishTestFinalDetails", sqlCon);
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

            }
        }

        internal async Task SavetblQuestionPeparEnglishClassTGTDetails(QuestionPepar10ViewModel QuestionDetails)
        {

            try
            {


                if (QuestionDetails != null)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("InsertQuestionPaperEnglishClassTGTDetails", conn);
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

        internal async Task<string> SaveTestSeriesClassTGTDetails(Test10DetailsViewModel ClassTGTTestSeriesDetails)
        {
            string TestIndexId = "";
            try
            {
                if (ClassTGTTestSeriesDetails != null)
                {
                    TestIndexId = Guid.NewGuid().ToString();
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                        await sqlCon.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("sp_SaveTestSiriseClassTGTDetails", sqlCon);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;

                        sql_cmnd.Parameters.AddWithValue("@TestIndexId", TestIndexId);
                        sql_cmnd.Parameters.AddWithValue("@TestSerisId", ClassTGTTestSeriesDetails.TestId);
                        sql_cmnd.Parameters.AddWithValue("@TestName", ClassTGTTestSeriesDetails.QuizName);
                        sql_cmnd.Parameters.AddWithValue("@QuestionConnectionId", ClassTGTTestSeriesDetails.ConnectionQuestion);
                        sql_cmnd.Parameters.AddWithValue("@DateTimeStamp", DateTime.Now);
                        sql_cmnd.Parameters.AddWithValue("@Remark", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark1", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark2", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark3", "");

                       await sql_cmnd.ExecuteNonQueryAsync();
                       await sqlCon.CloseAsync();
                    }
                }



            }
            catch (Exception ex)
            {
                // Handle exception
            }

            return TestIndexId;
        }

        internal async Task UpdateClassTGTEnlishFinalTestDetails(string TestIndexId, List<TblTgtenglisgTestFinalDetail> LsClassTGTDetails)
        {

            try
            {
                if (LsClassTGTDetails.Count() > 0)
                {
                    List<string> TestIdList = new List<string>();

                    TestIdList = LsClassTGTDetails.Select(x => x.TestId.ToString()).ToList();
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                        await sqlCon.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("sp_UpdateClassTGTEnglishTestFinalDetais", sqlCon);
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

        internal async Task UpdatetblQuestionPeparEnglishClassTGTDetails(int PrimaryId, QuestionPepar10ViewModel QuestionDetails)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("UpdateQuestionPaperEnglishClassTGTDetailsById", conn))
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

        internal async Task SavetblQuestionPeparEnglishClassPGTDetails(QuestionPepar10ViewModel QuestionDetails)
        {

            try
            {


                if (QuestionDetails != null)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("InsertQuestionPaperEnglishClassPGTDetails", conn);
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

        internal async Task UpdatetblQuestionPeparEnglishClassPGTDetails(int PrimaryId, QuestionPepar10ViewModel QuestionDetails)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("UpdateQuestionPaperEnglishClassPGTDetailsById", conn))
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

        internal async Task DeletetblQuestionPeparEnglishClassPGTDetails(int PrimaryId)
        {
            try
            {
                if (PrimaryId > 0)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("DeleteQuestionPaperEnglishClassPGTDetails", conn);
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

        internal async Task<List<TGTQuestionSetViewModel>> FillClassPGTQuestionSetDetailsBySubjectName(List<TGTQuestionSetViewModel> LsClassPGTDetails)
        {

            try
            {

                var Selectdata = $"Select * from Tbl_QuezIndexPGTDetails";

                SqlConnection connection = new SqlConnection(ConnectionString.Connection);
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(Selectdata, connection);


                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    TGTQuestionSetViewModel lsdata1 = new TGTQuestionSetViewModel();
                    lsdata1.QuestionSetName = reader["QuezName"].ToString();
                    lsdata1.id = Convert.ToInt32(reader["Id"]);

                    LsClassPGTDetails.Add(lsdata1);
                }
                await connection.CloseAsync();
            }
            catch (Exception ex)
            {


            }
            return LsClassPGTDetails;

        }

        internal async Task SavetblClassPGTEnglisgTestFinalDetails(TblPgtenglisgTestFinalDetail finalResute)
        {
            try
            {

                using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                {


                    await sqlCon.OpenAsync();
                    SqlCommand sql_cmnd = new SqlCommand("spTbl_PGTEnglishTestFinalDetails", sqlCon);
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
            catch(Exception ex)
            {

            }
        }

        internal async Task<List<TblClass9EnglisgTestFinalDetail>> GetClassPGTEnglishTest20Details(List<TblClass9EnglisgTestFinalDetail> LsClassPGTEnglisgTestFinalDetails)
        {
            try
            {
                string SelectQuery = "SELECT TOP (20) * FROM Tbl_PGTENglisgTestFinalDetails ORDER BY DatetimeStamp DESC";
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                {
                    await sqlCon.OpenAsync();
                    SqlCommand sql_cmnd = new SqlCommand(SelectQuery, sqlCon);
                    sql_cmnd.CommandType = CommandType.Text;

                    using (SqlDataReader reader = await sql_cmnd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            TblClass9EnglisgTestFinalDetail ClassPGTEnglishTestDetails = new TblClass9EnglisgTestFinalDetail
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
                            LsClassPGTEnglisgTestFinalDetails.Add(ClassPGTEnglishTestDetails);
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return LsClassPGTEnglisgTestFinalDetails;
        }

        internal async Task<string> SaveTestSeriesClassPGTDetails(Test10DetailsViewModel ClassPGTTestSeriesDetails)
        {
            string TestIndexId = "";
            try
            {
                if (ClassPGTTestSeriesDetails != null)
                {
                    TestIndexId = Guid.NewGuid().ToString();
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                        sqlCon.Open();
                        SqlCommand sql_cmnd = new SqlCommand("sp_SaveTestSiriseClassPGTDetails", sqlCon);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;

                        sql_cmnd.Parameters.AddWithValue("@TestIndexId", TestIndexId);
                        sql_cmnd.Parameters.AddWithValue("@TestSerisId", ClassPGTTestSeriesDetails.TestId);
                        sql_cmnd.Parameters.AddWithValue("@TestName", ClassPGTTestSeriesDetails.QuizName);
                        sql_cmnd.Parameters.AddWithValue("@QuestionConnectionId", ClassPGTTestSeriesDetails.ConnectionQuestion);
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

        internal async Task UpdateClassPGTEnlishFinalTestDetails(string TestIndexId, List<TblClass9EnglisgTestFinalDetail> LsClassPGTEnglisgTestFinalDetails)
        {
            try
            {
                if (LsClassPGTEnglisgTestFinalDetails.Count() > 0)
                {
                    List<string> TestIdList = new List<string>();

                    TestIdList = LsClassPGTEnglisgTestFinalDetails.Select(x => x.TestId.ToString()).ToList();
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                        await sqlCon.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("sp_UpdateClassPGTEnglishTestFinalDetais", sqlCon);
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

        internal async Task<List<TblQuestionPeparEnglishPgtdetail>> GetClassPGTQuestionDetailsByConnectedQuestion(int ConnectedQuestion)
        {
            List<TblQuestionPeparEnglishPgtdetail> LsClassPGTDetails = new List<TblQuestionPeparEnglishPgtdetail>();
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
                                        TblQuestionPeparEnglishPgtdetail ClassPGTPaperModel = new TblQuestionPeparEnglishPgtdetail();
                                        ClassPGTPaperModel.QuezIndexId = _CommonFunction.MapIntegerValue(Reader["QuezIndexId"], defaultValue: 0);
                                        ClassPGTPaperModel.Id = _CommonFunction.MapIntegerValue(Reader["Id"], defaultValue: 0);
                                        ClassPGTPaperModel.AnswerA = Reader["AnswerA"].ToString() ?? "";
                                        ClassPGTPaperModel.AnswerB = Reader["AnswerB"].ToString() ?? "";
                                        ClassPGTPaperModel.AnswerC = Reader["AnswerC"].ToString() ?? "";
                                        ClassPGTPaperModel.AnswerD = Reader["AnswerD"].ToString() ?? "";
                                        ClassPGTPaperModel.CurrectAnswer = Reader["CurrectAnswer"].ToString() ?? "";
                                        ClassPGTPaperModel.QuestionNo = Reader["QuestionNo"].ToString() ?? "";
                                        ClassPGTPaperModel.Remark = Reader["Remark"].ToString() ?? "";
                                        ClassPGTPaperModel.QuezName = Reader["QuezName"].ToString() ?? "";
                                        ClassPGTPaperModel.ConnectedQuestion = _CommonFunction.MapIntegerValue(Reader["ConnectedQuestion"], defaultValue: 0);
                                        LsClassPGTDetails.Add(ClassPGTPaperModel);

                                    }
                                }
                                return LsClassPGTDetails;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return LsClassPGTDetails;
        }

        internal async Task<List<ResultDetailsViewModel>> GetClassPGTEnglishTestFinalResultDetails(List<ResultDetailsViewModel> LsClassPGTEnglishTestResult, string id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString: ConnectionString.Connection))
                {
                    using (SqlCommand cmd = new SqlCommand("GetClassPGTTestSeriesDetails", conn))
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

                                LsClassPGTEnglishTestResult.Add(lsadata);
                            }
                        }
                    }
                    await conn.CloseAsync();
                }
            }
            catch (Exception ex)
            {

            }
            return LsClassPGTEnglishTestResult;
        }

        internal async Task<List<TGTPGTLTViewModel>> FillClassLTQuizDetails(List<TGTPGTLTViewModel> LsLTQuizDetails)
        {

            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString.Connection);

                SqlCommand command = new SqlCommand("SelectTblQuizeIndexLTdetails", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    TGTPGTLTViewModel lsdata = new TGTPGTLTViewModel();
                    lsdata.Id = Convert.ToInt32(reader["Id"]);
                    lsdata.QuezName = reader["QuezName"].ToString();
                    lsdata.ClassName = reader["ClassName"].ToString();
                    lsdata.SubjectName = reader["SubjectName"].ToString();
                    lsdata.Remark = reader["Remark"].ToString();
                    LsLTQuizDetails.Add(lsdata);
                }
               await connection.CloseAsync();
            }
            catch (Exception ex)
            {

            }

           return LsLTQuizDetails;
        }

        internal async Task<bool> InsertLTQuizDetails(TGTPGTLTViewModel ClassLTDetails)
        {
            try
            {
                if (ClassLTDetails != null)
                {
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                        await sqlCon.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("InserTblquizeIndeLTDetails", sqlCon);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;

                        sql_cmnd.Parameters.AddWithValue("@QuezName", ClassLTDetails.QuezName);
                        sql_cmnd.Parameters.AddWithValue("@ClassName", ClassLTDetails.ClassName);
                        sql_cmnd.Parameters.AddWithValue("@SubjectName", ClassLTDetails.SubjectName);
                        sql_cmnd.Parameters.AddWithValue("@Remark", ClassLTDetails.Remark);
                        //sql_cmnd.Parameters.AddWithValue("@Remark1", data.Remark1);
                        sql_cmnd.Parameters.AddWithValue("@Remark2", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark3", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark4", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark5", "");
                        sql_cmnd.Parameters.AddWithValue("@DatetimeStamp", DateTime.Now);

                        await sql_cmnd.ExecuteNonQueryAsync();
                        await sqlCon.CloseAsync();

                        return true;
                    }
                }

            }
            catch (Exception ex)
            {


            }
            return false;
        }

        internal async Task FillQuestionPaperClaassLTDetails(QuestionPepar10ViewModel ClassLTPaperDetails, int PrimaryId)
        {
            try
            {
                if (PrimaryId > 0)
                {

                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("GetQuestionPaperClassLTDetailsById", conn);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@PrimaryId", PrimaryId);
                        SqlDataReader reader = await sql_cmnd.ExecuteReaderAsync();
                        if (reader.HasRows)
                        {
                            while (await reader.ReadAsync())
                            {
                                ClassLTPaperDetails.Id = _CommonFunction.MapIntegerValue(reader["Id"]);
                                ClassLTPaperDetails.QuestionNo = reader["QuestionNo"].ToString();
                                ClassLTPaperDetails.AnswerA = reader["AnswerA"].ToString();
                                ClassLTPaperDetails.AnswerB = reader["AnswerB"].ToString();
                                ClassLTPaperDetails.CurrectAnswer = reader["CurrectAnswer"].ToString();
                                ClassLTPaperDetails.AnswerD = reader["AnswerD"].ToString();
                                ClassLTPaperDetails.AnswerC = reader["AnswerC"].ToString();
                                ClassLTPaperDetails.ConnectedQuestion = _CommonFunction.MapIntegerValue(reader["ConnectedQuestion"], defaultValue: 0);
                                ClassLTPaperDetails.PrimaryId = _CommonFunction.MapIntegerValue(reader["Id"], defaultValue: 0);
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

        internal async Task<List<QuestionPepar10ViewModel>> FillQuestionpaperClassLTDetailsById(List<QuestionPepar10ViewModel> LsQuestionDetais, int Id)
        {
            try
            {
                if (Id > 0)
                {

                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("GetQuestionPaperClassLTDetailsByConnectedQuestion", conn);
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

        internal async Task SavetblQuestionPeparEnglishClassLTDetails(QuestionPepar10ViewModel QuestionDetails)
        {
            try
            {


                if (QuestionDetails != null)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("InsertQuestionPaperEnglishClassLTDetails", conn);
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

        internal async Task UpdatetblQuestionPeparEnglishClassLTDetails(int PrimaryId, QuestionPepar10ViewModel QuestionDetails)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("UpdateQuestionPaperEnglishClassLTDetailsById", conn))
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

        internal async Task DeletetblQuestionPeparEnglishClassLTDetails(int PrimaryId)
        {
            try
            {
                if (PrimaryId > 0)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("DeleteQuestionPaperEnglishClassLTDetails", conn);
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

        internal async Task<List<TGTQuestionSetViewModel>> FillClassLTQuestionSetDetails(List<TGTQuestionSetViewModel> LsClassLtDetails)
        {
            try
            {

                var Selectdata = $"Select * from Tbl_QuezIndexLTDetails";

                SqlConnection connection = new SqlConnection(ConnectionString.Connection);
                connection.Open();
                SqlCommand command = new SqlCommand(Selectdata, connection);

                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TGTQuestionSetViewModel lsdata1 = new TGTQuestionSetViewModel();
                    lsdata1.QuestionSetName = reader["QuezName"].ToString();
                    lsdata1.id = Convert.ToInt32(reader["Id"]);

                    LsClassLtDetails.Add(lsdata1);
                }
                connection.Close();
            }
            catch (Exception ex)
            {


            }

            return LsClassLtDetails;
        }

        internal async Task SavetblClassLTEnglisgTestFinalDetails(TblTgtenglisgTestFinalDetail finalResute)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
            {

                await sqlCon.OpenAsync();
                SqlCommand sql_cmnd = new SqlCommand("spTbl_LTEnglishTestFinalDetails", sqlCon);
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

        internal async Task<List<TblLtenglisgTestFinalDetail>> GetClassLTEnglishTest20Details(List<TblLtenglisgTestFinalDetail> LsClassLTEnglisgTestFinalDetails)
        {
            try
            {
                string SelectQuery = "SELECT TOP (20) * FROM Tbl_LTEnglisgTestFinalDetails ORDER BY DatetimeStamp DESC";
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                {
                    await sqlCon.OpenAsync();
                    SqlCommand sql_cmnd = new SqlCommand(SelectQuery, sqlCon);
                    sql_cmnd.CommandType = CommandType.Text;

                    using (SqlDataReader reader = await sql_cmnd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            TblLtenglisgTestFinalDetail Class9EnglishTestDetails = new TblLtenglisgTestFinalDetail
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
                            LsClassLTEnglisgTestFinalDetails.Add(Class9EnglishTestDetails);
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return LsClassLTEnglisgTestFinalDetails;
        }

        internal async Task<string> SaveTestSeriesClassLTDetails(Test10DetailsViewModel Class9TestSeriesDetails)
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
                        SqlCommand sql_cmnd = new SqlCommand("sp_SaveTestSiriseClassLTDetails", sqlCon);
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

        internal async Task UpdateClassLTEnlishFinalTestDetails(string TestIndexId, List<TblLtenglisgTestFinalDetail> LsClassLTEnglisgTestFinalDetails)
        {
            try
            {
                if (LsClassLTEnglisgTestFinalDetails.Count() > 0)
                {
                    List<string> TestIdList = new List<string>();

                    TestIdList = LsClassLTEnglisgTestFinalDetails.Select(x => x.TestId.ToString()).ToList();
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                        await sqlCon.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("sp_UpdateClassLTEnglishTestFinalDetais", sqlCon);
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

        internal async Task<List<TblQuestionPeparEnglishLtdetail>> GetClassLTQuestionDetailsByConnectedQuestion(int ConnectedQuestion)
        {
            List<TblQuestionPeparEnglishLtdetail> LsClassLTDetails = new List<TblQuestionPeparEnglishLtdetail>();
            try
            {
                if (ConnectedQuestion > 0)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString: ConnectionString.Connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_GetClassLTEnglishQuestionsDetails", conn))
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
                                        TblQuestionPeparEnglishLtdetail ClassLTPaperModel = new TblQuestionPeparEnglishLtdetail();
                                        ClassLTPaperModel.QuezIndexId = _CommonFunction.MapIntegerValue(Reader["QuezIndexId"], defaultValue: 0);
                                        ClassLTPaperModel.Id = _CommonFunction.MapIntegerValue(Reader["Id"], defaultValue: 0);
                                        ClassLTPaperModel.AnswerA = Reader["AnswerA"].ToString() ?? "";
                                        ClassLTPaperModel.AnswerB = Reader["AnswerB"].ToString() ?? "";
                                        ClassLTPaperModel.AnswerC = Reader["AnswerC"].ToString() ?? "";
                                        ClassLTPaperModel.AnswerD = Reader["AnswerD"].ToString() ?? "";
                                        ClassLTPaperModel.CurrectAnswer = Reader["CurrectAnswer"].ToString() ?? "";
                                        ClassLTPaperModel.QuestionNo = Reader["QuestionNo"].ToString() ?? "";
                                        ClassLTPaperModel.Remark = Reader["Remark"].ToString() ?? "";
                                        ClassLTPaperModel.QuezName = Reader["QuezName"].ToString() ?? "";
                                        ClassLTPaperModel.ConnectedQuestion = _CommonFunction.MapIntegerValue(Reader["ConnectedQuestion"], defaultValue: 0);
                                        LsClassLTDetails.Add(ClassLTPaperModel);

                                    }
                                }
                                return LsClassLTDetails;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return LsClassLTDetails;
        }

        internal async Task<List<ResultDetailsViewModel>> GetClassLTEnglishTestFinalResultDetails(List<ResultDetailsViewModel> LsClassLTEnglishTestResult, string id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString: ConnectionString.Connection))
                {
                    using (SqlCommand cmd = new SqlCommand("GetClassLTTestSeriesDetails", conn))
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

                                LsClassLTEnglishTestResult.Add(lsadata);
                            }
                        }
                    }
                    await conn.CloseAsync();
                }
            }
            catch (Exception ex)
            {

            }
            return LsClassLTEnglishTestResult;
        }

        internal async Task<bool> UpdateTGTQuizDetails(TGTPGTLTViewModel data)
        {
            try
            {
                if (data != null)
                {
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                        sqlCon.Open();
                        SqlCommand sql_cmnd = new SqlCommand("UpdateTblquizeIndeTGTDetails", sqlCon);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;

                        sql_cmnd.Parameters.AddWithValue("@Id", data.Id);
                        sql_cmnd.Parameters.AddWithValue("@QuezName", data.QuezName);
                        sql_cmnd.Parameters.AddWithValue("@ClassName", data.ClassName);
                        sql_cmnd.Parameters.AddWithValue("@SubjectName", data.SubjectName);
                        sql_cmnd.Parameters.AddWithValue("@Remark", data.Remark);

                        sql_cmnd.Parameters.AddWithValue("@Remark2", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark3", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark4", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark5", "");

                        sql_cmnd.ExecuteNonQuery();
                        sqlCon.Close();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
            }
            return false;
        }

        internal async Task<TGTPGTLTViewModel> FillClassTGTLQuizDetailsUsingId(int TGTId)
        {
            TGTPGTLTViewModel lsdata = new TGTPGTLTViewModel();
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString.Connection);

                SqlCommand command = new SqlCommand("SelectTblQuizeIndeTGTdetails", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", TGTId);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                 
                    lsdata.Id = Convert.ToInt32(reader["Id"]);
                    lsdata.QuezName = reader["QuezName"].ToString();
                    lsdata.ClassName = reader["ClassName"].ToString();
                    lsdata.SubjectName = reader["SubjectName"].ToString();
                    lsdata.Remark = reader["Remark"].ToString();
                 
                }
                connection.Close();
            }
            catch (Exception ex)
            {

            }

            return lsdata;
        }

        internal async Task<bool> DeleteTGTDetails(int? TGTId)
        {
            try
            {
                if (TGTId > 0)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("DeleteQuezeIndexTGTDetails", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Id", TGTId);

                            await conn.OpenAsync();
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        internal async Task<TGTPGTLTViewModel> FillClassPGTLQuizDetailsUsingId(int PGTId)
        {
            TGTPGTLTViewModel lsdata = new TGTPGTLTViewModel();
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString.Connection);

                SqlCommand command = new SqlCommand("SelectTblQuizeIndexPGTdetails", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", PGTId);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    lsdata.Id = Convert.ToInt32(reader["Id"]);
                    lsdata.QuezName = reader["QuezName"].ToString();
                    lsdata.ClassName = reader["ClassName"].ToString();
                    lsdata.SubjectName = reader["SubjectName"].ToString();
                    lsdata.Remark = reader["Remark"].ToString();

                }
                connection.Close();
            }
            catch (Exception ex)
            {

            }

            return lsdata;
        }

        internal async Task<bool> DeletePGTIdDetails(int? PGTId)
        {
            try
            {
                if (PGTId > 0)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("DeleteQuezeIndexPGTDetails", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Id", PGTId);

                            await conn.OpenAsync();
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        internal async Task<bool> UpdatePGTQuizDetails(TGTPGTLTViewModel data)
        {
            try
            {
                if (data != null)
                {
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                        sqlCon.Open();
                        SqlCommand sql_cmnd = new SqlCommand("UpdateTblquizeIndePGTDetails", sqlCon);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;

                        sql_cmnd.Parameters.AddWithValue("@Id", data.Id);
                        sql_cmnd.Parameters.AddWithValue("@QuezName", data.QuezName);
                        sql_cmnd.Parameters.AddWithValue("@ClassName", data.ClassName);
                        sql_cmnd.Parameters.AddWithValue("@SubjectName", data.SubjectName);
                        sql_cmnd.Parameters.AddWithValue("@Remark", data.Remark);

                        sql_cmnd.Parameters.AddWithValue("@Remark2", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark3", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark4", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark5", "");

                        sql_cmnd.ExecuteNonQuery();
                        sqlCon.Close();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
            }
            return false;
        }

        internal async Task<bool> UpdateLTQuizDetails(TGTPGTLTViewModel data)
        {
            try
            {
                if (data != null)
                {
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                        sqlCon.Open();
                        SqlCommand sql_cmnd = new SqlCommand("UpdateTblquizeIndeLTDetails", sqlCon);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;

                        sql_cmnd.Parameters.AddWithValue("@Id", data.Id);
                        sql_cmnd.Parameters.AddWithValue("@QuezName", data.QuezName);
                        sql_cmnd.Parameters.AddWithValue("@ClassName", data.ClassName);
                        sql_cmnd.Parameters.AddWithValue("@SubjectName", data.SubjectName);
                        sql_cmnd.Parameters.AddWithValue("@Remark", data.Remark);

                        sql_cmnd.Parameters.AddWithValue("@Remark2", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark3", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark4", "");
                        sql_cmnd.Parameters.AddWithValue("@Remark5", "");

                        sql_cmnd.ExecuteNonQuery();
                        sqlCon.Close();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
            }
            return false;
        }

        internal async Task<TGTPGTLTViewModel> FillClassLTEnglishQuizDetailsUsingId(int LTId)
        {
            TGTPGTLTViewModel lsdata = new TGTPGTLTViewModel();
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString.Connection);

                SqlCommand command = new SqlCommand("[SelectTblQuizeIndexLTdetails]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", LTId);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    lsdata.Id = Convert.ToInt32(reader["Id"]);
                    lsdata.QuezName = reader["QuezName"].ToString();
                    lsdata.ClassName = reader["ClassName"].ToString();
                    lsdata.SubjectName = reader["SubjectName"].ToString();
                    lsdata.Remark = reader["Remark"].ToString();

                }
                connection.Close();
            }
            catch (Exception ex)
            {

            }

            return lsdata;
        }

        internal async Task<bool> DeleteLTIdDetails(int? LTId)
        {
            try
            {
                if (LTId > 0)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("DeleteQuezeIndexLTDetails", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Id", LTId);

                            await conn.OpenAsync();
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }
    }
}
