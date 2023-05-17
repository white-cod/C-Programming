#include "Person.h"
#include<iostream>
using namespace std;

char* Person::Gets()
{
	char ch;
	int n = 0;
	char* str = NULL;
	while ((ch = getchar()) != '\n')
	{
		str = (char*)realloc(str, n + 1);
		str[n] = ch;
		n++;
	}
	str = (char*)realloc(str, n + 1);
	str[n] = 0;
	return str;
}

Person::Person()
{
	Name = NULL;
}

Person::Person(const Person& copy)
{
	Age = copy.Age;
	Name = (char*)malloc(strlen(copy.Name) + 1);
	strcpy_s(Name, strlen(copy.Name) + 1, copy.Name);
}

Person& Person::operator=(const Person& copy)
{
	if (this != &copy)
	{
		if (Name != NULL) free(Name);
		Age = copy.Age;
		Name = (char*)malloc(strlen(copy.Name) + 1);
		strcpy_s(Name, strlen(copy.Name) + 1, copy.Name);
	}
	return *this;
}

void Person::Vvod()
{
	cout << "Enter your name: ";
	if (Name != NULL) free(Name);
	Name = Gets();
	cout << "Enter age: ";
	cin >> Age;
	cin.ignore();
}

void Person::Show()
{
	cout << "Name: " << Name << "\tAge: " << Age << "\n";
}

char* Person::GetName()
{
	return Name;
}

Person::~Person()
{
	free(Name);
}