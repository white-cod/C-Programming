#include "Drob.h"

int main()
{
	system("CLS");

	Drob A(3, 4);
	Drob B;
	B.SetChisl(1);
	B.SetZnam(2);
	cout << "\n";

	A.Show();
	cout << "Increment operation: \n";
	(++A).Show();
	cout << "\n";

	A.Show();
	cout << "Decrement operation: \n";
	(--A).Show();
	cout << "\n";
	cout << "\n";
}