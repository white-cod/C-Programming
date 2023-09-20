namespace clock2
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
            components = new System.ComponentModel.Container();
            timeLabel = new Label();
            timeTextBox = new TextBox();
            adjustButton = new Button();
            startButton = new Button();
            Timer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Location = new Point(201, 105);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(38, 15);
            timeLabel.TabIndex = 0;
            timeLabel.Text = "label1";
            // 
            // timeTextBox
            // 
            timeTextBox.Location = new Point(74, 181);
            timeTextBox.Name = "timeTextBox";
            timeTextBox.Size = new Size(100, 23);
            timeTextBox.TabIndex = 1;
            // 
            // adjustButton
            // 
            adjustButton.Location = new Point(273, 181);
            adjustButton.Name = "adjustButton";
            adjustButton.Size = new Size(75, 23);
            adjustButton.TabIndex = 2;
            adjustButton.Text = "Adjust Time";
            adjustButton.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            startButton.Location = new Point(194, 266);
            startButton.Name = "startButton";
            startButton.Size = new Size(75, 23);
            startButton.TabIndex = 3;
            startButton.Text = "Start Timer";
            startButton.UseVisualStyleBackColor = true;
            // 
            // Timer
            // 
            Timer.Interval = 1000;
            Timer.Tick += Timer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(443, 364);
            Controls.Add(startButton);
            Controls.Add(adjustButton);
            Controls.Add(timeTextBox);
            Controls.Add(timeLabel);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label timeLabel;
        private TextBox timeTextBox;
        private Button adjustButton;
        private Button startButton;
        private System.Windows.Forms.Timer Timer;
    }
}