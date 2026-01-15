using Microsoft.Data.SqlClient;
using quezemasterNew.CommonFunctional;
using quezemasterNew.Models.UPPViewModel;
using quezemasterNew.Models.ViewModel;
using System.Data;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace quezemasterNew.BussinesLogic
{
    public class UPPHelper
    {
        CommonHelperData _CommonHelperData = new CommonHelperData();
        internal async Task<List<UppQuestionSetViewModel>> GetUPPQuizRecords(List<UppQuestionSetViewModel> LsQuizDetails)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    using(SqlCommand cmd= new SqlCommand("SP_GetQuizIndex20Details",conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        await conn.OpenAsync();
                        using (SqlDataReader Reader= await cmd.ExecuteReaderAsync())
                        {
                            while(await Reader.ReadAsync())
                            {

                            }
                        }
                    }
                }






                    var Selectdata = $"Select * from Tbl_QuezIndex20Details";

                SqlConnection connection = new SqlConnection(ConnectionString.Connection);
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(Selectdata, connection);

                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    UppQuestionSetViewModel lsdata1 = new UppQuestionSetViewModel();
                    lsdata1.QuestionSetName = reader["QuezName"].ToString()??"";
                    lsdata1.id = _CommonHelperData.MapIntegerValue(reader["Id"]);

                    LsQuizDetails.Add(lsdata1);
                }
                connection.Close();
            }
            catch (Exception ex)
            {


            }
            return LsQuizDetails;
        }

        internal async Task<List<ResultDetailsViewModel>> ResultDetailsByTestIndexId(List<ResultDetailsViewModel> LsResult,string TestSeriseId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString: ConnectionString.Connection))
                {
                    using (SqlCommand cmd = new SqlCommand( "GetResultDetailsByTestIndexId", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TestIndexId", TestSeriseId);

                        await conn.OpenAsync();
                        using (SqlDataReader Reader = await cmd.ExecuteReaderAsync())
                        {
                            int i = 1;
                            while (await Reader.ReadAsync())
                            {
                                ResultDetailsViewModel result = new ResultDetailsViewModel();
                                result.SRNumber = i;
                                result.Question = Reader["Question"].ToString() ?? "";
                                result.AnsswerA = Reader["AnswerA"].ToString() ?? "";
                                result.AnsswerB = Reader["AnswerB"].ToString() ?? "";
                                result.AnsswerC = Reader["AnswerC"].ToString() ?? "";
                                result.AnsswerD = Reader["AnswerD"].ToString() ?? "";
                                result.CurrectAnsawer = Reader["CurrectAnswer"].ToString() ?? "";
                                result.TotalCurrectAnswer = _CommonHelperData.MapIntegerValue(Reader["TotalCurrectAnswer"]);
                                i++;
                                LsResult.Add(result);
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {

            }
            return LsResult;
        }
    }
}
