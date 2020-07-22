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

namespace ECommerce_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance;

        public MainWindow() {
            Instance = this;
            InitializeComponent();
        }

        private void mainCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            this.DragMove();
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        public void showLogin() {
            signinCtrl.Visibility = Visibility.Visible;
            signupCtrl.Visibility = Visibility.Hidden;
        }

        public void showSignUp() {
            signinCtrl.Visibility = Visibility.Hidden;
            signupCtrl.Visibility = Visibility.Visible;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {

        }
    }
}
