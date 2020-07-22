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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace ECommerce_GUI.MainApp
{
    /// <summary>
    /// Interaction logic for RechargeWindow.xaml
    /// </summary>
    public partial class RechargeWindow : Window
    {
        public double money;

        public RechargeWindow() {
            InitializeComponent();
        }

        private void moneyBox_KeyDown(object sender, KeyEventArgs e) {
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

        private void moneyBox_TextChanged(object sender, TextChangedEventArgs e) {
            string text = (sender as TextBox).Text;
            double value = 0.0f;

            if (text.Length > 2 && double.TryParse(text, out value)) {
                (sender as TextBox).Text = string.Format(System.Globalization.CultureInfo.CurrentCulture,
                    "{0:n0}", value);
                (sender as TextBox).CaretIndex = (sender as TextBox).Text.Length;
            }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e) {
            money = double.Parse(moneyBox.Text);
            this.DialogResult = true;
        }
    }
}
