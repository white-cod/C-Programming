#include"Drob.h"

int main()
{
	int a, b, num;
	cout << "Enter chislitel:" << endl;
	cin >> a;
	cout << "Enter znamenatel:" << endl;
	cin >> b;
	Drob obj;
	obj.Drob2(a, b);
	obj.reduct(obj.Broad());
	obj.Print();
	cout << "Select a num" << '\n';
	cout << "1 - Sum\n";
	cout << "2 - Subtraction\n";
	cout << "3 - Multiplyn\n";
	cout << "4 - Divisiono\n";
	cin >> num;
	switch (num)
	{
	case 1:
		cout << "Enter term" << endl;
		cin >> a;
		obj.Add(a);
		break;
	case 2:
		cout << "Enter subtrahend" << endl;
		cin >> a;
		obj.Sub(a);
		break;
	case 3:
		cout << "Enter multiplier" << endl;
		cin >> a;
		obj.Mult(a);
		break;
	case 4:
		cout << "Enter divisor" << endl;
		cin >> a;
		obj.Divi(a);
		break;
	default:
		cout << "Error!" << endl;
	}
}