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
        private List<Control> controls;

        public SellerWindow()
        {
            InitializeComponent();
            controls = new List<Control>();
        }

        private void btnAllPro_Click(object sender, RoutedEventArgs e)
        {
            ActiveUserControl(typeof(UCAllProducts));
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnmini_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        bool stateWin = false;
        private void btnMaxi_Click(object sender, RoutedEventArgs e)
        {
            if (stateWin)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
            stateWin = !stateWin;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void btnAddPro_Click(object sender, RoutedEventArgs e)
        {
            ActiveUserControl(typeof(UCDetailProduct));
        }

        private void ActiveUserControl(Type type)
        {
            Control control = controls.Find(x => x.GetType() == type);
            if (control == null)
            {
                control = (Control)Activator.CreateInstance(type);
                controls.Add(control);
            }
            ActiveItem.Content = control;
        }
    }
}
