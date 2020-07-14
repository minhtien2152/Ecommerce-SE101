using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models
{
    public class ProductReview
    {
        public string UserId { get; set; }
        public string userName { get; set; }
        public int Rating { get; set; }
        public string Content { get; set; }
        public string DatePost { get; set; }
    }
}
