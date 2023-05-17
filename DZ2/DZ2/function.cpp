#include <iostream>
using namespace std;
#include "function1.h"
void IntFillArr(int* arr, int n)
{
	//srand(time(NULL));
	for (int i = 0; i < n; i++)
	{
		arr[i] = rand() % 25;
	}
}

void IntPrintArr(int* arr, int n)
{
	for (int i = 0; i < n; i++)
	{
		cout << arr[i] << "\t";
	}
	cout << "\n";
}

void IntMinArr(int* arr, int n)
{
	int min = arr[0];
	for (int i = 0; i < n; i++)
		if (arr[i] < min)
			min = arr[i];
	cout << "Min: " << min << "\n";
}

void IntMaxArr(int* arr, int n)
{
	int max = arr[0];
	for (int i = 0; i < n; i++)
		if (arr[i] > max)
			max = arr[i];
	cout << "Max: " << max << "\n";
}

void IntSortArr(int* arr, int n)
{
	for (int i = 0; i < n; i++)
		for (int j = 0; j < n; j++)
			if (arr[j] < arr[i])
				swap(arr[i], arr[j]);
}

void IntChangeArr(int* arr)
{
	int b;
	int temp;
	cout << "Enter the item number you want to change\n";
	cin >> b;
	cout << "Enter new value\n";
	cin >> temp;
	arr[b + 1] = temp;
}

//double arr

void FloatFillArr(double* arr, int n)
{
	srand(time(NULL));
	for (int i = 0; i < n; i++)
	{
		arr[i] = rand() / 10.0 * 2;
	}
}

void FloatPrintArr(double* arr, int n)
{
	for (int i = 0; i < n; i++)
	{
		cout << arr[i] << " ";
	}
}

void FloatMinArr(double* arr, int n)
{
	double min = arr[0];
	for (int i = 0; i < n; i++)
		if (arr[i] < min)
			min = arr[i];
	cout << "Min: " << min << "\n";
}

void FloatMaxArr(double* arr, int n)
{
	double max = arr[0];
		for (int i = 0; i < n; i++)
			if (arr[i] > max)
				max = arr[i];
	cout << "Max: " << max << "\n";
}

void FloatSortArr(double* arr, int n)
{
	for (int i = 0; i < n; i++)
		for (int j = 0; j < n; j++)
			if (arr[j] < arr[i])
				swap(arr[i], arr[j]);
}

void FloatChangeArr(double* arr)
{
	int b;
	double temp;
	cout << "Enter the item number you want to change\n";
	cin >> b;
	cout << "Enter new value\n";
	cin >> temp;
	arr[b + 1] = temp;
}

//char arr

void CharFillArr(char* arr, int n)
{

	for (int i = 0; i < n; i++)
	{
		arr[i] = rand() % 100;
	}
}

void CharPrintArr(char* arr, int n)
{
	for (int i = 0; i < n; i++)
	{
		cout << arr[i] << " ";
	}
}

void CharMinArr(char* arr, int n)
{
	char min = arr[0];
	for (int i = 0; i < n; i++)
		if (arr[i] < min)
			min = arr[i];
	cout << "Min: " << min << "\n";
}

void CharMaxArr(char* arr, int n)
{
	char max = arr[0];
	for (int i = 0; i < n; i++)
		if (arr[i] > max)
			max = arr[i];
	cout << "Max: " << max << "\n";
}

void CharSortArr(char* arr, int n)
{
	for (int i = 0; i < n; i++)
		for (int j = 0; j < n; j++)
			if (arr[j] < arr[i])
				swap(arr[i], arr[j]);
}

void CharChangeArr(char* arr)
{
	char b;
	char temp;
	cout << "Enter the item number you want to change\n";
	cin >> b;
	cout << "Enter new value\n";
	cin >> temp;
	arr[b + 1] = temp;
}