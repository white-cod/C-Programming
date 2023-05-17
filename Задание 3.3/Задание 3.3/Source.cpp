#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_ALL, "");
	float r;
	r = 0;
	
	for (int i = 1; i <= 1000; i++)
	{

		r = r + i;

	}
	r = r / 1000;
	cout << "Среднее арифметическое = " << r;
	return 0;
}