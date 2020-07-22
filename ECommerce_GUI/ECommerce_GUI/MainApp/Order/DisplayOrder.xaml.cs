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
    /// Interaction logic for DisplayOrder.xaml
    /// </summary>
    public partial class DisplayOrder : UserControl
    {
        public Library.Models.Order order = new Library.Models.Order();

        public DisplayOrder() {
            InitializeComponent();
        }

        public async void initData(Library.Models.Order value) {
            order = value;

            this.orderIDText.Text += order.OrderId.Substring(0, 20);

            if (order.isArrived == 1) {
                this.deliveryText.Text += "Delivered";
            }
            else this.deliveryText.Text += "Is Delivering";

            if (order.expectedShippingTime == "") {
                this.expectedShipTime.Text += "Processing";
            }
            else this.expectedShipTime.Text += string.Format("{0:dd/MM/yyyy HH:mm:ss}", order.expectedShippingTime);

            this.totalText.Text += string.Format("{0:N0} VNĐ", order.Total);

            if (order.isPaid == 1 && order.isArrived == 1 && order.customerRecived == 1) {
                receive.Content = "OK";
                receive.IsEnabled = false;
            }
            else {
                if (order.isArrived == 1)
                    receive.IsEnabled = true;
                else receive.IsEnabled = false;
            }
        }

        private void detail_Click(object sender, RoutedEventArgs e) {
            DetailOrder newDetail = new DetailOrder();
            newDetail.initData(order.OrderId);

            CustomerWindow.Instance.addUIElement(newDetail);
            CustomerWindow.Instance.bringToFront(newDetail);
        }

        private void receive_Click(object sender, RoutedEventArgs e) {

        }

        private void delete_Click(object sender, RoutedEventArgs e) {

        }
    }
}
