
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Pulsar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isYellowToRed = true;
        private DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(200);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (isYellowToRed)
            {
                ChangeColor(Color.FromRgb(255, 255, 0), Color.FromRgb(255, 0, 0));
            }
            else
            {
                ChangeColor(Color.FromRgb(255, 0, 0), Color.FromRgb(255, 255, 0));
            }

            isYellowToRed = !isYellowToRed;
        }

        private void ChangeColor(Color from, Color to)
        {
            RadialGradientBrush brush = new RadialGradientBrush();

            GradientStop startStop = new GradientStop(from, 0);
            GradientStop endStop = new GradientStop(to, 1);

            brush.GradientStops.Add(startStop);
            brush.GradientStops.Add(endStop);

            circle.Fill = brush;

            DoubleAnimation animation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromMilliseconds(500)
            };

            startStop.BeginAnimation(GradientStop.OffsetProperty, animation);
            endStop.BeginAnimation(GradientStop.OffsetProperty, animation);
        }

    }
}