#include"Overcoat.h"

Overcoat::Overcoat():
	str(nullptr), price(0) {}

Overcoat::Overcoat(string s, int p):
	str(s), price(p) {}

Overcoat::Overcoat(const Overcoat& other):
	str(other.str), price(other.price) {}

Overcoat Overcoat::operator=(const Overcoat& other)const
{
	swap(*this, other);
	return *this;
}

bool Overcoat::operator> (const Overcoat& other) const
{
	return (price > other.price);
}

bool Overcoat::operator==(const Overcoat& other) const
{
	if (str.size() != other.str.size())
	{
		return false;
	}
	for (int i = 0; i < str.size(); ++i)
	{
		if (str[i] != other.str[i])
		{
			return false;
		}
	}
	return true;
}

void Overcoat::print()
{
	cout << "\n" << str << "Price: " << price << endl;
}