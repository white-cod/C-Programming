#include "Drob.h"

Drob::~Drob() {}

void Drob::Show()
{
	cout << " " << Chisl << endl;
	cout << "---\n";
	cout << " " << Znam << endl;
}

void Drob::SetChisl(int Chisl)
{
	this->Chisl = Chisl;
}

void Drob::SetZnam(int Znam)
{
	this->Znam = Znam;
}

int Drob::GetZnam() const
{
	return Znam;
}

int Drob::GetChisl() const
{
	return Chisl;
}