using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using quezemasterNew.CommonFunctional;
using quezemasterNew.Models;
using quezemasterNew.Models.Class9;
using quezemasterNew.Models.ViewModel;
using quezemasterNew.Models.ViewModel.Test;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace quezemasterNew.BussinesLogic
{
    public class BPSCEnglishPageHelper
    {
        CommonFunctions _CommonFunction = new CommonFunctions();

        internal async Task<List<QuestionPepar10ViewModel>> FillQnPaperEngClassBPSCDetailsByConnectedQuestion(int ConnectedQuestion)
        {
            List<QuestionPepar10ViewModel> LsQuestionDetails = new List<QuestionPepar10ViewModel>();
            try
            {
                if (ConnectedQuestion > 0)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString: ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        using (SqlCommand cmd = new SqlCommand("SP_GetClassBPSCEnglishByConnectedQuestion", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ConnectedQuestion", ConnectedQuestion);
                            using (SqlDataReader Reader = await cmd.ExecuteReaderAsync())
                            {
                                if (Reader != null)
                                {
                                    while (await Reader.ReadAsync())
                                    {
                                        QuestionPepar10ViewModel BPSCPaperModel = new QuestionPepar10ViewModel();
                                        BPSCPaperModel.Id = _CommonFunction.MapIntegerValue(Reader["Id"], defaultValue: 0);
                                        BPSCPaperModel.AnswerC = Reader["AnswerC"].ToString() ?? "";
                                        BPSCPaperModel.AnswerD = Reader["AnswerD"].ToString() ?? "";
                                        BPSCPaperModel.AnswerA = Reader["AnswerA"].ToString() ?? "";
                                        BPSCPaperModel.AnswerB = Reader["AnswerB"].ToString() ?? "";
                                        BPSCPaperModel.AnswerE = Reader["AnswerE"].ToString() ?? "";
                                        BPSCPaperModel.CurrectAnswer = Reader["CurrectAnswer"].ToString() ?? "";
                                        BPSCPaperModel.QuestionNo = Reader["QuestionNo"].ToString() ?? "";
                                        BPSCPaperModel.ConnectedQuestion = _CommonFunction.MapIntegerValue(Reader["ConnectedQuestion"], defaultValue: 0);
                                        LsQuestionDetails.Add(BPSCPaperModel);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
            }
            return LsQuestionDetails;
        }
        internal async Task FillQuestionPaperEnglishClassBPSCDetails(QuestionPepar10ViewModel BPSCDetails, int PrimaryId)
        {
            try
            {
                if (PrimaryId > 0)
                {

                    using (SqlConnection conn = new SqlConnection(connectionString: ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        using (SqlCommand cmd = new SqlCommand("SP_GetClassBPSCEnglishByPrimaryId", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@TblPrimaryd", PrimaryId);
                            using (SqlDataReader SqlReader = await cmd.ExecuteReaderAsync())
                            {
                                if (SqlReader != null)
                                {
                                    while (await SqlReader.ReadAsync())
                                    {
                                        BPSCDetails.QuestionNo = SqlReader["QuestionNo"].ToString() ?? "";
                                        BPSCDetails.AnswerA = SqlReader["AnswerA"].ToString() ?? "";
                                        BPSCDetails.AnswerB = SqlReader["AnswerB"].ToString() ?? "";
                                        BPSCDetails.CurrectAnswer = SqlReader["CurrectAnswer"].ToString() ?? "";
                                        BPSCDetails.AnswerD = SqlReader["AnswerD"].ToString() ?? "";
                                        BPSCDetails.AnswerC = SqlReader["AnswerC"].ToString() ?? "";
                                        BPSCDetails.AnswerE = SqlReader["AnswerE"].ToString() ?? "";
                                        BPSCDetails.ConnectedQuestion = _CommonFunction.MapIntegerValue(SqlReader["ConnectedQuestion"], defaultValue: 0);
                                        BPSCDetails.PrimaryId = _CommonFunction.MapIntegerValue(SqlReader["Id"], defaultValue: 0);
                                    }
                                }
                            }

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                // Handle exception
            }

        }

        internal async Task<List<Class9ViewModel>> GetBPSCSaveDetails(List<Class9ViewModel> LsCass9Records, string SubjectName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString: ConnectionString.Connection))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SP_GetQuizIndexDetailsBySubject", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SubjectName", SubjectName);
                        using (SqlDataReader SqlReader = await cmd.ExecuteReaderAsync())
                        {
                            if (SqlReader != null)
                            {
                                while (await SqlReader.ReadAsync())
                                {
                                    Class9ViewModel lsdata = new Class9ViewModel();
                                    lsdata.Id = Convert.ToInt32(SqlReader["Id"]);
                                    lsdata.QuezName = SqlReader["QuezName"].ToString();
                                    lsdata.ClassName = SqlReader["ClassName"].ToString();
                                    lsdata.SubjectName = SqlReader["SubjectName"].ToString();
                                    lsdata.Remark = SqlReader["Remark"].ToString();
                                    LsCass9Records.Add(lsdata);
                                }
                            }
                        }


                    }
                    await conn.CloseAsync();
                }
            }
            catch (Exception ex)
            {

            }
            return LsCass9Records;
        }




        internal async Task SaveBPSCRecords(Class9ViewModel BPSCData)
        {
            try
            {
                if (BPSCData != null)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {

                        await conn.OpenAsync();
                        using (SqlCommand sql_cmnd = new SqlCommand("InserTblquizeIndeClassBPSCDetails", conn))
                        {

                            sql_cmnd.CommandType = CommandType.StoredProcedure;

                            sql_cmnd.Parameters.AddWithValue("@QuezName", BPSCData.QuezName);
                            sql_cmnd.Parameters.AddWithValue("@ClassName", BPSCData.ClassName);
                            sql_cmnd.Parameters.AddWithValue("@SubjectName", BPSCData.SubjectName);
                            sql_cmnd.Parameters.AddWithValue("@Remark", BPSCData.Remark);
                            //sql_cmnd.Parameters.AddWithValue("@Remark1", data.Remark1);
                            sql_cmnd.Parameters.AddWithValue("@Remark2", "");
                            sql_cmnd.Parameters.AddWithValue("@Remark3", "");
                            sql_cmnd.Parameters.AddWithValue("@Remark4", "");
                            sql_cmnd.Parameters.AddWithValue("@Remark5", "");
                            sql_cmnd.Parameters.AddWithValue("@DatetimeStamp", DateTime.Now);

                            await sql_cmnd.ExecuteNonQueryAsync();
                        }
                        await conn.CloseAsync();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        internal async Task SaveBPSCClassEnglishQuestionPaper(QuestionPepar10ViewModel QuestionPaperData)
        {
            try
            {
                if (QuestionPaperData != null)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {

                        using (SqlCommand cmd = new SqlCommand("SaveQuestionPeparEnglishClassBPSCDetail", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@QuestionNo", QuestionPaperData.QuestionNo);
                            cmd.Parameters.AddWithValue("@AnswerA", QuestionPaperData.AnswerA);
                            cmd.Parameters.AddWithValue("@AnswerB", QuestionPaperData.AnswerB);
                            cmd.Parameters.AddWithValue("@AnswerC", QuestionPaperData.AnswerC);
                            cmd.Parameters.AddWithValue("@AnswerD", QuestionPaperData.AnswerD);
                            cmd.Parameters.AddWithValue("@AnswerE", QuestionPaperData.AnswerE);
                            cmd.Parameters.AddWithValue("@CurrectAnswer", QuestionPaperData.CurrectAnswer);
                            cmd.Parameters.AddWithValue("@Remark", QuestionPaperData.Remark);
                            cmd.Parameters.AddWithValue("@Remark1", QuestionPaperData.Remark1);
                            cmd.Parameters.AddWithValue("@Remark2", QuestionPaperData.Remark2);
                            cmd.Parameters.AddWithValue("@Remark3", QuestionPaperData.Remark3);
                            cmd.Parameters.AddWithValue("@Remark4", QuestionPaperData.Remark4);
                            cmd.Parameters.AddWithValue("@Remark5", QuestionPaperData.Remark5);
                            cmd.Parameters.AddWithValue("@ConnectedQuestion", QuestionPaperData.ConnectedQuestion);
                            cmd.Parameters.AddWithValue("@DatetimeStamp", DateTime.Now);
                            await conn.OpenAsync();
                            await cmd.ExecuteNonQueryAsync();
                            await conn.CloseAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        internal async Task UpdateBPSCClassEnglishQuestionPaperDetails(QuestionPepar10ViewModel data)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateQuestionPeparEnglishClassBPSCDetail", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", data.PrimaryId);
                        cmd.Parameters.AddWithValue("@QuestionNo", data.QuestionNo);
                        cmd.Parameters.AddWithValue("@AnswerA", data.AnswerA);
                        cmd.Parameters.AddWithValue("@AnswerB", data.AnswerB);
                        cmd.Parameters.AddWithValue("@AnswerC", data.AnswerC);
                        cmd.Parameters.AddWithValue("@AnswerD", data.AnswerD);
                        cmd.Parameters.AddWithValue("@AnswerE", data.AnswerE);
                        cmd.Parameters.AddWithValue("@CurrectAnswer", data.CurrectAnswer);
                        cmd.Parameters.AddWithValue("@Remark", data.Remark);
                        cmd.Parameters.AddWithValue("@Remark1", data.Remark1);
                        cmd.Parameters.AddWithValue("@Remark2", data.Remark2);
                        cmd.Parameters.AddWithValue("@Remark3", data.Remark3);
                        cmd.Parameters.AddWithValue("@Remark4", data.Remark4);
                        cmd.Parameters.AddWithValue("@Remark5", data.Remark5);
                        cmd.Parameters.AddWithValue("@ConnectedQuestion", data.ConnectedQuestion);
                        cmd.Parameters.AddWithValue("@DatetimeStamp", DateTime.Now);
                        await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                        await conn.CloseAsync();

                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
            }
        }




        internal async Task DeleteTblQuestionPaperBPSCDetails(int PrimaryId)
        {
            try
            {
                if (PrimaryId != 0)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString: ConnectionString.Connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("DeleteTblQuestionPeparEnglishClassBpscdetails", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@PrimaryId", PrimaryId);
                            await conn.OpenAsync();

                            await cmd.ExecuteNonQueryAsync();
                            await conn.CloseAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        internal async Task<List<Class9QuestionSetViewModel>> GetOnlineTestDetails(List<Class9QuestionSetViewModel> LsOnlineTestRecords, string SubjectName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString: ConnectionString.Connection))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SP_GetQuizIndexDetailsBySubject", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SubjectName", SubjectName);
                        using (SqlDataReader SqlReader = await cmd.ExecuteReaderAsync())
                        {
                            if (SqlReader != null)
                            {
                                while (await SqlReader.ReadAsync())
                                {
                                    Class9QuestionSetViewModel lsdata = new Class9QuestionSetViewModel();
                                    lsdata.QuestionSetName = SqlReader["QuezName"].ToString() ?? "";
                                    lsdata.id = _CommonFunction.MapIntegerValue(SqlReader["Id"], defaultValue: 0);
                                    LsOnlineTestRecords.Add(lsdata);
                                }
                            }
                        }


                    }
                    await conn.CloseAsync();
                }
            }
            catch (Exception ex)
            {

            }
            return LsOnlineTestRecords;
        }

        internal async Task<List<ResultDetailsViewModel>> FillBPSCTestSeriesDetails(string TestIndexId, List<ResultDetailsViewModel> LsBPSCTestSeriesResult)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString: ConnectionString.Connection))
                {
                    using (SqlCommand cmd = new SqlCommand("GetBPSCTestSeriesDetails", conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TestIndexId", TestIndexId);
                        await conn.OpenAsync();
                        using (SqlDataReader Reader = await cmd.ExecuteReaderAsync())
                        {

                            if (Reader != null)
                            {
                                int i = 1;
                                while (await Reader.ReadAsync())
                                {
                                    ResultDetailsViewModel TestSeriesDetails = new ResultDetailsViewModel();
                                    TestSeriesDetails.SRNumber = i;
                                    TestSeriesDetails.Question = Reader["QuestionNo"].ToString() ?? "";
                                    TestSeriesDetails.AnsswerA = Reader["AnswerA"].ToString() ?? "";
                                    TestSeriesDetails.AnsswerB = Reader["AnswerB"].ToString() ?? "";
                                    TestSeriesDetails.AnsswerC = Reader["AnswerC"].ToString() ?? "";
                                    TestSeriesDetails.AnsswerD = Reader["AnswerD"].ToString() ?? "";
                                    TestSeriesDetails.AnsswerE = Reader["AnswerE"].ToString() ?? "";
                                    TestSeriesDetails.CurrectAnsawer = Reader["CurrectAnswer"].ToString() ?? "";
                                    TestSeriesDetails.TotalCurrectAnswer = _CommonFunction.MapIntegerValue(Reader["TotalCorrectAnswers"], defaultValue: 0);
                                    i++;
                                    LsBPSCTestSeriesResult.Add(TestSeriesDetails);
                                }
                            }
                        }
                    }
                    await conn.CloseAsync();
                }
            }
            catch (Exception ex)
            {

            }
            return LsBPSCTestSeriesResult;
        }

        internal async Task SaveGKEnglishTestFinalDetails(TblClassGkenglisgTestFinalDetail GKTestDetails)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                {

                    sqlCon.Open();
                    SqlCommand sql_cmnd = new SqlCommand("spTbl_ClassBPSCEnglishTestFinalDetails", sqlCon);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;

                    sql_cmnd.Parameters.AddWithValue("@QuestionNo", GKTestDetails.QuestionNo);
                    sql_cmnd.Parameters.AddWithValue("@AnswerA", GKTestDetails.AnswerA);
                    sql_cmnd.Parameters.AddWithValue("@AnswerB", GKTestDetails.AnswerB);
                    sql_cmnd.Parameters.AddWithValue("@AnswerC", GKTestDetails.AnswerC);
                    sql_cmnd.Parameters.AddWithValue("@AnswerD", GKTestDetails.AnswerD);
                    sql_cmnd.Parameters.AddWithValue("@AnswerE", GKTestDetails.AnswerE);
                    sql_cmnd.Parameters.AddWithValue("@CurrectAnswer", GKTestDetails.CurrectAnswer);
                    sql_cmnd.Parameters.AddWithValue("@ConnectedQuestion", GKTestDetails.ConnectedQuestion);
                    sql_cmnd.Parameters.AddWithValue("@TestQuestionId", GKTestDetails.TestQuestionId);
                    sql_cmnd.Parameters.AddWithValue("@CurrentUser", GKTestDetails.CurrentUser);
                    sql_cmnd.Parameters.AddWithValue("@Remark", GKTestDetails.Remark);
                    sql_cmnd.Parameters.AddWithValue("@Remark1", GKTestDetails.Remark1);
                    sql_cmnd.Parameters.AddWithValue("@Remark2", GKTestDetails.Remark2);
                    sql_cmnd.Parameters.AddWithValue("@Remark3", GKTestDetails.Remark3);
                    sql_cmnd.Parameters.AddWithValue("@Remark4", GKTestDetails.Remark4);
                    sql_cmnd.Parameters.AddWithValue("@DatetimeStamp", GKTestDetails.DatetimeStamp);
                    sql_cmnd.Parameters.AddWithValue("@TestSerise", GKTestDetails.TestSerise);

                    sql_cmnd.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
            catch (Exception ex)
            {
                // Handle exception
            }
        }

        internal async Task<List<TblClassBpscenglisgTestFinalDetail>> GetBPSCEnglishTestDetails()
        {
            List<TblClassBpscenglisgTestFinalDetail> LsBPSCEnglishTestDetails = new List<TblClassBpscenglisgTestFinalDetail>();
            try
            {
                string SelectQuery = "SELECT TOP (20) * FROM [Tbl_ClassBPSCEnglisgTestFinalDetails] ORDER BY DatetimeStamp DESC";
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                {
                    await sqlCon.OpenAsync();
                    SqlCommand sql_cmnd = new SqlCommand(SelectQuery, sqlCon);
                    sql_cmnd.CommandType = CommandType.Text;
           
                    using (SqlDataReader reader = await sql_cmnd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            TblClassBpscenglisgTestFinalDetail BPSCEnglishTestDetails = new TblClassBpscenglisgTestFinalDetail
                            {
                                TestId = _CommonFunction.MapIntegerValue(reader["Id"], defaultValue: 0),
                                QuestionNo = reader["QuestionNo"].ToString() ?? "",
                                AnswerA = reader["AnswerA"].ToString() ?? "",
                                AnswerB = reader["AnswerB"].ToString() ?? "",
                                AnswerC = reader["AnswerC"].ToString() ?? "",
                                AnswerD = reader["AnswerD"].ToString() ?? "",
                                AnswerE = reader["AnswerE"].ToString() ?? "",
                                CurrectAnswer = reader["CurrectAnswer"].ToString() ?? "",
                                ConnectedQuestion = _CommonFunction.MapIntegerValue(reader["ConnectedQuestion"], defaultValue: 0),
                                TestQuestionId = _CommonFunction.MapIntegerValue(reader["TestQuestionId"], defaultValue: 0),
                                CurrentUser = reader["CurrentUser"].ToString() ?? "",
                                DatetimeStamp = _CommonFunction.MapDateTimeValue(reader["DatetimeStamp"],defaultValue: new DateTime(1900,01,01)),
                                TestSerise = reader["TestSerise"].ToString() ?? ""
                            };
                            LsBPSCEnglishTestDetails.Add(BPSCEnglishTestDetails);
                        }
                    }
                
                }
            }
            catch (Exception ex)
            {
                // Handle exception
            }
            return LsBPSCEnglishTestDetails;
        }




        internal async Task<string> SaveTestSeriesClassBPSCDetails(Test10DetailsViewModel TestSeriesDetails)
        {
            string TestIndexId = "";
            try
            { 
               if(TestSeriesDetails!=null)
                {
                    TestIndexId = Guid.NewGuid().ToString();
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                        sqlCon.Open();
                        SqlCommand sql_cmnd = new SqlCommand("sp_SaveTestSiriseClassBPSCDetails", sqlCon);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;

                        sql_cmnd.Parameters.AddWithValue("@TestIndexId", TestIndexId);
                        sql_cmnd.Parameters.AddWithValue("@TestSerisId", TestSeriesDetails.TestId);
                        sql_cmnd.Parameters.AddWithValue("@TestName", TestSeriesDetails.QuizName);
                        sql_cmnd.Parameters.AddWithValue("@QuestionConnectionId", TestSeriesDetails.ConnectionQuestion);
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

        internal async Task UpdateBPSCClassEnlishFinalTestDetails(string TestIndexId, List<TblClassBpscenglisgTestFinalDetail> LsTestDetails)
        {
            try
            {
                if (LsTestDetails.Count()>0)
                {
                     List<string> TestIdList= new List<string>();

                    TestIdList= LsTestDetails.Select(x => x.TestId.ToString()).ToList();
                    using (SqlConnection sqlCon = new SqlConnection(ConnectionString.Connection))
                    {

                        sqlCon.Open();
                        SqlCommand sql_cmnd = new SqlCommand("sp_UpdateBPSCEnglishTestFinalDetais", sqlCon);
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

        internal async Task<List<TblQuestionPeparEnglishClassBpscdetail>> GetBPSCQuestionDetailsByConnectedQuestion(int ConnectedQuestion)
        {
            List<TblQuestionPeparEnglishClassBpscdetail> LsBPSCDetails = new List<TblQuestionPeparEnglishClassBpscdetail>();
            try
            {
                if(ConnectedQuestion>0)
                {
                    using(SqlConnection conn  = new SqlConnection(connectionString: ConnectionString.Connection))
                    {
                        using(SqlCommand cmd = new SqlCommand("sp_GetBPSCEnglishQuestionsDetails", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@QuizId", ConnectedQuestion);
                            await conn.OpenAsync();
                            using(SqlDataReader Reader = await cmd.ExecuteReaderAsync())
                            {
                               
                                if (Reader != null)
                                {
                                    while (await Reader.ReadAsync())
                                    {
                                        TblQuestionPeparEnglishClassBpscdetail BPSCPaperModel = new TblQuestionPeparEnglishClassBpscdetail();
                                        BPSCPaperModel.QuezIndexId = _CommonFunction.MapIntegerValue(Reader["QuezIndexId"], defaultValue: 0);             
                                        BPSCPaperModel.Id = _CommonFunction.MapIntegerValue(Reader["Id"], defaultValue: 0);             
                                        BPSCPaperModel.AnswerA = Reader["AnswerA"].ToString() ?? "";
                                        BPSCPaperModel.AnswerB = Reader["AnswerB"].ToString() ?? "";
                                        BPSCPaperModel.AnswerC = Reader["AnswerC"].ToString() ?? "";
                                        BPSCPaperModel.AnswerD = Reader["AnswerD"].ToString() ?? "";
                                        BPSCPaperModel.AnswerE = Reader["AnswerE"].ToString() ?? "";
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
            catch(Exception ex)
            {

            }
            return LsBPSCDetails;
        }
    }
}
