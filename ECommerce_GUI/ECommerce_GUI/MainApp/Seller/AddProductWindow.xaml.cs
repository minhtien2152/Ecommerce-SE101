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
using Microsoft.Win32;
using Library.Models;
using FlightTicketManagement.Helper;
using ECommerce_GUI.Helper;

namespace ECommerce_GUI.MainApp.Seller
{
    /// <summary>
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public string shopId;
        List<ImageModel> listImg = new List<ImageModel>();

        public AddProductWindow() {
            this.shopId = ViewProduct.Instance.shopId;
            Console.WriteLine(this.shopId); 
            InitializeComponent();
        }

        private void chooseImg_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            fileDialog.Title = "Choose Shop Image";
            fileDialog.Multiselect = true;

            if (fileDialog.ShowDialog() == true) {
                foreach (string item in fileDialog.FileNames) {
                    ImageModel imgData = new ImageModel();

                    imgData.name = APIHelper.Instance.GenerateID();
                    imgData.data = System.IO.File.ReadAllBytes(item);
                    imgData.fileName = item;

                    listImg.Add(imgData); 
                    imageUrl.Text += $"\n{item}"; 
                }
            }
        }

        private void imageUrl_PreviewDragOver(object sender, DragEventArgs e) {
            e.Handled = true;
        }

        private void imageUrl_Drop(object sender, DragEventArgs e) {
            var validExtensions = new[] { ".png", ".jpg", ".jpeg", ".jpe", ".jfif" };
            var lst = (IEnumerable<string>)e.Data.GetData(DataFormats.FileDrop);

            foreach (var ext in lst.Select(f => System.IO.Path.GetExtension(f))) {
                if (!validExtensions.Contains(ext.ToLower())) {
                    e.Handled = true;
                    return;
                }
            }

            foreach (string item in (string[])e.Data.GetData(DataFormats.FileDrop)) {
                ImageModel imgData = new ImageModel();

                imgData.name = APIHelper.Instance.GenerateID();
                imgData.data = System.IO.File.ReadAllBytes(item);
                imgData.fileName = item;

                listImg.Add(imgData);
                imageUrl.Text += $"\n{item}";
            }
        }

        public void price_KeyDown(object sender, KeyEventArgs e) {
            // backspace press 
            if (e.Key == Key.Back)
                return;

            bool keyboardHandle = true;

            if (!e.Key.ToString().Contains("Oem")) {
                foreach (char item in e.Key.ToString()) {
                    if (char.IsDigit(item)) {
                        keyboardHandle = false;
                        break;
                    }
                }
            }
            e.Handled = keyboardHandle;
        }

        public void price_TextChanged(object sender, TextChangedEventArgs e) {
            string text = (sender as TextBox).Text;
            double value = 0.0f;

            if (text.Length > 2 && double.TryParse(text, out value)) {
                (sender as TextBox).Text = string.Format(System.Globalization.CultureInfo.CurrentCulture,
                    "{0:n0}", value);
                (sender as TextBox).CaretIndex = (sender as TextBox).Text.Length;
            }
        }

        private async void addProduct_Click(object sender, RoutedEventArgs e) {
            if (productName.Text == "" || productPrice.Text.Length < 4 || listImg.Count < 1) {
                MessageBox.Show("Invalid Input");
                return;
            }
            ProductCreate newProduct = new ProductCreate();
            newProduct.shopId = this.shopId;
            newProduct.productName = productName.Text;
            newProduct.quantity = int.Parse(quantity.Text);
            newProduct.price = double.Parse(productPrice.Text);
            newProduct.description = description.Text;
            newProduct.uploadDate = string.Format("{0:yyyy/MM/dd HH:mm:ss}", 
                DateTime.Now.ToString());
            newProduct.state = 0;

            Response<string> productCreate = await APIHelper.Instance.Post<Response<string>>
                (ApiRoutes.Shop.createProduct, newProduct); 

            foreach (var item in listImg) {
                ProductImage newImage = new ProductImage();
                newImage.productId = productCreate.Result;
                newImage.imageUrl = item.name;

                await APIHelper.Instance.Post<object>(ApiRoutes.Product.createProductImage, newImage);

                await APIHelper.Instance.UploadImage<object>(item);
            }
            this.DialogResult = true;
        }

        private void clearImg_Click(object sender, RoutedEventArgs e) {
            imageUrl.Text = "Drag And Drop Images Here";
            listImg.Clear();
        }

        private void quantity_KeyDown(object sender, KeyEventArgs e) {
            e.Handled = true;
        }
    }
}
