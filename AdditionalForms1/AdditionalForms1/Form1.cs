namespace AdditionalForms1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();

            if (form2.Product != null)
            {
                listBoxProducts.Items.Add(form2.Product);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listBoxProducts.SelectedItem != null)
            {
                Product selectedProduct = (Product)listBoxProducts.SelectedItem;

                Form2 form2 = new Form2(selectedProduct);
                form2.ShowDialog();

                if (form2.Product != null)
                {
                    int selectedIndex = listBoxProducts.SelectedIndex;
                    listBoxProducts.Items[selectedIndex] = form2.Product;
                }
            }
            else
            {
                MessageBox.Show("Выберите продукт для редактирования.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}