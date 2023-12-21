using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
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

namespace TCP_screenshotServer
{
    public partial class MainWindow : Window
    {
        private const int ServerPort = 12345;
        private TcpListener tcpListener;
        private Task listeningTask;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartListeningButton_Click(object sender, RoutedEventArgs e)
        {
            StartListening();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            string savePath = GetSavePath();
            if (savePath != null)
            {
                SaveLocationTextBox.Text = savePath;
            }
        }

        private void StartListening()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, ServerPort);
                listeningTask = Task.Run(async () =>
                {
                    tcpListener.Start();
                    UpdateStatus("Listening for connections...");

                    while (true)
                    {
                        TcpClient client = await tcpListener.AcceptTcpClientAsync();
                        HandleClientAsync(client);
                    }
                });
            }
            catch (Exception ex)
            {
                UpdateStatus($"Error starting listener: {ex.Message}");
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            try
            {
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] buffer = new byte[8192];
                    using (MemoryStream ms = new MemoryStream())
                    {
                        int bytesRead;
                        while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await ms.WriteAsync(buffer, 0, bytesRead);
                        }

                        DisplayScreenshot(ms.ToArray());
                        SaveScreenshot(ms.ToArray());
                        UpdateStatus("Screenshot received and saved.");
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateStatus($"Error handling client: {ex.Message}");
            }
            finally
            {
                client.Close();
            }
        }

        private void DisplayScreenshot(byte[] imageData)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = new MemoryStream(imageData);
                bitmap.EndInit();

                ImageControl.Source = bitmap;
            });
        }

        private void SaveScreenshot(byte[] imageData)
        {
            try
            {
                string savePath = GetSavePath();
                if (string.IsNullOrWhiteSpace(savePath))
                {
                    UpdateStatus("Save location is empty.");
                    return;
                }

                File.WriteAllBytes(savePath, imageData);
                UpdateStatus($"Screenshot saved to: {savePath}");
            }
            catch (Exception ex)
            {
                UpdateStatus($"Error saving screenshot: {ex.Message}");
            }
        }

        private string GetSavePath()
        {
            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.Filter = "PNG files (*.png)|*.png";
            dialog.Title = "Save Screenshot";
            dialog.FileName = System.IO.Path.Combine("Screens", $"Screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png");
            dialog.OverwritePrompt = false;

            dialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            return dialog.FileName;
        }



        private void UpdateStatus(string message)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                StatusTextBlock.Text = message;
            });
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            tcpListener?.Stop();
        }
    }
}