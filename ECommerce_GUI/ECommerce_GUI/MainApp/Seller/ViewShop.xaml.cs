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
    /// Interaction logic for ViewShop.xaml
    /// </summary>
    public partial class ViewShop : UserControl
    {
        public ViewShop() {
            InitializeComponent();
        }

        public async void initData() {
            SellerWindow.Instance.startWaitting();
            
            string userId = AuthenticatedUser.user.UserId;

            Response<List<Shop>> response = await APIHelper.Instance.Get<Response<List<Shop>>>
                (ApiRoutes.Shop.getShop.Replace("{id}", userId));

            await Task.Factory.StartNew(() => {
                this.Dispatcher.Invoke(() => {
                    foreach (var item in response.Result) {
                        DisplayShop newDisplay = new DisplayShop();
                        newDisplay.Margin = new Thickness(10);

                        newDisplay.initData(item);

                        shopPanel.Children.Add(newDisplay);
                    }
                });
            });
            SellerWindow.Instance.endWaitting();
        }
    }
}
