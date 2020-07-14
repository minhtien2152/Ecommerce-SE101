using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models
{
    public class OrderDetail
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
