using System.Media;

namespace clock1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(@"F:\C++\Проэкт\clock1\clock1\juke_sound.wav");
            player.Play();
        }
    }
}