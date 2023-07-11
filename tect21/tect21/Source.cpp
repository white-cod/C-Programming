#include <iostream>
using namespace std;

class A {
	int a;
public:
	A(int x)
	{
		a = x;
		cout << "A(" << a << ")\n";
	}
	~A()
	{
		cout << "~A(" << a << ")\n";
	}
	void show()
	{
		cout << a << "\n";
	}

};
void f(A a)
{
	a.show();
}
void main() {
	A a1(123);
	f(a1);
}