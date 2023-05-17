#pragma once
class Person
{
	char* Name;
	int Age;
	char* Gets();
public:
	Person();
	Person(const Person&);
	Person& operator=(const Person&);
	void Vvod();
	void Show();
	char* GetName();
	~Person();
};