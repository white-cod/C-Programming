#include <iostream>
using namespace std;


int main()
{
	setlocale(LC_ALL, "");
	int Number, n1, n2, n3, n4, newNumber, temp;
	cout << "Введите 4-значное число \n";
	cin >> Number;
	if (Number / 1000 < 1)
	{
		cout << "Ваше число меньше 4-значьного \n";
	}
	else if (Number / 1000 > 9)
	{
		cout << "Ваше число больше 4-значьного \n";
	}
	else
	{
		cout << "Ваше число подходит \n";
		n4 = Number % 10;
		temp = Number / 10;
		n3 = temp % 10;
		temp = temp / 10;
		n2 = temp % 10;
		n1 = temp / 10;
		cout << n1 << " " << n2 << " " << n3 << " " << n4 << " ";
		cout << "Изменим это число: \n";
		newNumber = n2 * 1000 + n1 * 100 + n4 * 10 + n3;
		cout << "Ваше новое число:" << newNumber;
	}

	return 0;

}