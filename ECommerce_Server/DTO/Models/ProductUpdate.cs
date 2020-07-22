using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models
{
    public class ProductUpdate
    {
        public string productId { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public string description { get; set; }
    }
}
