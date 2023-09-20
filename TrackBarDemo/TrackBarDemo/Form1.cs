namespace TrackBarDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void transparencyTrackBar_Scroll(object sender, EventArgs e)
        {
            float opacityValue = transparencyTrackBar.Value / 100.0f;
            Opacity = opacityValue;
        }

        private void colorTrackBar_Scroll(object sender, EventArgs e)
        {
            int redValue = colorTrackBar.Value;
            Color newColor = Color.FromArgb(redValue, BackColor.G, BackColor.B);
            BackColor = newColor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}