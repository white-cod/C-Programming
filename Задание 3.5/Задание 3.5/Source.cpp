#include <iostream>
using namespace std;

int main()
{
	setlocale(LC_ALL, "");
    int a;
    cout << "¬ведите число\n";
    cin >> a;
    if (a > 0 || a < 10)
    {
        for (int i = 1; i <= 10; i++)
        {
            cout << a << " * " << i << " = " << a * i << endl;
        }
    }
    else
    {
        return 0;
    }

    return 0;

}