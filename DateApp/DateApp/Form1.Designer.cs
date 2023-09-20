namespace DateApp
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
            monthCalendar1 = new MonthCalendar();
            txtDay = new TextBox();
            txtMonth = new TextBox();
            txtYear = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtDate = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(480, 71);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 0;
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;
            // 
            // txtDay
            // 
            txtDay.Location = new Point(206, 81);
            txtDay.Name = "txtDay";
            txtDay.Size = new Size(100, 23);
            txtDay.TabIndex = 1;
            // 
            // txtMonth
            // 
            txtMonth.Location = new Point(206, 128);
            txtMonth.Name = "txtMonth";
            txtMonth.Size = new Size(100, 23);
            txtMonth.TabIndex = 2;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(206, 174);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(100, 23);
            txtYear.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(139, 81);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 4;
            label1.Text = "День";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(139, 128);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 5;
            label2.Text = "Месяц";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(139, 174);
            label3.Name = "label3";
            label3.Size = new Size(26, 15);
            label3.TabIndex = 6;
            label3.Text = "Год";
            // 
            // txtDate
            // 
            txtDate.Location = new Point(206, 254);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(100, 23);
            txtDate.TabIndex = 7;
            txtDate.TextChanged += txtDate_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(140, 257);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 8;
            label4.Text = "Ввод";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(txtDate);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtYear);
            Controls.Add(txtMonth);
            Controls.Add(txtDay);
            Controls.Add(monthCalendar1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MonthCalendar monthCalendar1;
        private TextBox txtDay;
        private TextBox txtMonth;
        private TextBox txtYear;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtDate;
        private Label label4;
    }
}