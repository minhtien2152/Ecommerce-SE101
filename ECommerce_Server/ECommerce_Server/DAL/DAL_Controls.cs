using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerFTM.DAL.Query;
using ServerFTM.DAL;
using System.Data;
using System.Reflection;
using Library.Models;

namespace ServerFTM.DAL.Controls
{
    class DAL_Controls
    {
        private static DAL_Controls controls;
        public static DAL_Controls Controls
        {
            get
            {
                if (controls == null)
                    controls = new DAL_Controls();
                return controls;
            }
            set => controls = value;
        }

        public bool signUp(Account profile)
        {
            try
            {
                return DataProvider.Instance.ExecuteNonQuery(DefineSQLQuery.AccountQuery.ProcSignUp,
                    new object[] {
                            profile.UserId,
                            profile.userName,
                            profile.password,
                            profile.type,
                            profile.SignUpDate,
                            profile.Name,
                            profile.phoneNum,
                            profile.Address,
                            profile.email,
                            profile.lastEdit
                    }) > 0;
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public DataTable signin(Account profile)
        {
            try
            {
                DataTable result = DataProvider.Instance.ExecuteQuery(DefineSQLQuery.AccountQuery.ProcSignIn,
                    new object[] {
                        profile.userName,
                        profile.password
                    });
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public DataTable getTopSellingProductId()
        {
            DataTable result = DataProvider.Instance.ExecuteQuery(DefineSQLQuery.ProductQuery.ProcGetTopSellingProductId);

            return result;
        }

        public DataTable getAllProductId()
        {
            DataTable result = DataProvider.Instance.ExecuteQuery(DefineSQLQuery.ProductQuery.ProcGetAllProductId);

            return result;
        }

        public DataTable getProductDisplay(string productId)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery(DefineSQLQuery.ProductQuery.ProcGetProductDisplay,
                new object[] {
                    productId
                });
            return result;
        }


        public DataTable getProductDetail(string productId)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery(DefineSQLQuery.ProductQuery.ProcGetProductDetail,
                new object[] {
                    productId
                });
            return result;
        }

        public DataTable getProductReview(string productId)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery(DefineSQLQuery.ProductQuery.ProcGetProductReview,
                new object[] {
                    productId
                });
            return result;
        }

        public DataTable getProductImage(string productId)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery(DefineSQLQuery.ProductQuery.ProcGetProductImage,
                new object[] {
                    productId
                });
            return result;
        }

        public DataTable checkCart(Cart value)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery(DefineSQLQuery.Cart.ProcCheckCartQuantity,
                new object[] {
                    value.UserId,
                    value.ProductId,
                    value.Quantity
                });
            return result;
        }

        public bool insertCart(Cart value)
        {
            try
            {
                return DataProvider.Instance.ExecuteNonQuery(DefineSQLQuery.Cart.ProcInsertCart,
                    new object[] {
                        value.UserId,
                        value.ProductId,
                        value.Quantity
                    }) > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool deleteCart(Cart value)
        {
            try
            {
                return DataProvider.Instance.ExecuteNonQuery(DefineSQLQuery.Cart.ProcDeleteCart,
                    new object[] {
                        value.UserId,
                        value.ProductId,
                        value.Quantity
                    }) > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool clearCart(Cart value)
        {
            try
            {
                return DataProvider.Instance.ExecuteNonQuery(DefineSQLQuery.Cart.ProcClearCart,
                    new object[] {
                        value.UserId,
                        value.ProductId,
                        value.Quantity
                    }) > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DataTable getCart(string userId)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery(DefineSQLQuery.Cart.ProcGetCart,
                new object[] {
                    userId
                });
            return result;
        }

        public bool createOrder(Order value)
        {
            try
            {
                return DataProvider.Instance.ExecuteNonQuery(DefineSQLQuery.Order.ProcCreateOrder,
                    new object[] {
                        value.OrderId,
                        value.UserId,
                        value.Address,
                        value.Total,
                        value.Date,
                        value.isPaid
                    }) > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool createOrderDetail(OrderDetail value)
        {
            try
            {
                return DataProvider.Instance.ExecuteNonQuery(DefineSQLQuery.Order.ProcCreateOrderDetail,
                    new object[] {
                        value.OrderId,
                        value.ProductId,
                        value.Quantity

                    }) > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool rechargeAccount(AccountMoney value)
        {
            try
            {
                return DataProvider.Instance.ExecuteNonQuery(DefineSQLQuery.AccountQuery.ProcRechargeAccount,
                    new object[] {
                        value.UserId,
                        value.moneyAdd
                    }) > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DataTable getOrder(string userId)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery(DefineSQLQuery.Order.ProcGetOrder,
                new object[] {
                    userId
                });
            return result;
        }

        public DataTable getOrderDetail(string orderID)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery(DefineSQLQuery.Order.ProcGetOrderDetail,
                new object[] {
                    orderID
                });
            return result;
        }

        public bool MakePayment(OrderDetail value, string paymentId, string dateCheckout)
        {
            try
            {
                return DataProvider.Instance.ExecuteNonQuery(DefineSQLQuery.Order.ProcMakePayment,
                    new object[] {
                        paymentId,
                        dateCheckout,
                        value.OrderId,
                        value.ProductId,
                        value.Quantity
                    }) > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        } 

        public DataTable getShippingLog(string orderId)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery(DefineSQLQuery.Transport.ProcGetShippingLog,
                new object[] {
                    orderId
                });
            return result;
        }

        public DataTable getCurrentBalance(string userid)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery(DefineSQLQuery.AccountQuery.ProcGetCurrentBalance,
                new object[] {
                    userid
                });
            return result;
        }

        public DataTable getProductSearchList(string search)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery(DefineSQLQuery.ProductQuery.ProcSearchProduct,
                new object[] {
                    search
                });
            return result;
        }
    }
}
