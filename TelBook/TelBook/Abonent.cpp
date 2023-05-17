#include "Abonent.h"

void Abonent::Vvod()
{
	cout << "Enter Fio: ";
	gets_s(Fio);
	cout << "Enter telephone number: ";
	gets_s(Tel);
	cout << "Enter home phone number: ";
	gets_s(HomeTel);
	cout << "Enter mobile phone number: ";
	gets_s(MobileTel);
}

void Abonent::Show()
{
	cout << "Fio: " << Fio << "\tTel: " << Tel << "\tHome tel" << HomeTel << "\t Mobile tel" << MobileTel << endl;
}

char* Abonent::GetFio()
{
	return Fio;
}