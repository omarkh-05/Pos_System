using DataLayer;
using Entities;
using System;
using System.Data;
using System.Threading.Tasks;

namespace businessLayer
{
    public class SalesDetailBLL
    {
        private SalesDetail _sale;

        public SalesDetailBLL() { _sale = new SalesDetail(); }

        public SalesDetailBLL(SalesDetail sale) { _sale = sale; }

        public SalesDetail CurrentSale
        {
            get => _sale;
            set => _sale = value;
        }

        public async Task<bool> SaveAsync()
        {
            if (_sale == null || _sale.SalesDetails == null || _sale.SalesDetails.Rows.Count == 0)
            {
                return false;
            }

            return await SalesDetailsDLL.AddSaleAsync(_sale);
        }

        public static async Task<DataTable> GetSaleDetailsAsync(int salesId)
        {
            return await SalesDetailsDLL.GetSalesDetailsBySalesID(salesId);
        }
    }
}
