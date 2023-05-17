#include"String.h"

String::String()
{
	str = nullptr;
}

String::String(const char* _str)
{
	int Long = strlen(_str);
	str = new char[Long + 1];
	strcpy(str, _str);
}

String& String::operator=(const String& obj)
{
	if (str != nullptr)
	{
		delete[]str;
	}
	int Long = strlen(obj.str);
	str = new char[Long + 1];
	strcpy(str, obj.str);
	return *this;
}

String::String(const String& obj)
{
	int Long = strlen(obj.str);
	str = new char[Long + 1];
	strcpy(str, obj.str);
}

String String::operator+(const String& obj)
{
	String newStr;
	int Long = strlen(str);
	int NextLong = strlen(obj.str);
	newStr.str = new char[Long + NextLong + 1];
	int i = 0;

	for (; i < Long; i++)
	{
		newStr.str[i] = str[i];
	}

	for (size_t j = 0; j < NextLong; j++, i++)
	{
		newStr.str[i] = obj.str[j];
	}

	newStr.str[Long + NextLong] = '\0';
	return newStr;
}

void String::Print()
{
	cout << str << endl;	
}

String::~String()
{
	delete[]str;
}