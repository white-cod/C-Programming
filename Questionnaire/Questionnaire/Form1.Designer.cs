namespace Questionnaire
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
            label1 = new Label();
            btnAdd = new Button();
            txtFirstName = new TextBox();
            lstUsers = new ListBox();
            btnEdit = new Button();
            btnRemove = new Button();
            btnExportText = new Button();
            btnImportText = new Button();
            btnExportXML = new Button();
            btnImportXML = new Button();
            txtLastName = new TextBox();
            txtEmail = new TextBox();
            txtPhoneNumber = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 68);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 0;
            label1.Text = "First Name";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(578, 197);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(148, 65);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(100, 23);
            txtFirstName.TabIndex = 2;
            // 
            // lstUsers
            // 
            lstUsers.FormattingEnabled = true;
            lstUsers.ItemHeight = 15;
            lstUsers.Location = new Point(378, 65);
            lstUsers.Name = "lstUsers";
            lstUsers.Size = new Size(275, 94);
            lstUsers.TabIndex = 3;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(378, 198);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(483, 197);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 23);
            btnRemove.TabIndex = 5;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnExportText
            // 
            btnExportText.Location = new Point(378, 236);
            btnExportText.Name = "btnExportText";
            btnExportText.Size = new Size(75, 23);
            btnExportText.TabIndex = 6;
            btnExportText.Text = "ExportText";
            btnExportText.UseVisualStyleBackColor = true;
            btnExportText.Click += btnExportText_Click;
            // 
            // btnImportText
            // 
            btnImportText.Location = new Point(483, 236);
            btnImportText.Name = "btnImportText";
            btnImportText.Size = new Size(75, 23);
            btnImportText.TabIndex = 7;
            btnImportText.Text = "ImportText";
            btnImportText.UseVisualStyleBackColor = true;
            btnImportText.Click += btnImportText_Click;
            // 
            // btnExportXML
            // 
            btnExportXML.Location = new Point(378, 276);
            btnExportXML.Name = "btnExportXML";
            btnExportXML.Size = new Size(75, 23);
            btnExportXML.TabIndex = 8;
            btnExportXML.Text = "ExportXML";
            btnExportXML.UseVisualStyleBackColor = true;
            btnExportXML.Click += btnExportXML_Click;
            // 
            // btnImportXML
            // 
            btnImportXML.Location = new Point(483, 276);
            btnImportXML.Name = "btnImportXML";
            btnImportXML.Size = new Size(75, 23);
            btnImportXML.TabIndex = 9;
            btnImportXML.Text = "ImportXML";
            btnImportXML.UseVisualStyleBackColor = true;
            btnImportXML.Click += btnImportXML_Click;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(148, 112);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(100, 23);
            txtLastName.TabIndex = 10;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(148, 152);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 11;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(148, 198);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(100, 23);
            txtPhoneNumber.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 115);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 13;
            label2.Text = "Last Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 155);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 14;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(54, 201);
            label4.Name = "label4";
            label4.Size = new Size(88, 15);
            label4.TabIndex = 15;
            label4.Text = "Phone Number";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtPhoneNumber);
            Controls.Add(txtEmail);
            Controls.Add(txtLastName);
            Controls.Add(btnImportXML);
            Controls.Add(btnExportXML);
            Controls.Add(btnImportText);
            Controls.Add(btnExportText);
            Controls.Add(btnRemove);
            Controls.Add(btnEdit);
            Controls.Add(lstUsers);
            Controls.Add(txtFirstName);
            Controls.Add(btnAdd);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnAdd;
        private TextBox txtFirstName;
        private ListBox lstUsers;
        private Button btnEdit;
        private Button btnRemove;
        private Button btnExportText;
        private Button btnImportText;
        private Button btnExportXML;
        private Button btnImportXML;
        private TextBox txtLastName;
        private TextBox txtEmail;
        private TextBox txtPhoneNumber;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}