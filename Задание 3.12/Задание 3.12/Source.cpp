#include <iostream>
using namespace std;
int main()
{
    setlocale(LC_ALL, "");
    int num1, num2;
    cout << "Введите 2 числа\n";
    cin >> num1 >> num2;
    int i;
    for (i = 1; i <= num1 && i <= num2; i++) 
    {
        if (num1 % i == 0 && num2 % i == 0)
        cout << "Число для которого оба ваших числа делятся без остатка: " << i << "\n";
    }

}