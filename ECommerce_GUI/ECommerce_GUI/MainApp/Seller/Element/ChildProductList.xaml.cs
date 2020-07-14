using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ECommerce_GUI.MainApp.Seller.Element
{
    /// <summary>
    /// Interaction logic for ChildProductList.xaml
    /// </summary>
    public partial class ChildProductList : UserControl
    {
        private int price;
        private int soldnumber;
        private int inventorynumber;
        private string name;
        private string id;

        public string ProductName { get => name;set { name = value; tbName.Text = name; }}
        public int Price { get => price; set { price = value; } }
        public int Soldnumber { get => soldnumber; set { soldnumber = value;} }
        public int Inventorynumber { get => inventorynumber; set { inventorynumber = value; } }
        public string Id { get => id; set => id = value; }
        public bool IsChecked { get; set; }
        public delegate void OnSelected(string id);
        public event OnSelected Selected;


        public ChildProductList()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Selected!=null)
                Selected(id);
        }
    }
}
