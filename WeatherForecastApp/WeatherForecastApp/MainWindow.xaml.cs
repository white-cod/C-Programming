using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Newtonsoft.Json;

namespace WeatherForecastApp
{
    public partial class MainWindow : Window
    {
        private const string ApiKey = "0eabf055a07f534ccae79232c9e542fe";
        private const string ApiEndpoint = "https://api.openweathermap.org/data/2.5/onecall";

        public SeriesCollection TemperatureSeries { get; set; }
        public string[] TemperatureLabels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            TemperatureSeries = new SeriesCollection();
            TemperatureLabels = new string[0];

            Formatter = value => value.ToString("N1");

            DataContext = this;
        }

        private async void GetForecast_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double latitude = double.Parse(LatitudeTextBox.Text);
                double longitude = double.Parse(LongitudeTextBox.Text);

                string apiUrl = $"{ApiEndpoint}?lat={latitude}&lon={longitude}&units=metric&lang=ua&appid={ApiKey}";

                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync(apiUrl);
                    var forecast = JsonConvert.DeserializeObject<WeatherForecast>(json);

                    UpdateTemperatureGraph(forecast);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateTemperatureGraph(WeatherForecast forecast)
        {
            TemperatureSeries.Clear();

            var temperatures = new ChartValues<ObservablePoint>();

            foreach (var hourlyForecast in forecast.Hourly)
            {
                temperatures.Add(new ObservablePoint
                {
                    X = hourlyForecast.Dt,
                    Y = hourlyForecast.Temp
                });
            }

            TemperatureSeries.Add(new LineSeries
            {
                Title = "Temperature",
                Values = temperatures
            });

            TemperatureLabels = new string[forecast.Hourly.Length];
            for (int i = 0; i < forecast.Hourly.Length; i++)
            {
                TemperatureLabels[i] = forecast.Hourly[i].Dt.ToString("HH:mm");
            }

            RaisePropertyChanged(nameof(TemperatureSeries));
            RaisePropertyChanged(nameof(TemperatureLabels));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public class WeatherForecast
        {
            public HourlyForecast[] Hourly { get; set; }
        }

        public class HourlyForecast
        {
            public long Dt { get; set; }
            public required Main Main { get; set; }
            public double Temp { get; internal set; }
        }

        public class Main
        {
            public double Temp { get; set; }
            public double Humidity { get; set; }
        }
    }

}