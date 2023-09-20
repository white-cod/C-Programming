namespace GDI1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            int logoWidth = 816;
            int logoHeight = 480;

            Bitmap logo = LogoGenerator.GenerateLogo(logoWidth, logoHeight);
            pictureBox1.Image = logo;
        }

    }
}