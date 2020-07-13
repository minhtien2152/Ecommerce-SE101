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

        public static class Cart
        {
            public const string CheckCartQuantity = Base + "/Cart/CheckCartQuantity/UserId={userId}/ProductId={productId}/Quantity={quantity}";
            public const string InsertCart = Base + "/Cart/InsertCart";
            public const string DeleteCart = Base + "/Cart/DeleteCart";
        }

        public class Utility
        {
            public static string makeCheckCartURL(Library.Models.Cart value)
            {
                string result = Base + "/Cart/CheckCartQuantity/UserId={userId}/ProductId={productId}/Quantity={quantity}";
                result = result.Replace("{userId}", value.UserId);
                result = result.Replace("{productId}", value.ProductId);
                result = result.Replace("{quantity}", value.Quantity.ToString());
                return result;
            }
        }
    }
}
