using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdditionalForms
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fullName = textBoxFullName.Text;
            string dob = textBoxDOB.Text;
            string height = textBoxHeight.Text;

            Form1 form1 = (Form1)Application.OpenForms["Form1"];
            form1.SetInformation(fullName, dob, height);
            this.Close();
        }

    }
}
