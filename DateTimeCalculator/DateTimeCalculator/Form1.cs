namespace DateTimeCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimeSpan difference = dateTimePicker2.Value - dateTimePicker1.Value;
            int days = difference.Days;
            label1.Text = "ƒни между выбранными датами: " + days.ToString();

            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;
            int years = endDate.Year - startDate.Year;
            int months = endDate.Month - startDate.Month;
            int days1 = endDate.Day - startDate.Day;

            if (days < 0)
            {
                months--;
                days += DateTime.DaysInMonth(startDate.Year, startDate.Month);
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            textBox1.Text = days1.ToString();
            textBox2.Text = months.ToString();
            textBox3.Text = years.ToString();
        }

    }
}