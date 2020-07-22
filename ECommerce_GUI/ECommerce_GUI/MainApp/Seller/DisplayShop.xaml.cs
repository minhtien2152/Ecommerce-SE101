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
    /// Interaction logic for DisplayShop.xaml
    /// </summary>
    public partial class DisplayShop : UserControl
    {
        public Shop shopData = new Shop();

        public DisplayShop() {
            InitializeComponent();
        }

        public async void initData(Shop value) {
            shopData = value;

            SellerWindow.Instance.startWaitting();

            await Task.Factory.StartNew(() => {
                this.Dispatcher.Invoke(() => {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(APIHelper.Instance.makeImageUrl(value.shopImageUrl), 
                        UriKind.Absolute);
                    bitmap.DecodePixelWidth = 254;
                    bitmap.EndInit();

                    shopImg.Source = bitmap;
                    shopImg.Stretch = Stretch.Uniform;
                });
            });
            shopName.Text = value.shopName;

            SellerWindow.Instance.endWaitting();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            SellerWindow.Instance.addProduct.IsEnabled = true;

            ViewProduct newView = new ViewProduct();
            newView.initData(this.shopData.shopId);

            SellerWindow.Instance.addUIElement(SellerWindow.Instance.shopGrid, newView);
            SellerWindow.Instance.bringToFrontShop(newView);
        }
    }
}
