#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <Windows.h>
#include <string.h>
#include <conio.h>
#include <iomanip>

using namespace std;

using namespace std;

class Reservoir
{
	char* Name = new char[20];
	long long Long, Width, Depth;
public:
	void AddRes(const char*);
	void PrintRes();
	void Volume();
	void Area();
	void Srav();
	int Getsea();

	Reservoir(const Reservoir& obj);
	Reservoir();
	~Reservoir();
};