using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_GUI.Helper
{
    public class ApiRoutes
    {
        public const string Base = "api";

        public static class Account
        {
            public const string signup = Base + "/Account/SignUp";
            public const string signin = Base + "/Account/SignIn";
        }

        public static class Product
        {
            public const string getTopSellingProductId = Base + "/Product/GetTopSellingProductId";
            public const string getAllProductId = Base + "/Product/GetAllProductId";
            public const string getProductDisplay = Base + "/Product/GetProductDisplay/ID={id}";
            public const string getProductDetail = Base + "/Product/GetProductDetail/ID={id}";
            public const string getProductImg = Base + "/Product/GetProductImg/ID={id}";
            public const string getProductReview = Base + "/Product/GetProductReview/ID={id}"; 
        }
    }
}
