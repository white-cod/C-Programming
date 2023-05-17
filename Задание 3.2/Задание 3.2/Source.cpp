#include <iostream>
using namespace std;

int main()
{
	setlocale(LC_ALL, "");
	int x, y, f;
	float p;
	p = 1;
	cout << "¬ведите число которое хотите возвесть в степень \n";
	cin >> x;
	cout << "¬ведите степень \n";
	cin >> y;
	if (y == 0)
	{
		p = 1;

	}
	else
	{
		f = 1;
		
		while (f <= abs(y))
		{
			p = p * x;
			f = f++;

		}
		if (y < 0)
		{

			p = 1 / p;

		}
	}
	cout << "–езультат = " << p;
	
	return 0;
	

}