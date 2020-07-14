using ECommerce_GUI.Helper;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ECommerce_GUI.MainApp.Cart
{
    /// <summary>
    /// Interaction logic for DisplayCart.xaml
    /// </summary>
    public partial class DisplayCart : UserControl
    {
        public Library.Models.Cart cart = new Library.Models.Cart();
        public double unitPrice; 

        public DisplayCart()
        {
            InitializeComponent();
        }

        public async void initData(Library.Models.Cart value)
        {
            cart = value;

            Response<ProductDisplay> display = await APIHelper.Instance.Get<Response<ProductDisplay>>
                (ApiRoutes.Product.getProductDisplay.Replace("{id}", value.ProductId));

            await loadUrlImg(display.Result.ImgURL);
            productName.Text = display.Result.ProductName;
            productPrice.Text = string.Format("{0:N0}", display.Result.Price);
            productQuantity.Text = string.Format("Quantity: {0}", value.Quantity.ToString());

            unitPrice = display.Result.Price; 

            CartMain.Instance.totalMoney += value.Quantity * display.Result.Price;
            if (CartMain.Instance.totalMoneyText != null)
            {
                CartMain.Instance.totalMoneyText.Text = string.Format
                    ("Total: {0:N0} VNĐ", CartMain.Instance.totalMoney); 
            }
        }

        public async Task loadUrlImg(string url)
        {
            await Task.Factory.StartNew(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(url, UriKind.Absolute);
                    bitmap.EndInit();

                    productImg.Source = bitmap;
                    productImg.Stretch = Stretch.Fill;
                });
            });
        }

        private void buyMore_Click(object sender, RoutedEventArgs e)
        {
            DetailProduct buyMore = new DetailProduct();
            buyMore.initData(cart.ProductId);

            CustomerWindow.Instance.addUIElement(buyMore);
            CustomerWindow.Instance.bringToFront(buyMore);

            CartMain.Instance.removeView();

            CustomerWindow.Instance.endWatting();
        }

        public async Task removeCart()
        {
            CartMain.Instance.totalMoney -= cart.Quantity * unitPrice;
            if (CartMain.Instance.totalMoneyText != null)
            {
                CartMain.Instance.totalMoneyText.Text = string.Format
                    ("Total: {0:N0} VNĐ", CartMain.Instance.totalMoney);
            }

            Response<object> response = await APIHelper.Instance.Post<Response<object>>
                (ApiRoutes.Cart.DeleteCart, cart);

            CartMain.Instance.removeCart(this);

            List<DisplayCart> currentCarts = CartMain.Instance.cartPanel.Children.OfType<DisplayCart>().
                ToList<DisplayCart>();

            if (currentCarts.Count <= 1)
            {
                CartMain.Instance.removeView();
            }
            this.IsEnabled = false;
        }

        public async void clearCart()
        {
            Response<object> response = await APIHelper.Instance.Post<Response<object>>
                (ApiRoutes.Cart.ClearCart, cart);

            CartMain.Instance.removeCart(this);

            List<DisplayCart> currentCarts = CartMain.Instance.cartPanel.Children.OfType<DisplayCart>().
                ToList<DisplayCart>();

            if (currentCarts.Count <= 1)
            {
                CartMain.Instance.removeView();
            }
            this.IsEnabled = false;
        }

        private async void deleteCart_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow.Instance.startWaitting();

            await removeCart();

            CustomerWindow.Instance.endWatting();
        }
    }
}
