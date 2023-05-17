#include <iostream>
#include <time.h>
using namespace std;


template<typename T1, typename T2>

decltype(auto) Summa(T1 oper1, T2 oper2)
{
	auto res = oper1 + oper2;
	return res;
}

template<typename T1, typename T2>
auto Compare(T1 oper1, T2 oper2)
{
	if (oper1 > oper2)
	{
		return oper1;
	}
	else
	{
		return oper2;
	}
}

int Summa(int oper1, int oper2, int oper3)
{
	return oper1 + oper2 + oper3;
}



template<typename T>
void Print(T res)
{
	cout << res << endl;
}

template<typename T>
void Gen(T array1[], int size)
{
	for (int i = 0; i < size; i++)
	{
		array1[i] = rand() % 20000 / 100.0 + 1;
	}
}

/*
void Gen(int array1[], int size)
{
	for (int i = 0; i < size; i++)
	{
		array1[i] = rand() % 20 + 1;
	}
}

void Gen(double array1[], int size)
{
	for (int i = 0; i < size; i++)
	{
		array1[i] = rand() % 20000 / 100.0 + 1;
	}
}
*/
void Gen(char array1[], int size)
{
	for (int i = 0; i < size; i++)
	{
		array1[i] = rand() % ('z' - 'a') + 'a';
	}
}

template<typename T>
void Print(T array1[], int size)
{
	for (int i = 0; i < size; i++)
	{
		cout << array1[i] << " : ";
	}
	cout << endl;
}

/*
void Print(int array1[], int size)
{
	for (int i = 0; i < size; i++)
	{
		cout << array1[i] << " : ";
	}
	cout << endl;
}

void Print(double array1[], int size)
{
	for (int i = 0; i < size; i++)
	{
		cout << array1[i] << " : ";
	}
	cout << endl;
}

void Print(char array1[], int size)
{
	for (int i = 0; i < size; i++)
	{
		cout << array1[i] << " : ";
	}
	cout << endl;
}
*/
template<typename T>
void Sort(T array1[], int size)
{
	for (int j = 0; j < size; j++)
	{
		for (int i = 0; i < size - 1; i++)
		{
			if (array1[i] > array1[i + 1])
			{
				T tmp = array1[i];
				array1[i] = array1[i + 1];
				array1[i + 1] = tmp;
			}
		}
	}
}

/*
void Sort(int array1[], int size)
{
	for (int j = 0; j < size; j++)
	{
		for (int i = 0; i < size - 1; i++)
		{
			if (array1[i] > array1[i + 1])
			{
				int tmp = array1[i];
				array1[i] = array1[i + 1];
				array1[i + 1] = tmp;
			}
		}
	}
}

void Sort(double array1[], int size)
{
	for (int j = 0; j < size; j++)
	{
		for (int i = 0; i < size - 1; i++)
		{
			if (array1[i] > array1[i + 1])
			{
				double tmp = array1[i];
				array1[i] = array1[i + 1];
				array1[i + 1] = tmp;
			}
		}
	}
}

void Sort(char array1[], int size)
{
	for (int j = 0; j < size; j++)
	{
		for (int i = 0; i < size - 1; i++)
		{
			if (array1[i] > array1[i + 1])
			{
				char tmp = array1[i];
				array1[i] = array1[i + 1];
				array1[i + 1] = tmp;
			}
		}
	}
}
*/

void Gen(int matrix[][10], int rows, int colls)
{
	for (int i = 0; i < rows; i++)
	{
		for (int j = 0; j < colls; j++)
		{
			matrix[i][j] = rand() % 20 + 1;
		}
	}
}


int main()
{
	srand(time(NULL));

	double compareOper1 = 18.656;
	int compareOper2 = 45;

	if (compareOper1 > compareOper2)
	{
		cout << compareOper1 << endl;
	}
	else
	{
		cout << compareOper2 << endl;
	}

	

	int oper1 = 100;
	int oper2 = 200;
	int res = oper1 + oper2;
	double res10 = 0;
	Print(res);

	res = Summa(oper1, oper2);
	Print(res);

	
	res = Summa(10.434, oper2 + 10);
	Print(res);

	
	res10 = Summa(10.434, 'f');
	Print(res10);

	
	res10 = Summa(340.434, 'G');
	Print(res10);

	res = Summa(10, 20, 30);
	Print(res);

	

	res10 = Summa(10.434, 77.543);
	Print(res10);

	const int size = 10;
	char array1[size]{};

	Gen(array1, size);
	Print(array1, size);
	Sort(array1, size);
	Print(array1, size);

	cout << "//////////////////////////////////" << endl;

	int array2[size]{};
	Gen(array2, size);
	Print(array2, size);
	Sort(array2, size);
	Print(array2, size);

	cout << "//////////////////////////////////" << endl;

	const int size1 = 15;
	double array3[size1]{};
	Gen(array3, size1);
	Print(array3, size1);
	Sort(array3, size1);
	Print(array3, size1);

	cout << "//////////////////////////////////" << endl;

	const int rows = 10;
	const int colls = 10;

	int matrix[rows][colls]{};

	Gen(matrix, rows, colls);

}