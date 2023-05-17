#include <iostream>
using namespace std;

int powInnumber(int number, int powNum)
{
    if (powNum == 0)
        return 1;
    if (powNum == 1)
        return number;
    int result = number;
    for (int i = 0; i < powNum - 1; i++)
        result *= number;
        return result;
    
}

void main()
{
    int number, powNum;
    cout << "Enter number : ";
    cin >> number;
    cout << "Enter positive pow : ";
    cin >> powNum;
    if (powNum < 0)
        cout "Enter positive pow";
        return;
    cout << "Rezultat = " << powInnumber(number, powNum) << endl;
}