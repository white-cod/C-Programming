namespace ResumeApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Form1_Load);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string resumeText = "Hi, my name is Tim and I'm a C++/C# developer. But I'm also expanding my professional skills and am actively learning HTML/CSS website markup languages to work in freelancing, and I'm also actively learning JavaScript to expand my technology stack. I also have skills in web design and can design for your landing page or small shop as well as banners and business cards. I am constantly looking for opportunities to grow in my professional field, studying various online courses and keeping up with the latest trends in web development.";

            int messageBoxLength = 50;
            int totalLength = resumeText.Length;
            int messageBoxCount = (int)Math.Ceiling((double)totalLength / messageBoxLength);

            for (int i = 0; i < messageBoxCount - 1; i++)
            {
                int startIndex = i * messageBoxLength;
                string message = resumeText.Substring(startIndex, messageBoxLength);
                MessageBox.Show(message, "Resume");
            }

            int lastMessageBoxLength = totalLength - (messageBoxCount - 1) * messageBoxLength;
            string lastMessage = resumeText.Substring((messageBoxCount - 1) * messageBoxLength, lastMessageBoxLength);
            MessageBox.Show(lastMessage, $"Resume ({totalLength}/{messageBoxCount})");
        }
    }
}