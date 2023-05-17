#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_ALL, "");
	int n1, n2, n3, same, res = 0, temp;
	for (int i = 100; i <= 999; i++)
	{
		same = 0;
		n3 = i % 10;
		temp = i / 10;
		n2 = temp % 10;
		n1 = temp / 10;

		if ((n1 == n2) && (n1 != n3) && (n2 != n3))	
		{
			same++;
		}
		if ((n1 != n2) && (n1 == n3) && (n2 != n3))	
		{
			same++;
		}
		if ((n1 != n2) && (n1 != n3) && (n2 == n3))
		{
			same++;
		}
		if (same == 1)
		{
			cout << i << "\n";
			res++;
		}
	}
	cout << "Чисел с одинаковыми цифрами:" << res;
		
	return 0;
			
}    