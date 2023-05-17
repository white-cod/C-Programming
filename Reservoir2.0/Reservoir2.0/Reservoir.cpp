#include "Reservoir.h"

Reservoir::Reservoir()
{
	id = 0;
	code = 0;
	Reservoir_Name = new char[10]{ "Без имени" };
	width = 0;
	length = 0;
	depth = 0;
	Tip = new char[2]{ "-" };
	Dop_Info = new char[2]{ "-" };
	area = 0;
	volume = 0;
}

Reservoir::Reservoir(int _id, int _code, const char* _name, double _width, double _length, double _depth, const char* _tip, const char* _info)
{
	id = _id;
	code = _code;
	width = _width;
	length = _length;
	depth = _depth;

	Reservoir_Name = new char[strlen(_name) + 1];
	Dop_Info = new char[strlen(_info) + 1];
	Tip = new char[strlen(_tip) + 1];

	strcpy(Reservoir_Name, _name);
	strcpy(Dop_Info, _info);
	strcpy(Tip, _tip);
}

Reservoir::Reservoir(const Reservoir& obj)
{
	id = obj.id;
	code = obj.code;

	Reservoir_Name = new char[strlen(obj.Reservoir_Name + 1)];
	strcpy(Reservoir_Name, obj.Reservoir_Name);

	width = obj.width;
	length = obj.length;
	depth = obj.depth;

	Dop_Info = new char[strlen(obj.Dop_Info + 1)];
	strcpy(Dop_Info, obj.Dop_Info);

	Tip = new char[strlen(obj.Tip + 1)];
	strcpy(Tip, obj.Tip);

	area = obj.area;
	volume = obj.volume;
}

void Reservoir::DeleteReservoir(Reservoir*& vodoem, int* countreservoir, int* _number)
{
	system("cls");
	gotoxy(0, 6);
	cout << "Удаление Водоема" << endl;


	int numbertmp = *_number;

	int p_count = 0;

	//кадастровый номер для удаления
	int delnumber;

	//счетчик был ли удален абонент
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

			temp[i].Reservoir_Name = new char[strlen(vodoem[p_count].Reservoir_Name) + 1];
			temp[i].Tip = new char[strlen(vodoem[p_count].Tip) + 1];
			temp[i].Dop_Info = new char[strlen(vodoem[p_count].Dop_Info) + 1];

			strcpy(temp[i].Reservoir_Name, vodoem[p_count].Reservoir_Name);
			strcpy(temp[i].Tip, vodoem[p_count].Tip);
			strcpy(temp[i].Dop_Info, vodoem[p_count].Dop_Info);

			p_count++;
		}
	}

	if (countdel)
	{
		cout << "Изменения внесены...\n";
	}

	delete[]vodoem;
	vodoem = temp;

	if (!countdel)
	{
		cout << "Кадастровый номер не найден.\n";
		cout << "Нажми любую кнопку для возврата к меню.";
	}
}

void Reservoir::AddReservoir(Reservoir*& vodoem, int* countreservoir, int* _number)
{
	system("cls");
	gotoxy(0, 6);
	cout << "Добавление Водоема" << endl;

	Reservoir* temp = new Reservoir[*countreservoir + 1];
	char _name, _tip, _info;
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

		temp[i].Reservoir_Name = new char[strlen(vodoem[i].Reservoir_Name) + 1];
		temp[i].Tip = new char[strlen(vodoem[i].Tip) + 1];
		temp[i].Dop_Info = new char[strlen(vodoem[i].Dop_Info) + 1];

		strcpy(temp[i].Reservoir_Name, vodoem[i].Reservoir_Name);
		strcpy(temp[i].Tip, vodoem[i].Tip);
		strcpy(temp[i].Dop_Info, vodoem[i].Dop_Info);
	}

	temp[*countreservoir].id = numbertmp;

	cout << "Введите кадастровый код водоема: ";
	cin >> temp[*countreservoir].code;
	cin.ignore();

	cout << "Введите Наименование водоема: ";
	char buff[250];
	cin.getline(buff, 250);
	_name = strlen(buff);
	temp[*countreservoir].Reservoir_Name = new char[_name + 1];
	strcpy(temp[*countreservoir].Reservoir_Name, buff);

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
	_tip = strlen(buff);
	temp[*countreservoir].Tip = new char[_tip + 1];
	strcpy(temp[*countreservoir].Tip, buff);

	cout << "Введите Дополнительную информацию: ";
	cin.getline(buff, 250);
	_info = strlen(buff);
	temp[*countreservoir].Dop_Info = new char[_info + 1];
	strcpy(temp[*countreservoir].Dop_Info, buff);
	cout << endl;

	(*countreservoir)++;
	(*_number)++;

	delete[]vodoem;

	vodoem = temp;

	cout << "Изменения внесены...\n";
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

long double Reservoir::SearchArea(Reservoir* vodoem, const int countreservoir, int _code, int* _idarray, int* check)
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

void Reservoir::AutoSearchArea(Reservoir* vodoem, const int countreservoir)
{
	long double area = 0;
	for (size_t i = 0; i < countreservoir; i++)
	{
		area = vodoem[i].Getwidth() * vodoem[i].Getlength();
		vodoem[i].Setarea(area);
	}
}

void Reservoir::SearchAreaTip(Reservoir* vodoem, char const* charsearch, int const countreservoir)
{
	int countsearch = 0;

	for (size_t i = 0; i < countreservoir; i++)
	{
		char* temp = strstr(vodoem[i].Tip, charsearch);

		if (temp)
		{
			countsearch++;

			if (countsearch == 1)
			{
				gotoxy(0, 13);
				cout << "+-------+---------------------------+-----------------+-------------+\n";
				gotoxy(0, 14);
				cout << "|Код    | Наименование              | Тип             | Площадь, км |\n";
				gotoxy(0, 15);
				cout << "+-------+---------------------------+-----------------+-------------+\n";
			}

			cout << left << "| " << setw(5) << vodoem[i].code << " | " << setw(26);
			vodoem[i].Show_One_Reservoir();

			cout << left << "| " << setw(15) << vodoem[i].Tip << " | " << setw(11) << vodoem[i].area << " | " << endl;
		}

	}

	cout << "+-------+---------------------------+-----------------+-------------+\n";

	if (countsearch < 1)
	{
		cout << "Водоемов по запросу не найдено" << endl;
		cout << "Нажми любую кнопку для возврата к меню.";
	}

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
	cout << left << "| " << setw(5) << code << " | " << setw(26) << Reservoir_Name << " | " << setw(10) << width << " | " << setw(9) << length << " | " << setw(10) << depth << " | " << setw(15) << Tip << " | " << setw(47) << Dop_Info << " | " << endl;

}

void Reservoir::Show_One_Reservoir()
{
	cout << Reservoir_Name;
}

Reservoir::~Reservoir()
{
	delete[]Reservoir_Name;
	delete[]Dop_Info;
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
	return Reservoir_Name;
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

char* Reservoir::GetDop_Info()
{
	return Dop_Info;
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
	if (Reservoir_Name)
	{
		delete[] Reservoir_Name;
	}

	Reservoir_Name = new char[strlen(_Reservoir_Name) + 1];
	strcpy(Reservoir_Name, _Reservoir_Name);
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

void Reservoir::SetDop_Info(char* _Dop_Info)
{
	if (Dop_Info)
	{
		delete[] Dop_Info;
	}

	Dop_Info = new char[strlen(_Dop_Info) + 1];
	strcpy(Dop_Info, _Dop_Info);
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

void Reservoir::Setarea(long double _area)
{
	area = _area;
}

void Reservoir::Setvolume(long double _volume)
{
	volume = _volume;
}