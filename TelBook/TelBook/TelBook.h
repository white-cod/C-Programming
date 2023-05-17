#pragma once
#include"Abonent.h"
class TelBook
{
	Abonent* mas;
	int size;
	int sizeMax;
public:
	TelBook(int);
	void Add();
	void Print();
	void FindFio();
	void DelFio();
	~TelBook();
};