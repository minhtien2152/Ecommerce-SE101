using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models
{
    public class ProductCreate
    {
        public string shopId { get; set; }
        public string productId { get; set; }
        public string productName { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public string uploadDate { get; set; }
        public int quantity { get; set; }
        public int state { get; set; }
    }
}
