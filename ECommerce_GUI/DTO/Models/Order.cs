using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models
{
    public class Order
    {
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public string Address { get; set; }
        public double Total { get; set; }
        public string Date { get; set; }
        public int isPaid { get; set; }
        public int isArrived { get; set; }
    }
}
