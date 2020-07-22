using ECommerce_GUI.Helper;
using ECommerce_GUI.MainApp.Product;
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

namespace ECommerce_GUI.MainApp.Order
{
    /// <summary>
    /// Interaction logic for DisplayDetailOrder.xaml
    /// </summary>
    public partial class DisplayDetailOrder : UserControl
    {
        public DisplayDetailOrder() {
            InitializeComponent();
        }

        public async Task loadUrlImg(string url) {
            await Task.Factory.StartNew(() => {
                this.Dispatcher.Invoke(() => {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(APIHelper.Instance.makeImageUrl(url), UriKind.Absolute);
                    bitmap.DecodePixelWidth = 1920; 
                    bitmap.EndInit();

                    productImg.Source = bitmap;
                });
            });
        }

        public async void initData(OrderDetail value) {
            Response<ProductDisplay> display = await APIHelper.Instance.Get<Response<ProductDisplay>>
                (ApiRoutes.Product.getProductDisplay.Replace("{id}", value.ProductId));

            await loadUrlImg(display.Result.ImgURL);

            productName.Text = display.Result.ProductName;
            unitPrice.Text = string.Format("{0:N0} VNĐ", display.Result.Price);
            quantity.Text = string.Format("Quantity: {0}", value.Quantity.ToString());
        }
    }
}
