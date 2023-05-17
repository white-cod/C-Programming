#include <iostream>
using namespace std;

double power(double base, int exp)
{
    double result = 1;

    int loop_ends;
    if (exp < 0)
        loop_ends = -1 * exp;
    else
        loop_ends = exp;

    for (int i = 0; i < loop_ends; ++i)
        result *= base;

    if (exp < 0)
        result = 1 / result;

    return result;
}
int main()
{
    cout << "Please enter a base: ";
    double base;
    cin >> base;

    cout << "\nPlease enter a power: ";
    int exp;
    cin >> exp;

    cout << "\nThe result is: " << power(base, exp);

    return 0;
}