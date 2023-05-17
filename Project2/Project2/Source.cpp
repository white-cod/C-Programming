#include <iostream>
using namespace std;

int main()
{
	setlocale(LC_ALL, "");
	float monthe, money, a, b;

	cout << "¬ведите сумму депозита ";
	cin >> money;
	cout << "¬ведите количество мес€цев ";
	cin >> monthe;

	b = money * (5 / 100) / 365 * monthe;
	cout << b;
}