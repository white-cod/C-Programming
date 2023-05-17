#include <iostream>

using namespace std;

int main() {
    int a, b;
    cout << "Enter the starting number: ";
    cin >> a;
    cout << "Enter the ending number: ";
    cin >> b;

    int product = 1;
    for (int i = a; i <= b; i++) {
        product *= i;
    }

    cout << "The product of numbers from " << a << " to " << b << " is " << product << endl;

    return 0;
}