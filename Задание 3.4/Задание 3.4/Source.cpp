#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_ALL, "");
    float a, s = 1;
    cout << "Введите число от 1 до 20\n";
    cin >> a;
    for (int i = a; i <= 20; i++)
    {
        s = s * i;
    }
    
    cout << "Производное  = " << s;
        
    return 0;


}