using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace TwoFormTextEditor
{
    public partial class Form2 : Form
    {
        public Form2(string content)
        {
            InitializeComponent();
            textBox1.Text = content;
        }

        private string initialText;

        private void btnSave_Click(object sender, EventArgs e)
        {
            ((Form1)System.Windows.Forms.Application.OpenForms["Form1"]).UpdateTextBox(textBox1.Text);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
