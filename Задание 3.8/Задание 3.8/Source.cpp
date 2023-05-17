#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_ALL, "");
	int n, d, i = 0, newN = 0;
	cout << "¬ведите положительное число:\n";
	cin >> n;
	while (n > 0)
	{
		d = n % 10;
		if ((d != 3) && (d != 6))
		{
			newN = newN + d * pow(10, i);
			i++;
		}

		n = n / 10;
	}
	cout << "„исло без цифр 3 и 6: " << newN;
	return 0;
}