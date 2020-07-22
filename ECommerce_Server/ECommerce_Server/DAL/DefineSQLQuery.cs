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
            public const string ProcRechargeAccount = "EXECUTE ProcRechargeAccount @UserId , @moneyAdd";
            public const string ProcGetCurrentBalance = "EXECUTE ProcGetCurrentBalance @userid";
        }

        public class ProductQuery
        {
            public const string ProcGetTopSellingProductId = "EXECUTE ProcGetTopSellingProductId";
            public const string ProcGetAllShopProductId_Buyer = "EXECUTE ProcGetAllShopProductId_Buyer";
            public const string ProcGetProductDisplay = "EXECUTE ProcGetProductDisplay @productID";
            public const string ProcGetProductDetail = "EXECUTE ProcGetProductDetail @productID";
            public const string ProcGetProductReview = "EXECUTE ProcGetProductReview @productID";
            public const string ProcGetProductImage = "EXECUTE ProcGetProductImage @productID";
            public const string ProcSearchProduct = "EXECUTE ProcSearchProduct @search";
            public const string ProcCreateImage = "EXECUTE ProcCreateImage @productID , @imageUrl"; 
        }

        public class ShopQuery
        {
            public const string ProcGetShop = "EXECUTE ProcGetShop @userId";
            public const string ProcCreateShop = "EXECUTE ProcCreateShop @shopid , @userId , @shopName , @shopImageUrl";
            public const string ProcCreateShopProduct = "EXECUTE ProcCreateShopProduct @shopid , @productId , @productName , @description , @price , @UploadDate , @quantity , @state";
            public const string ProcGetAllShopProductId_Seller = "EXECUTE ProcGetAllShopProductId_Seller @shopId";
            public const string ProcUpdateProductInfo = "EXECUTE ProcUpdateProductInfo @productId , @productName , @quantity , @price , @description";
        }

        public class Cart
        {
            public const string ProcCheckCartQuantity = "EXECUTE ProcCheckCartQuantity @userid , @productId , @quantity";
            public const string ProcInsertCart = "EXECUTE ProcInsertCart @userid , @productId , @quantity";
            public const string ProcDeleteCart = "EXECUTE ProcDeleteCart @userid , @productId , @quantity";
            public const string ProcClearCart = "EXECUTE ProcClearCart @userid , @productId , @quantity";
            public const string ProcGetCart = "EXECUTE ProcGetCart @userid";
        }

        public class Order
        {
            public const string ProcCreateOrder = "EXECUTE ProcCreateOrder @OrderId , @UserId , @Address , @Total , @Date , @isPaid";
            public const string ProcCreateOrderDetail = "EXECUTE ProcCreateOrderDetail @OrderId , @ProductId , @Quantity";
            public const string ProcGetOrder = "EXECUTE ProcGetOrder @UserId";
            public const string ProcGetOrderDetail = "EXECUTE ProcGetOrderDetail @OrderId";
            public const string ProcMakePayment = "EXECUTE ProcMakePayment @moneyTransitId , @datecheckout , @orderId , @ProductId , @Quantity";
        }

        public class Transport
        {
            public const string ProcGetShippingLog = "EXECUTE ProcGetShippingLog @OrderID";
        }
    }
}
