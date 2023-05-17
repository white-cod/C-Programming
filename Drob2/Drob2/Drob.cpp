#include "Drob.h"

int main()
{
	Drob Drob1;
	Drob Drob2;

	cout << "Please enter the first fraction\n ";
	Drob1.EnterDrob();
	cout << "\n";
	cout << "First fraction:\n ";
	Drob1.ShowDrob();
	cout << "\n";

	cout << "Please enter the second fraction\n ";
	Drob2.EnterDrob();
	cout << "\n";
	cout << "Second fraction:\n ";
	Drob2.ShowDrob();
	cout << "\n";

	cout << "Select arithmetic sign\n";
	cout << "1 - Add\n";
	cout << "2 - Sub\n";
	cout << "3 - Mult\n";
	cout << "4 - Div\n";
	int symbol;
	char ch_symbol = '.';
	cin >> symbol;

	switch (symbol)
	{
	case 1:
		cout << &(Drob1 + Drob2);
		break;
	case 2:
		cout << &(Drob1 - Drob2);
		break;
	case 3:
		cout << &(Drob1 * Drob2);
		break;
	case 4:
		cout << &(Drob1 / Drob2);
		break;
	default:
		cout << "Error!\n";
		return symbol;
		break;
	}

	system("pause");
	return 0;
}
																								//не вышло разыменовать
Drob& operator+(Drob const& value1, Drob const& value2)
{
	Drob result;
	result.chisl = (value1.chisl * value2.znam) + (value2.chisl * value1.znam);
	result.znam = value1.znam * value2.znam;
	return result;
};

Drob& operator-(Drob const& value1, Drob const& value2)
{
	Drob result;
	result.chisl = (value1.chisl * value2.znam) - (value2.chisl * value1.znam);
	result.znam = value1.znam * value2.znam;
	return result;
};

Drob& operator*(Drob const& value1, Drob const& value2)
{
	Drob result;
	result.chisl = value1.chisl * value2.chisl;
	result.znam = value1.znam * value2.znam;
	return result;
};

Drob& operator/(Drob const& value1, Drob const& value2)
{
	Drob result;
	result.chisl = value1.chisl * value1.znam;
	result.znam = value1.znam * value2.chisl;
	return result;
};