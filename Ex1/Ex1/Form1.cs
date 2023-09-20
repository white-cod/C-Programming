namespace Ex1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("information.txt"))
            {
                writer.WriteLine("Фамилия: " + txtLastName.Text);
                writer.WriteLine("Имя: " + txtFirstName.Text);
                writer.WriteLine("Отчество: " + txtPatronymic.Text);
                writer.WriteLine("Пол: " + cmbGender.Text);
                writer.WriteLine("Дата рождения: " + dtpBirthDate.Value.ToShortDateString());
                writer.WriteLine("Семейное положение: " + cmbMaritalStatus.Text);
                writer.WriteLine("Дополнительная информация: " + txtAdditionalInfo.Text);
            }
        }
    }
}