using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models
{
    public class Account
    {
        public string UserId { get; set; }
        public string userName { get; set;}
        public string password { get; set; }
        public string token { get; set; }
        public long balance { get; set; }
        public int type { get; set; }
        public string SignUpDate { get; set; }
        public string Name { get; set; }
        public string phoneNum { get; set; }
        public string Address { get; set; }
        public string email { get; set; }
        public string lastEdit { get; set; }
    }
}
