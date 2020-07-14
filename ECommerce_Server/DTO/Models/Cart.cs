using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models
{
    public class Cart
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
