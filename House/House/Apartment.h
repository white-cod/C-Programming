#pragma once
#include"Person.h"
class Apartment
{
	Person* mas;
	int size;
	int Nomer;
public:
	Apartment();
	Apartment(const Apartment&);
	Apartment& operator=(const Apartment&);
	void Add_Person();
	void Del_Person();
	void Print();
	void SetNomer(int);
	int Poisk_Name(const char*);
	int GetSize();
	~Apartment();
};
