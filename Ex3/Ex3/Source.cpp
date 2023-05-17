#include "Header.h"
#include <string>

using namespace std;

int main()
{
	Deque<int> di;
	for (int i = 0; i < 10; ++i)
	{
		di.addBegin(i);
		di.addEnd(i);
	}

	while (!di.isEmpty())
		cout << di.outBegin() << ' ';
	cout << endl;

	Deque<string> ds;
	ds.addBegin("Alpha Centauri");
	ds.addBegin("Proxima Centauri");

	string s1("Epsilon Eridani");
	ds.addBegin(move(s1));

	string s2 = "Sirius";
	ds.addEnd(move(s2));
	ds.addEnd("Epsilon Tucanae");

	while (!ds.isEmpty())
	{
		cout << ds.End() << endl;
		ds.popEnd();
	}

	return 0;
}