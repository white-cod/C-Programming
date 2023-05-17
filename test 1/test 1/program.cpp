#include<iostream>
#include "function.h"
#include<time.h>
using namespace std;

void main()
{
    srand(time(0));
    int n = 5;
    Reservoir* a = new Reservoir[n];
    Reservoir b;
    //= a[2];
    //int z = 0;
    /*for (int i = 0; i < n; i++)
    {
        a[i].Volume();
        a[i].Area();
        a[i].Srav();
        if (a[i].Getsea()>12500)
        {
            z++;
        }

    }
    cout << z << endl;*/
    a[2].Show();
    a[2].Add("qazwsx");
    a[2].Show();

    //b = a[2];
    b.Show();

    cout << endl;

    /*a.Volume();
    a.Area();
    a.Srav();*/

    delete[] a;
}