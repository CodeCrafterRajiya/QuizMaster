using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.Data.SqlClient;
using quezemasterNew.CommonFunctional;
using quezemasterNew.Models;
using quezemasterNew.Models.ViewModel;
using System.Data;

namespace quezemasterNew.BussinesLogic
{
    public class HomePageHelper
    {

        CommonHelperData _CommonHelperData = new CommonHelperData();
        internal async Task<List<enquiryformviewmodel>> GetAllEnquiryDetails(List<enquiryformviewmodel> LsAllEnquirDetails)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                {
                    using(SqlCommand cmd= new SqlCommand("SPGetAllEnquiryDetails", conn))
                    {
                       await conn.OpenAsync();
                        cmd.CommandType = CommandType.StoredProcedure;
                        using(SqlDataReader Datareader = await cmd.ExecuteReaderAsync())
                        {
                            while(await Datareader.ReadAsync())
                            {
                                enquiryformviewmodel EnquiryFormData = new enquiryformviewmodel();
                                EnquiryFormData.Id = _CommonHelperData.MapIntegerValue(Datareader["Id"]);
                                EnquiryFormData.Name = Datareader["Name"].ToString() ?? "";
                                EnquiryFormData.MobileNo = Datareader["MobileNo"].ToString();
                                EnquiryFormData.EmailId = Datareader["EmailId"].ToString();
                                EnquiryFormData.Message = Datareader["Message"].ToString();
                                EnquiryFormData.DateTimeStamp = _CommonHelperData.MapDateTimeValue(Datareader["DateTimeStamp"], DefaultValue: new DateTime(1900, 01, 01, 0, 0, 0));
                                LsAllEnquirDetails.Add(EnquiryFormData);
                            }
                        }
;

                    }
                }
            }
            catch(Exception ex)
            {

            }
            return LsAllEnquirDetails;
        }

        internal async Task<List<UsersDetails>> GetAllUserDetails(List<UsersDetails> LsAllUserDetails)
        {
                try
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString.Connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_GetAllUserDetails", connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            await connection.OpenAsync();

                            using (var reader = await cmd.ExecuteReaderAsync())
                            {
                                while (await reader.ReadAsync())
                                {
                                    UsersDetails lsdata = new UsersDetails();
                                    lsdata.Name = reader["Name1"].ToString() ?? "";
                                    lsdata.EmailId = reader["Email"].ToString() ?? "";
                                    lsdata.MobileNo = reader["PhoneNumber"].ToString() ?? "";
                                    lsdata.Role = reader["FormalRoleName"].ToString() ?? "";
                                    LsAllUserDetails.Add(lsdata);
                                }
                            }
                        }
                        await connection.CloseAsync();
                    }

                }
                catch (Exception ex)
                {

                }
            return LsAllUserDetails;

        }

        internal async Task SaveEnquiryDetails(TblEnquiryFormDetail EnquiryDetails)
        {
            try
            {
                if (EnquiryDetails != null)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString.Connection))
                    {
                        using (SqlCommand cmd = new SqlCommand("SPSaveEnquiryFormDetails", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Name", EnquiryDetails.Name);
                            cmd.Parameters.AddWithValue("@MobileNo", EnquiryDetails.MobileNo);
                            cmd.Parameters.AddWithValue("@EmailId", EnquiryDetails.EmailId);
                            cmd.Parameters.AddWithValue("@Message", EnquiryDetails.Message);
                            cmd.Parameters.AddWithValue("@DateTimeStamp", DateTime.Now);
                            await conn.OpenAsync();
                            await cmd.ExecuteNonQueryAsync();
                        }
                        await conn.CloseAsync();
                    }

                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
