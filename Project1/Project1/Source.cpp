#include <iostream>
#include <Windows.h>
using namespace std;
int main()
{
	setlocale(LC_ALL, "");
	/*
	Это работает
	*/
	float digit1;
	float digit2;

	cout << "Enter 2 numbers" << endl;

	cin >> digit1;
	cin >> digit2;
	cout << digit1 << " + " << digit2 << " = " << digit1 + digit2 << endl;
	cout << digit1 << " - " << digit2 << " = " << digit1 - digit2 << endl;
	cout << digit1 << " * " << digit2 << " = " << digit1 * digit2 << endl;
	cout << digit1 << " / " << digit2 << " = " << digit1 / digit2 << endl;
	
}