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

namespace ECommerce_GUI.MainApp.Product
{
    /// <summary>
    /// Interaction logic for ProductMain.xaml
    /// </summary>
    public partial class ProductMain : UserControl
    {
        public ProductMain() {
            InitializeComponent();
        }

        public async void refreshData() {
            CustomerWindow.Instance.startWaitting();

            Response<List<string>> topSellingId = await APIHelper.Instance.Get<Response<List<string>>>
                (ApiRoutes.Product.getTopSellingProductId);

            Response<List<string>> allProductId = await APIHelper.Instance.Get<Response<List<string>>>
                (ApiRoutes.Product.getAllProductId);

            await initTopSelling(topSellingId.Result);
            await initAllProduct(allProductId.Result);

            CustomerWindow.Instance.endWatting();
        }

        public async Task initTopSelling(List<string> topSellingId) {
            await Task.Factory.StartNew(() => {
                foreach (string id in topSellingId) {
                    this.Dispatcher.Invoke(() => {
                        DisplayProduct product = new DisplayProduct();
                        product.Margin = new Thickness(12);
                        product.initData(id);

                        topSellingProductPanel.Children.Add(product);
                    });
                }
            });
        }

        public async Task initAllProduct(List<string> allProductId) {
            await Task.Factory.StartNew(() => {
                foreach (string id in allProductId) {
                    this.Dispatcher.Invoke(() => {
                        DisplayProduct product = new DisplayProduct();
                        product.Margin = new Thickness(12);
                        product.initData(id);

                        allProductPanel.Children.Add(product);
                    });
                }
            });
        }
    }
}
