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
    /// Interaction logic for ViewProduct.xaml
    /// </summary>
    public partial class ViewProduct : UserControl
    {
        public static ViewProduct Instance;
        public string shopId;

        public ViewProduct() {
            Instance = this;
            InitializeComponent();
        }

        private void goBack_Click(object sender, RoutedEventArgs e) {
            SellerWindow.Instance.addProduct.IsEnabled = false;
            SellerWindow.Instance.removeUIElement(SellerWindow.Instance.shopGrid, this);
        }

        public async void initData(string shopId) {
            this.shopId = shopId;

            SellerWindow.Instance.startWaitting();

            Response<List<string>> response = await APIHelper.Instance.Get<Response<List<string>>>
                (ApiRoutes.Shop.getShopProductId.Replace("{id}", this.shopId));

            await Task.Factory.StartNew(() => {
                this.Dispatcher.Invoke(() => {
                    foreach (string item in response.Result) {
                        DisplayShopProduct newDisplay = new DisplayShopProduct();
                        newDisplay.Margin = new Thickness(10);

                        newDisplay.initData(item);

                        productPanel.Children.Add(newDisplay);
                    }
                });
            }); 

            SellerWindow.Instance.endWaitting();
        }
    }
}
