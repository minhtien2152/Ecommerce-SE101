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

namespace ECommerce_GUI.Login
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>

    public partial class SignUp : UserControl
    {
        public SignUp() {
            InitializeComponent();
        }

        private async void signup_Click(object sender, RoutedEventArgs e) {
            Account newUser = new Account();

            newUser.Name = name.Text;
            newUser.userName = username.Text;
            newUser.password = password.Password.ToString();
            newUser.phoneNum = phoneNumer.Text;
            newUser.Address = address.Text;
            newUser.email = email.Text;

            Response<object> responsce = await APIHelper.Instance.Post<Response<object>>
                (ApiRoutes.Account.signup, newUser);

            if (responsce.IsSuccess) {
                MainWindow.Instance.showLogin();
            }
            else {
                MessageBox.Show("sign up failed");
            }
        }

        private void backToLogin_Click(object sender, RoutedEventArgs e) {
            MainWindow.Instance.showLogin();
        }
    }
}
