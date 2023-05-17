#include <iostream>
using namespace std;

int main()
{
	setlocale(LC_ALL, "");
	int n1, n2, n3, n4, n5, n6, n7, maxNumber;
	cout << "Необходимо ввести 7 чисел\n\n";
	cout << "Введите первое число:\n";
	cin >> n1;
	cout << "Введите второе число:\n";
	cin >> n2;
	cout << "Введите третье число:\n";
	cin >> n3;
	cout << "Введите четвертое число:\n";
	cin >> n4;
	cout << "Введите пятое число:\n";
	cin >> n5;
	cout << "Введите шестое число:\n";
	cin >> n6;
	cout << "Введите седьмое число:\n";
	cin >> n7;
	if (n1 > n2)
	{
		maxNumber = n1;
	}
	else
	{
		maxNumber = n2;
	}
	if (n3 > maxNumber)
	{
		maxNumber = n3;
	}
	if (n4 > maxNumber)
	{
		maxNumber = n4;
	}
	if (n5 > maxNumber)
	{
			maxNumber = n5;
	}
	if (n6 > maxNumber)
	{
		maxNumber = n6;
	}
	if (n7 > maxNumber)
	{
		maxNumber = n7;
	}
	cout << "Максимальное число:" << maxNumber;
	return 0; 
}