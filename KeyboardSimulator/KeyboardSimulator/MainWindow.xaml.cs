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
using System.Windows.Threading;

namespace KeyboardSimulator
{
    public partial class MainWindow : Window
    {
        private Random random = new Random();
        private DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            // Initialize timer
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

        private void StartTraining_Click(object sender, RoutedEventArgs e)
        {
            int difficulty = (int)DifficultySlider.Value;

            for (int i = 0; i < difficulty; i++)
            {
                int randomIndex = random.Next(0, 26);
                char letter = (char)('A' + randomIndex);
                KeyboardButton.Content = letter.ToString();
                KeyboardButton.IsEnabled = true;
            }

            timer.Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KeyboardButton.IsEnabled = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            KeyboardButton.IsEnabled = true;
        }
    }
}
