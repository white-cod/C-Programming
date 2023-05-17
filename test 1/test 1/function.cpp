#include<iostream>
using namespace std; 
int main()
{
	setlocale(LC_ALL, "rus");
	cout << "¬ведите радиус круга\n";
	double R;
	cin >> R;
	cout << R * 3.14 * 2;
}