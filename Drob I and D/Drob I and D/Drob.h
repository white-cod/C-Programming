#pragma once
#include <iostream>
using namespace std;

class Drob
{
public:
	Drob(int Chisl = 0, int Znam = 1)
	{
		SetChisl(Chisl);
		SetZnam(Znam);
	}
	Drob(const Drob& Sender)
	{
		SetChisl(Sender.Chisl);
		SetZnam(Sender.Znam);
	}
	~Drob();

	void Show();
	void SetChisl(int Chisl);
	void SetZnam(int Znam);
	int GetZnam() const;
	int GetChisl() const;

	Drob& operator++()
	{
		this->Chisl += this->Znam;
		return *this;
	}

	Drob& operator--()
	{
		this->Chisl -= this->Znam;
		return *this;
	}
private:
	int Chisl;
	int Znam;
};