#include <iostream>
#define MIN(x,y) ((x)<(y)?(x):(y))
#define MAX(x,y) ((x)>(y)?(x):(y))
#define POW2(x) ((x)*(x))
#define POW(x,y) ((!y)?1:x*pow(x,y-1))
#define EVEN(x) ( x % 2 == 0 ? " четное" : " не четное" )

using namespace std;

int main()
{
	setlocale(LC_ALL, "");
	cout << "Выберете математическое действие:\n";
	cout << "1 - Поиск минимального числа из двух\n";
	cout << "2 - Поиск максимального числа из двух\n";
	cout << "3 - Возвести число в квадрат\n";
	cout << "4 - Возвести число в степень\n";
	cout << "5 - Проверка на четность\n";
	int choice, a;
	double x, y;
	cin >> choice;

	switch (choice)
	{
	case 1:
		cout << "\nВведите два числа\n";
		cin >> x >> y;
		cout << "Минимальное число - " << MIN(x, y) << endl;
		break;
	case 2:
		cout << "Введите два числа\n";
		cin >> x >> y;
		cout << "Максимальное число - " << MAX(x, y) << endl;
		break;
	case 3:
		cout << "Введите число\n";
		cin >> x;
		cout << "Квадрат числа " << x << " Число " << POW2(x) << endl;
		break;
	case 4:
		cout << "Введите число\n";
		cin >> x;
		cout << "Введите степень числа\n";
		cin >> y;
		cout << x << "^" << y << " = " << POW(x, y) << endl;
		break;
	case 5:
		cout << "Введите целое число\n";
		cin >> a;
		cout << "Число " << a << EVEN(a) << endl;
		break;
	default:
		cout << "Некоректный выбор пункта\n";
		break;
	}
}