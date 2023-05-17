#include <iostream>
#include <Windows.h>
#include <ctime>
using namespace std;
int** createArr2D(int  rows, int cols) {
	int** mas = new int* [rows];
	for (size_t r = 0; r < rows; r++)
		mas[r] = new int[cols] { 0 };
	return mas;
}
void deleteArr2D(int** mas, int rows) {
	for (size_t r = 0; r < rows; r++)
		delete[]  mas[r];
	delete[]  mas;
}
void Print(int** mas2d, int ryadkiv, int stovpciv) {
	for (size_t r = 0; r < ryadkiv; r++)
	{
		for (size_t c = 0; c < stovpciv; c++)
			cout << *(*(mas2d + r) + c) << "\t";
		cout << endl;
	}
}
void Set(int** mas2d, int ryadkiv, int stovpciv) {
	for (size_t r = 0; r < ryadkiv; r++)
		for (size_t c = 0; c < stovpciv; c++)
			mas2d[r][c] = -100 + rand() % 201;
}
void AddRowEnd(int**& mas2d, int& r, int& c) {
	int** newmas2d = createArr2D(r + 1, c);
	for (size_t i = 0; i < r; i++)
	{
		for (size_t j = 0; j < c; j++)
		{
			newmas2d[i][j] = mas2d[i][j];
		}
	}
	delete[]mas2d;
	mas2d = newmas2d;
	r++;
}
int main()
{
	int rows, cols;
	cout << "rows="; cin >> rows;
	cout << "cols="; cin >> cols;
	int** arr = createArr2D(rows, cols);
	Set(arr, rows, cols);
	Print(arr, rows, cols);
	cout << "***********************************************" << endl;
	AddRowEnd(arr, rows, cols);
	Print(arr, rows, cols);
	deleteArr2D(arr, rows);
	return 0;
}