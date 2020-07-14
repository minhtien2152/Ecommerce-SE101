using ECommerce_GUI.MainApp.Seller.Element;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ECommerce_GUI.MainApp.Seller
{
    /// <summary>
    /// Interaction logic for UCAllProducts.xaml
    /// </summary>
    public partial class UCAllProducts : UserControl
    {
        public BindingList<ChildProductList> Products { get; set; }

        public UCAllProducts()
        {
            InitializeComponent();
            Random random = new Random();
            string[] name = new string[] { "Quần đùi", "Áo ba lỗ", "Kính", "Laptop", "Giày Gucci" };

            for (int i = 0; i < 10; i++)
            {
                ChildProductList childProductList = new ChildProductList()
                {
                    ProductName = name[random.Next(0, 4)],
                    Price = random.Next(1000, 1000000),
                    Inventorynumber = random.Next(1, 100),
                    Soldnumber = random.Next(1, 100),
                };
                childProductList.Selected += UCAllProducts_Selected;
                lvProduct.Items.Add(childProductList);
            }
        }
        private void UCAllProducts_Selected(string id)
        {
            DetailProduct detailProduct = new DetailProduct();
            detailProduct.ShowDialog();
        }
    }
}
