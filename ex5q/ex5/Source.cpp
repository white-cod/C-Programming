#include "Header.h"
using namespace std;

int main()
{

	Array<int> test;

	cout << "method \"GetSize\":\n";
	cout << test.getSize() << endl << endl;

	test.add(1);
	test.add(2);
	test.add(3);
	cout << "method \"Add\":\n";
	test.show();

	cout << "method \"GetUpperBound\":\n";
	cout << test.getUpperBound() << endl << endl;

	cout << "method \"IsEmpty\":\n";
	cout << test.isEmpty() << endl << endl;

	cout << "method \"GetSize\" (show the number of array elements for which memory is allocated):\n";
	cout << test.getSize() << endl << endl;

	test.setSize(5);
	cout << "method \"SetSize 5\n";
	cout << test.getSize() << endl << endl;

	test.setAt(3, 4);
	test.setAt(4, 5);
	cout << "method \"SetAt\" (value 4 and 5):\n";
	test.show();

	cout << "method \"FreeExtra\" (value 10):\n";
	test.setSize(10);
	test.freeExtra();
	cout << test.getSize() << endl << endl;

	cout << "method \"GetAt\" (Get the value of the 3rd element):\n";
	cout << test.getAt(2) << endl << endl;

	cout << "method \"operator[]\n";
	cout << test[2] << endl << endl;

	Array<int> test2;
	test2 = test;
	cout << "method \"operator=\" (created a second array and set it equal to the first one.)\n";
	test2.show();

	cout << "method \"GetData\" (Get array address):\n";
	cout << test.getData() << endl << endl;

	cout << "method \"Append\" (Added to the first array the second):\n";
	test.appEnd(test2);
	test.show();

	cout << "method \"InsertAt\" (Insert the number 100 in the second position):\n";
	test.insertAt(2, 100);
	test.show();

	cout << "method \"RemoveAt\" (Removed the number 100 from the second position):\n";
	test.removeAt(2);
	test.show();

	return 0;
}