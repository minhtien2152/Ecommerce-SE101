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

namespace ECommerce_GUI.MainApp.Order
{
    /// <summary>
    /// Interaction logic for OrderMain.xaml
    /// </summary>
    public partial class OrderMain : UserControl
    {
        public OrderMain()
        {
            InitializeComponent();
        }

        public async void initData()
        {
            Response<List<Library.Models.Order>> orderList = await APIHelper.Instance.Get<Response<List<Library.Models.Order>>>
                (ApiRoutes.Order.getOrder.Replace("{id}", AuthenticatedUser.user.UserId));

            await Task.Factory.StartNew(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    foreach (var item in orderList.Result)
                    {
                        DisplayOrder newDisplay = new DisplayOrder();
                        newDisplay.Margin = new Thickness(0, 10, 0, 10);
                        newDisplay.initData(item);

                        this.orderPanel.Children.Add(newDisplay);
                    }
                });
            });
        }

        public void removeView()
        {
            CustomerWindow.Instance.removeUIElement(this);
            this.IsEnabled = false;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            removeView();
        }
    }
}
