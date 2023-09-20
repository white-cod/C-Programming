using System.Data;

namespace calculator
{
    public partial class Form1 : Form
    {
        private string currentNumber = string.Empty;
        private double result = 0;
        private char operation = ' ';

        public Form1()
        {
            InitializeComponent();
        }

        private void AppendNumber(string number)
        {
            currentNumber += number;
            txtDisplay.Text = currentNumber;
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            AppendNumber(button.Text);
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentNumber))
            {
                result = double.Parse(currentNumber);
                currentNumber = string.Empty;
            }

            Button button = (Button)sender;
            operation = button.Text[0];
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentNumber))
            {
                double operand = double.Parse(currentNumber);

                switch (operation)
                {
                    case '+':
                        result += operand;
                        break;
                    case '-':
                        result -= operand;
                        break;
                    case '*':
                        result *= operand;
                        break;
                    case '/':
                        if (operand != 0)
                            result /= operand;
                        else
                            MessageBox.Show("Cannot divide by zero.");
                        break;
                }

                txtDisplay.Text = result.ToString();
                currentNumber = string.Empty;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            currentNumber = string.Empty;
            result = 0;
            operation = ' ';
            txtDisplay.Clear();
        }
        private void btn0_Click(object sender, EventArgs e)
        {
            AppendNumber("0");
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            AppendNumber("1");
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            AppendNumber("2");
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            AppendNumber("3");
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            AppendNumber("4");
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            AppendNumber("5");
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            AppendNumber("6");
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            AppendNumber("7");
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            AppendNumber("8");
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            AppendNumber("9");
        }

    }
}