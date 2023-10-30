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

namespace AppWithButtons
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void openButton_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush gradientBrush = new SolidColorBrush(Color.FromRgb(255, 255, 0));
            textBox1.Background = new LinearGradientBrush(Colors.Red, Colors.Yellow, 45.0);
            textBox2.Background = new LinearGradientBrush(Colors.Red, Colors.Yellow, 45.0);
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text))
            {
                this.Close();
            }
        }

        private void appearanceDropdown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedValue = (appearanceDropdown.SelectedItem as ComboBoxItem)?.Content?.ToString();

            if (selectedValue == "Option 1")
            {
                textBox1.FontFamily = new FontFamily("Arial");
                textBox2.FontFamily = new FontFamily("Arial");
                textBox1.FontSize = 12;
                textBox2.FontSize = 12;
                textBox1.Foreground = Brushes.Black;
                textBox2.Foreground = Brushes.Black;
            }
            else if (selectedValue == "Option 2")
            {
                textBox1.FontFamily = new FontFamily("Verdana");
                textBox2.FontFamily = new FontFamily("Verdana");
                textBox1.FontSize = 14;
                textBox2.FontSize = 14;
                textBox1.Foreground = Brushes.Blue;
                textBox2.Foreground = Brushes.Blue;
            }
        }

    }

}
