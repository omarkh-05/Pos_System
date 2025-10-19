using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public short Quantity { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public string Barcode { get; set; }
        public short CategoryID { get; set; }
    }
}
