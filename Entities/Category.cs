using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Category
    {
        public short CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string ImagePath { get; set; } = null;
    }
}
