
using Microsoft.Data.SqlClient;
using quezemasterNew.CommonFunctional;
using quezemasterNew.Models;
using quezemasterNew.Models.ViewModel;
using System.Collections.Generic;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace quezemasterNew.BussinesLogic
{
    public class QuestionPeparHelper
    {
        CommonFunctions _CommonFunction = new CommonFunctions();

        internal async Task DeletetblQuestionPeparEnglish20Details(int PrimaryId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                {
                    using (SqlCommand cmd = new SqlCommand("DeleteQuestionPeparEnglish20Details", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", PrimaryId);

                        await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"An error occurred while deleting question details: {ex.Message}");
            }
        }

        internal async Task FillQuestionPaperDetailsById(int PrimaryId, TblQuestionPeparEnglish20Detail QuestionPaperDetails)
        {
            try
            {
                if(PrimaryId > 0)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("GetQuestionPaperEnglish20DetailsById", conn);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@PrimaryId", PrimaryId);
                        SqlDataReader reader = await sql_cmnd.ExecuteReaderAsync();
                        if (reader.HasRows)
                        {
                            while (await reader.ReadAsync())
                            {
                                QuestionPaperDetails.Id = _CommonFunction.MapIntegerValue(reader["Id"]);
                                QuestionPaperDetails.QuestionNo = reader["QuestionNo"].ToString();
                                QuestionPaperDetails.AnswerA = reader["AnswerA"].ToString();
                                QuestionPaperDetails.AnswerB = reader["AnswerB"].ToString();
                                QuestionPaperDetails.CurrectAnswer = reader["CurrectAnswer"].ToString();
                                QuestionPaperDetails.AnswerD = reader["AnswerD"].ToString();
                                QuestionPaperDetails.AnswerC = reader["AnswerC"].ToString();
                                QuestionPaperDetails.ConnectedQuestion = _CommonFunction.MapIntegerValue(reader["ConnectedQuestion"], defaultValue: 0);
                            
                            }
                        }
                        await conn.CloseAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        internal async Task<List<TblQuestionPeparEnglish20Detail>> FillQuestionPaperDetilsByConnectedQuestionId(int PrimaryId)
        {
            List <TblQuestionPeparEnglish20Detail> LsQuestionPaperDetails = new List<TblQuestionPeparEnglish20Detail>();
            try
            {
                if (PrimaryId > 0)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        await conn.OpenAsync();
                        SqlCommand sql_cmnd = new SqlCommand("GetQustPaperEnglish20DetailsByConnectedQust", conn);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@ConnectedQuestion", PrimaryId);
                        SqlDataReader reader = await sql_cmnd.ExecuteReaderAsync();
                        if (reader.HasRows)
                        {
                            while (await reader.ReadAsync())
                            {
                                TblQuestionPeparEnglish20Detail QuestionPaperDetails = new TblQuestionPeparEnglish20Detail();
                                QuestionPaperDetails.Id = _CommonFunction.MapIntegerValue(reader["Id"]);
                                QuestionPaperDetails.QuestionNo = reader["QuestionNo"].ToString();
                                QuestionPaperDetails.AnswerA = reader["AnswerA"].ToString();
                                QuestionPaperDetails.AnswerB = reader["AnswerB"].ToString();
                                QuestionPaperDetails.CurrectAnswer = reader["CurrectAnswer"].ToString();
                                QuestionPaperDetails.AnswerD = reader["AnswerD"].ToString();
                                QuestionPaperDetails.AnswerC = reader["AnswerC"].ToString();
                                QuestionPaperDetails.ConnectedQuestion = _CommonFunction.MapIntegerValue(reader["ConnectedQuestion"], defaultValue: 0);
                                LsQuestionPaperDetails.Add(QuestionPaperDetails);
                            }
                        }
                        await conn.CloseAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return LsQuestionPaperDetails;
        }

        internal async Task SaveTblQuestionPeparEnglish20Detail(QuestionPepar10ViewModel QuestionDetails)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                {
                    using (SqlCommand cmd = new SqlCommand("InsertQuestionPeparEnglish20Details", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@QuestionNo", QuestionDetails.QuestionNo ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@AnswerA", QuestionDetails.AnswerA ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@AnswerB", QuestionDetails.AnswerB ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@AnswerC", QuestionDetails.AnswerC ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@AnswerD", QuestionDetails.AnswerD ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@CurrectAnswer", QuestionDetails.CurrectAnswer ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Remark", QuestionDetails.Remark ?? "");
                        cmd.Parameters.AddWithValue("@Remark1", QuestionDetails.Remark1 ?? "");
                        cmd.Parameters.AddWithValue("@Remark2", QuestionDetails.Remark2 ?? "");
                        cmd.Parameters.AddWithValue("@Remark3", QuestionDetails.Remark3 ?? "");
                        cmd.Parameters.AddWithValue("@Remark4", QuestionDetails.Remark4 ?? "");
                        cmd.Parameters.AddWithValue("@Remark5", QuestionDetails.Remark5 ?? "");
                        cmd.Parameters.AddWithValue("@ConnectedQuestion", QuestionDetails.ConnectedQuestion ?? (object)DBNull.Value);

                        await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"An error occurred while saving question details: {ex.Message}");
            }
        }

        internal async Task UpdateTblQuestionPeparEnglish20Detail(QuestionPepar10ViewModel QuestionDetails)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateQuestionPeparEnglish20Details", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Id", QuestionDetails.PrimaryId);
                        cmd.Parameters.AddWithValue("@QuestionNo", QuestionDetails.QuestionNo ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@AnswerA", QuestionDetails.AnswerA ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@AnswerB", QuestionDetails.AnswerB ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@AnswerC", QuestionDetails.AnswerC ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@AnswerD", QuestionDetails.AnswerD ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@CurrectAnswer", QuestionDetails.CurrectAnswer ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Remark", QuestionDetails.Remark ?? "");
                        cmd.Parameters.AddWithValue("@Remark1", QuestionDetails.Remark1 ?? "");
                        cmd.Parameters.AddWithValue("@Remark2", QuestionDetails.Remark2 ?? "");
                        cmd.Parameters.AddWithValue("@Remark3", QuestionDetails.Remark3 ?? "");
                        cmd.Parameters.AddWithValue("@Remark4", QuestionDetails.Remark4 ?? "");
                        cmd.Parameters.AddWithValue("@Remark5", QuestionDetails.Remark5 ?? "");
                        cmd.Parameters.AddWithValue("@ConnectedQuestion", QuestionDetails.ConnectedQuestion ?? (object)DBNull.Value);

                        await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"An error occurred while updating question details: {ex.Message}");
            }
        }
    }
}
