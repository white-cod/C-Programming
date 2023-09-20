namespace TreeView
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            treeViewDirectories = new System.Windows.Forms.TreeView();
            SuspendLayout();
            // 
            // treeViewDirectories
            // 
            treeViewDirectories.Dock = DockStyle.Fill;
            treeViewDirectories.Location = new Point(0, 0);
            treeViewDirectories.Name = "treeViewDirectories";
            treeViewDirectories.Size = new Size(800, 450);
            treeViewDirectories.TabIndex = 0;
            treeViewDirectories.AfterSelect += treeViewDirectories_AfterSelect;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(treeViewDirectories);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TreeView treeViewDirectories;
        private MenuStrip menuStrip1;
    }
}