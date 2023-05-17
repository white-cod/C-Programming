#pragma once
#include <iostream>
#include <Windows.h>

using namespace std;

class Reservoir
{
public:

	int id;
	int code;
	char* Reservoir_Name = nullptr;
	double width;
	double length;
	double depth;
	char* Tip = nullptr;
	long double area;
	long double volume;
	
	Reservoir();
	Reservoir(int id, int code, const char* name, double width, double length, double depth, const char* tip, const char* info);

	Reservoir(const Reservoir& obj);

	void DeleteReservoir(Reservoir*& vodoem, int* countreservoir, int* _number);

	void AddReservoir(Reservoir*& vodoem, int* countreservoir, int* _number);

	//ручной расчет площади по кадастровому номеру воды S = a * b, где S Ч площадь; a - длина и b - ширина.
	//используетс€ вручную, после изменени€ данных по единичной позиции
	long double SearchArea(Reservoir* vodoem, const int countreservoir, int _code, int* _idarray, int* check);

	//поиск дл€ сравнени€ площади водоемов одного типа (поиск учитывает регистр)
	//если ввести одну букву "р" то в результат попадут все типы, где есть эта буква
	void SearchAreaTip(Reservoir* vodoem, char const* charsearch, int const countreservoir);

	//расчет объема воды (Q = width * length * depth, где Q Ч объем; width * length * depth Ч ширина, длина и глубина)
	long double SearchVolume(Reservoir* vodoem, const int countreservoir, int _code, int* _idarray, int* check);

	bool CheckTip(Reservoir* vodoem, int const countreservoir, int _code1, int _code2, int* _idarray1, int* _idarray2);

	//вывод типа водоема
	void Show_Tip();

	//вывод водоемов на экран
	void Show_Reservoir();

	//вывод одного водоема на экран
	void Show_One_Reservoir();

	~Reservoir();
	//геттеры

	int Getid();
	int Getcode();
	char* GetReservoir_Name();
	double Getwidth();
	double Getlength();
	double Getdepth();
	char* GetDop_Info();
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