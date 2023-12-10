using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows;
using Microsoft.Win32;

namespace Encoder
{
    public partial class MainWindow : Window
    {
        private CancellationTokenSource cancellationTokenSource;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void FileButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = FilePathTextBox.Text;
            string key = KeyTextBox.Text;

            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show("Пожалуйста, введите правильный путь к файлу.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                MessageBox.Show("Введите ключ шифрования (пароль).", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            cancellationTokenSource = new CancellationTokenSource();

            bool isEncrypt = EncryptRadioButton.IsChecked ?? false;
            bool isDecrypt = DecryptRadioButton.IsChecked ?? false;

            if (isEncrypt && FileIsEncrypted(filePath))
            {
                MessageBox.Show("Файл уже зашифрован.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (isDecrypt && !FileIsEncrypted(filePath))
            {
                MessageBox.Show("Файл не зашифрован.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            ThreadPool.QueueUserWorkItem(state => EncryptDecryptFile(filePath, key, isEncrypt, cancellationTokenSource.Token));
        }

        private bool FileIsEncrypted(string filePath)
        {
            return filePath.EndsWith(".encrypted", StringComparison.OrdinalIgnoreCase);
        }

        private void EncryptDecryptFile(string filePath, string key, bool isEncrypt, CancellationToken cancellationToken)
        {
            try
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(key);
                byte[] fileBytes = File.ReadAllBytes(filePath);
                int totalBytes = fileBytes.Length;
                int processedBytes = 0;

                Dispatcher.Invoke(() => ProgressBar.Maximum = totalBytes);

                Thread.Sleep(1500);

                for (int i = 0; i < totalBytes; i++)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        Dispatcher.Invoke(() => ProgressBar.Value = 0);
                        MessageBox.Show("Операция отменена.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    fileBytes[i] = (byte)(fileBytes[i] ^ keyBytes[i % keyBytes.Length]);

                    processedBytes++;
                    int finalProcessedBytes = processedBytes;
                    Dispatcher.Invoke(() => ProgressBar.Value = finalProcessedBytes);
                }

                string resultFilePath = isEncrypt ? filePath + ".encrypted" : filePath + ".decrypted";

                File.WriteAllBytes(resultFilePath, fileBytes);

                Dispatcher.Invoke(() =>
                {
                    ProgressBar.Value = totalBytes;
                    MessageBox.Show($"{(isEncrypt ? "Шифрование" : "Дешифрование")} завершено.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                });
            }
            catch (Exception ex)
            {
                Dispatcher.Invoke(() => MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error));
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
            }
        }
    }
}