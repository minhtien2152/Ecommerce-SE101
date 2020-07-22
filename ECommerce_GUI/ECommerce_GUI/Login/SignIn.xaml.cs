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
using ECommerce_GUI.Helper;
using ECommerce_GUI.MainApp;
using FlightTicketManagement.Helper;
using Library.Models;

namespace ECommerce_GUI.Login
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : UserControl
    {
        public SignIn() {
            InitializeComponent();
        }

        private async void signin_Click(object sender, RoutedEventArgs e) {
            if (await APIHelper.Instance.Authenticate(username.Text, password.Password.ToString())) {
                MainWindow.Instance.Hide();

                CustomerWindow app = new MainApp.CustomerWindow();
                app.Closed += App_Closed;
                app.Show();
            }
            else {
                MessageBox.Show("sign in failed");
            }
        }

        private void App_Closed(object sender, EventArgs e) {
            MainWindow.Instance.Close();
        }

        private void noAccount_Click(object sender, RoutedEventArgs e) {
            MainWindow.Instance.showSignUp();
        }
    }
}
