#include <iostream>
using namespace std;
#define INTEGER
#define DOUBLE
#define CHAR
#include "function1.h"

int main()
{
	Type arr[5];
	Fill(arr, 5);
	Print(arr, 5);
	Min(arr, 5);
	Max(arr, 5);
	Sort(arr, 5);
	Change(arr, 5);
}