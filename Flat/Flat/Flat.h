#pragma once
#include <iostream>
using namespace std;

class Flat
{
    int area;
    int price;

public:
    Flat() : area(0), price(0) {};
    Flat(int a_a, int price)
    {
        area = a_a;
        this->price = price;
    }

    bool operator ==(const Flat& comparison)
    {
        return this->area == comparison.area;
    }

    Flat& operator = (const Flat& assignments)
    {
        this->area = assignments.area;
        this->price = assignments.price;
        return *this;
    }

    bool operator >(const Flat& comparison)
    {
        return this->area > comparison.area;
    }

    friend ostream& operator <<(ostream& output, Flat object);
};