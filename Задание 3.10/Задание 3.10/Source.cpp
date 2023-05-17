#include <iostream>
using namespace std;

int main()
{
    int A, A1, sum = 0;
    cout << "A="; 
    cin >> A;
    if (A < 0) 
    A = -A;
    A1 = A;
    while (A > 0)
    {
        sum += A % 10;
        A /= 10;
    }
    if (sum * sum * sum == A1 * A1) cout << "YES\n";
    else cout << "NO\n";
  
    return 0;
}