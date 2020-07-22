using ECommerce_GUI.MainApp;
using ECommerce_GUI.MainApp.Seller;
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
using System.Windows.Shapes;

namespace ECommerce_GUI.MainApp
{
    /// <summary>
    /// Interaction logic for Seller.xaml
    /// </summary>
    public partial class SellerWindow : Window
    {
        int shopFrontPageIndex = 2;

        public static SellerWindow Instance;

        public SellerWindow() {
            Instance = this;
            InitializeComponent();
        }

        private void tileBar_MouseDown(object sender, MouseButtonEventArgs e) {
            if (System.Windows.Input.Mouse.LeftButton == MouseButtonState.Pressed) {
                this.DragMove();
            }
        }

        public void startWaitting() {
            this.waitting.Visibility = Visibility.Visible;
        }

        public void endWaitting() {
            this.waitting.Visibility = Visibility.Hidden;
        }

        public void bringToFrontShop(UIElement value) {
            if (this.shopGrid.Children.Count <= 2) {
                shopFrontPageIndex = 2;
            }
            Canvas.SetZIndex(value, shopFrontPageIndex++);
        }

        public void sendToBackShop(UIElement value) {
            Canvas.SetZIndex(value, shopFrontPageIndex - 2);
        }

        public void addUIElement(Panel parent, UIElement value) {
            parent.Children.Add(value);
        }

        public void removeUIElement(Panel parent, UIElement value) {
            parent.Children.Remove(value);
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void minimizeBtn_Click(object sender, RoutedEventArgs e) {
            this.WindowState = WindowState.Minimized;
        }

        private void shop_Click(object sender, RoutedEventArgs e) {
            Canvas.SetZIndex(shopGrid, 1);
            Canvas.SetZIndex(moneyGrid, 0);

            List<ViewShop> checkList = shopGrid.Children.OfType<ViewShop>().ToList<ViewShop>();

            if (checkList.Count == 0) {
                ViewShop newView = new ViewShop();

                newView.initData();
                shopGrid.Children.Add(newView);
            }
        }

        private void totalSales_Click(object sender, RoutedEventArgs e) {
            Canvas.SetZIndex(shopGrid, 0);
            Canvas.SetZIndex(moneyGrid, 1);
        }

        private void addProduct_Click(object sender, RoutedEventArgs e) {
            AddProductWindow addProduct = new AddProductWindow();
            addProduct.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            addProduct.ShowDialog();
        }

        private void addShop_Click(object sender, RoutedEventArgs e) {
            AddShopWindow addShop = new AddShopWindow();
            addShop.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            addShop.ShowDialog();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e) {
            ViewShop newView = new ViewShop();

            newView.initData();
            shopGrid.Children.Add(newView);

            this.bringToFrontShop(newView);
        }

        private void customerChannel_Click(object sender, RoutedEventArgs e) {
            this.Hide();

            CustomerWindow.Instance.Show();
        }

        private void refresh_Click(object sender, RoutedEventArgs e) {
            shopGrid.Children.Clear();
            moneyGrid.Children.Clear();

            ViewShop newView = new ViewShop();

            newView.initData();
            shopGrid.Children.Add(newView);

            this.bringToFrontShop(newView);
        }
    }
}
