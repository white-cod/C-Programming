#include "House.h"
#include <iostream>
using namespace std;

House::House(int n)
{
	size = n;
	dom = new Apartment[size];
	for (int i = 0; i < size; i++)
	{
		dom[i].SetNomer(i + 1);
	}
	cout << "Enter address ";
	gets_s(Adress);
}

void House::Zaselenie()
{
	cout << "Enter apartment number: ";
	int Nom;
	cin >> Nom;
	cin.ignore();
	if (Nom <= size && Nom >= 1)
	{
		dom[Nom - 1].Add_Person();
	}
	else
	{
		cout << "Takogo nomera net.\n";
	}
}

void House::Viselenie()
{
	cout << "Enter apartment number: ";
	int Nom;
	cin >> Nom;
	cin.ignore();
	if (Nom <= size && Nom >= 1)
	{
		if (dom[Nom - 1].GetSize() != 0)
			dom[Nom - 1].Del_Person();
		else
			cout << "This apartment is empty\n";
	}
	else
	{
		cout << "No such number\n";
	}
}

void House::Print()
{
	cout << "Adress: " << Adress << "\n";
	int f = 0;
	for (int i = 0; i < size; i++)
	{
		if (dom[i].GetSize() != 0)
		{
			dom[i].Print();
			f = 1;
		}
	}
	if (f == 0)
		cout << "The house is empty.\n";
}

void House::Print_Apartment()
{
	cout << "Enter apartment number: ";
	int Nom;
	cin >> Nom;
	cin.ignore();
	if (Nom <= size && Nom >= 1)
	{
		if (dom[Nom - 1].GetSize() != 0)
			dom[Nom - 1].Print();
		else
			cout << "This apartment is empty\n";
	}
	else
	{
		cout << "No such number.\n";
	}
}

void House::Poisk_Gilca()
{
	char str[20];
	cout << "Enter name: ";
	gets_s(str);
	int f = 0;
	for (int i = 0; i < size; i++)
	{
		if (dom[i].Poisk_Name(str) == 1)
			f = 1;
	}
	if (f == 0)
		cout << "There is no such resident\n";
}

House::~House()
{
	delete[] dom;
}