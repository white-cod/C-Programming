using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace taskView
{

    public partial class MainWindow : Window
    {
        private ObservableCollection<ProcessInfo> processes;
        private Timer updateTimer;

        public MainWindow()
        {
            InitializeComponent();
            processes = new ObservableCollection<ProcessInfo>();
            processListView.ItemsSource = processes;

            updateTimer = new Timer(UpdateProcessList, null, 0, 5000);
        }

        public class ProcessInfo
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public int ThreadCount { get; set; }
            public int HandleCount { get; set; }
        }

        private void UpdateProcessList(object state)
        {
            Dispatcher.Invoke(() =>
            {
                processes.Clear();

                foreach (Process process in Process.GetProcesses())
                {
                    processes.Add(new ProcessInfo
                    {
                        Name = process.ProcessName,
                        Id = process.Id,
                        ThreadCount = process.Threads.Count,
                        HandleCount = process.HandleCount
                    });
                }
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                DefaultExt = ".txt"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (ProcessInfo process in processes)
                    {
                        writer.WriteLine($"Name: {process.Name}, ID: {process.Id}, Threads: {process.ThreadCount}, Handles: {process.HandleCount}");
                    }
                }
            }
        }
    }
}