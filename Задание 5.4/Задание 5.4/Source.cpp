#include <iostream>
#include <iomanip>
using namespace std;

void card(int suit, int num)
{
	char card[13] = { 'A', '2', '3', '4', '5', '6','7','8','9','0','J','Q','K', };
	cout << " _____________________ \n";
	cout << "|                     |\n";
	cout << "|                     |\n";
	if (num == 10)cout << '|' << setw(4) << "1" << card[num - 1] << "                |\n";
	else cout << '|' << setw(4) << card[num - 1] << "                 |\n";
	cout << "|		      |\n";
	cout << "|                     |\n";
	cout << "|                     |\n";
	cout << "|                     |\n";
	cout << "|                     |\n";
	switch (suit)
	{
		case 1: cout << '|' << setw(12) << "HEART" << "         |\n"; break;
		case 2: cout << '|' << setw(12) << "DIAMOND" << "         |\n"; break;
		case 3: cout << '|' << setw(12) << "CLUB" << "         |\n"; break;
		case 4: cout << '|' << setw(12) << "SPADE" << "         |\n"; break;
	}
	cout << "|                     |\n";
	cout << "|                     |\n";
	cout << "|                     |\n";
	cout << "|                     |\n";
	if (num == 10)cout << "|              " << "1" << card[num - 1] << "     |\n";
	else cout << "|               " << card[num - 1] << "     |\n";
	cout << "|                     |\n";
	cout << "|_____________________|\n";
}

int main()
{
	int a, b;
	cout << "Enter card\n1 - Ace \n2 - Two\n3 - Three\n4 - Four\n5 - Five\n6 - Six\n7 - Seven\n8 - Eight\n9 - Nine\n10 - Ten\n11 - Jacket\n12 - Quin\n13 - King" << endl;
	cin >> a;
	cout << "\n\t\t\tCard suits\n1. Heart.\n2. Diamond\n3. Club\n4. Spade\n";
	cout << "Input a card suit: ";
	cin >> b;
	card(b, a);
}
