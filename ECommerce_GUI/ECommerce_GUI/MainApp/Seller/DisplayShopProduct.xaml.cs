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
    /// Interaction logic for DisplayShopProduct.xaml
    /// </summary>
    public partial class DisplayShopProduct : UserControl
    {
        public string productId;
        public int _quantity;
        List<string> imageUrls = new List<string>();

        public DisplayShopProduct() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            UpdateProductInfo newDisplay = new UpdateProductInfo();
            newDisplay.initData(this.productId, _quantity);

            SellerWindow.Instance.addUIElement(SellerWindow.Instance.shopGrid, newDisplay);
            SellerWindow.Instance.bringToFrontShop(newDisplay);
        }

        public async void initData(string productId) {
            SellerWindow.Instance.startWaitting();

            this.productId = productId;

            Response<ProductDisplay> response = await APIHelper.Instance.Get<Response<ProductDisplay>>
                (ApiRoutes.Product.getProductDisplay.Replace("{id}", productId));
            _quantity = response.Result.Quantity;

            await Task.Factory.StartNew(() => {
                this.Dispatcher.Invoke(() => {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(APIHelper.Instance.makeImageUrl(response.Result.ImgURL), 
                        UriKind.Absolute);
                    bitmap.DecodePixelWidth = 1920;
                    bitmap.EndInit();

                    productImg.Source = bitmap;
                    productImg.Stretch = Stretch.Uniform;
                });
            });
            productName.Text = response.Result.ProductName;
            totalSale.Text += response.Result.totalSale.ToString();
            quantity.Text += response.Result.Quantity.ToString();

            if (response.Result.state == 1) {
                status.Text = "Verified";
                status.Foreground = Brushes.Green;
            }
            else {
                status.Text = "Pending";
                status.Foreground = Brushes.Red;
            }
            SellerWindow.Instance.endWaitting();
        }
    }
}
