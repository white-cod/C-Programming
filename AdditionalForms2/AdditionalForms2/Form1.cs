namespace AdditionalForms2
{
    public partial class Form1 : Form
    {

        private Form2 additionalForm;

        public Form1()
        {
            InitializeComponent();

            additionalForm = new Form2();

            this.Show();
            additionalForm.Show();

            textBoxMain.TextChanged += TextBoxMain_TextChanged;
        }
        private void TextBoxMain_TextChanged(object sender, EventArgs e)
        {
            additionalForm.UpdateText(textBoxMain.Text);
        }
    }
}