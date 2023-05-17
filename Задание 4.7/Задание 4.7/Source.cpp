#include <iostream>
#include <time.h>
using namespace std;
int  main()
{
    const int n = 10;
    int i, mini, maxi, min = numeric_limits<int>::max(), max = numeric_limits<int>::min(), A[n], sum = 0, prod = 1, p, first, last, sum2 = 0;
    
    srand(time(0));
    for (i = 0; i < n; i++)
    {
        A[i] = rand()%20 - 10;
        cout << A[i] << " ";
        if (A[i] < 0)
            sum += A[i];
        if (A[i] > max)
        {
            max = A[i];
            maxi = i;
        }
        if (A[i] < min)
        {
            min = A[i];
            mini = i;
        }
    }
    
    if (maxi > mini)
        for (i = mini; i <= maxi; i++)
            prod *= A[i];
    else
        for (i = maxi; i <= mini; i++)
            prod *= A[i];
    
    for (int i = 0; i < n; i++)
    {
        
        if (i % 2 == 0)
        p = A[i];
    }

    for (int i = 0; i < n; i++)
        if (A[i] < 0)
        {
            first = i;
            break;
        }
    for (int i = n - 1; i >= 0; i--)
        if (A[i] < 0)
        {
            last = i;
            break;
        }
    for (int i = first + 1; i < last; i++)
    {

        sum2 += A[i];

    }
    cout << "\nsum= " << sum << "\nprod= " << prod << "\nprod even= " << p << "\nsum2= " << sum2;
}