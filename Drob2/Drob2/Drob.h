#pragma once
#include <iostream>
using namespace std;

class Drob
{
	int chisl;
	int znam;

public:
	Drob() :chisl(1), znam(1) {};

	void  EnterDrob()
	{
		cin >> chisl;
		cout << "---\n ";
		cin >> znam;
	};

	void ShowDrob()
	{
		cout << "\n" << " " << chisl << "\n" << "---" << "\n" << " " << znam << "\n";
	};
	friend Drob& operator+(Drob const& value1, Drob const& value2);
	friend Drob& operator-(Drob const& value1, Drob const& value2);
	friend Drob& operator*(Drob const& value1, Drob const& value2);
	friend Drob& operator/(Drob const& value1, Drob const& value2);
};