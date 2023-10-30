using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace SimpleTextEditorWPF
{
    public partial class MainWindow : Window
    {
        public List<string> foregroundColors { get; set; } = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            ForegroundSelector.DataContext = this;
            foreach (PropertyInfo propertyInfo in typeof(Brushes).GetProperties())
            {
                if (propertyInfo.PropertyType == typeof(SolidColorBrush))
                {
                    SolidColorBrush brush = (SolidColorBrush)propertyInfo.GetValue(null, null);
                    foregroundColors.Add(brush.Color.ToString());
                }
            }
            ForegroundSelector.ItemsSource = foregroundColors;
        }

        private void SizeBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender != null && !string.IsNullOrEmpty(((TextBox)sender).Text))
            {
                if (!int.TryParse(((TextBox)sender).Text, out int size))
                {
                    ((TextBox)sender).Text = "14";
                }
            }
        }
    }
}