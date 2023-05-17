#include <iostream>
#include "Matrix.h"
using namespace std;

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(0));
	Matrix<double> A(3, 4);
	A.SetMat(-10, 10);

	cout << "A:\n" << A << endl;
	cout << "Max: " << A.Max() << endl;
	cout << "Min: " << A.Min() << endl << endl;

	Matrix<double> B(4, 3);
	B.SetMat(-10, 10);
	cout << "B:\n" << B << endl;
	cout << "A + B:\n" << A + B << endl << endl;
	cout << "A - B\n" << A - B << endl << endl;
	try {
		cout << "A * B:\n" << A * B << endl << endl;
	}
	catch (const char* ex)
	{
		cout << "Error = " << ex << endl;
	}

	cout << A * 5 << endl << endl;

	Matrix<double> C(2, 2);
	cout << "Enter a value for the new matrix:\n";
	cin >> C;
	cout << "C:\n" << C << endl;

	return 0;
}