using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models
{
    public class ProductDetail
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string shopId { get; set; }
        public string shopName { get; set; }
        public string shopImageUrl { get; set; }
        public int totalSale { get; set; }

        public string displayPrice
        {
            get
            {
                return string.Format("{0:N0}", Price) + " VNĐ";
            }
        }
    }
}
