#include <iostream>
using namespace std;

int main()
{
	setlocale(LC_ALL, "");
	double money, deposit;
	cout << "¬ведите сумму денежного вклада в евро\n";
	cin >> money;
	cout << "¬ведите процент годовых, которые выплачивает банк.\n";
	cin >> deposit;
	deposit = (deposit / 100) / 12;
	money = money * deposit;
	cout << "Ѕвнк будет выплачивать " << money << " евро ежемес€чно";

	return 0;

}