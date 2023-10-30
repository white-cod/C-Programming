namespace AdditionalForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        public void SetInformation(string fullName, string dob, string height)
        {
            textBoxInfo.Text = $"Имя: {fullName} День рождения: {dob} Рост: {height}";
        }

    }
}