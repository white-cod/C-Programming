using System;
using System.Media;
using System.Windows.Forms;

namespace clock2
{
    public partial class Form1 : Form
    {
        private void Timer_Tick(object sender, EventArgs e)
        {
            int remainingTime = int.Parse(timeTextBox.Text);

            if (remainingTime > 0)
            {
                remainingTime--;
                timeTextBox.Text = remainingTime.ToString();
            }
            else
            {
                Timer.Stop();
                SoundPlayer player = new SoundPlayer(@"F:\\C++\\Project\\clock1\\clock1\\juke_sound.wav");
            }
        }

    }
}