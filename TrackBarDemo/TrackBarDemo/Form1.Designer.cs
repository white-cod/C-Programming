namespace TrackBarDemo
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
            transparencyTrackBar = new TrackBar();
            colorTrackBar = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)transparencyTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)colorTrackBar).BeginInit();
            SuspendLayout();
            // 
            // transparencyTrackBar
            // 
            transparencyTrackBar.Location = new Point(165, 145);
            transparencyTrackBar.Maximum = 100;
            transparencyTrackBar.Name = "transparencyTrackBar";
            transparencyTrackBar.Size = new Size(104, 45);
            transparencyTrackBar.TabIndex = 0;
            transparencyTrackBar.Scroll += transparencyTrackBar_Scroll;
            // 
            // colorTrackBar
            // 
            colorTrackBar.Location = new Point(311, 145);
            colorTrackBar.Maximum = 100;
            colorTrackBar.Name = "colorTrackBar";
            colorTrackBar.Size = new Size(104, 45);
            colorTrackBar.TabIndex = 1;
            colorTrackBar.Scroll += colorTrackBar_Scroll;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 355);
            Controls.Add(colorTrackBar);
            Controls.Add(transparencyTrackBar);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)transparencyTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)colorTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar transparencyTrackBar;
        private TrackBar colorTrackBar;
    }
}