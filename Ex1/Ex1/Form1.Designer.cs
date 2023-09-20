namespace Ex1
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
            txtLastName = new TextBox();
            txtPatronymic = new TextBox();
            txtFirstName = new TextBox();
            cmbGender = new ComboBox();
            dtpBirthDate = new DateTimePicker();
            cmbMaritalStatus = new ComboBox();
            txtAdditionalInfo = new TextBox();
            btnSave = new Button();
            label1 = new Label();
            Имя = new Label();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            SuspendLayout();
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(158, 67);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(100, 23);
            txtLastName.TabIndex = 0;
            // 
            // txtPatronymic
            // 
            txtPatronymic.Location = new Point(158, 159);
            txtPatronymic.Name = "txtPatronymic";
            txtPatronymic.Size = new Size(100, 23);
            txtPatronymic.TabIndex = 1;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(158, 113);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(100, 23);
            txtFirstName.TabIndex = 2;
            // 
            // cmbGender
            // 
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "Женский", "Мужской" });
            cmbGender.Location = new Point(158, 250);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(121, 23);
            cmbGender.TabIndex = 4;
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Location = new Point(158, 203);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(200, 23);
            dtpBirthDate.TabIndex = 5;
            // 
            // cmbMaritalStatus
            // 
            cmbMaritalStatus.FormattingEnabled = true;
            cmbMaritalStatus.Items.AddRange(new object[] { "Не женат(а)", "Женат(а)", "Разведен(а)" });
            cmbMaritalStatus.Location = new Point(158, 295);
            cmbMaritalStatus.Name = "cmbMaritalStatus";
            cmbMaritalStatus.Size = new Size(121, 23);
            cmbMaritalStatus.TabIndex = 6;
            // 
            // txtAdditionalInfo
            // 
            txtAdditionalInfo.Location = new Point(158, 347);
            txtAdditionalInfo.Name = "txtAdditionalInfo";
            txtAdditionalInfo.Size = new Size(100, 23);
            txtAdditionalInfo.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(357, 346);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 8;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 70);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 9;
            label1.Text = "Фамилия";
            // 
            // Имя
            // 
            Имя.AutoSize = true;
            Имя.Location = new Point(36, 116);
            Имя.Name = "Имя";
            Имя.Size = new Size(31, 15);
            Имя.TabIndex = 10;
            Имя.Text = "Имя";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 159);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 11;
            label3.Text = "Отчество";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 203);
            label5.Name = "label5";
            label5.Size = new Size(90, 15);
            label5.TabIndex = 13;
            label5.Text = "Дата рождения";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(36, 350);
            label6.Name = "label6";
            label6.Size = new Size(107, 15);
            label6.TabIndex = 14;
            label6.Text = "Доп. информация";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(36, 250);
            label7.Name = "label7";
            label7.Size = new Size(30, 15);
            label7.TabIndex = 15;
            label7.Text = "Пол";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(36, 295);
            label8.Name = "label8";
            label8.Size = new Size(99, 15);
            label8.TabIndex = 16;
            label8.Text = "Сем. положение";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 441);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(Имя);
            Controls.Add(label1);
            Controls.Add(btnSave);
            Controls.Add(txtAdditionalInfo);
            Controls.Add(cmbMaritalStatus);
            Controls.Add(dtpBirthDate);
            Controls.Add(cmbGender);
            Controls.Add(txtFirstName);
            Controls.Add(txtPatronymic);
            Controls.Add(txtLastName);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtLastName;
        private TextBox txtPatronymic;
        private TextBox txtFirstName;
        private ComboBox cmbGender;
        private DateTimePicker dtpBirthDate;
        private ComboBox cmbMaritalStatus;
        private TextBox txtAdditionalInfo;
        private Button btnSave;
        private Label label1;
        private Label Имя;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}