using ECommerce_GUI.Helper;
using ECommerce_GUI.MainApp.Cart;
using ECommerce_GUI.MainApp.Order;
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
using System.Windows.Shapes;
using ToastNotifications;
using ToastNotifications.Display;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;
using ToastNotifications.Utilities;

namespace ECommerce_GUI.MainApp
{
    /// <summary>
    /// Interaction logic for MainApp.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        public static CustomerWindow Instance;
        int frontPageIndex = 2;

        public Notifier notifier;

        public CustomerWindow()
        {
            Instance = this;
            InitializeComponent();

            ControlPositionProvider displayRegion = new ControlPositionProvider
                (this, this.toastNotificationArea, Corner.TopRight, 5, 5);

            this.notifier = new Notifier(x =>
            {
                x.PositionProvider = displayRegion; 
                x.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                    notificationLifetime: TimeSpan.FromSeconds(5),
                    maximumNotificationCount: MaximumNotificationCount.FromCount(5));
                x.Dispatcher = Application.Current.Dispatcher;
            });
        }

        public void bringToFront(UIElement value)
        {
            if (this.controlGrid.Children.Count <= 2)
            {
                frontPageIndex = 2;
            }
            Canvas.SetZIndex(value, frontPageIndex++);
        }

        public void sendToBack(UIElement value)
        {
            Canvas.SetZIndex(value, frontPageIndex - 2);
        }

        public void addUIElement(UIElement value)
        {
            this.controlGrid.Children.Add(value);
        }

        public void removeUIElement(UIElement value)
        {
            this.controlGrid.Children.Remove(value);
        }

        public void startWaitting()
        {
            watting.Visibility = Visibility.Visible;
        }

        public void endWatting()
        {
            watting.Visibility = Visibility.Hidden;
        }

        private void tileBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void sellerPage_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            SellerWindow app = new SellerWindow();
            app.Closed += App_Closed;
            app.Show();
        }

        private void App_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            username.Content = AuthenticatedUser.user.userName;

            ProductMain products = new ProductMain();
            this.addUIElement(products);
            this.bringToFront(products);

            products.refreshData();
        }

        private void cart_Click(object sender, RoutedEventArgs e)
        {
            var check = this.controlGrid.Children.OfType<CartMain>();

            if (check.ToList().Count > 0)
                return;

            CartMain cartView = new CartMain();
            cartView.initData();

            this.addUIElement(cartView);
            this.bringToFront(cartView); 
        }

        private async void rechargeAccount_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow.Instance.startWaitting();

            RechargeWindow recharge = new RechargeWindow();
            recharge.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            Nullable<bool> dialogResult = recharge.ShowDialog();

            if (dialogResult == true)
            {
                AccountMoney moneyAdd = new AccountMoney();
                moneyAdd.UserId = AuthenticatedUser.user.UserId;
                moneyAdd.moneyAdd = recharge.money;

                Response<object> response = await APIHelper.Instance.Post<Response<object>>
                    (ApiRoutes.Account.rechargeAccount, moneyAdd);
            }
            CustomerWindow.Instance.endWatting();
        }

        private void homePage_Click(object sender, RoutedEventArgs e)
        {
            this.controlGrid.Children.Clear();

            ProductMain products = new ProductMain();
            this.addUIElement(products);
            this.bringToFront(products);

            products.refreshData();
        }

        private void orders_Click(object sender, RoutedEventArgs e)
        {
            OrderMain orders = new OrderMain();
            this.addUIElement(orders);
            this.bringToFront(orders);

            orders.initData();
        }
    }
}