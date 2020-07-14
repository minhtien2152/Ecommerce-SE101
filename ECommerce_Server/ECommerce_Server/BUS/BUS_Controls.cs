using ServerFTM.DAL.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library.Models;
using System.Diagnostics;
using System.Security.Cryptography.Xml;

namespace ServerFTM.BUS
{
    class BUS_Controls
    {
        private static BUS_Controls controls;
        public static BUS_Controls Controls
        {
            get
            {
                if (controls == null)
                    controls = new BUS_Controls();
                return controls;
            }
            set => controls = value;
        }
        #region Account

        public bool signup(Account profile)
        {
            profile.UserId = GenerateID();
            profile.SignUpDate = string.Format("{0:yyyy/MM/dd HH:mm:ss}", DateTime.Now.ToString());
            profile.lastEdit = string.Format("{0:yyyy/MM/dd HH:mm:ss}", DateTime.Now.ToString());

            Debug.WriteLine(profile.SignUpDate);
            return DAL_Controls.Controls.signUp(profile);
        }

        public Account signin(Account profile)
        {
            Account result = null;
            DataTable account = DAL_Controls.Controls.signin(profile);

            if (account != null && account.Rows.Count > 0)
            {
                result = new Account();
                result.UserId = account.Rows[0]["UserId"].ToString();
                result.userName = account.Rows[0]["userName"].ToString();
                result.type = Convert.ToInt32(account.Rows[0]["type"].ToString());
                result.balance = (long)Convert.ToDouble(account.Rows[0]["balance"].ToString());
                result.Name = account.Rows[0]["Name"].ToString();
                result.phoneNum = account.Rows[0]["phoneNum"].ToString();
                result.Address = account.Rows[0]["Address"].ToString();
                result.email = account.Rows[0]["email"].ToString();
            }
            return result;
        }

        public List<string> getTopSellingProductId()
        {
            List<string> result = new List<string>();

            DataTable listId = DAL_Controls.Controls.getTopSellingProductId();

            if (listId != null)
            {
                foreach (DataRow row in listId.Rows)
                {
                    result.Add(row["ProductId"].ToString());
                }
            }
            return result;
        }

        public List<string> getAllProductId()
        {
            List<string> result = new List<string>();

            DataTable listId = DAL_Controls.Controls.getAllProductId();

            if (listId != null)
            {
                foreach (DataRow row in listId.Rows)
                {
                    result.Add(row["ProductId"].ToString());
                }
            }
            return result;
        }

        public ProductDisplay getProductDisplay(string productId)
        {
            ProductDisplay result = new ProductDisplay();

            DataTable productDisplay = DAL_Controls.Controls.getProductDisplay(productId);

            if (productDisplay != null)
            {
                result.ProductName = productDisplay.Rows[0]["ProductName"].ToString();
                result.ImgURL = productDisplay.Rows[0]["ImgURL"].ToString();
                result.Price = double.Parse(productDisplay.Rows[0]["Price"].ToString());
                result.totalSale = int.Parse(productDisplay.Rows[0]["totalSale"].ToString());
            }
            return result;
        }

        public ProductDetail getProductDetail(string productId)
        {
            ProductDetail result = new ProductDetail();

            DataTable productDetail = DAL_Controls.Controls.getProductDetail(productId);

            if (productDetail != null)
            {
                result.ProductName = productDetail.Rows[0]["ProductName"].ToString();
                result.Price = double.Parse(productDetail.Rows[0]["Price"].ToString());
                result.Description = productDetail.Rows[0]["Description"].ToString();
                result.shopId = productDetail.Rows[0]["shopId"].ToString();
                result.totalSale = int.Parse(productDetail.Rows[0]["totalSale"].ToString());
                result.shopName = productDetail.Rows[0]["shopName"].ToString();
                result.shopImageUrl = productDetail.Rows[0]["shopImageUrl"].ToString();
            }
            return result;
        }

        public List<ProductReview> getProductReview(string productId)
        {
            List<ProductReview> result = new List<ProductReview>();

            DataTable productReview = DAL_Controls.Controls.getProductReview(productId);

            if (productReview != null)
            {
                foreach (DataRow row in productReview.Rows)
                {
                    ProductReview item = new ProductReview();

                    item.UserId = productReview.Rows[0]["UserId"].ToString();
                    item.userName = productReview.Rows[0]["userName"].ToString();
                    item.Rating = int.Parse(productReview.Rows[0]["Rating"].ToString());
                    item.Content = productReview.Rows[0]["Content"].ToString();
                    item.DatePost = productReview.Rows[0]["DatePost"].ToString();

                    result.Add(item);
                }

            }
            return result;
        }

        public List<string> getProductImg(string productId)
        {
            List<string> result = new List<string>();

            DataTable listImg = DAL_Controls.Controls.getProductImage(productId);

            if (listImg != null)
            {
                foreach (DataRow row in listImg.Rows)
                {
                    result.Add(row["ImgURL"].ToString());
                }
            }
            return result;
        }

        public int checkCart(Cart value)
        {
            DataTable check = DAL_Controls.Controls.checkCart(value);

            return int.Parse(check.Rows[0]["check"].ToString());
        }

        public bool insertCart(Cart value)
        {
            return DAL_Controls.Controls.insertCart(value);
        }

        public bool deleteCart(Cart value)
        {
            return DAL_Controls.Controls.deleteCart(value);
        }

        public bool clearCart(Cart value)
        {
            return DAL_Controls.Controls.clearCart(value); 
        }

        public List<Cart> getCart(string userId)
        {
            List<Cart> result = new List<Cart>();

            DataTable cartList = DAL_Controls.Controls.getCart(userId);

            if (cartList != null)
            {
                foreach (DataRow row in cartList.Rows)
                {
                    Cart item = new Cart();
                    item.UserId = row["UserId"].ToString();
                    item.ProductId = row["ProductId"].ToString();
                    item.Quantity = int.Parse(row["Quantity"].ToString());

                    result.Add(item);
                }
            }
            return result;
        }

        public string createOrder(Order value)
        {
            value.OrderId = GenerateID();
            if (DAL_Controls.Controls.createOrder(value))
            {
                return value.OrderId;
            }
            return ""; 
        }

        public bool createOrderDetail(OrderDetail value)
        {
            return DAL_Controls.Controls.createOrderDetail(value);
        }

        public bool rechargeAccount(AccountMoney value)
        {
            return DAL_Controls.Controls.rechargeAccount(value);
        }

        public bool makePayment(OrderDetail value)
        {
            string paymentId = GenerateID();
            string dateCheckout = string.Format("{0:yyyy/MM/dd HH:mm:ss}", DateTime.Now.ToString());

            return DAL_Controls.Controls.MakePayment(value, paymentId, dateCheckout);
        }

        public List<Order> getOrder(string userId)
        {
            List<Order> result = new List<Order>();

            DataTable orderList = DAL_Controls.Controls.getOrder(userId);

            if (orderList != null)
            {
                foreach (DataRow row in orderList.Rows)
                {
                    Order item = new Order();
                    item.OrderId = row["OrderId"].ToString();
                    item.Address = row["Address"].ToString();
                    item.Total = double.Parse(row["Total"].ToString());
                    item.Date = row["Date"].ToString();
                    item.isPaid = int.Parse(row["isPaid"].ToString());
                    item.isArrived = int.Parse(row["isArrived"].ToString());

                    result.Add(item);
                }
            }
            return result;
        }

        public List<OrderDetail> getOrderDetail(string orderId)
        {
            List<OrderDetail> result = new List<OrderDetail>();

            DataTable orderDetailList = DAL_Controls.Controls.getOrderDetail(orderId);

            if (orderDetailList != null)
            {
                foreach (DataRow row in orderDetailList.Rows)
                {
                    OrderDetail item = new OrderDetail();
                    item.OrderId = orderId;
                    item.ProductId = row["ProductId"].ToString();
                    item.Quantity = int.Parse(row["Quantity"].ToString());

                    result.Add(item);
                }
            }
            return result;
        }

        public List<ShippingLog> GetShippingLogs(string orderId)
        {
            List<ShippingLog> result = new List<ShippingLog>();

            DataTable shippingLogs = DAL_Controls.Controls.getShippingLog(orderId);

            if (shippingLogs != null)
            {
                foreach (DataRow row in shippingLogs.Rows)
                {
                    ShippingLog item = new ShippingLog();
                    item.OrderId = orderId;
                    item.date = row["date"].ToString();
                    item.content = row["content"].ToString();

                    result.Add(item);
                }
            }
            return result;
        }

        public double getCurrentBalance(string userid)
        {
            DataTable balance = DAL_Controls.Controls.getCurrentBalance(userid);

            if (balance != null)
            {
                return double.Parse(balance.Rows[0]["balance"].ToString());
            }
            return double.NaN;
        }

        string GenerateID()
        {
            StringBuilder builder = new StringBuilder();
            Enumerable
               .Range(65, 26)
                .Select(e => ((char)e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .ToList().ForEach(e => builder.Append(e));
            return builder.ToString();
        }

        #endregion


        #region Product

        internal bool AddProduct(ProductInfo productInfo)
        {
            return DAL_Controls.Controls.AddProduct(productInfo);
        }

        #endregion
    }
}