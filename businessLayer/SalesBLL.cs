using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLayer
{
    public class SalesBLL
    {
        public static async Task<DataTable> GetAllSales()
        {
            return await SalesDLL.GetAllSales();
        }
    }
}
