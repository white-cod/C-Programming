namespace AcademySTEP
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
            tabControl1 = new TabControl();
            Departments = new TabPage();
            RefreshBtn = new Button();
            Delete1 = new Button();
            SaveChangesBtn = new Button();
            DepartmentsDataGridView = new DataGridView();
            Forms = new TabPage();
            RefreshBtn1 = new Button();
            Delete2 = new Button();
            SaveChangesBtn1 = new Button();
            FormsDataGridView = new DataGridView();
            Groups = new TabPage();
            RefreshBtn2 = new Button();
            Delete3 = new Button();
            SaveChangesBtn2 = new Button();
            GroupsDataGridView = new DataGridView();
            Students = new TabPage();
            RefreshBtn4 = new Button();
            Delete4 = new Button();
            SaveChangesBtn3 = new Button();
            StudentsDataGridView = new DataGridView();
            tabControl1.SuspendLayout();
            Departments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DepartmentsDataGridView).BeginInit();
            Forms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FormsDataGridView).BeginInit();
            Groups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GroupsDataGridView).BeginInit();
            Students.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)StudentsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Departments);
            tabControl1.Controls.Add(Forms);
            tabControl1.Controls.Add(Groups);
            tabControl1.Controls.Add(Students);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(545, 388);
            tabControl1.TabIndex = 0;
            // 
            // Departments
            // 
            Departments.Controls.Add(RefreshBtn);
            Departments.Controls.Add(Delete1);
            Departments.Controls.Add(SaveChangesBtn);
            Departments.Controls.Add(DepartmentsDataGridView);
            Departments.Location = new Point(4, 24);
            Departments.Name = "Departments";
            Departments.Padding = new Padding(3);
            Departments.Size = new Size(537, 360);
            Departments.TabIndex = 0;
            Departments.Text = "Departments";
            Departments.UseVisualStyleBackColor = true;
            // 
            // RefreshBtn
            // 
            RefreshBtn.Location = new Point(456, 64);
            RefreshBtn.Name = "RefreshBtn";
            RefreshBtn.Size = new Size(75, 23);
            RefreshBtn.TabIndex = 8;
            RefreshBtn.Text = "Refresh";
            RefreshBtn.UseVisualStyleBackColor = true;
            RefreshBtn.Click += RefreshBtn_Click;
            // 
            // Delete1
            // 
            Delete1.Location = new Point(456, 35);
            Delete1.Name = "Delete1";
            Delete1.Size = new Size(75, 23);
            Delete1.TabIndex = 7;
            Delete1.Text = "Delete";
            Delete1.UseVisualStyleBackColor = true;
            Delete1.Click += Delete1_Click;
            // 
            // SaveChangesBtn
            // 
            SaveChangesBtn.Location = new Point(456, 6);
            SaveChangesBtn.Name = "SaveChangesBtn";
            SaveChangesBtn.Size = new Size(75, 23);
            SaveChangesBtn.TabIndex = 5;
            SaveChangesBtn.Text = "Save";
            SaveChangesBtn.UseVisualStyleBackColor = true;
            SaveChangesBtn.Click += SaveChangesBtn_Click;
            // 
            // DepartmentsDataGridView
            // 
            DepartmentsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DepartmentsDataGridView.Location = new Point(6, 6);
            DepartmentsDataGridView.Name = "DepartmentsDataGridView";
            DepartmentsDataGridView.RowTemplate.Height = 25;
            DepartmentsDataGridView.Size = new Size(444, 348);
            DepartmentsDataGridView.TabIndex = 0;
            // 
            // Forms
            // 
            Forms.Controls.Add(RefreshBtn1);
            Forms.Controls.Add(Delete2);
            Forms.Controls.Add(SaveChangesBtn1);
            Forms.Controls.Add(FormsDataGridView);
            Forms.Location = new Point(4, 24);
            Forms.Name = "Forms";
            Forms.Padding = new Padding(3);
            Forms.Size = new Size(537, 360);
            Forms.TabIndex = 1;
            Forms.Text = "Forms";
            Forms.UseVisualStyleBackColor = true;
            // 
            // RefreshBtn1
            // 
            RefreshBtn1.Location = new Point(456, 64);
            RefreshBtn1.Name = "RefreshBtn1";
            RefreshBtn1.Size = new Size(75, 23);
            RefreshBtn1.TabIndex = 9;
            RefreshBtn1.Text = "Refresh";
            RefreshBtn1.UseVisualStyleBackColor = true;
            RefreshBtn1.Click += RefreshBtn1_Click;
            // 
            // Delete2
            // 
            Delete2.Location = new Point(456, 35);
            Delete2.Name = "Delete2";
            Delete2.Size = new Size(75, 23);
            Delete2.TabIndex = 7;
            Delete2.Text = "Delete";
            Delete2.UseVisualStyleBackColor = true;
            Delete2.Click += Delete2_Click;
            // 
            // SaveChangesBtn1
            // 
            SaveChangesBtn1.Location = new Point(456, 6);
            SaveChangesBtn1.Name = "SaveChangesBtn1";
            SaveChangesBtn1.Size = new Size(75, 23);
            SaveChangesBtn1.TabIndex = 5;
            SaveChangesBtn1.Text = "Save";
            SaveChangesBtn1.UseVisualStyleBackColor = true;
            SaveChangesBtn1.Click += SaveChangesBtn1_Click;
            // 
            // FormsDataGridView
            // 
            FormsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            FormsDataGridView.Location = new Point(6, 6);
            FormsDataGridView.Name = "FormsDataGridView";
            FormsDataGridView.RowTemplate.Height = 25;
            FormsDataGridView.Size = new Size(444, 348);
            FormsDataGridView.TabIndex = 1;
            // 
            // Groups
            // 
            Groups.Controls.Add(RefreshBtn2);
            Groups.Controls.Add(Delete3);
            Groups.Controls.Add(SaveChangesBtn2);
            Groups.Controls.Add(GroupsDataGridView);
            Groups.Location = new Point(4, 24);
            Groups.Name = "Groups";
            Groups.Padding = new Padding(3);
            Groups.Size = new Size(537, 360);
            Groups.TabIndex = 2;
            Groups.Text = "Groups";
            Groups.UseVisualStyleBackColor = true;
            // 
            // RefreshBtn2
            // 
            RefreshBtn2.Location = new Point(456, 64);
            RefreshBtn2.Name = "RefreshBtn2";
            RefreshBtn2.Size = new Size(75, 23);
            RefreshBtn2.TabIndex = 9;
            RefreshBtn2.Text = "Refresh";
            RefreshBtn2.UseVisualStyleBackColor = true;
            RefreshBtn2.Click += RefreshBtn2_Click;
            // 
            // Delete3
            // 
            Delete3.Location = new Point(456, 35);
            Delete3.Name = "Delete3";
            Delete3.Size = new Size(75, 23);
            Delete3.TabIndex = 7;
            Delete3.Text = "Delete";
            Delete3.UseVisualStyleBackColor = true;
            Delete3.Click += Delete3_Click;
            // 
            // SaveChangesBtn2
            // 
            SaveChangesBtn2.Location = new Point(456, 6);
            SaveChangesBtn2.Name = "SaveChangesBtn2";
            SaveChangesBtn2.Size = new Size(75, 23);
            SaveChangesBtn2.TabIndex = 5;
            SaveChangesBtn2.Text = "Save";
            SaveChangesBtn2.UseVisualStyleBackColor = true;
            SaveChangesBtn2.Click += SaveChangesBtn2_Click;
            // 
            // GroupsDataGridView
            // 
            GroupsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GroupsDataGridView.Location = new Point(6, 6);
            GroupsDataGridView.Name = "GroupsDataGridView";
            GroupsDataGridView.RowTemplate.Height = 25;
            GroupsDataGridView.Size = new Size(444, 348);
            GroupsDataGridView.TabIndex = 1;
            // 
            // Students
            // 
            Students.Controls.Add(RefreshBtn4);
            Students.Controls.Add(Delete4);
            Students.Controls.Add(SaveChangesBtn3);
            Students.Controls.Add(StudentsDataGridView);
            Students.Location = new Point(4, 24);
            Students.Name = "Students";
            Students.Padding = new Padding(3);
            Students.Size = new Size(537, 360);
            Students.TabIndex = 3;
            Students.Text = "Students";
            Students.UseVisualStyleBackColor = true;
            // 
            // RefreshBtn4
            // 
            RefreshBtn4.Location = new Point(456, 64);
            RefreshBtn4.Name = "RefreshBtn4";
            RefreshBtn4.Size = new Size(75, 23);
            RefreshBtn4.TabIndex = 9;
            RefreshBtn4.Text = "Refresh";
            RefreshBtn4.UseVisualStyleBackColor = true;
            RefreshBtn4.Click += RefreshBtn4_Click;
            // 
            // Delete4
            // 
            Delete4.Location = new Point(456, 35);
            Delete4.Name = "Delete4";
            Delete4.Size = new Size(75, 23);
            Delete4.TabIndex = 4;
            Delete4.Text = "Delete";
            Delete4.UseVisualStyleBackColor = true;
            Delete4.Click += Delete4_Click;
            // 
            // SaveChangesBtn3
            // 
            SaveChangesBtn3.Location = new Point(456, 6);
            SaveChangesBtn3.Name = "SaveChangesBtn3";
            SaveChangesBtn3.Size = new Size(75, 23);
            SaveChangesBtn3.TabIndex = 2;
            SaveChangesBtn3.Text = "Save";
            SaveChangesBtn3.UseVisualStyleBackColor = true;
            SaveChangesBtn3.Click += SaveChangesBtn3_Click;
            // 
            // StudentsDataGridView
            // 
            StudentsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            StudentsDataGridView.Location = new Point(6, 6);
            StudentsDataGridView.Name = "StudentsDataGridView";
            StudentsDataGridView.RowTemplate.Height = 25;
            StudentsDataGridView.Size = new Size(444, 348);
            StudentsDataGridView.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(569, 410);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            Departments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DepartmentsDataGridView).EndInit();
            Forms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)FormsDataGridView).EndInit();
            Groups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)GroupsDataGridView).EndInit();
            Students.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)StudentsDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage Departments;
        private DataGridView DepartmentsDataGridView;
        private TabPage Forms;
        private TabPage Groups;
        private TabPage Students;
        private Button Delete2;
        private Button SaveChangesBtn1;
        private DataGridView FormsDataGridView;
        private Button Delete3;
        private Button SaveChangesBtn2;
        private DataGridView GroupsDataGridView;
        private Button Delete4;
        private Button SaveChangesBtn3;
        private DataGridView StudentsDataGridView;
        private Button Delete1;
        private Button SaveChangesBtn;
        private Button RefreshBtn;
        private Button RefreshBtn1;
        private Button RefreshBtn2;
        private Button RefreshBtn4;
    }
}