#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <Windows.h>
#include <string.h>
#include <conio.h>


using namespace std;

class Reservoir
{
private:
	int id;
	int code;
	char* ResName = nullptr;
	double width;
	double length;
	double depth;
	char* Tip = nullptr;
	double area;
	double volume;

public:

	Reservoir();

	Reservoir(int id, int code, const char* name, double width, double length, double depth, const char* tip);

	Reservoir(const Reservoir& obj);

	void DelRes(Reservoir*& vodoem, int* countreservoir, int* number);

	void AddRes(Reservoir*& vodoem, int* countreservoir, int* number);

	double SearchArea(Reservoir* vodoem, const int countreservoir, int code, int* idarray, int* check);

	void SearchAreaTip(Reservoir* vodoem, char const* charsearch, int const countreservoir);

	long double SearchVolume(Reservoir* vodoem, const int countreservoir, int code, int* idarray, int* check);

	bool CheckTip(Reservoir* vodoem, int const countreservoir, int code1, int code2, int* idarray1, int* idarray2);
	
	void Show_Tip();

	void Show_Reservoir();

	void Show_One_Reservoir();

	~Reservoir();

	int Getid();
	int Getcode();
	char* GetReservoir_Name();
	double Getwidth();
	double Getlength();
	double Getdepth();
	char* GetTip();
	long double Getarea();
	long double Getvolume();

	void Setid(int id);
	void Setcode(int code);
	void SetReservoir_Name(char* ReservoirName);
	void Setwidth(double width);
	void Setlength(double length);
	void Setdepth(double depth);
	void SetTip(char* Tip);
	void Setarea(double area);
	void Setvolume(double volume);
};