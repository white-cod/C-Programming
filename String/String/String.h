#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <Windows.h>
#include <string.h>

using namespace std;

class String
{
private:
	char* str;
public:
	String();
	String(const char* _str);
	String& operator =(const String& obj);
	String(const String& obj);
	String operator +(const String& obj);
	void Print();

	~String();
};