#pragma once
#include <iostream>
#include <string>
#include "Windows.h"
using namespace std;

class String
{
private:
    string data;
    int size;
public:

    String(string settingData) : data{ settingData } { size = data.size(); }

    int returnSize()
    {
        return size;
    }

    char operator[](const int index)
    {
        char* line = new char[size];
        data.copy(line, size);
        return line[index - 1];
    }

    int operator()(const char& element)
    {
        return data.find(element) + 1;
    }
};