namespace BestOil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            cmbFuelType = new ComboBox();
            lblFuelPrice = new Label();
            txtLiters = new TextBox();
            rbtnLiters = new RadioButton();
            rbtnMoney = new RadioButton();
            lblPayment = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            label1 = new Label();
            groupBox3 = new GroupBox();
            btnCalculateTotal = new Button();
            groupBox4 = new GroupBox();
            txtTotalCafePurchase = new Label();
            label7 = new Label();
            label6 = new Label();
            chkProduct1 = new CheckBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtProduct4Quantity = new TextBox();
            chkProduct4 = new CheckBox();
            txtProduct2Quantity = new TextBox();
            chkProduct2 = new CheckBox();
            txtProduct3Quantity = new TextBox();
            chkProduct3 = new CheckBox();
            txtProduct1Quantity = new TextBox();
            btnCalculateAmount = new Button();
            lblCalculatedAmount = new Label();
            clearFormTimer = new System.Windows.Forms.Timer(components);
            groupBox5 = new GroupBox();
            toolTip1 = new ToolTip(components);
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabelDayOfWeek = new ToolStripStatusLabel();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            ukrainianToolStripMenuItem = new ToolStripMenuItem();
            englishToolStripMenuItem = new ToolStripMenuItem();
            notifyIcon1 = new NotifyIcon(components);
            timer1 = new System.Windows.Forms.Timer(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // cmbFuelType
            // 
            resources.ApplyResources(cmbFuelType, "cmbFuelType");
            cmbFuelType.FormattingEnabled = true;
            cmbFuelType.Items.AddRange(new object[] { resources.GetString("cmbFuelType.Items"), resources.GetString("cmbFuelType.Items1"), resources.GetString("cmbFuelType.Items2") });
            cmbFuelType.Name = "cmbFuelType";
            toolTip1.SetToolTip(cmbFuelType, resources.GetString("cmbFuelType.ToolTip"));
            cmbFuelType.SelectedIndexChanged += cmbFuelType_SelectedIndexChanged;
            // 
            // lblFuelPrice
            // 
            resources.ApplyResources(lblFuelPrice, "lblFuelPrice");
            lblFuelPrice.Name = "lblFuelPrice";
            toolTip1.SetToolTip(lblFuelPrice, resources.GetString("lblFuelPrice.ToolTip"));
            // 
            // txtLiters
            // 
            resources.ApplyResources(txtLiters, "txtLiters");
            txtLiters.Name = "txtLiters";
            toolTip1.SetToolTip(txtLiters, resources.GetString("txtLiters.ToolTip"));
            // 
            // rbtnLiters
            // 
            resources.ApplyResources(rbtnLiters, "rbtnLiters");
            rbtnLiters.Checked = true;
            rbtnLiters.Name = "rbtnLiters";
            rbtnLiters.TabStop = true;
            toolTip1.SetToolTip(rbtnLiters, resources.GetString("rbtnLiters.ToolTip"));
            rbtnLiters.UseVisualStyleBackColor = true;
            // 
            // rbtnMoney
            // 
            resources.ApplyResources(rbtnMoney, "rbtnMoney");
            rbtnMoney.Name = "rbtnMoney";
            rbtnMoney.TabStop = true;
            toolTip1.SetToolTip(rbtnMoney, resources.GetString("rbtnMoney.ToolTip"));
            rbtnMoney.UseVisualStyleBackColor = true;
            // 
            // lblPayment
            // 
            resources.ApplyResources(lblPayment, "lblPayment");
            lblPayment.Name = "lblPayment";
            toolTip1.SetToolTip(lblPayment, resources.GetString("lblPayment.ToolTip"));
            // 
            // groupBox1
            // 
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(txtLiters);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(rbtnMoney);
            groupBox1.Controls.Add(cmbFuelType);
            groupBox1.Controls.Add(rbtnLiters);
            groupBox1.Controls.Add(lblFuelPrice);
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            toolTip1.SetToolTip(groupBox1, resources.GetString("groupBox1.ToolTip"));
            // 
            // groupBox2
            // 
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.Controls.Add(lblPayment);
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            toolTip1.SetToolTip(groupBox2, resources.GetString("groupBox2.ToolTip"));
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            toolTip1.SetToolTip(label1, resources.GetString("label1.ToolTip"));
            // 
            // groupBox3
            // 
            resources.ApplyResources(groupBox3, "groupBox3");
            groupBox3.Controls.Add(btnCalculateTotal);
            groupBox3.Controls.Add(groupBox4);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(chkProduct1);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(txtProduct4Quantity);
            groupBox3.Controls.Add(chkProduct4);
            groupBox3.Controls.Add(txtProduct2Quantity);
            groupBox3.Controls.Add(chkProduct2);
            groupBox3.Controls.Add(txtProduct3Quantity);
            groupBox3.Controls.Add(chkProduct3);
            groupBox3.Controls.Add(txtProduct1Quantity);
            groupBox3.Name = "groupBox3";
            groupBox3.TabStop = false;
            toolTip1.SetToolTip(groupBox3, resources.GetString("groupBox3.ToolTip"));
            // 
            // btnCalculateTotal
            // 
            resources.ApplyResources(btnCalculateTotal, "btnCalculateTotal");
            btnCalculateTotal.Name = "btnCalculateTotal";
            toolTip1.SetToolTip(btnCalculateTotal, resources.GetString("btnCalculateTotal.ToolTip"));
            btnCalculateTotal.UseVisualStyleBackColor = true;
            btnCalculateTotal.Click += btnCalculateTotal_Click;
            // 
            // groupBox4
            // 
            resources.ApplyResources(groupBox4, "groupBox4");
            groupBox4.Controls.Add(txtTotalCafePurchase);
            groupBox4.Name = "groupBox4";
            groupBox4.TabStop = false;
            toolTip1.SetToolTip(groupBox4, resources.GetString("groupBox4.ToolTip"));
            // 
            // txtTotalCafePurchase
            // 
            resources.ApplyResources(txtTotalCafePurchase, "txtTotalCafePurchase");
            txtTotalCafePurchase.Name = "txtTotalCafePurchase";
            toolTip1.SetToolTip(txtTotalCafePurchase, resources.GetString("txtTotalCafePurchase.ToolTip"));
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            toolTip1.SetToolTip(label7, resources.GetString("label7.ToolTip"));
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            toolTip1.SetToolTip(label6, resources.GetString("label6.ToolTip"));
            // 
            // chkProduct1
            // 
            resources.ApplyResources(chkProduct1, "chkProduct1");
            chkProduct1.Name = "chkProduct1";
            toolTip1.SetToolTip(chkProduct1, resources.GetString("chkProduct1.ToolTip"));
            chkProduct1.UseVisualStyleBackColor = true;
            chkProduct1.CheckedChanged += chkProduct1_CheckedChanged;
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            toolTip1.SetToolTip(label5, resources.GetString("label5.ToolTip"));
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            toolTip1.SetToolTip(label4, resources.GetString("label4.ToolTip"));
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            toolTip1.SetToolTip(label3, resources.GetString("label3.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            toolTip1.SetToolTip(label2, resources.GetString("label2.ToolTip"));
            // 
            // txtProduct4Quantity
            // 
            resources.ApplyResources(txtProduct4Quantity, "txtProduct4Quantity");
            txtProduct4Quantity.Name = "txtProduct4Quantity";
            toolTip1.SetToolTip(txtProduct4Quantity, resources.GetString("txtProduct4Quantity.ToolTip"));
            // 
            // chkProduct4
            // 
            resources.ApplyResources(chkProduct4, "chkProduct4");
            chkProduct4.Name = "chkProduct4";
            toolTip1.SetToolTip(chkProduct4, resources.GetString("chkProduct4.ToolTip"));
            chkProduct4.UseVisualStyleBackColor = true;
            chkProduct4.CheckedChanged += chkProduct4_CheckedChanged;
            // 
            // txtProduct2Quantity
            // 
            resources.ApplyResources(txtProduct2Quantity, "txtProduct2Quantity");
            txtProduct2Quantity.Name = "txtProduct2Quantity";
            toolTip1.SetToolTip(txtProduct2Quantity, resources.GetString("txtProduct2Quantity.ToolTip"));
            // 
            // chkProduct2
            // 
            resources.ApplyResources(chkProduct2, "chkProduct2");
            chkProduct2.Name = "chkProduct2";
            toolTip1.SetToolTip(chkProduct2, resources.GetString("chkProduct2.ToolTip"));
            chkProduct2.UseVisualStyleBackColor = true;
            chkProduct2.CheckedChanged += chkProduct2_CheckedChanged;
            // 
            // txtProduct3Quantity
            // 
            resources.ApplyResources(txtProduct3Quantity, "txtProduct3Quantity");
            txtProduct3Quantity.Name = "txtProduct3Quantity";
            toolTip1.SetToolTip(txtProduct3Quantity, resources.GetString("txtProduct3Quantity.ToolTip"));
            // 
            // chkProduct3
            // 
            resources.ApplyResources(chkProduct3, "chkProduct3");
            chkProduct3.Name = "chkProduct3";
            toolTip1.SetToolTip(chkProduct3, resources.GetString("chkProduct3.ToolTip"));
            chkProduct3.UseVisualStyleBackColor = true;
            chkProduct3.CheckedChanged += chkProduct3_CheckedChanged;
            // 
            // txtProduct1Quantity
            // 
            resources.ApplyResources(txtProduct1Quantity, "txtProduct1Quantity");
            txtProduct1Quantity.Name = "txtProduct1Quantity";
            toolTip1.SetToolTip(txtProduct1Quantity, resources.GetString("txtProduct1Quantity.ToolTip"));
            // 
            // btnCalculateAmount
            // 
            resources.ApplyResources(btnCalculateAmount, "btnCalculateAmount");
            btnCalculateAmount.Name = "btnCalculateAmount";
            toolTip1.SetToolTip(btnCalculateAmount, resources.GetString("btnCalculateAmount.ToolTip"));
            btnCalculateAmount.UseVisualStyleBackColor = true;
            btnCalculateAmount.Click += btnCalculateAmount_Click;
            // 
            // lblCalculatedAmount
            // 
            resources.ApplyResources(lblCalculatedAmount, "lblCalculatedAmount");
            lblCalculatedAmount.Name = "lblCalculatedAmount";
            toolTip1.SetToolTip(lblCalculatedAmount, resources.GetString("lblCalculatedAmount.ToolTip"));
            // 
            // clearFormTimer
            // 
            clearFormTimer.Interval = 10000;
            // 
            // groupBox5
            // 
            resources.ApplyResources(groupBox5, "groupBox5");
            groupBox5.Controls.Add(btnCalculateAmount);
            groupBox5.Controls.Add(lblCalculatedAmount);
            groupBox5.Name = "groupBox5";
            groupBox5.TabStop = false;
            toolTip1.SetToolTip(groupBox5, resources.GetString("groupBox5.ToolTip"));
            // 
            // statusStrip1
            // 
            resources.ApplyResources(statusStrip1, "statusStrip1");
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabelDayOfWeek, toolStripDropDownButton1 });
            statusStrip1.Name = "statusStrip1";
            toolTip1.SetToolTip(statusStrip1, resources.GetString("statusStrip1.ToolTip"));
            // 
            // toolStripStatusLabel1
            // 
            resources.ApplyResources(toolStripStatusLabel1, "toolStripStatusLabel1");
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabelDayOfWeek
            // 
            resources.ApplyResources(toolStripStatusLabelDayOfWeek, "toolStripStatusLabelDayOfWeek");
            toolStripStatusLabelDayOfWeek.Name = "toolStripStatusLabelDayOfWeek";
            // 
            // toolStripDropDownButton1
            // 
            resources.ApplyResources(toolStripDropDownButton1, "toolStripDropDownButton1");
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { ukrainianToolStripMenuItem, englishToolStripMenuItem });
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            // 
            // ukrainianToolStripMenuItem
            // 
            resources.ApplyResources(ukrainianToolStripMenuItem, "ukrainianToolStripMenuItem");
            ukrainianToolStripMenuItem.Name = "ukrainianToolStripMenuItem";
            ukrainianToolStripMenuItem.Click += ukrainianToolStripMenuItem_Click;
            // 
            // englishToolStripMenuItem
            // 
            resources.ApplyResources(englishToolStripMenuItem, "englishToolStripMenuItem");
            englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            englishToolStripMenuItem.Click += englishToolStripMenuItem_Click;
            // 
            // notifyIcon1
            // 
            resources.ApplyResources(notifyIcon1, "notifyIcon1");
            notifyIcon1.Tag = "123";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(statusStrip1);
            Controls.Add(groupBox5);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Name = "Form1";
            Tag = "";
            toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbFuelType;
        private Label lblFuelPrice;
        private TextBox txtLiters;
        private RadioButton rbtnLiters;
        private RadioButton rbtnMoney;
        private Label lblPayment;
        private GroupBox groupBox1;
        private Label label1;
        private GroupBox groupBox2;
        private CheckBox chkProduct3;
        private TextBox txtProduct1Quantity;
        private CheckBox chkProduct1;
        private TextBox txtProduct4Quantity;
        private CheckBox chkProduct4;
        private TextBox txtProduct2Quantity;
        private CheckBox chkProduct2;
        private TextBox txtProduct3Quantity;
        private Label label2;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private GroupBox groupBox4;
        private Label txtTotalCafePurchase;
        private Button btnCalculateTotal;
        private Button btnCalculateAmount;
        private Label lblCalculatedAmount;
        private System.Windows.Forms.Timer clearFormTimer;
        private GroupBox groupBox5;
        private ToolTip toolTip1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem ukrainianToolStripMenuItem;
        private ToolStripMenuItem englishToolStripMenuItem;
        private NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer timer1;
        private GroupBox groupBox3;
        private ToolStripStatusLabel toolStripStatusLabelDayOfWeek;
    }
}