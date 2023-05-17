#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <Windows.h>
#include <string.h>
#include <conio.h>
#include <iomanip>

using namespace std;

class Reservoir
{
private:

	int id;
	int code;
	char* Reservoir_Name = nullptr;
	double width;
	double length;
	double depth;
	char* Dop_Info = nullptr;
	char* Tip = nullptr;
	long double area;
	long double volume;

public:

	Reservoir();
	//Reservoir(Reservoir*& vodoem, int* countreservoir, int* _number);
	Reservoir(int _id, int _code, const char* _name, double _width, double _length, double _depth, const char* _tip, const char* _info);

	//конструктор копирования
	Reservoir(const Reservoir& obj);

	void DeleteReservoir(Reservoir*& vodoem, int* countreservoir, int* _number);

	void AddReservoir(Reservoir*& vodoem, int* countreservoir, int* _number);

	//ручной расчет площади по кадастровому номеру воды S = a * b, где S — площадь; a - длина и b - ширина.
	//используется вручную, после изменения данных по единичной позиции
	long double SearchArea(Reservoir* vodoem, const int countreservoir, int _code, int* _idarray, int* check);

	//автоматический расчет площади (если база большая может занять время)
	void AutoSearchArea(Reservoir* vodoem, const int countreservoir);

	//поиск для сравнения площади водоемов одного типа (поиск учитывает регистр)
	//если ввести одну букву "р" то в результат попадут все типы, где есть эта буква
	void SearchAreaTip(Reservoir* vodoem, char const* charsearch, int const countreservoir);

	//расчет объема воды (Q = width * length * depth, где Q — объем; width * length * depth — ширина, длина и глубина)
	long double SearchVolume(Reservoir* vodoem, const int countreservoir, int _code, int* _idarray, int* check);

	bool CheckTip(Reservoir* vodoem, int const countreservoir, int _code1, int _code2, int* _idarray1, int* _idarray2);

	//вывод типа водоема
	void Show_Tip();

	//вывод водоемов на экран
	void Show_Reservoir();

	//вывод одного водоема на экран
	void Show_One_Reservoir();


	//геттеры

	int Getid();
	int Getcode();
	char* GetReservoir_Name();
	double Getwidth();
	double Getlength();
	double Getdepth();
	char* GetTip();
	long double Getarea();
	long double Getvolume();

	//сеттеры
	void Setid(int _id);
	void Setcode(int _code);
	void SetReservoir_Name(char* _Reservoir_Name);
	void Setwidth(double _width);
	void Setlength(double _length);
	void Setdepth(double _depth);
	void SetTip(char* _Tip);
	void Setarea(long double _area);
	void Setvolume(long double _volume);

};

//-----------------------------------------------------------------------------------------------

void gotoxy(int, int);

void ChangeCursorStatus(bool);
void MenuFun1();
void MenuFun2();
void MenuFun3();
void MenuFun4();
void MenuFun5();
void MenuFun6();
//-----------------------------------------------------------------------------------------------