#include <iostream>
using namespace std;

int main()
{
	setlocale(LC_ALL, "");
	
	int Number, n1, n2, n3, n4, n5, n6, sum1, sum2, temp;
	cout << "Введите 6-значное число \n";
	cin >> Number;
	if (Number / 100000 < 1)
	{
		cout << "Ваше число меньше чем 6-значное \n";

	}
	else if (Number / 100000 > 9)
	{
		cout << "Ваше число больше чем 6-значное \n";
	}
	else
	{
		cout << "Ваше число подходит \n";
		n6 = Number % 10;
		temp = Number / 10;
		n5 = temp % 10;
		temp = temp / 10;
		n4 = temp % 10;
		temp = temp / 10;
		n3 = temp % 10;
		temp = temp / 10;
		n2 = temp % 10;
		n1 = temp / 10;
		cout << n1 << " " << n2 << " " << n3;
		cout << " " << n4 << " " << n5 << " " << n6 << "\n";
		sum1 = n1 + n2 + n3;
		sum2 = n4 + n5 + n6;
		if (sum1 == sum2)
		{
			cout << "Ваше число счастливое!";

		}
		else
		{
			cout << "Ваше число не приносит удачу!";

		}

	}


	return 0;




}