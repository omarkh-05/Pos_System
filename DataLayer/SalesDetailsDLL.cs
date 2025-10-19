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
    public class SalesDetailsDLL
    {
        static string connectionstring = Settings.connectionstring;

        public static async Task<bool> AddSaleAsync(SalesDetail sale)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                using (SqlCommand cmd = new SqlCommand("SP_SalesAndSalesDetails_AddMulti", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // تمرير بيانات الفاتورة
                    cmd.Parameters.AddWithValue("@SalesDate", sale.SalesDate);
                    cmd.Parameters.AddWithValue("@Total", sale.Total);
                    cmd.Parameters.AddWithValue("@UserID", sale.UserID);
                    cmd.Parameters.AddWithValue("@PaymentMethod", sale.PaymentMethod);
                    cmd.Parameters.AddWithValue("@DiscountUsed", sale.DiscountUsed);

                    // TVP للـ SalesDetails
                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@SalesDetails", sale.SalesDetails);    
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.SalesDetailTable"; // اسم الـUser Defined Table Type في SQL

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }

                return true;
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"AddSaleAsync Error: {ex.Message}", EventLogEntryType.Error);
                return false;
            }
        }



        public static async Task<DataTable> GetSalesDetailsBySalesID(int salesId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                using (SqlCommand cmd = new SqlCommand("SP_SalesDetails_GetDetailsBySalesID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SalesID", salesId);

                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"GetSalesDetailsBySalesID Error: {ex.Message}", EventLogEntryType.Error);
            }

            return dt;
        }
    }
}
