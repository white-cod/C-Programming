#include"String.h"


MyString::MyString()
{
	str = nullptr;
}

MyString::MyString(const char* _str)
{
	//считаем кол-во сивмолов которые пришли
	int length = strlen(_str);

	//выделяем динамическую память под символы которые пришли + 1 для символа '\0'
	str = new char[length + 1];

	//копируем содержимое строки 2 (которая пришла в функцию) в строку 1
	strcpy(str, _str);
}


MyString& MyString::operator=(const MyString& obj)
{
	if (str != nullptr)
	{
		delete[]str;
	}

	int length = strlen(obj.str);
	str = new char[length + 1];

	strcpy(str, obj.str);

	return *this;
}

MyString::MyString(const MyString& obj)
{
	int length = strlen(obj.str);
	str = new char[length + 1];

	strcpy(str, obj.str);
}

MyString MyString::operator+(const MyString& obj)
{
	MyString newStr;

	int length = strlen(str);
	int secondlength = strlen(obj.str);

	newStr.str = new char[length + secondlength + 1];

	int i = 0;

	for (; i < length; i++)
	{
		newStr.str[i] = str[i];
	}


	for (size_t j = 0; j < secondlength; j++, i++)
	{
		newStr.str[i] = obj.str[j];
	}

	newStr.str[length + secondlength] = '\0';

	return newStr;
}


void MyString::Print()
{
	{
		cout << str << endl;
	}
}

MyString::~MyString()
{
	//очищаем динамическую память выделенную под массив char *srt
	delete[]str;
}