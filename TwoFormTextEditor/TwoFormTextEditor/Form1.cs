namespace TwoFormTextEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string content = File.ReadAllText(openFileDialog.FileName);
                textBox1.Text = content;
                editButton.Enabled = true;
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(textBox1.Text);
            form2.Show();
        }
        public void UpdateTextBox(string content)
        {
            textBox1.Text = content;
        }

    }
}