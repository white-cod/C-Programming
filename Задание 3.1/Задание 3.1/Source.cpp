#include <iostream>
using namespace std;

int main()
{
	setlocale(LC_ALL, "");
	int sum, n;
	sum = 0;
	cout << "¬ведите целое число \n";
	cin >> n;
	while ( n <= 500)
	{
		sum = sum + n;
		n = n++;
	}
	cout << "—умма целых чисел = " << sum;


	return 0;



}