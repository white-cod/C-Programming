#define _CRT_SECURE_NO_WARNINGS
#include "Overcoat.h"

int main() {

	setlocale(0, "");

	Overcoat coat1("Jacket ", 200);
	Overcoat coat2("Jeans ", 100);
	Overcoat coat3 = coat1;
	coat1.print();
	coat2.print();
	coat3.print();
	if (coat1 == coat2)
		cout << "Both types of clothes are the same\n";
	else
		cout << "Types of clothes are different\n";
	if (coat3 > coat2)
		cout << "Item 3 is more expensive than item 2\n";
	else
		cout << "Item 2 is more expensive than item 3\n";
	return 0;
}