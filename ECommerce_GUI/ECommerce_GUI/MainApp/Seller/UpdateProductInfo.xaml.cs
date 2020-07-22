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

namespace ECommerce_GUI.MainApp.Seller
{
    /// <summary>
    /// Interaction logic for UpdateProductInfo.xaml
    /// </summary>
    public partial class UpdateProductInfo : UserControl
    {
        string productId; 
        List<string> imgList = new List<string>();
        int currentImg = 0;

        public UpdateProductInfo() {
            InitializeComponent();
        }

        private async Task loadUrl(string url) {
            CustomerWindow.Instance.startWaitting();

            await Task.Factory.StartNew(() => {
                this.Dispatcher.Invoke(() => {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(APIHelper.Instance.makeImageUrl(url), UriKind.Absolute);
                    bitmap.DecodePixelWidth = 254;
                    bitmap.EndInit();

                    productImg.Source = bitmap;
                });
            });
            CustomerWindow.Instance.endWatting();
        }

        public async void initData(string productId, int quantity) {
            this.productId = productId;

            SellerWindow.Instance.startWaitting();

            Response<ProductDetail> response = await APIHelper.Instance.Get<Response<ProductDetail>>
                (ApiRoutes.Product.getProductDetail.Replace("{id}", productId));

            Response<List<string>> imgResponse = await APIHelper.Instance.Get<Response<List<string>>>
                (ApiRoutes.Product.getProductImg.Replace("{id}", productId));
            this.imgList = imgResponse.Result;

            await loadUrl(this.imgList[currentImg]);

            productName.Text = response.Result.ProductName;
            productPrice.Text = string.Format("{0:N0}", response.Result.Price);
            productQuantity.Text = quantity.ToString();
            productQuantity.Minimum = quantity;
            description.Text = response.Result.Description;

            SellerWindow.Instance.endWaitting();
        }

        public void price_KeyDown(object sender, KeyEventArgs e) {
            // backspace press 
            if (e.Key == Key.Back)
                return;

            bool keyboardHandle = true;

            if (!e.Key.ToString().Contains("Oem")) {
                foreach (char item in e.Key.ToString()) {
                    if (char.IsDigit(item)) {
                        keyboardHandle = false;
                        break;
                    }
                }
            }
            e.Handled = keyboardHandle;
        }

        public void price_TextChanged(object sender, TextChangedEventArgs e) {
            string text = (sender as TextBox).Text;
            double value = 0.0f;

            if (text.Length > 2 && double.TryParse(text, out value)) {
                (sender as TextBox).Text = string.Format(System.Globalization.CultureInfo.CurrentCulture,
                    "{0:n0}", value);
                (sender as TextBox).CaretIndex = (sender as TextBox).Text.Length;
            }
        }

        private async void nextImg_Click(object sender, RoutedEventArgs e) {
            this.currentImg++;

            if (this.currentImg >= this.imgList.Count) {
                this.currentImg = this.imgList.Count - 1;
                return;
            }
            await loadUrl(this.imgList[currentImg]);
        }

        private async void prevImg_Click(object sender, RoutedEventArgs e) {
            this.currentImg--;

            if (this.currentImg <= -1) {
                this.currentImg = 0;
                return;
            }
            await loadUrl(this.imgList[currentImg]);
        }

        private async void saveData_Click(object sender, RoutedEventArgs e) {
            if (productName.Text == "" || productPrice.Text.Length < 4) {
                MessageBox.Show("Invalid Input");
                return;
            }
            SellerWindow.Instance.startWaitting();

            ProductUpdate newUpdate = new ProductUpdate();
            newUpdate.productId = this.productId;
            newUpdate.productName = productName.Text;
            newUpdate.price = Convert.ToDouble(productPrice.Text);
            newUpdate.quantity = int.Parse(productQuantity.Text);
            newUpdate.description = description.Text;

            await APIHelper.Instance.Post<Response<object>>(ApiRoutes.Shop.updateProductInfo, newUpdate);

            SellerWindow.Instance.endWaitting();
        }

        private void goBack_Click(object sender, RoutedEventArgs e) {
            SellerWindow.Instance.removeUIElement(SellerWindow.Instance.shopGrid, this);
        }

        private void productQuantity_KeyDown(object sender, KeyEventArgs e) {
            e.Handled = true;
        }
    }
}
