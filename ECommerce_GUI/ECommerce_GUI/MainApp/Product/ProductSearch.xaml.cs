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
    /// Interaction logic for ProductSearch.xaml
    /// </summary>
    public partial class ProductSearch : UserControl
    {
        public ProductSearch() {
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e) {
            CustomerWindow.Instance.removeUIElement(this);
            this.IsEnabled = false;
        }

        public async void initData(List<Library.Models.ProductSearch> searchList) {
            CustomerWindow.Instance.startWaitting();

            foreach (var item in searchList) {
                DisplayProduct newDisplay = new DisplayProduct();
                newDisplay.Margin = new Thickness(12);
                newDisplay.initData(item.ProductId);

                this.productSearchPanel.Children.Add(newDisplay);
            }
            CustomerWindow.Instance.endWatting();
        }
    }
}
