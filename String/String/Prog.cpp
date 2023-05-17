#include"String.h"

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	String str("String");
	String str1("String1");
	str.Print();
	String resultat = str + str1;
	resultat.Print();
	cout << endl;
	char buff[80];
	cout << "¬ведите первую строку: ";
	cin.getline(buff, 80);
	str = buff;
	cout << "¬ведите вторую строку: ";
	cin.getline(buff, 80);
	str1 = buff;
	cout << endl;

	resultat = str + str1;
	resultat.Print();
}