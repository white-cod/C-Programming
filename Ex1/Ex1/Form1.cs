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
                writer.WriteLine("�������: " + txtLastName.Text);
                writer.WriteLine("���: " + txtFirstName.Text);
                writer.WriteLine("��������: " + txtPatronymic.Text);
                writer.WriteLine("���: " + cmbGender.Text);
                writer.WriteLine("���� ��������: " + dtpBirthDate.Value.ToShortDateString());
                writer.WriteLine("�������� ���������: " + cmbMaritalStatus.Text);
                writer.WriteLine("�������������� ����������: " + txtAdditionalInfo.Text);
            }
        }
    }
}