#include <iostream>
#include "time.h"
using namespace std;
const int SIZE = 10;
double ave(int array[][SIZE])
{
    double SUMMA = 0;
    for (int i = 0; i < SIZE; i++)
        for (int j = 0; j < SIZE; j++)
            SUMMA += array[i][j];
    return SUMMA / (SIZE * SIZE);
}
void print(int array[][SIZE])
{
    cout << "Array" << endl;
    for (int i = 0; i < SIZE; i++)
    {
        for (int j = 0; j < SIZE; j++)
            cout << array[i][j] << "\t";
        cout << endl;
    }
}
void set(int array[][SIZE])
{
    srand(time(0));
    for (int i = 0; i < SIZE; i++)
        for (int j = 0; j < SIZE; j++)
            array[i][j] = rand() % 100;
}

int main()
{
    int a[SIZE][SIZE];
    set(a);
    print(a);
    cout << "Average = " << ave(a) << endl;
    return 0;
}