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
using Library;

namespace ECommerce_GUI.MainApp.Product
{
    /// <summary>
    /// Interaction logic for ProductDisplay.xaml
    /// </summary>
    public partial class DisplayProduct : UserControl
    {
        string productId;

        public DisplayProduct() {
            InitializeComponent();
        }

        public async void initData(string productId) {
            this.productId = productId;

            string apiUrl = ApiRoutes.Product.getProductDisplay;
            apiUrl = apiUrl.Replace("{id}", productId);
            Response<Library.Models.ProductDisplay> response = await APIHelper.Instance.Get
                <Response<Library.Models.ProductDisplay>>(apiUrl);

            Library.Models.ProductDisplay display = response.Result;

            await displayUrl(display);
            productPrice.Text = display.displayPrice;
            productName.Text = display.ProductName;
            productTotalSale.Text = "Sold " + display.totalSale.ToString();
        }

        public async Task displayUrl(Library.Models.ProductDisplay display) {
            await Task.Factory.StartNew(() => {
                this.Dispatcher.Invoke(() => {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(APIHelper.Instance.makeImageUrl(display.ImgURL), 
                        UriKind.Absolute);
                    bitmap.DecodePixelWidth = 1920;
                    bitmap.EndInit();

                    productMainUrl.ImageSource = bitmap;
                    productMainUrl.Stretch = Stretch.Uniform;
                });
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            DetailProduct viewDetail = new DetailProduct();
            viewDetail.initData(this.productId);

            CustomerWindow.Instance.addUIElement(viewDetail);
            CustomerWindow.Instance.bringToFront(viewDetail);
        }
    }
}
