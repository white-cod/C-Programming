#include <iostream>
using namespace std;

int main()
{
	setlocale(LC_ALL, "");
	int day, weeks;
	cout << "Введите количество дней \n";
	cin >> day;
	weeks = day / 7;
	day = day % 7;
	cout << "Недель : " << weeks << "\n";
	cout << "Дней : " << day << "\n";

	return 0;
}