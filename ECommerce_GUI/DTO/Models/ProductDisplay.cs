using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models
{
    public class ProductDisplay
    {
        public string ProductName { get; set; }
        public string ImgURL { get; set; }
        public double Price { get; set; }
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
