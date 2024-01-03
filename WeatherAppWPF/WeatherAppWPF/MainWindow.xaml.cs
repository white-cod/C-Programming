using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
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
using LiveCharts.Defaults;

namespace WeatherAppWPF
{
    public partial class MainWindow : Window
    {
        private const string API_KEY = "0eabf055a07f534ccae79232c9e542fe";
        private DispatcherTimer timer = new DispatcherTimer();
        private string CurrentCity;
        public WeatherData CurrentWeather { get; set; } = new WeatherData();
        public SeriesCollection TemperatureValues { get; set; } = new SeriesCollection();
        public SeriesCollection TemperatureSeries { get; set; } = new SeriesCollection();
        public List<string> TemperatureLabels { get; set; } = new List<string>();

        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(60);
            timer.Tick += TimerAsyncMakeRequestAndDisplay;
        }

        private async Task<bool> GetWeatherFromAPI()
        {
            using (var client = new HttpClient())
            {
                string url = $"https://api.openweathermap.org/data/2.5/weather?q={CurrentCity}&appid={API_KEY}";

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    WeatherData weatherData = JsonSerializer.Deserialize<WeatherData>(content);

                    CurrentWeather = weatherData;
                    return true;
                }
                return false;
            }
        }


        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
            {
                timer.Stop();
            }

            CurrentCity = SearchBox.Text;

            await AsyncMakeRequestAndDisplay();
            timer.Start();
        }

        private async Task DisplayData()
        {
            if (CurrentWeather == null) return;

            CityBlock.Text = "City: " + CurrentWeather.name;
            Temperature.Text = "Temperature C: " + (Math.Round(CurrentWeather.main.temp - 273, 1)).ToString();
            Lon.Text = "Lon: " + CurrentWeather.coord.lon.ToString();
            Lat.Text = "Lat: " + CurrentWeather.coord.lat.ToString();

            TemperatureSeries.Clear();
            TemperatureLabels.Clear();

            var temperatureValue = Math.Round(CurrentWeather.main.temp - 273, 1);

            TemperatureSeries.Add(new LineSeries
            {
                Title = "Temperature",
                Values = new ChartValues<ObservableValue> { new ObservableValue(temperatureValue) }
            });

            TemperatureLabels.Add("Label1");

            TemperatureChart.Series = TemperatureSeries;
        }



        private async void TimerAsyncMakeRequestAndDisplay(object sender, EventArgs e)
        {
            await AsyncMakeRequestAndDisplay();
            UpdateChart();
        }

        private void UpdateChart()
        {
            DisplayData();
        }

        private async Task AsyncMakeRequestAndDisplay()
        {
            if (String.IsNullOrEmpty(SearchBox.Text)) return;

            if (await GetWeatherFromAPI())
            {
                DisplayData();
                SearchErrorLabel.Visibility = Visibility.Collapsed;
            }
            else
            {
                SearchErrorLabel.Visibility = Visibility.Visible;
            }
        }


        ///////////////////////////////
        ///

        public class Weather
        {
            public string main { get; set; }
            public string description { get; set; }

            [Newtonsoft.Json.JsonConstructor]
            public Weather(string main, string description)
            {
                this.description = description;
                this.main = main;
            }
        }

        public class Coord
        {
            public double lon { get; set; }
            public double lat { get; set; }

            [Newtonsoft.Json.JsonConstructor]
            public Coord(double lon, double lat)
            {
                this.lon = lon;
                this.lat = lat;
            }
        }

        public class Sys
        {
            public string country { get; set; }
            [Newtonsoft.Json.JsonConstructor]
            public Sys(string country)
            {
                this.country = country;
            }
        }

        public class Main
        {
            public double temp { get; set; }
            public double feels_like { get; set; }

            [Newtonsoft.Json.JsonConstructor]
            public Main(double temp, double feels_like)
            {
                this.temp = temp;
                this.feels_like = feels_like;
            }
        }

        public class Wind
        {
            public double speed { get; set; }
            [Newtonsoft.Json.JsonConstructor]
            public Wind(double speed)
            {
                this.speed = speed;
            }
        }

        public class WeatherData
        {
            public Coord coord { get; set; }
            public Main main { get; set; }
            public Sys sys { get; set; }
            public Wind wind { get; set; }
            public List<Weather> weather { get; set; }
            public string base_ { get; set; }
            public string name { get; set; }
            public int dt { get; set; }

            public WeatherData() { }

            [Newtonsoft.Json.JsonConstructor]
            public WeatherData(Coord coord, Main main, Sys sys, Wind wind, List<Weather> weather, string base_, string name, int dt)
            {
                this.coord = coord;
                this.main = main;
                this.sys = sys;
                this.wind = wind;
                this.weather = weather;
                this.base_ = base_;
                this.name = name;
                this.dt = dt;
            }


        }
    }
}