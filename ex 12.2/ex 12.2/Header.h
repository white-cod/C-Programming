#pragma once
#include <iostream>
#include <cmath>
using namespace std;

class myString
{
protected:

    char* data;
    int size;

public:

    myString(const char* input, int size) : data{ input ? new char[strlen(input) + 1] : nullptr }, size{ size }
    {
        if (data != nullptr)
        {
            strcpy_s(data, strlen(input) + 1, input);
        }
        else if (size > 0)
        {
            for (int i = 0; i < size; i++)
            {
                data[i] = '0';
            }
        }
    }

    myString(int size) :myString(new char[size + 1], size) {}

    myString(const char* input) :myString(input, strlen(input)) {}

    myString() :myString(new char[80], 80) {}

    myString(const myString& orig) :myString(orig.data, orig.size) {}


    myString(myString&& orig) noexcept
    {
        cout << "debug move operator" << *this;
        if (data != nullptr)
        {
            delete[] data;
        }
        data = orig.data;
        size = orig.size;
        orig.data = nullptr;
        orig.size = 0;
    }

    ~myString()
    {
        if (data)
        {
            delete[] data;
        }
    }

    friend ostream& operator << (ostream& output, const myString& outMS)
    {

        for (int i = 0; i < outMS.size; i++)
        {
            output << outMS.data[i];
        }
        return output;
    }

    friend istream& operator >> (istream& input, myString& inMS)
    {
        string temp;
        input >> temp;
        inMS.size = temp.size();
        inMS.data = new char[inMS.size + 1];
        for (int i = 0; i < inMS.size; i++)
        {
            inMS.data[i] = temp[i];
        }
        return input;
    }

    myString& operator = (myString& ms)
    {
        if (&ms == this)
        {
            return *this;
        }
        if (data)
            delete[] data;

        data = new char[ms.size + 1];
        strcpy_s(data, ms.size + 1, ms.data);
        size = ms.size;
        return *this;
    }

    myString& operator = (const char* input)
    {
        if (input == data)
            return *this;
        if (data)
            delete[] data;
        size = strlen(input);
        data = new char[size + 1];
        for (int i = 0; i < size; i++)
        {
            data[i] = input[i];
        }
        return *this;
    }

    bool operator ==(myString& ms2)
    {
        if (size == ms2.size)
        {
            for (int i = 0; i < size; i++)
            {
                if (data[i] != ms2.data[i])
                    return false;
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    bool operator !=(myString& ms2)
    {
        if (*this == ms2)
        {
            return false;
        }
        else
            return true;
    }
};

class myBitStr :public myString
{
    int* ConvertToBit(const char*& cstr)
    {
        int size = strlen(cstr);
        int* asciiStr = new int[size];
        int* bitStr = new int[size * 8 + 1];
        int index = 0;
        int power;

        for (int i = 0; i < size; i++)
        {
            asciiStr[i] = (int)cstr[i];
        }

        for (int i = 0; i < size; i++)
        {
            power = 7;
            while (power >= 0)
            {
                if (asciiStr[i] >= pow(2, power))
                {
                    asciiStr[i] -= pow(2, power);
                    bitStr[index] = 1;

                }
                else
                {
                    bitStr[index] = 0;
                }

                index++;
                power--;
            }
        }

        return bitStr;
    }
public:

    myBitStr(const char* input)
    {
        delete[] data;
        size = strlen(input) * 8;
        int* numData = new int[size];
        numData = ConvertToBit(input);
        data = new char[size + 1];
        for (int i = 0; i < size; i++)
        {
            if (numData[i] == 1)
            {
                data[i] = '1';
            }
            else
            {
                data[i] = '0';
            }
        }
    }

    myBitStr(int size) : myString(size) {}

    myBitStr() :myBitStr(" ") {}

    myBitStr(const myBitStr& orig) :myBitStr(orig.data) {}

    myBitStr(myBitStr&& orig) noexcept
    {
        if (data != nullptr)
        {
            delete[] data;
        }
        data = orig.data;
        size = orig.size;
        orig.data = nullptr;
        orig.size = 0;
    }

    myBitStr operator + (const myBitStr& ms2)
    {
        myBitStr result(size + ms2.size);
        int index = 0;
        for (int i = 0; i < result.size; i++)
        {
            if (i < size)
            {
                result.data[i] = data[i];
            }
            else
            {
                result.data[i] = ms2.data[index];
                index++;
            }
        }
        cout << result << endl;
        return result;
    }

    myBitStr operator += (myBitStr& ms2)
    {
        return *this + ms2;
    }

    myBitStr& operator = (const myBitStr& ms)
    {
        if (&ms == this)
        {
            return *this;
        }
        if (data != nullptr)
        {
            delete[] data;
        }

        data = new char[ms.size + 1];
        for (int i = 0; i < ms.size; i++)
        {
            data[i] = ms.data[i];
        }

        size = ms.size;
        return *this;
    }
};