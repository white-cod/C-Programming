#include "Reservoir.h"

Reservoir::Reservoir()
{
	id = 0;
	code = 0;
	ResName = new char[10]{ "Без имени" };
	width = 0;
	length = 0;
	depth = 0;
	Tip = new char[2]{ "-" };
	area = 0;
	volume = 0;
}

Reservoir::Reservoir(int id, int code, const char* name, double width, double length, double depth, const char* tip)
{
	id = id;
	code = code;
	width = width;
	length = length;
	depth = depth;

	ResName = new char[strlen(name) + 1];
	Tip = new char[strlen(tip) + 1];

	strcpy(ResName, name);
	strcpy(Tip, tip);
}

void Reservoir::DelRes(Reservoir*& vodoem, int* countreservoir, int* _number)
{
	system("cls");
	cout << "Удаление Водоема" << endl;


	int numbertmp = *_number;
	int p_count = 0;
	int delnumber;
	int countdel = 0;

	cout << "Введите кадастровый номер водоема для удаления: ";
	cin >> delnumber;
	cin.ignore();

	for (size_t i = 0; i < *countreservoir; i++)
	{
		if (vodoem[i].code == delnumber)
		{
			(*countreservoir)--;
			countdel++;
		}
	}

	Reservoir* temp = new Reservoir[*countreservoir];

	for (size_t i = 0; i < *countreservoir; i++)
	{
		if (vodoem[p_count].code == delnumber)
		{
			p_count++;
			i--;
		}

		else if (vodoem[p_count].code != delnumber)
		{
			temp[i].id = vodoem[p_count].id;
			temp[i].code = vodoem[p_count].code;
			temp[i].width = vodoem[p_count].width;
			temp[i].length = vodoem[p_count].length;
			temp[i].depth = vodoem[p_count].depth;
			temp[i].area = vodoem[p_count].area;
			temp[i].volume = vodoem[p_count].volume;

			temp[i].ResName = new char[strlen(vodoem[p_count].ResName) + 1];
			temp[i].Tip = new char[strlen(vodoem[p_count].Tip) + 1];

			strcpy(temp[i].ResName, vodoem[p_count].ResName);
			strcpy(temp[i].Tip, vodoem[p_count].Tip);

			p_count++;
		}
	}

	if (countdel)
	{
		cout << "Изменения внесены\n";
	}

	delete[]vodoem;
	vodoem = temp;

	if (!countdel)
	{
		cout << "Кадастровый номер не найден.\n";
		cout << "Нажми любую кнопку для возврата к меню.";
	}
}

void Reservoir::AddRes(Reservoir*& vodoem, int* countreservoir, int* _number)
{
	system("cls");
	cout << "Добавление Водоема" << endl;

	Reservoir* temp = new Reservoir[*countreservoir + 1];
	char name, tip;
	int numbertmp = *_number;

	for (size_t i = 0; i < *countreservoir; i++)
	{
		temp[i].id = vodoem[i].id;
		temp[i].code = vodoem[i].code;
		temp[i].width = vodoem[i].width;
		temp[i].length = vodoem[i].length;
		temp[i].depth = vodoem[i].depth;
		temp[i].area = vodoem[i].area;
		temp[i].volume = vodoem[i].volume;

		temp[i].ResName = new char[strlen(vodoem[i].ResName) + 1];
		temp[i].Tip = new char[strlen(vodoem[i].Tip) + 1];

		strcpy(temp[i].ResName, vodoem[i].ResName);
		strcpy(temp[i].Tip, vodoem[i].Tip);
	}

	temp[*countreservoir].id = numbertmp;

	cout << "Введите кадастровый код водоема: ";
	cin >> temp[*countreservoir].code;
	cin.ignore();

	cout << "Введите Наименование водоема: ";
	char buff[250];
	cin.getline(buff, 250);
	name = strlen(buff);
	temp[*countreservoir].ResName = new char[name + 1];
	strcpy(temp[*countreservoir].ResName, buff);

	cout << "Введите Ширину(км) водоема: ";
	cin >> temp[*countreservoir].width;
	cin.ignore();

	cout << "Введите Длину(км) водоема: ";
	cin >> temp[*countreservoir].length;
	cin.ignore();

	cout << "Введите Глубину(м) водоема: ";
	cin >> temp[*countreservoir].depth;
	cin.ignore();

	cout << "Введите Тип водоема: ";
	cin.getline(buff, 250);
	tip = strlen(buff);
	temp[*countreservoir].Tip = new char[tip + 1];
	strcpy(temp[*countreservoir].Tip, buff);

	(*countreservoir)++;
	(*_number)++;

	delete[]vodoem;

	vodoem = temp;

	cout << "Изменения внесены\n";
	cout << "Нажми любую кнопку для возврата к меню.";
}

long double Reservoir::SearchVolume(Reservoir* vodoem, const int countreservoir, int _code, int* _idarray, int* check)
{
	int searchidarray = 0;
	int count = 0;
	long double volume = 0;

	for (size_t i = 0; i < countreservoir; i++)
	{
		if (vodoem[i].code == _code)
		{
			searchidarray = count;
			*_idarray = count;
			(*check)++;
		}
		count++;
	}
	cout << endl;

	if (check++)
	{
		volume = vodoem[searchidarray].Getwidth() * vodoem[searchidarray].Getlength() * (vodoem[searchidarray].Getdepth() / 1000);
		vodoem[searchidarray].Setvolume(volume);
	}

	return volume;
}

double Reservoir::SearchArea(Reservoir* vodoem, const int countreservoir, int _code, int* _idarray, int* check)
{
	int searchidarray = 0;
	int count = 0;
	long double area = 0;

	for (size_t i = 0; i < countreservoir; i++)
	{
		if (vodoem[i].code == _code)
		{
			searchidarray = count;
			*_idarray = count;
			(*check)++;
		}
		count++;
	}
	cout << endl;

	if (check++)
	{
		area = vodoem[searchidarray].Getwidth() * vodoem[searchidarray].Getlength();
		vodoem[searchidarray].Setarea(area);
	}

	return area;
}

bool Reservoir::CheckTip(Reservoir* vodoem, int const countreservoir, int _code1, int _code2, int* _idarray1, int* _idarray2)
{


	for (size_t i = 0; i < countreservoir; i++)
	{
		if (vodoem[i].code == _code1)
			*_idarray1 = i;

		if (vodoem[i].code == _code2)
			*_idarray2 = i;
	}

	if (!strcmp(vodoem[*_idarray1].Tip, vodoem[*_idarray2].Tip))
		return true;

	else
		return false;
}

void Reservoir::Show_Tip()
{
	cout << Tip;
}

void Reservoir::Show_Reservoir()
{
	cout << left << code << " | " << ResName << " | " << width << " | " << length << " | " << depth << " | " << Tip << " | " << endl;

}

void Reservoir::Show_One_Reservoir()
{
	cout << ResName;
}

Reservoir::~Reservoir()
{
	delete[]ResName;
	delete[]Tip;
}

int Reservoir::Getid()
{
	return id;
}

int Reservoir::Getcode()
{
	return code;
}

char* Reservoir::GetReservoir_Name()
{
	return ResName;
}

double Reservoir::Getwidth()
{
	return width;
}

double Reservoir::Getlength()
{
	return length;
}

double Reservoir::Getdepth()
{
	return depth;
}


char* Reservoir::GetTip()
{
	return Tip;
}

long double Reservoir::Getarea()
{
	return area;
}

long double Reservoir::Getvolume()
{
	return volume;
}

void Reservoir::Setid(int _id)
{
	id = _id;
}

void Reservoir::Setcode(int _code)
{
	code = _code;
}

void Reservoir::SetReservoir_Name(char* _Reservoir_Name)
{
	if (ResName)
	{
		delete[] ResName;
	}

	ResName = new char[strlen(_Reservoir_Name) + 1];
	strcpy(ResName, _Reservoir_Name);
}

void Reservoir::Setwidth(double _width)
{
	width = _width;
}

void Reservoir::Setlength(double _length)
{
	length = _length;
}

void Reservoir::Setdepth(double _depth)
{
	depth = _depth;
}

void Reservoir::SetTip(char* _Tip)
{
	if (Tip)
	{
		delete[] Tip;
	}

	Tip = new char[strlen(_Tip) + 1];
	strcpy(Tip, _Tip);
}

void Reservoir::Setarea(double _area)
{
	area = _area;
}

void Reservoir::Setvolume(double _volume)
{
	volume = _volume;
}