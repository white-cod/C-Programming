#pragma once

#ifndef HUMAN_H
#define HUMAN_H

#include "IResident.h"

class Human : public IResident
{
protected:
	static const int STR_SIZE = 256;
	char* name;
	char* lastName;
	int age;

public:
	Human();
	Human(const char* name, const char* lastName);

	virtual void Init() = 0;
	virtual void Print();

	virtual ~Human();
};

#endif