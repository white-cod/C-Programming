#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_ALL, "");
	int n1, n2, n3, res = 0, temp, same;
	for (int i = 100; i <= 999; i++)
	{
		same = 0;
		n3 = i % 10;
		temp = i / 10;
		n2 = temp % 10;
		n1 = temp / 10;
		
		if ((n1 != n2) && (n1 != n3) && (n2 != n3))
		{
			cout << i << "\n";
			res++;
		}
	}
	cout << "Чисел с разными цифрами:" << res;
	
	return 0;
}