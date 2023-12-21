using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;

class Program
{
    private const string ServerIp = "192.168.50.228";
    private const int ServerPort = 12345;
    private const int CaptureIntervalInSeconds = 5;

    static void Main()
    {
        Timer screenshotTimer = new Timer(CaptureAndSendScreenshot, null, TimeSpan.Zero, TimeSpan.FromSeconds(CaptureIntervalInSeconds));

        Console.CancelKeyPress += (sender, e) =>
        {
            screenshotTimer.Dispose();
            e.Cancel = true;
        };

        Thread.Sleep(Timeout.Infinite);
    }

    private static void CaptureAndSendScreenshot(object state)
    {
        try
        {
            using (TcpClient client = new TcpClient(ServerIp, ServerPort))
            using (NetworkStream stream = client.GetStream())
            {
                byte[] screenshotData = CaptureScreenshot();
                stream.Write(screenshotData, 0, screenshotData.Length);
                Console.WriteLine($"Screenshot sent successfully at {DateTime.Now}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static byte[] CaptureScreenshot()
    {
        int screenWidth = 1920;
        int screenHeight = 1080;

        using (Bitmap screenshot = new Bitmap(screenWidth, screenHeight))
        using (Graphics graphics = Graphics.FromImage(screenshot))
        {
            graphics.CopyFromScreen(0, 0, 0, 0, screenshot.Size);
            using (MemoryStream ms = new MemoryStream())
            {
                screenshot.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}