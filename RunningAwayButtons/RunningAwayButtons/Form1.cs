namespace RunningAwayButtons
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ћы и не сомневались, что вы так думаете!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int x = rand.Next(0, this.ClientSize.Width - button2.Width);
            int y = rand.Next(0, this.ClientSize.Height - button2.Height);
            button2.Location = new Point(x, y);
        }
    }
}