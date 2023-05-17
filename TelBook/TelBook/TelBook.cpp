#include "TelBook.h"

TelBook::TelBook(int n)
{
	sizeMax = n;
	mas = new Abonent[sizeMax];
	size = 0;
}

void TelBook::Add()
{
	if (size < sizeMax)
	{
		mas[size].Vvod();
		size++;
	}
	else
	{
		cout << "TelBook full.\n";
	}
}

void TelBook::Print()
{
	for (int i = 0; i < size; i++)
	{
		mas[i].Show();
	}
}

void TelBook::FindFio()
{
	char str[25];
	cout << "Enter the name of the person you are looking for ";
	gets_s(str);
	int f = 0;
	for (int i = 0; i < size; i++)
	{
		if (strcmp(str, mas[i].GetFio()) == 0)
		{
			mas[i].Show();
			f = 1;
		}
	}
	if (f == 0)
		cout << "No matches found\n";
}

void TelBook::DelFio()
{
	char str[25];
	cout << "Enter the name of the person to be deleted ";
	gets_s(str);
	int f = 0;
	for (int i = 0; i < size; i++)
	{
		if (strcmp(str, mas[i].GetFio()) == 0)
		{
			for (int j = i; j < size - 1; j++)
			{
				mas[j] = mas[j + 1];
			}
			size--;
			i--;
			f = 1;
		}
	}
	if (f == 0)
		cout << "No matches found\n";
}

TelBook::~TelBook()
{
	delete[] mas;
}