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
            Account result = new Account();
            DataTable account = DAL_Controls.Controls.signin(profile);
                
            if (account != null)
            {
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
                foreach(DataRow row in listId.Rows)
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
                result.Description = productDetail.Rows[0]["totalSale"].ToString();
                result.shopName = productDetail.Rows[0]["shopName"].ToString();
                result.shopImageUrl = productDetail.Rows[0]["shopImageUrl"].ToString();
            }
            return result;
        }

        public ProductReview getProductReview(string productId)
        {
            ProductReview result = new ProductReview();

            DataTable productReview = DAL_Controls.Controls.getProductDetail(productId);

            if (productReview != null)
            {
                result.UserId = productReview.Rows[0]["UserId"].ToString();
                result.userName = productReview.Rows[0]["userName"].ToString();
                result.Rating = int.Parse(productReview.Rows[0]["Rating"].ToString());
                result.Content = productReview.Rows[0]["Content"].ToString();
                result.DatePost = productReview.Rows[0]["DatePost"].ToString();
            }
            return result;
        }

        public List<string> getProductImg(string productId)
        {
            List<string> result = new List<string>();

            DataTable listImg = DAL_Controls.Controls.getProductImage(productId); 

            if (listImg != null)
            {
                foreach(DataRow row in listImg.Rows)
                {
                    result.Add(row["ImgURL"].ToString()); 
                }
            }
            return result;
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
    }
}