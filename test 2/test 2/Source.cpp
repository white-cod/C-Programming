#include <iostream>
#include <time.h>

using namespace std;

int main()
{
	int arr[10];

	for (int i = 0; i < 10; i++)
	{
		arr[i] = rand() % 10;
	}

	for (int i = 0; i < 10; i++)
	{
		cout << arr[i] << " ";
	}
}