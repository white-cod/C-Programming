#pragma once
#include"Apartment.h"
class House
{
	Apartment* dom;
	int size;
	char Adress[25];
public:
	House(int);
	void Zaselenie();
	void Viselenie();
	void Print();
	void Print_Apartment();
	void Poisk_Gilca();
	~House();
};