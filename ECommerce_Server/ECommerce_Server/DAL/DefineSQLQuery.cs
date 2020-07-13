using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerFTM.DAL.Query
{
    public class DefineSQLQuery
    {
        public class AccountQuery
        {
            public const string ProcSignUp = "EXECUTE ProcSignUp @UserID , @userName , @password , @type , @SignUpDate , @Name , @phoneNum , @Address , @email , @lastEdit";
            public const string ProcSignIn = "EXECUTE ProcSignIn @userName , @password";
        }

        public class ProductQuery
        {
            public const string ProcGetTopSellingProductId = "EXECUTE ProcGetTopSellingProductId";
            public const string ProcGetAllProductId = "EXECUTE ProcGetAllProductId";
            public const string ProcGetProductDisplay = "EXECUTE ProcGetProductDisplay @productID";
            public const string ProcGetProductDetail = "EXECUTE ProcGetProductDetail @productID";
            public const string ProcGetProductReview = "EXECUTE ProcGetProductReview @productID";
            public const string ProcGetProductImage = "EXECUTE ProcGetProductImage @productID"; 
        }

        public class Cart
        {
            public const string ProcCheckCartQuantity = "EXECUTE ProcCheckCartQuantity @userid , @productId , @quantity";
            public const string ProcInsertCart = "EXECUTE ProcInsertCart @userid , @productId , @quantity";
            public const string ProcDeleteCart = "EXECUTE ProcDeleteCart @userid , @productId , @quantity";
        }
    }
}
