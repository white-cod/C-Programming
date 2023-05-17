#include <iostream>
using namespace std;
int main()
{
	srand(time(0));
	char pole[3][3];
	int radok, stovp;
	int user_row, user_col;

	for (int r = 0; r < 3; r++)
	{
		for (int s = 0; s < 3; s++)
		{
			pole[r][s] = ' ';
		}
	}
	while (true)
	{
		cout << "Your step. Enter row and col of step" << endl;
		cin >> user_row;
		cin >> user_col;

		pole[user_row][user_col] = 'O';

		if ((pole[0][0] != ' ' && pole[0][0] == pole[1][0] && pole[1][0] == pole[2][0]) ||
			(pole[0][1] != ' ' && pole[0][1] == pole[1][1] && pole[1][1] == pole[2][1]) ||
			(pole[0][2] != ' ' && pole[0][2] == pole[1][2] && pole[1][2] == pole[2][2]) ||
			(pole[0][0] != ' ' && pole[0][0] == pole[0][1] && pole[0][1] == pole[0][2]) ||
			(pole[1][0] != ' ' && pole[1][0] == pole[1][1] && pole[1][1] == pole[1][2]) ||
			(pole[2][0] != ' ' && pole[2][0] == pole[2][1] && pole[2][1] == pole[2][2]) ||
			(pole[0][0] != ' ' && pole[0][0] == pole[1][1] && pole[1][1] == pole[2][2]) ||
			(pole[0][2] != ' ' && pole[0][2] == pole[1][1] && pole[1][1] == pole[2][0]))
		{
			cout << "Nice" << endl;
			break;
		}

		while (true)
		{
			radok = rand() % 3;
			stovp = rand() % 3;
			if (pole[radok][stovp] == ' ')
				break;
		}

		pole[radok][stovp] = 'X';


		cout << pole[0][0] << "|" << pole[0][1] << "|" << pole[0][2] << endl;
		cout << "-----" << endl;
		cout << pole[1][0] << "|" << pole[1][1] << "|" << pole[1][2] << endl;
		cout << "-----" << endl;
		cout << pole[2][0] << "|" << pole[2][1] << "|" << pole[2][2] << endl;

		cout << endl << endl;

		if ((pole[0][0] != ' ' && pole[0][0] == pole[1][0] && pole[1][0] == pole[2][0]) ||
			(pole[0][1] != ' ' && pole[0][1] == pole[1][1] && pole[1][1] == pole[2][1]) ||
			(pole[0][2] != ' ' && pole[0][2] == pole[1][2] && pole[1][2] == pole[2][2]) ||
			(pole[0][0] != ' ' && pole[0][0] == pole[0][1] && pole[0][1] == pole[0][2]) ||
			(pole[1][0] != ' ' && pole[1][0] == pole[1][1] && pole[1][1] == pole[1][2]) ||
			(pole[2][0] != ' ' && pole[2][0] == pole[2][1] && pole[2][1] == pole[2][2]) ||
			(pole[0][0] != ' ' && pole[0][0] == pole[1][1] && pole[1][1] == pole[2][2]) ||
			(pole[0][2] != ' ' && pole[0][2] == pole[1][1] && pole[1][1] == pole[2][0]))
		{
			cout << "Loooooser!!!" << endl;
			break;
		}

	}
	return 0;
}