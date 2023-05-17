#include <iostream>
using namespace std;

int main()
{
	setlocale(LC_ALL, "");
	int nume, size;
	cout << "¬ведите желаемый размер строки массива\n";
	cin >> size;
	cout << "¬ведите число\n";
	cin >> nume;
	int** arr = new int* [size];
	for (int i = 0; i < size; i++)
	{
		arr[i] = new int[size];
		for (int a = 0; a < size; a++)
		{
			arr[i][a] = nume;
			nume += 1;
			cout << arr[i][a] << " ";



		}
		cout << endl;
	}
	return 0;
}