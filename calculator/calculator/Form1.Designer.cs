namespace calculator
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
            txtDisplay = new TextBox();
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btn4 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btn7 = new Button();
            btn8 = new Button();
            btn9 = new Button();
            btnAdd = new Button();
            btnSubtract = new Button();
            btnMultiply = new Button();
            btnDivide = new Button();
            btnClear = new Button();
            btnEqual = new Button();
            btn0 = new Button();
            SuspendLayout();
            // 
            // txtDisplay
            // 
            txtDisplay.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            txtDisplay.Location = new Point(102, 48);
            txtDisplay.Name = "txtDisplay";
            txtDisplay.Size = new Size(200, 36);
            txtDisplay.TabIndex = 0;
            // 
            // btn1
            // 
            btn1.Location = new Point(68, 327);
            btn1.Name = "btn1";
            btn1.Size = new Size(50, 50);
            btn1.TabIndex = 1;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += btn1_Click;
            // 
            // btn2
            // 
            btn2.Location = new Point(141, 327);
            btn2.Name = "btn2";
            btn2.Size = new Size(50, 50);
            btn2.TabIndex = 2;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += btn2_Click;
            // 
            // btn3
            // 
            btn3.Location = new Point(212, 327);
            btn3.Name = "btn3";
            btn3.Size = new Size(50, 50);
            btn3.TabIndex = 3;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += btn3_Click;
            // 
            // btn4
            // 
            btn4.Location = new Point(68, 254);
            btn4.Name = "btn4";
            btn4.Size = new Size(50, 50);
            btn4.TabIndex = 4;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += btn4_Click;
            // 
            // btn5
            // 
            btn5.Location = new Point(141, 254);
            btn5.Name = "btn5";
            btn5.Size = new Size(50, 50);
            btn5.TabIndex = 5;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = true;
            btn5.Click += btn5_Click;
            // 
            // btn6
            // 
            btn6.Location = new Point(212, 254);
            btn6.Name = "btn6";
            btn6.Size = new Size(50, 50);
            btn6.TabIndex = 6;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = true;
            btn6.Click += btn6_Click;
            // 
            // btn7
            // 
            btn7.Location = new Point(68, 181);
            btn7.Name = "btn7";
            btn7.Size = new Size(50, 50);
            btn7.TabIndex = 7;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = true;
            btn7.Click += btn7_Click;
            // 
            // btn8
            // 
            btn8.Location = new Point(141, 181);
            btn8.Name = "btn8";
            btn8.Size = new Size(50, 50);
            btn8.TabIndex = 8;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += btn8_Click;
            // 
            // btn9
            // 
            btn9.Location = new Point(212, 181);
            btn9.Name = "btn9";
            btn9.Size = new Size(50, 50);
            btn9.TabIndex = 9;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = true;
            btn9.Click += btn9_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(212, 108);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(50, 50);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnOperator_Click;
            // 
            // btnSubtract
            // 
            btnSubtract.Location = new Point(282, 108);
            btnSubtract.Name = "btnSubtract";
            btnSubtract.Size = new Size(50, 50);
            btnSubtract.TabIndex = 11;
            btnSubtract.Text = "-";
            btnSubtract.UseVisualStyleBackColor = true;
            btnSubtract.Click += btnOperator_Click;
            // 
            // btnMultiply
            // 
            btnMultiply.Location = new Point(68, 400);
            btnMultiply.Name = "btnMultiply";
            btnMultiply.Size = new Size(50, 50);
            btnMultiply.TabIndex = 12;
            btnMultiply.Text = "*";
            btnMultiply.UseVisualStyleBackColor = true;
            btnMultiply.Click += btnOperator_Click;
            // 
            // btnDivide
            // 
            btnDivide.Location = new Point(212, 400);
            btnDivide.Name = "btnDivide";
            btnDivide.Size = new Size(50, 50);
            btnDivide.TabIndex = 13;
            btnDivide.Text = "/";
            btnDivide.UseVisualStyleBackColor = true;
            btnDivide.Click += btnOperator_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(68, 108);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(50, 50);
            btnClear.TabIndex = 14;
            btnClear.Text = "C";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnEqual
            // 
            btnEqual.Location = new Point(141, 108);
            btnEqual.Name = "btnEqual";
            btnEqual.Size = new Size(50, 50);
            btnEqual.TabIndex = 15;
            btnEqual.Text = "=";
            btnEqual.UseVisualStyleBackColor = true;
            btnEqual.Click += btnEqual_Click;
            // 
            // btn0
            // 
            btn0.Location = new Point(141, 400);
            btn0.Name = "btn0";
            btn0.Size = new Size(50, 50);
            btn0.TabIndex = 16;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = true;
            btn0.Click += btn0_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(396, 512);
            Controls.Add(btn0);
            Controls.Add(btnEqual);
            Controls.Add(btnClear);
            Controls.Add(btnDivide);
            Controls.Add(btnMultiply);
            Controls.Add(btnSubtract);
            Controls.Add(btnAdd);
            Controls.Add(btn9);
            Controls.Add(btn8);
            Controls.Add(btn7);
            Controls.Add(btn6);
            Controls.Add(btn5);
            Controls.Add(btn4);
            Controls.Add(btn3);
            Controls.Add(btn2);
            Controls.Add(btn1);
            Controls.Add(txtDisplay);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDisplay;
        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Button btn4;
        private Button btn5;
        private Button btn6;
        private Button btn7;
        private Button btn8;
        private Button btn9;
        private Button btnAdd;
        private Button btnSubtract;
        private Button btnMultiply;
        private Button btnDivide;
        private Button btnClear;
        private Button btnEqual;
        private Button btn0;
    }
}