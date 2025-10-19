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
    public class SalesDLL
    {
        static string connectionstring = Settings.connectionstring;
        public static async Task<DataTable> GetAllSales()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                using (SqlCommand cmd = new SqlCommand("SP_Sales_GetAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"Sales_GetAll Error : {ex.Message}", EventLogEntryType.Error);
            }

            return dt;
        }
    }
}
