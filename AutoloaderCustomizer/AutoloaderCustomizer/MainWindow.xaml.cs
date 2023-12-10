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
using Microsoft.Win32;

namespace AutoloaderCustomizer
{
    public partial class MainWindow : Window
    {
        private const string RegistryKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Run";

        public MainWindow()
        {
            InitializeComponent();
            LoadPrograms();
        }

        private void LoadPrograms()
        {
            programListBox.Items.Clear();

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath))
            {
                if (key != null)
                {
                    foreach (var valueName in key.GetValueNames())
                    {
                        programListBox.Items.Add(valueName);
                    }
                }
            }
        }

        private void AddProgram_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {

                string filePath = openFileDialog.FileName;

                string programName = System.IO.Path.GetFileNameWithoutExtension(filePath);

                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath, true))
                {
                    key.SetValue(programName, filePath);
                }

                LoadPrograms();
            }
        }

        private void RemoveProgram_Click(object sender, RoutedEventArgs e)
        {
            if (programListBox.SelectedItem != null)
            {
                string programName = programListBox.SelectedItem.ToString();

                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath, true))
                {
                    key.DeleteValue(programName, false);
                }

                LoadPrograms();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите программу для удаления.", "Программа не выбрана", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}