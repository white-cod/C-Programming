#include <iostream>
#include "time.h"
using namespace std;

int main()
{
	int const n = 50, a = 0, b = 100;
	int mass[n];
	int min, max;
	srand(time(0));

	for (int i = 0; i < n; i++)
	{
		mass[i] = a + rand() % (b - a);
		cout << mass[i] << " ";

	}
	min = mass[0];
	max = mass[0];
	for (int i = 1; i < n; i++)
	{
		if (mass[i] > max)
		{
			max = mass[i];
		}
		if (mass[i] < min)
		{
			min = mass[i];
		}

	}
	cout << "min:" << min << ", max:" << max;
	return 0;
}
