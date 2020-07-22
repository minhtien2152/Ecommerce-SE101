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
using System.IO;
using FlightTicketManagement.Helper;
using Library.Models;
using ECommerce_GUI.Helper;
using Microsoft.Win32;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

namespace ECommerce_GUI.MainApp.Seller
{
    /// <summary>
    /// Interaction logic for AddShopWindow.xaml
    /// </summary>
    public partial class AddShopWindow : Window
    {
        ImageModel imgData;

        public AddShopWindow() {
            InitializeComponent();
        }

        private async void shopImgUrl_Drop(object sender, DragEventArgs e) {
            var validExtensions = new[] { ".png", ".jpg", ".jpeg", ".jpe", ".jfif" };
            var lst = (IEnumerable<string>)e.Data.GetData(DataFormats.FileDrop);

            foreach (var ext in lst.Select(f => System.IO.Path.GetExtension(f))) {
                if (!validExtensions.Contains(ext.ToLower())) {
                    e.Handled = true;
                    return;
                }
            }

            string imageDir = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];

            imgData = new ImageModel();
            this.imgData.name = APIHelper.Instance.GenerateID();
            this.imgData.data = System.IO.File.ReadAllBytes(imageDir);
            this.imgData.fileName = imageDir;

            e.Effects = DragDropEffects.Link;

            (sender as TextBox).Text = imageDir;
        }

        private async void addShopBtn_Click(object sender, RoutedEventArgs e) {
            if (imgData == null || shopName.Text == "") {
                MessageBox.Show("Invalid Input");
                return;
            }
            await APIHelper.Instance.UploadImage<object>(this.imgData);

            Shop newShop = new Shop();
            newShop.userId = AuthenticatedUser.user.UserId;
            newShop.shopName = this.shopName.Text;
            newShop.shopImageUrl = this.imgData.name;

            await APIHelper.Instance.Post<object>(ApiRoutes.Shop.createShop, newShop);

            this.DialogResult = true;
        }

        private void shopImgUrl_PreviewDragOver(object sender, DragEventArgs e) {
            e.Handled = true;
        }

        private void chooseImage_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            fileDialog.Title = "Choose Shop Image";

            if (fileDialog.ShowDialog() == true) {

                string imageDir = fileDialog.FileNames[0];

                imgData = new ImageModel();
                this.imgData.name = APIHelper.Instance.GenerateID();
                this.imgData.data = System.IO.File.ReadAllBytes(imageDir);
                this.imgData.fileName = imageDir;

                shopImgUrl.Text = imageDir;
            } 
        }
    }
}
