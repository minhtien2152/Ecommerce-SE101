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
            DataProvider.Instance.ExecuteNonQuery(DefineSQLQuery.AccountQuery.ProcSignUp,
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
                });

            return true;
        }

        public DataTable signin(Account profile)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery(DefineSQLQuery.AccountQuery.ProcSignIn,
                new object[] {
                    profile.userName,
                    profile.password
                });

            return result;
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
    }
}
