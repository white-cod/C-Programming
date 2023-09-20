namespace DateApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            txtDay.Text = e.Start.Day.ToString();
            txtMonth.Text = e.Start.Month.ToString();
            txtYear.Text = e.Start.Year.ToString();

            monthCalendar1.SelectionRange = new SelectionRange(e.Start, e.Start);
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            DateTime date;
            if (DateTime.TryParse(txtDate.Text, out date))
            {
                monthCalendar1.SetDate(date);
                monthCalendar1.SelectionRange = new SelectionRange(date, date);
            }
        }
    }
}