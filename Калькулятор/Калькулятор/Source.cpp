#include <iostream>
#include <math.h>
using namespace std;

int main()
{
	setlocale(LC_ALL, "");
	while (true)
	{
		double a, b;
		double resuit;
		cout << "\n\nВведите число\n";
		cin >> a;
		cout << "Введите математическое действие:\n\n";
		int selection;
		cout << "1-Сложение\n";
		cout << "2-Вычитание\n";
		cout << "3-Умножение\n";
		cout << "4-Деление\n";
		cout << "5-Возведение числа в степень\n";
		cout << "6-Корень числа\n";
		cin >> selection;

		switch (selection)
		{

		case 1:
			cout << "\nВведите второе число\n";
			cin >> b;
			cout << endl;
			cout << a << " + " << b << " = " << a + b;
			break;
		case 2:
			cout << "\nВведите второе число\n";
			cin >> b;
			cout << endl;
			cout << a << " - " << b << " = " << a - b;
			break;
		case 3:
			cout << "\nВведите множитель\n";
			cin >> b;
			cout << endl;
			cout << a << " * " << b << " = " << a * b;
			break;
		case 4:
			cout << "\nВведите делитель\n";
			cin >> b;
			cout << endl;
			cout << a << " / " << b << " = " << a / b;
			break;
		case 5: 
			cout << "\nВведите степень\n";
			cin >> b;
			cout << endl;
			resuit = pow(a, b);
			cout << a << " ^ " << b << " = " << resuit;
			break;
		case 6:
			resuit = sqrt(a);
			cout << "Корень числа " << a << " = " << resuit;
			break;
		default:
			cout << "Некоректный выбор пункта\n";
			break;
		}
	}
}