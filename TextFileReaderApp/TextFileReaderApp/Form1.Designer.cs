namespace TextFileReaderApp
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
            progressBar = new ProgressBar();
            btnOpenFile = new Button();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(134, 92);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(100, 23);
            progressBar.TabIndex = 0;
            // 
            // btnOpenFile
            // 
            btnOpenFile.Location = new Point(144, 175);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(75, 23);
            btnOpenFile.TabIndex = 1;
            btnOpenFile.Text = "OpenFile";
            btnOpenFile.UseVisualStyleBackColor = true;
            btnOpenFile.Click += btnOpenFile_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(144, 139);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(77, 15);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Status: Ready";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(373, 300);
            Controls.Add(lblStatus);
            Controls.Add(btnOpenFile);
            Controls.Add(progressBar);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBar;
        private Button btnOpenFile;
        private Label lblStatus;
    }
}