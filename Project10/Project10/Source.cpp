#include <iostream>
using namespace std;
int NOD(int a, int b)
{
    if (b == 0)
        return a;
    if (a > b)
        return NOD(b, a % b);
    else
        return NOD(a, b % a);
}

int main()
{
    int a, b;
    cout << "Enter 2 integers: " << endl;
    cin >> a;
    cin >> b;
    cout << "The greatest common divisor is: " << NOD(b, a % b) << endl;
    cin.get();
    cin.get();

}