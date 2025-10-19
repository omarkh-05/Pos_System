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
    public class ProductDLL
    {
        static string connectionstring = Settings.connectionstring;

        public static short Add(Product product)
        {
            short productID = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                using (SqlCommand cmd = new SqlCommand("SP_Product_Add", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                    cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
                    cmd.Parameters.AddWithValue("@ExDate", product.ExpireDate);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.AddWithValue("@Cost", product.Cost);
                    cmd.Parameters.AddWithValue("@Barcode", product.Barcode);
                    cmd.Parameters.AddWithValue("@CategoryID", product.CategoryID);

                    SqlParameter outputIdParam = new SqlParameter("@ProductID", SqlDbType.SmallInt)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputIdParam);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    productID = Convert.ToInt16(cmd.Parameters["@ProductID"].Value);
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"Product_Add Error : {ex.Message}", EventLogEntryType.Error);
            }

            return productID;
        }

        public static bool Update(Product product)
        {
            bool updated = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                using (SqlCommand cmd = new SqlCommand("SP_Product_Update", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProductID", product.ProductID);
                    cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                    cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
                    cmd.Parameters.AddWithValue("@ExDate", product.ExpireDate);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.AddWithValue("@Cost", product.Cost);
                    cmd.Parameters.AddWithValue("@Barcode", product.Barcode);
                    cmd.Parameters.AddWithValue("@CategoryID", product.CategoryID);

                    SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.ReturnValue
                    };
                    cmd.Parameters.Add(returnParameter);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    updated = returnParameter.Value != DBNull.Value && Convert.ToInt32(returnParameter.Value) == 1;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"Product_Update Error : {ex.Message}", EventLogEntryType.Error);
            }

            return updated;
        }

        
        public static async Task<DataTable> GetAllProducts()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                using (SqlCommand cmd = new SqlCommand("SP_Product_GetAll", conn))
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
                EventLog.WriteEntry("Application", $"Product_GetAll Error : {ex.Message}", EventLogEntryType.Error);
            }

            return dt;
        }
        public static async Task<DataTable> GetProductsByCategory(short categoryId)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                using (SqlCommand cmd = new SqlCommand("SP_Product_GetByCategoryID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryID", categoryId);

                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"Product_GetByCategoryID Error : {ex.Message}", EventLogEntryType.Error);
            }

            return dt;
        }
        public static async Task<Product> GetProductByID(short productId)
        {
            Product product = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                using (SqlCommand cmd = new SqlCommand("SP_Product_GetByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductID", productId);

                    await conn.OpenAsync();

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            product = new Product
                            {
                                ProductID = Convert.ToInt16(reader["ProductID"]),
                                ProductName = reader["ProductName"].ToString(),
                                Quantity = Convert.ToInt16(reader["Quantity"]),
                                ExpireDate = Convert.ToDateTime(reader["ExpireDate"]),
                                Price = Convert.ToDecimal(reader["Price"]),
                                Cost = Convert.ToDecimal(reader["Cost"]),
                                Barcode = reader["Barcode"].ToString(),
                                CategoryID = Convert.ToByte(reader["CategoryID"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"Product_GetByID Error : {ex.Message}", EventLogEntryType.Error);
            }

            return product;
        }
    }
}
