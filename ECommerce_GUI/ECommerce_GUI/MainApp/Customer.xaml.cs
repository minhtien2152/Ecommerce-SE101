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
    /// Interaction logic for MainApp.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        public CustomerWindow()
        {
            InitializeComponent();
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
    }
}
