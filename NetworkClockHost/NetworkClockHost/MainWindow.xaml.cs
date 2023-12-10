using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace NetworkClockHost
{
    public partial class MainWindow : Window
    {
        private UdpClient udpServer;
        private UdpClient udpReceiver;
        private Thread clockThread;
        private Thread receiveThread;
        private bool isClockRunning;
        private ObservableCollection<string> packetNames;

        public MainWindow()
        {
            InitializeComponent();
            packetNames = new ObservableCollection<string>();
            lstPacketNames.ItemsSource = packetNames;
        }

        private void StartClock_Click(object sender, RoutedEventArgs e)
        {
            if (!isClockRunning)
            {
                udpServer = new UdpClient();
                udpReceiver = new UdpClient(12345);
                isClockRunning = true;
                clockThread = new Thread(async () => await SendTimePacketsAsync());
                receiveThread = new Thread(ReceivePackets);
                clockThread.Start();
                receiveThread.Start();
            }
        }

        private async Task SendTimePacketsAsync()
        {
            try
            {
                IPAddress multicastAddress = IPAddress.Parse("192.168.50.228");
                int port = 12345;

                while (isClockRunning)
                {
                    string currentTime = DateTime.Now.ToString("HH:mm:ss");
                    byte[] data = Encoding.UTF8.GetBytes(currentTime);

                    await udpServer.SendAsync(data, data.Length, new IPEndPoint(multicastAddress, port));

                    Dispatcher.Invoke(() => lblTime.Content = currentTime);

                    Dispatcher.Invoke(() => packetNames.Insert(0, $"Packet {currentTime} sent"));

                    await Task.Delay(1000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void ReceivePackets()
        {
            try
            {
                while (isClockRunning)
                {
                    IPEndPoint remoteEndPoint = null;
                    byte[] receivedData = udpReceiver.Receive(ref remoteEndPoint);
                    string receivedTime = Encoding.UTF8.GetString(receivedData);

                    Dispatcher.Invoke(() => lblReceivedTime.Content = $"Received Time: {receivedTime}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while receiving packets: {ex.Message}");
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            StopClock();
        }

        private void StopClock()
        {
            isClockRunning = false;
            udpServer?.Close();
            udpReceiver?.Close();
            clockThread?.Join();
            receiveThread?.Join();
        }
    }
}