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

namespace Pulsar1
{
    public partial class MainWindow : Window
    {
        private Ellipse circle;
        private bool isYellowToRed = true;
        private int colorValue = 255;
        private DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            InitializeCircle();
            InitializeTimer();
        }

        private void InitializeCircle()
        {
            circle = new Ellipse();
            circle.Width = 200;
            circle.Height = 200;
            circle.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 0)); // Start with yellow
            Canvas.SetLeft(circle, canvas.ActualWidth / 2 - circle.Width / 2);
            Canvas.SetTop(circle, canvas.ActualHeight / 2 - circle.Height / 2);
            canvas.Children.Add(circle);
        }

        private void InitializeTimer()
        {
            timer.Interval = TimeSpan.FromMilliseconds(50);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (isYellowToRed)
                colorValue -= 2; // Gradually change color value from yellow to red
            else
                colorValue += 2; // Gradually change color value from red to yellow

            if (colorValue <= 0 || colorValue >= 255)
                isYellowToRed = !isYellowToRed;

            Color newColor = isYellowToRed ? Color.FromRgb(255, (byte)colorValue, 0) : Color.FromRgb(255, 255, (byte)colorValue);
            circle.Fill = new SolidColorBrush(newColor);
        }
    }
}
