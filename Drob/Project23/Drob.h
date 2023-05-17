#pragma once
#include <iostream>

using namespace std;

class Drob
{
public:

	int chisl, znamen;

	int Drob1(int a, int b)
	{
		if (b == 0)
		{
			cout << "Divided by zero!";
			return a;
		}
	}

	void Drob2(int a, int b)
	{
		chisl = a;
		znamen = b;
	}

	void Print()
	{
		cout << chisl << "/" << znamen << "\n";
	}

	void Add(int d)
	{
		chisl += (d*znamen);
		cout << chisl << '/' << znamen << endl;
	}

	void Sub(int d)
	{
		chisl -= (d * znamen);
		cout << chisl << '/' << znamen << endl;
	}

	void Mult(int d)
	{
		chisl *= d;
		cout << chisl << '/' << znamen << endl;
	}

	void Divi(int d)
	{
		znamen *= d;
		cout << chisl << '/' << znamen << endl;
	}

	int Broad()
	{
		return Drob1(chisl, znamen);
	}

	void reduct(int d)
	{
		chisl /= d;
		znamen /= d;
	}
};
