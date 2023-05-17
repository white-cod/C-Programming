#include "Human.h"
#include <iostream>
#include <string.h>

using namespace std;

Human::Human() : Human("","")
{
}

Human::Human(const char* name, const char* lastName) : name{ new char[Human::STR_SIZE] {} },
			lastName{ new char[Human::STR_SIZE] {} }, age { 18 }
{
	strcpy_s(this->name, Human::STR_SIZE, name);
	strcpy_s(this->lastName, Human::STR_SIZE, lastName);
}

void Human::Print()
{
	cout << "_________________________________________" << endl;
	cout << lastName << "  " << name << endl;
	cout << "The age =  " << age << endl;
	cout << "_________________________________________" << endl;
}

Human::~Human()
{
	delete[] name;
	name = nullptr;
	delete[] lastName;
	lastName = nullptr;
	age = 0;
}
