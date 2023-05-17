#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_ALL, "");
	int s, m, h;
	cout << "Введите время в секундах\n";
	cin >> s;
	m = s / 60;
	s = s % 60;
	h = m / 60;
	m = m % 60;
	cout << "Часов : " << h << "\n";
	cout << "Минут : " << m << "\n";
	cout << "Секунд : " << s << "\n";

	return 0;

}