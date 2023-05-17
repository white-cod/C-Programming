#include <iostream>
using namespace std;

void sumFun(int a, int b)
{

    int sum = 0;
    if (a < b)
    {
        int i = a + 1;
        while (i < b)
        {
            sum += i;
            i++;
        }
        cout << "sum is " << sum << endl;
    }
    else if (a > b)
    {
        int i = b + 1;
        while (i < a)
        {
            sum += i;
            i++;
        }
        cout << "sum is " << sum << endl;
    }
    else
    {
        cout << "sum is " << sum << endl;
    }
}
int main()
{
    int c, d;
    cout << "enter first number: ";
    cin >> c;
    cout << "enter second number: ";
    cin >> d;
    sumFun(c, d);
    return 0;
}