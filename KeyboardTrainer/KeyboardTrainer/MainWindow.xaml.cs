using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace KeyboardTrainer
{
    public partial class MainWindow : Window
    {
        enum Diffuculty
        {
            Easy = 0,
            Medium,
            Hard
        }

        private Button[] buttons;
        private bool IsStarted = false;
        private readonly Random random = new Random();
        private readonly DispatcherTimer timer = new DispatcherTimer();
        private Diffuculty CurrentDifficulty;
        private int totalPressed = 0;
        private int correctPressed = 0;


        public MainWindow()
        {
            InitializeComponent();

            buttons = new Button[] { ButtonZ, ButtonX, ButtonC, ButtonV, ButtonB, ButtonN, ButtonM,
            ButtonA, ButtonS, ButtonD, ButtonF, ButtonG, ButtonH, ButtonJ, ButtonK, ButtonL,
            ButtonQ, ButtonW, ButtonE, ButtonR, ButtonT, ButtonY, ButtonU, ButtonI, ButtonO, ButtonP,
            Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9, Button0, ButtonMin, ButtonPlus};

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            PreviewKeyDown += MainWindow_PreviewKeyDown;
            CurrentDifficulty = Diffuculty.Easy;

        }

        #region Slider using
        private void DifficultySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            switch (DifficultySlider.Value)
            {
                case 1:
                    CurrentDifficulty = Diffuculty.Easy;
                    timer.Interval = TimeSpan.FromSeconds(2);
                    break;
                case 2:
                    CurrentDifficulty = Diffuculty.Medium;
                    timer.Interval = TimeSpan.FromSeconds(1);
                    break;
                case 3:
                    CurrentDifficulty = Diffuculty.Hard;
                    timer.Interval = TimeSpan.FromSeconds(0.5);
                    break;
                default:
                    break;
            }
        }

        private void ChangeDifficultyInfo(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            switch (CurrentDifficulty)
            {
                case Diffuculty.Easy:
                    DifficultyInfo.Content = "Easy";
                    DifficultyInfo.Foreground = Brushes.Green;
                    break;
                case Diffuculty.Medium:
                    DifficultyInfo.Content = "Medium";
                    DifficultyInfo.Foreground = Brushes.Orange;
                    break;
                case Diffuculty.Hard:
                    DifficultyInfo.Content = "Hard";
                    DifficultyInfo.Foreground = Brushes.Red;
                    break;
            }
        }

        #endregion

        #region Training start/stop buttons
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();

            IsStarted = true;

            DifficultySlider.IsEnabled = false;
            StartButton.IsEnabled = false;
            StopButton.IsEnabled = true;
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();

            IsStarted = false;

            DifficultySlider.IsEnabled = true;
            StopButton.IsEnabled = false;
            StartButton.IsEnabled = true;

            InputLogBox.Text = String.Empty;
        }
        #endregion

        #region Main logic

        private void CalculateAndPrintAccuracy()
        {
            double accuracy = (double)correctPressed / totalPressed * 100;
            AccuracyInfo.Content = "Accuracy: " + accuracy.ToString("0.00") + "%";
        }
        #endregion

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (var button in buttons)
            {
                button.IsEnabled = false;
            }

            int randomIndex = random.Next(0, 35);
            buttons[randomIndex].IsEnabled = true;
        }

        private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            string keyText = e.Key.ToString();

            foreach (var button in buttons)
            {
                if (button.Content.ToString().Equals(keyText, StringComparison.OrdinalIgnoreCase) && button.IsEnabled)
                {
                    Button_Click(button, null);
                    break;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.IsEnabled = false;
            totalPressed++;

            string buttonText = clickedButton.Content.ToString();
            InputLogBox.AppendText(buttonText);

            if (clickedButton.IsEnabled)
            {
                correctPressed++;
            }


            CalculateAndPrintAccuracy();

        }
    }
}