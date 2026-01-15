using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using quezemasterNew.CommonFunctional;
using quezemasterNew.Models;
using quezemasterNew.Models.ViewModel;
using System.Data;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace quezemasterNew.BussinesLogic
{
    public class QuezIndex10DetailHelper
    {
        internal async Task<TblQuezIndex20Detail> GetQuezIndex10UPPDetailsUsingId(int UPPId)
        {
            TblQuezIndex20Detail UPPData = new TblQuezIndex20Detail();
            try
            {
                if(UPPId == 0) 
                    return UPPData;

                SqlConnection connection = new SqlConnection(ConnectionString.Connection);

                SqlCommand command = new SqlCommand("SelectQuezeIndex10Details", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", UPPId);
                
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    UPPData.Id = Convert.ToInt32(reader["Id"]);
                    UPPData.QuezName = reader["QuezName"].ToString();
                    UPPData.ClassName = reader["ClassName"].ToString();
                    UPPData.SubjectName = reader["SubjectName"].ToString();
                    UPPData.Remark = reader["Remark"].ToString();
                
                }
                connection.Close();
            }
            catch (Exception ex)
            {

            }
            return UPPData;
        }




        internal async Task<List<QuezIndex20DetailsViewModel>> GetQuezIndex10UPPDetails(List<QuezIndex20DetailsViewModel> LsQuezDetails)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString.Connection);

                SqlCommand command = new SqlCommand("SelectQuezeIndex10Details", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
             
     
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    QuezIndex20DetailsViewModel lsdata = new QuezIndex20DetailsViewModel();
                    lsdata.Id = Convert.ToInt32(reader["Id"]);
                    lsdata.QuezName = reader["QuezName"].ToString();
                    lsdata.ClassName = reader["ClassName"].ToString();
                    lsdata.SubjectName = reader["SubjectName"].ToString();
                    lsdata.Remark = reader["Remark"].ToString();
                    LsQuezDetails.Add(lsdata);
                }
                connection.Close();
            }
            catch (Exception ex)
            {

            }
            return LsQuezDetails;
        }

        internal async Task<bool> SaveGeneralAptitudeUppDetails(TblQuezIndex20Detail GeneralAptitudeUppModel)
        {
            try
            {
                if(GeneralAptitudeUppModel!=null)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("InsertQuezIndexClass10Details", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@QuezName", GeneralAptitudeUppModel.QuezName);
                            cmd.Parameters.AddWithValue("@ClassName", GeneralAptitudeUppModel.ClassName);
                            cmd.Parameters.AddWithValue("@SubjectName", GeneralAptitudeUppModel.SubjectName);
                            cmd.Parameters.AddWithValue("@Remark", GeneralAptitudeUppModel.Remark ?? "");
                            cmd.Parameters.AddWithValue("@Remark1", GeneralAptitudeUppModel.Remark1 ?? "");
                            cmd.Parameters.AddWithValue("@Remark2", GeneralAptitudeUppModel.Remark2 ?? "");
                            cmd.Parameters.AddWithValue("@Remark3", GeneralAptitudeUppModel.Remark3 ?? "");
                            cmd.Parameters.AddWithValue("@Remark4", GeneralAptitudeUppModel.Remark4 ?? "");
                            cmd.Parameters.AddWithValue("@Remark5", GeneralAptitudeUppModel.Remark5 ?? "");

                            await conn.OpenAsync();
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    return true;
                }
            }
            catch(Exception ex)
            {

            }
            return false;
        }

        internal async Task<bool> UpdateGeneralAptitudeUppDetails(TblQuezIndex20Detail GeneralAptitudeUppModel)
        {
            try
            {
                if (GeneralAptitudeUppModel != null)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("UpdateQuezeIndex10Details", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Id", GeneralAptitudeUppModel.Id);
                            cmd.Parameters.AddWithValue("@QuezName", GeneralAptitudeUppModel.QuezName);
                            cmd.Parameters.AddWithValue("@ClassName", GeneralAptitudeUppModel.ClassName);
                            cmd.Parameters.AddWithValue("@SubjectName", GeneralAptitudeUppModel.SubjectName);
                            cmd.Parameters.AddWithValue("@Remark", GeneralAptitudeUppModel.Remark ?? "");
                            cmd.Parameters.AddWithValue("@Remark1", GeneralAptitudeUppModel.Remark1 ?? "");
                            cmd.Parameters.AddWithValue("@Remark2", GeneralAptitudeUppModel.Remark2 ?? "");
                            cmd.Parameters.AddWithValue("@Remark3", GeneralAptitudeUppModel.Remark3 ?? "");
                            cmd.Parameters.AddWithValue("@Remark4", GeneralAptitudeUppModel.Remark4 ?? "");
                            cmd.Parameters.AddWithValue("@Remark5", GeneralAptitudeUppModel.Remark5 ?? "");

                            await conn.OpenAsync();
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                    return true;
                }
            }
            catch(Exception ex)
            {

            }
            return false;
        }

        internal async Task<bool> DeleteGeneralAptitudeUppDetails(int? UPPId)
        {
            try
            {
                if (UPPId>0)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("DeleteQuezeIndex10Details", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Id", UPPId);
      
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
