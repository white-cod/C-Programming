using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Olympiada_App;
using static Olympiada_App.OlympiadDataModel;

namespace OlympiadApp
{
    public partial class MainWindow : Window
    {
        private readonly OlympiadDbContext dbContext = new OlympiadDbContext();

        public MainWindow()
        {
            InitializeComponent();
            LoadOlympiads();
            LoadSports();
            LoadCountries();
            LoadMedalStandings();
            LoadMedalists();
            LoadMostGoldMedalsCountry();
            LoadMostGoldMedalsInSport();
            LoadCountryWithMostHostedOlympiads();
            LoadOlympicTeamComposition();
            LoadCountryPerformanceStatistics();
            LoadAthletes();
        }
        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadOlympiads();
            LoadSports();
            LoadCountries();
            LoadMedalStandings();
            LoadMedalists();
            LoadMostGoldMedalsCountry();
            LoadMostGoldMedalsInSport();
            LoadCountryWithMostHostedOlympiads();
            LoadOlympicTeamComposition();
            LoadCountryPerformanceStatistics();
            LoadAthletes();
        }

        private void LoadSports()
        {
            sportComboBox.ItemsSource = dbContext.Sports.ToList();
            var sports = dbContext.Sports.ToList();
            sportsDataGrid.ItemsSource = sports;
        }

        private void LoadOlympiads()
        {
            var olympiads = dbContext.GetOlympiads().ToList();
            olympiadComboBox.ItemsSource = olympiads;
            olympiadComboBox.DisplayMemberPath = "Year";
            olympiadsDataGrid.ItemsSource = olympiads;
        }

        private void LoadAthletes()
        {
            var athletes = dbContext.Athletes.ToList();
            athletesDataGrid.ItemsSource = athletes;
        }

        private void LoadMedalStandings()
        {
            if (olympiadComboBox.SelectedItem != null)
            {
                int selectedOlympiadId = ((Olympiad)olympiadComboBox.SelectedItem).OlympiadId;
                var medalStandings = dbContext.GetMedalStandingsForOlympiad(selectedOlympiadId);
                medalStandingsDataGrid.ItemsSource = medalStandings.ToList();
            }
        }

        private void LoadMedalists()
        {
            if (olympiadComboBox.SelectedItem != null)
            {
                int selectedOlympiadId = ((Olympiad)olympiadComboBox.SelectedItem).OlympiadId;
                var medalists = dbContext.GetMedalistsForOlympiad(selectedOlympiadId);
                medalistsDataGrid.ItemsSource = medalists.ToList();
            }
        }

        private void LoadCountries()
        {
            countryComboBox.ItemsSource = dbContext.Athletes.Select(a => a.Country).Distinct().ToList();
        }

        private void olympiadComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            LoadMedalStandings();
            LoadMedalists();
            LoadMostGoldMedalsCountry();
            LoadMostGoldMedalsInSport();
            LoadCountryWithMostHostedOlympiads();
            LoadCountryPerformanceStatistics();
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabItem selectedTab = (TabItem)tabControl.SelectedItem;

            if (selectedTab != null && selectedTab.Header.ToString() == "Medal Standings")
            {
                LoadMedalStandings();
            }

            if (selectedTab != null && selectedTab.Header.ToString() == "Medalists")
            {
                LoadMedalists();
            }

            if (selectedTab != null && selectedTab.Header.ToString() == "Most Gold Medals")
            {
                LoadMostGoldMedalsCountry();
            }

            if (selectedTab != null && selectedTab.Header.ToString() == "Country Performance Statistics")
            {
                LoadCountryPerformanceStatistics();
            }
        }

        private void LoadMostGoldMedalsCountry()
        {
            if (olympiadComboBox.SelectedItem != null)
            {
                int selectedOlympiadId = ((Olympiad)olympiadComboBox.SelectedItem).OlympiadId;
                string mostGoldMedalsCountry = dbContext.GetCountryWithMostGoldMedals(selectedOlympiadId);

                if (!string.IsNullOrEmpty(mostGoldMedalsCountry))
                {
                    mostGoldMedalsCountryTextBlock.Text = mostGoldMedalsCountry;
                }
            }
        }

        private void mostGoldMedalsTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadMostGoldMedalsCountry();
        }

        private void LoadMostGoldMedalsInSport()
        {
            if (sportComboBox.SelectedItem != null)
            {
                int selectedSportId = ((Sport)sportComboBox.SelectedItem).SportId;
                var mostGoldMedalsInSport = dbContext.GetMostGoldMedalsInSport(selectedSportId);

                mostGoldMedalsInSportDataGrid.ItemsSource = mostGoldMedalsInSport.ToList();
            }
        }

        private void LoadCountryWithMostHostedOlympiads()
        {
            var mostHostedCountry = dbContext.GetCountryWithMostHostedOlympiads();

            if (!string.IsNullOrEmpty(mostHostedCountry))
            {
                mostHostedCountryTextBlock.Text = mostHostedCountry;
            }
        }
        
        private void LoadOlympicTeamComposition()
        {
            if (countryComboBox.SelectedItem != null)
            {
                string selectedCountry = countryComboBox.SelectedItem.ToString();
                var olympicTeamComposition = dbContext.GetOlympicTeamComposition(selectedCountry);

                olympicTeamCompositionDataGrid.ItemsSource = olympicTeamComposition.ToList();
            }
        }

        private void LoadCountryPerformanceStatistics()
        {
            if (olympiadComboBox.SelectedItem != null)
            {
                int selectedOlympiadYear = ((Olympiad)olympiadComboBox.SelectedItem).Year;

                var countryPerformanceStatistics = dbContext.GetCountryPerformanceStatisticsForAll(selectedOlympiadYear);

                countryPerformanceStatisticsDataGrid.ItemsSource = countryPerformanceStatistics.ToList();
            }
        }

        private void olympiadPerformanceComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            LoadCountryPerformanceStatistics();
        }

        private void olympiadsDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var editedOlympiad = (Olympiad)e.Row.Item;

            dbContext.SaveChanges();
        }

        private void athletesDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var editedAthlete = (Athlete)e.Row.Item;

            dbContext.SaveChanges();
        }

        private void sportsDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var editedSport = (Sport)e.Row.Item;

            dbContext.SaveChanges();
        }
    }
}