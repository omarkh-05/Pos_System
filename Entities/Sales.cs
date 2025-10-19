using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Sales
    {
        public int SalesID { get; set; }
        public DateTime SalesDate { get; set; }
        public decimal Total { get; set; }
        public byte UserID { get; set; }
        public string PaymentMethod { get; set; }
        public string DiscountUsed { get; set; }
        public DataTable SalesDetails { get; set; }
    }
}
