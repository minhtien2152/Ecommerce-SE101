using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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

namespace ECommerce_GUI.MainApp.Seller
{
    /// <summary>
    /// Interaction logic for DetailProduct.xaml
    /// </summary>
    public partial class DetailProduct : Window
    {
        public BindingList<ImageSource> ProductImages { get; set; }
        public BindingList<ImageSource> ListAddImage { get; set; }
        public BindingList<ImageSource> ListDelImage { get; set; }


        public BitmapImage link { get; set; }

        public DetailProduct()
        {
            InitializeComponent();
            ListDelImage = new BindingList<ImageSource>();
            ListAddImage = new BindingList<ImageSource>();
            ProductImages = new BindingList<ImageSource>();
            for (int i = 0; i < 10; i++)
            {
                ProductImages.Add(new BitmapImage(new Uri(@"https://letranhung.vn/images/logo.png")));
            }
            lvImage.ItemsSource = ProductImages;

        }

        private void DelProduct_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImageSource imageSource = ((Border)sender).Tag as ImageSource;
            ListDelImage.Add(imageSource);
            ProductImages.Remove(imageSource);

        }

        private void addProduct_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == true)
            {
                foreach (string filename in fileDialog.FileNames)
                {
                    ListAddImage.Add(new BitmapImage(new Uri(filename)));
                    ProductImages.Add(new BitmapImage(new Uri(filename)));
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
