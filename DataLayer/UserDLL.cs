using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserDLL
    {
       static string connectionstring = Settings.connectionstring;


        public static byte Add(User user)
        {
            byte UserID = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                using (SqlCommand cmd = new SqlCommand("SP_User_Add", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Role", user.Role);
                    cmd.Parameters.AddWithValue("@IsActive", user.IsActive);
                    cmd.Parameters.AddWithValue("@ImgPath", user.ImagePath);

                    SqlParameter outputIdParam = new SqlParameter("@UserID", SqlDbType.TinyInt)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputIdParam);

                     conn.Open();
                     cmd.ExecuteNonQuery();

                    UserID = Convert.ToByte(cmd.Parameters["@UserID"].Value);
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"User_Add Error : {ex.Message}", EventLogEntryType.Error);
            }

            return UserID;
        }

        public static bool Update(User user)
        {
            bool Updated = false;
          try
          {
                using (SqlConnection connection = new SqlConnection(connectionstring))
             using (SqlCommand command = new SqlCommand("SP_User_Update", connection))
             {
                 command.CommandType = CommandType.StoredProcedure;

                 command.Parameters.AddWithValue("@UserName", user.UserName);
                 command.Parameters.AddWithValue("@Password", user.Password);
                 command.Parameters.AddWithValue("@Role", user.Role);
                 command.Parameters.AddWithValue("@ImgPath", user.ImagePath);
                 command.Parameters.AddWithValue("@IsActive", user.IsActive);
                 command.Parameters.AddWithValue("@UserID", user.UserId);

                 SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                 {
                     Direction = ParameterDirection.ReturnValue
                 };
                 command.Parameters.Add(returnParameter);

               connection.Open();
               command.ExecuteNonQuery();

                    Updated = returnParameter.Value != DBNull.Value && Convert.ToInt32(returnParameter.Value) == 1;
                }
          }catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"User_Update Error : {ex.Message}", EventLogEntryType.Error);
            }

            return Updated;
        }

        public static bool Delete(byte userid)
        {
            bool Deleted = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                using (SqlCommand command = new SqlCommand("SP_User_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", userid);

                    SqlParameter returnparameter = new SqlParameter(@"ReturnVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.ReturnValue
                    };
                    command.Parameters.Add(returnparameter);

                    connection.Open();
                    command.ExecuteNonQuery();

                     Deleted = (bool) returnparameter.Value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"User_Delete Error : {ex.Message}", EventLogEntryType.Error);
            }

            return Deleted;
        }

        public static async Task<DataTable> GetAllUsers()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                using (SqlCommand command = new SqlCommand("SP_User_GetAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        dt.Load(reader);
                    }

                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"User_GetAll Error : {ex.Message}", EventLogEntryType.Error);
            }

            return dt;
        }

        public static async Task<User> GetUserByID(byte userId)
        {
            User user = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                using (SqlCommand command = new SqlCommand("SP_User_GetUserInfo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", userId);

                    await connection.OpenAsync();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                UserId = Convert.ToByte(reader["UserID"]), // ← هذه السطر مفقود
                                UserName = reader["UserName"].ToString(),
                                Password = reader["Password"].ToString(),
                                Role = reader["Role"].ToString(),
                                ImagePath = reader["ImgPath"].ToString(),
                                IsActive = Convert.ToBoolean(reader["IsActive"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"User_GetByID Error : {ex.Message}", EventLogEntryType.Error);
            }

            return user;
        }

        public static async Task<User> GetUserForLogin(string UserName, string Password)
        {
            User user = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                using (SqlCommand command = new SqlCommand("SP_User_FindForLogin", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@UserName", SqlDbType.NVarChar, 50).Value = UserName;
                    command.Parameters.Add("@Password", SqlDbType.NVarChar, 200).Value = Password;

                    SqlParameter returnparameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.ReturnValue
                    };
                    command.Parameters.Add(returnparameter);

                    await connection.OpenAsync();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                UserId = Convert.ToByte(reader["UserID"]),
                                UserName = reader["UserName"].ToString(),
                                Role = reader["Role"].ToString(),
                                ImagePath = reader["ImgPath"].ToString(),
                                IsActive = Convert.ToBoolean(reader["IsActive"])
                            };
                        }
                    }

                    // ReturnValue يأتي بعد ExecuteReader
                    int result = (int)returnparameter.Value;
                    if (result != 1)
                        user = null;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"User_ForLogin Error : {ex.Message}", EventLogEntryType.Error);
            }

            return user;
        }
    }
}
