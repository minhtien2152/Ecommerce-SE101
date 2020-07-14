using ECommerce_GUI.Helper;
using FlightTicketManagement.Helper;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for DetailOrder.xaml
    /// </summary>
    public partial class DetailOrder : UserControl
    {
        public DetailOrder()
        {
            InitializeComponent();
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

        public async void initData(string orderId)
        {
            Response<List<OrderDetail>> orderDetailList = await APIHelper.Instance.Get<Response<List<OrderDetail>>>
                (ApiRoutes.Order.getOrderDetail.Replace("{id}", orderId));

            await Task.Factory.StartNew(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    foreach (var item in orderDetailList.Result)
                    {
                        DisplayDetailOrder newDisplay = new DisplayDetailOrder();
                        newDisplay.Margin = new Thickness(0, 10, 0, 10);
                        newDisplay.initData(item);

                        this.orderDetailPanel.Children.Add(newDisplay);
                    }
                });
            });
            await initShippingLog(orderId);
        }

        private async Task initShippingLog(string orderId)
        {
            Response<List<ShippingLog>> logList = await APIHelper.Instance.Get<Response<List<ShippingLog>>>
                (ApiRoutes.Transport.getShippingLog.Replace("{id}", orderId));

            await Task.Factory.StartNew(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    foreach (var item in logList.Result)
                    {
                        DateTime dt = DateTime.Parse(item.date);
                        this.shippingLog.Text += $"[{dt.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)}] " +
                            $"{item.content}\n\n";
                    }
                });
            });
        }
    }
}
