using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MdiApplication
{
    public partial class ChildForm : Form
    {
        public ChildForm()
        {
            InitializeComponent();
        }

        private void ToggleMenuItem_Click(object sender, EventArgs e)
        {
            if (ToggleMenuItem.Checked)
            {
                ToggleMenuItem.Checked = false;
                ChildTextBox.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                ToggleMenuItem.Checked = true;
                ChildTextBox.ForeColor = System.Drawing.Color.Blue;
            }
        }

        private string BufferText;

        public void Cut()
        {
            this.BufferText = ChildTextBox.SelectedText;
            ChildTextBox.SelectedText = "";
        }

        public void Copy()
        {
            this.BufferText = ChildTextBox.SelectedText;
        }

        public void Paste()
        {
            ChildTextBox.SelectedText = this.BufferText;
        }

        public void SelectAll()
        {
            ChildTextBox.SelectAll();
        }

        public void Delete()
        {
            ChildTextBox.SelectedText = "";
            this.BufferText = "";
        }

        private void cutMenuItem_Click(object sender, EventArgs e)
        {
            this.Cut();
        }

        private void copyMenuItem_Click(object sender, EventArgs e)
        {
            this.Copy();
        }

        private void pasteMenuItem_Click(object sender, EventArgs e)
        {
            this.Paste();
        }

        private void selectAllMenuItem_Click(object sender, EventArgs e)
        {
            this.SelectAll();
        }

        private void deleteMenuItem_Click(object sender, EventArgs e)
        {
            this.Delete();
        }

        private void cutContextMenuItem_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void copyContextMenuItem_Click(object sender, EventArgs e)
        {
            this.Copy();
        }

        private void pasteContextMenuItem_Click(object sender, EventArgs e)
        {
            this.Paste();
        }

        private void selectAllContextMenuItem_Click(object sender, EventArgs e)
        {
            this.SelectAll();
        }

        private void deleteContextMenuItem_Click(object sender, EventArgs e)
        {
            this.Delete();
        }
    }
}
