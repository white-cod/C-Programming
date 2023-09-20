namespace ProgressBar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                progressBar.Value = i;

                System.Threading.Thread.Sleep(100);

                Application.DoEvents();
            }
        }
    }
}