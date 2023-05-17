#include <iostream>
using namespace std;
int main()
{
    setlocale(LC_ALL, "");
    int num;
    cout << "Insert you number\n";
    cin >> num;

    for (int i = 1; i <= num; i++)
    {
        if (num % i == 0)
        cout << "„исло дл€ которого ваше число делитс€ без остатка: " << i << endl;
    }
}