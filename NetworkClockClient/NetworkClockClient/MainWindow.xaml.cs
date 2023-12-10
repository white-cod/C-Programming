using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
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
using System.Collections.ObjectModel;

namespace NetworkClockClient
{
    public partial class MainWindow : Window
    {
        private UdpClient udpClient;
        private Thread receiveThread;
        private bool isReceiving;
        private ObservableCollection<string> receivedPacketNames;

        public MainWindow()
        {
            InitializeComponent();
            receivedPacketNames = new ObservableCollection<string>();
            lstReceivedPackets.ItemsSource = receivedPacketNames;

            StartReceiving();
        }

        private void StartReceiving()
        {
            try
            {
                udpClient = new UdpClient(12345);
                isReceiving = true;
                receiveThread = new Thread(ReceiveTimePackets);
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ReceiveTimePackets()
        {
            try
            {
                while (isReceiving)
                {
                    IPEndPoint remoteEndpoint = null;
                    byte[] receivedData = udpClient.Receive(ref remoteEndpoint);

                    string receivedTime = Encoding.UTF8.GetString(receivedData);

                    Dispatcher.Invoke(() =>
                    {
                        lblReceivedTime.Content = $"Received Time: {receivedTime}";
                        receivedPacketNames.Insert(0, receivedTime);
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            StopReceiving();
        }

        private void StopReceiving()
        {
            isReceiving = false;
            udpClient?.Close();
            receiveThread?.Join();
        }
    }
}
