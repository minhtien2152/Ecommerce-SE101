using ECommerce_GUI.Helper;
using FlightTicketManagement.Helper;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToastNotifications.Messages;

namespace ECommerce_GUI.MainApp.Product
{
    /// <summary>
    /// Interaction logic for DetailProduct.xaml
    /// </summary>
    public partial class DetailProduct : UserControl
    { 
        List<string> imgs = new List<string>();
        int imgIndex = 0;

        string productId;

        public DetailProduct()
        {
            InitializeComponent();
        }

        private async Task<List<string>> getImg(string productId)
        {
            Response<List<string>> response = await APIHelper.Instance.Get
                <Response<List<string>>>(ApiRoutes.Product.getProductImg.Replace("{id}", productId));
            return response.Result;
        }

        private async Task<ProductDetail> getDetail(string productId)
        {
            Response<ProductDetail> response = await APIHelper.Instance.Get
                <Response<ProductDetail>>(ApiRoutes.Product.getProductDetail.Replace("{id}", productId));
            return response.Result;
        }

        private async Task<List<ProductReview>> getReview(string productId)
        {
            Response<List<ProductReview>> response = await APIHelper.Instance.Get
                <Response<List<ProductReview>>>(ApiRoutes.Product.getProductReview.Replace("{id}", productId));
            return response.Result;
        }

        private async Task loadUrl(string url)
        {
            CustomerWindow.Instance.startWaitting();

            await Task.Factory.StartNew(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(url, UriKind.Absolute);
                    bitmap.DecodePixelWidth = 800;
                    bitmap.DecodePixelHeight = 600;
                    bitmap.EndInit();

                    productImg.Source = bitmap;
                });
            });
            CustomerWindow.Instance.endWatting();
        }

        private async Task loadShopUrl(string url)
        {
            CustomerWindow.Instance.startWaitting();

            await Task.Factory.StartNew(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(url, UriKind.Absolute);
                    bitmap.DecodePixelWidth = 800;
                    bitmap.DecodePixelHeight = 600;
                    bitmap.EndInit();

                    shopImg.Source = bitmap;
                });
            });
            CustomerWindow.Instance.endWatting();
        }

        private async Task loadReview(List<ProductReview> reviews)
        {
            int sumRating = 0, countRating = 0;

            await Task.Factory.StartNew(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    foreach (var item in reviews)
                    {
                        sumRating += item.Rating;
                        countRating++;

                        string reviewDisplay = $"{item.userName} [{item.DatePost}] -> {item.Content}" +
                            "\n=================================\n";
                        reviewText.Text += reviewDisplay;
                    }
                });
            });
            if (countRating > 0)
            {
                productRating.Value = (int)(sumRating / countRating);
            }
            ratingCount.Text = string.Format("{0:N0}", double.Parse(countRating.ToString()));
        }

        public async void initData(string productId)
        {
            CustomerWindow.Instance.startWaitting();

            this.productId = productId;

            imgs = await getImg(productId);
            List<ProductReview> reviews = await getReview(productId);
            ProductDetail detail = await getDetail(productId);

            await loadUrl(imgs[0]);
            await loadShopUrl(detail.shopImageUrl);
            await loadReview(reviews);

            productName.Text = detail.ProductName;
            productPrice.Text = detail.displayPrice;
            productDescription.Text = detail.Description;
            shopName.Text = detail.shopName;

            CustomerWindow.Instance.endWatting();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow.Instance.removeUIElement(this);
            this.IsEnabled = false;
        }

        private void quantity_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private async void previousImg_Click(object sender, RoutedEventArgs e)
        {
            if (imgs.Count > 0 && imgIndex > 0)
            {
                await loadUrl(imgs[--imgIndex]);
            }
        }

        private async void nextImg_Click(object sender, RoutedEventArgs e)
        {
            if (imgs.Count > 0 && imgIndex < imgs.Count - 1)
            {
                await loadUrl(imgs[++imgIndex]);
            }
        }

        private void viewShop_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void addToCart_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow.Instance.startWaitting();

            Library.Models.Cart newCart = new Library.Models.Cart();
            newCart.UserId = AuthenticatedUser.user.UserId;
            newCart.ProductId = this.productId;
            newCart.Quantity = (int)quantity.Value;

            Response<int> result = await APIHelper.Instance.Get<Response<int>>
                (ApiRoutes.Utility.makeCheckCartURL(newCart));

            if (result.Result == 1)
            {
                insertCart(newCart);
            }
            else
            {
                CustomerWindow.Instance.notifier.ShowError("Quantity Too Large");
            }
            CustomerWindow.Instance.endWatting();
        }

        private async void insertCart(Library.Models.Cart newCart)
        {
            Response<object> result = await APIHelper.Instance.Post<Response<object>>
                    (ApiRoutes.Cart.InsertCart, newCart);

            if (result.IsSuccess)
            {
                CustomerWindow.Instance.notifier.ShowSuccess("Cart Added");
            }
            else CustomerWindow.Instance.notifier.ShowError("System Error");
        }
    }
}
