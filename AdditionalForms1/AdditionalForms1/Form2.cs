using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdditionalForms1
{
    public partial class Form2 : Form
    {
        private Product _existingProduct;

        public Form2(Product existingProduct = null)
        {
            InitializeComponent();
            _existingProduct = existingProduct;

            if (_existingProduct != null)
            {
                textBoxName.Text = _existingProduct.Name;
                textBoxCountry.Text = _existingProduct.Country;
                textBoxPrice.Text = _existingProduct.Price.ToString();
            }
        }

        public Product Product { get; private set; }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBoxName.Text;
                string country = textBoxCountry.Text;
                decimal price = decimal.Parse(textBoxPrice.Text);

                Product = new Product { Name = name, Country = country, Price = price };

                if (_existingProduct != null)
                {
                    _existingProduct.Name = name;
                    _existingProduct.Country = country;
                    _existingProduct.Price = price;
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}