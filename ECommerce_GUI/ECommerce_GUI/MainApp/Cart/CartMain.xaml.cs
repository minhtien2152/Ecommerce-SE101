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
using Xceed.Wpf.Toolkit;

namespace ECommerce_GUI.MainApp.Cart
{
    /// <summary>
    /// Interaction logic for DisplayCart.xaml
    /// </summary>
    public partial class CartMain : UserControl
    {
        public static CartMain Instance;

        public TextBlock totalMoneyText = null;
        public double totalMoney = 0.0f;

        public CartMain() {
            Instance = this;
            InitializeComponent();
        }

        public void removeCart(UIElement cart) {
            cartPanel.Children.Remove(cart);
        }

        private void createButton() {
            StackPanel newPanel = new StackPanel();
            newPanel.Orientation = Orientation.Horizontal;
            newPanel.Margin = new Thickness(0, 10, 0, 10);

            Button checkoutButton = new Button();
            checkoutButton.Content = "Checkout Order";
            checkoutButton.Height = 50;
            checkoutButton.FontSize = 25;
            checkoutButton.Margin = new Thickness(0, 0, 10, 0);
            checkoutButton.Click += CheckoutClick;
            checkoutButton.Background = (Brush)(new BrushConverter().ConvertFrom("#FF3AB75F"));

            Button deleteButton = new Button();
            deleteButton.Content = "Delete Order";
            deleteButton.Height = 50;
            deleteButton.FontSize = 25;
            deleteButton.Margin = new Thickness(10, 0, 10, 0);
            deleteButton.Click += DeleteCheckoutClick;
            deleteButton.Background = (Brush)(new BrushConverter().ConvertFrom("#FFB73A3A"));

            newPanel.Children.Add(checkoutButton);
            newPanel.Children.Add(deleteButton);

            this.cartPanel.Children.Add(newPanel);
        }

        private async void CheckoutClick(object sender, RoutedEventArgs e) {
            if (!totalMoneyText.Text.Contains("Total"))
                return;

            AddressWindow getAddress = new AddressWindow();
            getAddress.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;

            Nullable<bool> dialogResult = getAddress.ShowDialog();

            MessageBoxResult onlinePayment = Xceed.Wpf.Toolkit.MessageBox.Show("Would you like to pay online ?",
                "onlinePayment", MessageBoxButton.YesNo);

            if (dialogResult == true) {
                Library.Models.Order newOrder = new Library.Models.Order();
                newOrder.UserId = AuthenticatedUser.user.UserId;
                newOrder.Address = getAddress.deliveryAddress;
                newOrder.Date = string.Format("{0:yyyy/MM/dd HH:mm:ss}", DateTime.Now.ToString());
                newOrder.isArrived = 0;
                newOrder.Total = totalMoney;

                if (onlinePayment == MessageBoxResult.Yes) {
                    string getBalanceUrl = ApiRoutes.Account.getCurrentBalance.Replace("{id}", AuthenticatedUser.user.UserId);
                    Response<double> currentBalance = await APIHelper.Instance.Get<Response<double>>(getBalanceUrl);

                    if (currentBalance.Result < totalMoney) {
                        Xceed.Wpf.Toolkit.MessageBox.Show("You dont have enough money", "onlinePayment", MessageBoxButton.OKCancel);
                        return;
                    }
                    else {
                        newOrder.isPaid = 1;
                        await makePaymentOnline(newOrder);
                    }
                }
                else {
                    newOrder.isPaid = 0;
                    await createOrderOnly(newOrder);
                }
            }
            else {
                return;
            }
        }

        private async Task createOrderOnly(Library.Models.Order value) {
            Response<string> orderId = await APIHelper.Instance.Post<Response<string>>
                (ApiRoutes.Order.createOrder, value);

            List<DisplayCart> listCart = this.cartPanel.Children.OfType<DisplayCart>().ToList<DisplayCart>();

            foreach (var item in listCart) {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.OrderId = orderId.Result;
                orderDetail.ProductId = item.cart.ProductId;
                orderDetail.Quantity = item.cart.Quantity;

                Response<object> orderDetailResponse = await APIHelper.Instance.Post<Response<object>>
                    (ApiRoutes.Order.createOrderDetail, orderDetail);
            }
            foreach (var item in listCart) {
                item.clearCart();
            }
        }

        private async Task makePaymentOnline(Library.Models.Order value) {
            Response<string> orderId = await APIHelper.Instance.Post<Response<string>>
                (ApiRoutes.Order.createOrder, value);

            List<DisplayCart> listCart = this.cartPanel.Children.OfType<DisplayCart>().ToList<DisplayCart>();

            foreach (var item in listCart) {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.OrderId = orderId.Result;
                orderDetail.ProductId = item.cart.ProductId;
                orderDetail.Quantity = item.cart.Quantity;

                Response<object> orderDetailResponse = await APIHelper.Instance.Post<Response<object>>
                    (ApiRoutes.Order.createOrderDetail, orderDetail);
                Response<object> paymentResponse = await APIHelper.Instance.Post<Response<object>>
                    (ApiRoutes.Account.makePayment, orderDetail);
            }
            foreach (var item in listCart) {
                item.clearCart();
            }
        }

        private async void DeleteCheckoutClick(object sender, RoutedEventArgs e) {
            CustomerWindow.Instance.startWaitting();

            List<DisplayCart> listCart = this.cartPanel.Children.OfType<DisplayCart>().ToList<DisplayCart>();

            foreach (var item in listCart) {
                await item.removeCart();
            }
            CustomerWindow.Instance.endWatting();
        }

        private void createTextBlock(string money) {
            totalMoneyText = new TextBlock();
            totalMoneyText.Text = money;
            totalMoneyText.FontSize = 35;
            totalMoneyText.Foreground = Brushes.Red;
            totalMoneyText.Margin = new Thickness(0, 20, 0, 0);

            this.cartPanel.Children.Add(totalMoneyText);
        }

        public void removeView() {
            CustomerWindow.Instance.removeUIElement(this);
            this.IsEnabled = false;
        }

        private void back_Click(object sender, RoutedEventArgs e) {
            removeView();
        }

        public async void initData() {
            CustomerWindow.Instance.startWaitting();

            Response<List<Library.Models.Cart>> response = await APIHelper.Instance.Get<Response<List<Library.Models.Cart>>>
                (ApiRoutes.Cart.GetCart.Replace("{userId}", AuthenticatedUser.user.UserId));

            await Task.Factory.StartNew(() => {
                this.Dispatcher.Invoke(() => {
                    foreach (var item in response.Result) {
                        DisplayCart newCart = new DisplayCart();
                        newCart.Margin = new Thickness(0, 10, 0, 10);
                        newCart.initData(item);

                        this.cartPanel.Children.Add(newCart);
                    }
                });
            });

            if (response.Result.Count > 0) {
                createTextBlock("loading");
                createButton();
            }

            CustomerWindow.Instance.endWatting();
        }
    }
}
