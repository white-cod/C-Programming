using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorWPF
{
    public partial class MainWindow : Window
    {
        private char current_operator = ' ';

        private int operation_count = 0;

        private double fnum = 0;
        private double snum = 0;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            if (b == _1)
                NumCalc('1');
            else if (b == _2)
                NumCalc('2');
            else if (b == _3)
                NumCalc('3');
            else if (b == _4)
                NumCalc('4');
            else if (b == _5)
                NumCalc('5');
            else if (b == _6)
                NumCalc('6');
            else if (b == _7)
                NumCalc('7');
            else if (b == _8)
                NumCalc('8');
            else if (b == _9)
                NumCalc('9');
            else if (b == _0)
                NumCalc('0');
            else if (b == _point)
            {
                ResultInfo.Content = ResultInfo.Content + ",";
            }
            else if (b == _equal)
            {
                FinalCalculations();
                current_operator = ' ';
            }
            else if (b == _plus)
            {
                operation_count++;
                if (operation_count == 2)
                {
                    FinalCalculations();
                }

                current_operator = '+';
                ResultInfo.Content = ResultInfo.Content + "+";
            }
            else if (b == _minus)
            {
                operation_count++;
                if (operation_count == 2)
                {
                    FinalCalculations();
                }

                current_operator = '-';
                ResultInfo.Content = ResultInfo.Content + "-";
            }
            else if (b == _multiply)
            {
                operation_count++;
                if (operation_count == 2)
                {
                    FinalCalculations();
                }

                current_operator = '*';
                ResultInfo.Content = ResultInfo.Content + "*";
            }
            else if (b == _divide)
            {
                operation_count++;
                if (operation_count == 2)
                {
                    FinalCalculations();
                }

                current_operator = '/';
                ResultInfo.Content = ResultInfo.Content + "/";
            }
            else if (b == _exp)
            {
                operation_count++;
                if (operation_count == 2)
                {
                    FinalCalculations();
                }

                current_operator = 'e';
                ResultInfo.Content = ResultInfo.Content + "e";
            }
            else if (b == _root)
            {
                operation_count++;
                if (operation_count == 2)
                {
                    FinalCalculations();
                }

                current_operator = 'r';
                ResultInfo.Content = ResultInfo.Content + "r";
            }
            else if (b == _percent)
            {
                operation_count++;
                if (operation_count == 1)
                {
                    FinalCalculations();
                }

                current_operator = '%';
                ResultInfo.Content = ResultInfo.Content + "%";
            }
            else if (b == _clear_all)
            {
                ResultInfo.Content = "";
                fnum = 0;
                snum = 0;
                current_operator = ' ';
                operation_count = 0;
            }
            else
            {
                return;
            }
        }

        private void NumCalc(char num)
        {
            string temp_str = ResultInfo.Content as string;

            if (temp_str == null)
                return;
            else if (temp_str.Length >= 20)
                return;

            ResultInfo.Content = ResultInfo.Content + num.ToString();

            temp_str += num;

            if (current_operator == ' ')
            {
                fnum = double.Parse(temp_str);
            }
            else
            {
                int index = 0;

                for (int i = 0; i < temp_str.Length; i++)
                {
                    if (temp_str[i] == current_operator)
                    {
                        index = i;
                        break;
                    }
                }

                snum = double.Parse(temp_str[(index + 1)..(temp_str.Length)]);
            }
        }

        private void FinalCalculations()
        {
            if (current_operator == '+')
            {
                ResultInfo.Content = (fnum + snum).ToString();
                fnum = fnum + snum;
            }
            else if (current_operator == '-')
            {
                ResultInfo.Content = (fnum - snum).ToString();
                fnum = fnum - snum;
            }
            else if (current_operator == '*')
            {
                ResultInfo.Content = (fnum * snum).ToString();
                fnum = fnum * snum;
            }
            else if (current_operator == '/')
            {
                if (snum == 0)
                {
                    MessageBox.Show("You can't divide by zero.");
                    ResultInfo.Content = "";
                    fnum = 0;
                    return;
                }

                ResultInfo.Content = (fnum / snum).ToString();
                fnum = fnum / snum;
            }
            else if (current_operator == 'e')
            {
                ResultInfo.Content = (Math.Pow(fnum, snum)).ToString();
                fnum = Math.Pow(fnum, snum);
            }
            else if (current_operator == 'r')
            {
                if (fnum < 0)
                {
                    return;
                }

                ResultInfo.Content = (Math.Round(Math.Sqrt(fnum), 2).ToString());
                fnum = Math.Sqrt(fnum);
            }
            else if (current_operator == '%')
            {
                if (fnum < 0)
                {
                    return;
                }

                ResultInfo.Content = (Math.Round(fnum / 100, 2).ToString());
                fnum = Math.Round(fnum / 100, 2);
            }

            snum = 0;
            operation_count = 1;
        }
    }
}
