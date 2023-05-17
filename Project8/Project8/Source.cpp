#include <iostream>
#include <time.h>
using namespace std;

template<typename T>
void gen(T array_1[], int size)
{
	for (int i = 0; i < size; i++)
	{
		array_1[i] = rand() % 200 / 10.0 + 1;
	}
}


template<typename T>
void print(T array_1[], int size)
{
	for (int i = 0; i < size; i++)
	{
		cout << array_1[i] << "  ";
	}
	cout << endl;
}

template<typename T>
auto sort_min(T array_1[], int size)
{
	T min = array_1[0];
	for (int i = 0; i < size; i++)
	{
		if (min > array_1[i])
		{
			min = array_1[i];
		}
	}
	return min;
}

template<typename T>
auto sort_max(T array_1[], int size)
{
	T max = array_1[0];
	for (int i = 0; i < size; i++)
	{
		if (max < array_1[i])
		{
			max = array_1[i];
		}
	}
	return max;
}

int main()
{
	srand(time(NULL));
	const int size{ 10 };
	double array_2[size]{};
	gen(array_2, size);
	print(array_2, size);
	cout << "min => " << sort_min(array_2, size) << endl;
	cout << "max => " << sort_max(array_2, size) << endl;


	return 0;
}