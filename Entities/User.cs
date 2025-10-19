using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public byte UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ImagePath { get; set; }
        public string Role {  get; set; }
        public bool IsActive { get; set; }
    }
}
