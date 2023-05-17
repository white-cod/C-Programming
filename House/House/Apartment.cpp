#include "Apartment.h"
#include<iostream>
using namespace std;

Apartment::Apartment()
{
	mas = NULL;
	size = 0;
	Nomer = 0;
}

Apartment::Apartment(const Apartment& copy)
{
	size = copy.size;
	Nomer = copy.Nomer;
	mas = new Person[size];
	for (int i = 0; i < size; i++)
	{
		mas[i] = copy.mas[i];
	}
}

Apartment& Apartment::operator=(const Apartment& copy)
{
	if (this != &copy)
	{
		if (mas != NULL) delete[] mas;
		size = copy.size;
		Nomer = copy.Nomer;
		mas = new Person[size];
		for (int i = 0; i < size; i++)
		{
			mas[i] = copy.mas[i];
		}
	}
	return *this;
}

void Apartment::Add_Person()
{
	Person tmp;
	tmp.Vvod();
	int f = 0;
	for (int i = 0; i < size; i++)
	{
		if (strcmp(tmp.GetName(), mas[i].GetName()) == 0)
		{
			f = 1;
			break;
		}
	}
	if (f == 0)
	{
		Person* New = new Person[size + 1];
		for (int i = 0; i < size; i++)
		{
			New[i] = mas[i];
		}
		New[size] = tmp;
		delete[] mas;
		mas = New;
		size++;
		cout << "The person is inhabited in the house\n";
	}
	else
	{
		cout << "Person already lives here\n";
	}
}

void Apartment::Del_Person()
{
	char str[20];
	cout << "Enter namr: ";
	gets_s(str);
	int f = 0;
	for (int i = 0; i < size; i++)
	{
		if (strcmp(str, mas[i].GetName()) == 0)
		{
			f = 1;
			break;
		}
	}
	if (f == 1)
	{
		Person* New = new Person[size - 1];
		int j = 0;
		for (int i = 0; i < size; i++)
		{
			if (strcmp(str, mas[i].GetName()) != 0)
			{
				New[j] = mas[i];
				j++;
			}
		}
		delete[] mas;
		mas = New;
		size--;
		cout << "Gilec viselen.\n";
	}
	else
	{
		cout << "Person does not live here\n";
	}
}


void Apartment::Print()
{
	cout << "Apartment number: " << Nomer << "\n";
	for (int i = 0; i < size; i++)
	{
		mas[i].Show();
	}
}

void Apartment::SetNomer(int n)
{
	Nomer = n;
}

int Apartment::Poisk_Name(const char* str)
{
	int f = 0;
	for (int i = 0; i < size; i++)
	{
		if (strcmp(mas[i].GetName(), str) == 0)
		{
			cout << "The person lives in an apartment: " << Nomer << "\n";
			mas[i].Show();
			f = 1;
		}
	}
	return f;
}

int Apartment::GetSize()
{
	return size;
}

Apartment::~Apartment()
{
	delete[] mas;
}