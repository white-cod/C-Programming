using System.Media;
using System.Numerics;

namespace clock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            player = new SoundPlayer(@"F:\C++\Проэкт\clock\clock\portal-radio-song.wav");
        }

        private int countdownTime = 0;
        private SoundPlayer player;

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtTime.Text, out int timeInSeconds))
            {
                countdownTime = timeInSeconds;
                timer.Start();
                button1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Invalid time entered.");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            player.Stop();
            timer.Stop();
            ResetUI();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (countdownTime > 0)
            {
                countdownTime--;
                int minutes = countdownTime / 60;
                int seconds = countdownTime % 60;
                label1.Text = $"{minutes:00}:{seconds:00}";
            }
            else
            {
                PlayAlarmSound();
                timer.Stop();
                ResetUI();
            }
        }
        private void ResetUI()
        {
            button1.Enabled = true;
            countdownTime = 0;
            label1.Text = "00:00";
        }

        private void PlayAlarmSound()
        {
            SoundPlayer player = new SoundPlayer(@"F:\C++\Проэкт\clock\clock\portal-radio-song.wav");
            player.Play();
        }
    }
}