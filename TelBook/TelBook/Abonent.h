#pragma once
#include<iostream>
using namespace std;
class Abonent
{
	char Fio[25];
	char Tel[25];
	char HomeTel[25];
	char MobileTel[25];
public:
	void Vvod();
	void Show();
	char* GetFio();
};