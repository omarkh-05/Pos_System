using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CategoryDLL
    {
       static string connectionstring = Settings.connectionstring;
        public static short Add(Category category)
        {
            short CategoryID = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                using (SqlCommand cmd = new SqlCommand("SP_Category_Add",con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                    cmd.Parameters.AddWithValue("@ImagePath", category.ImagePath);
                    SqlParameter outputIdParam = new SqlParameter("@CategoryID", SqlDbType.TinyInt)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputIdParam);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    CategoryID = Convert.ToInt16(cmd.Parameters["@CategoryID"].Value);
                }

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"Category_Add Error : {ex.Message}", EventLogEntryType.Error);
            }

            return CategoryID;
        }

        public static async Task<DataTable> GetAllCategories()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                using (SqlCommand command = new SqlCommand("SP_Category_GetAll", connection))
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
                EventLog.WriteEntry("Application", $"Category_GetAll Error : {ex.Message}", EventLogEntryType.Error);
            }

            return dt;
        }

        public static async Task<string> GetCategoryName(short CategoryID)
        {
            string categoryname = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                using (SqlCommand command = new SqlCommand("SP_Category_GetName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@CategoryID", CategoryID);

                    // إخراج: CategoryName
                    SqlParameter outputParam = new SqlParameter("@CategoryName", SqlDbType.NVarChar, 50)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputParam);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    // قراءة الناتج
                    categoryname = outputParam.Value?.ToString();
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"Category_GetName Error : {ex.Message}", EventLogEntryType.Error);
            }

            return categoryname;
        }

        public static async Task<short> GetCategoryID(string CategoryName)
        {
            short CategoryID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                using (SqlCommand command = new SqlCommand("SP_Category_GetID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@CategoryName", CategoryName);

                    // إخراج: CategoryName
                    SqlParameter outputParam = new SqlParameter("@CategoryID", SqlDbType.TinyInt)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputParam);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    // قراءة الناتج
                    CategoryID =Convert.ToInt16(outputParam.Value);
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"Category_GetID Error : {ex.Message}", EventLogEntryType.Error);
            }

            return CategoryID;
        }
    }
}
