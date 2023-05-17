#include<iostream>
#include<conio.h>
using namespace std;
#include"House.h"
int main()
{
	House d(20);
	char ch;
	do
	{
		system("cls");
		cout << "Menu.\n";
		cout << "1 - Register for an apartment\n";
		cout << "2 - Move out of the apartment\n";
		cout << "3 - Person search\n";
		cout << "4 - Apartment search\n";
		cout << "5 - All tenants\n";
		cout << "Esc - Exit.\n";
		ch = _getch();
		switch (ch)
		{
		case '1':system("cls");
			d.Zaselenie();
			system("pause");
			break;
		case '2':system("cls");
			d.Viselenie();
			system("pause");
			break;
		case '3':system("cls");
			d.Poisk_Gilca();
			system("pause");
			break;
		case '4':system("cls");
			d.Print_Apartment();
			system("pause");
			break;
		case '5':system("cls");
			d.Print();
			system("pause");
			break;
		}
	} while (ch != 27);
}