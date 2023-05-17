#include "Complex1.h"

int main()
{

    Complex k1, k2, k3, res;
    double s;
    /*double c;*/
    cin >> k1;
    cin >> k2;
    cout << "Entered public number: ";
    cin >> s;
    k3 = k2;
    cout << "First complex number = " << k1;
    cout << "Second complex number = " << k2;
    cout << "Real number = " << s << endl;
    res = k1 + k2;
    cout << "k1 + k2 = " << res;
    k2 = k3;
    res = k1 - k2;
    cout << "k1 - k2 = " << res;
    k2 = k3;
    res = k1 * k2;
    cout << "k1 * k2 = " << res;
    k2 = k3;
    res = k1 * s;
    cout << "const * k1 = " << res;
    res = s * k1;
    cout << "k1 * const = " << res;
    k1[0] = 6;
    k1[1] = 15;
    cout << "New complex number = " << k1[0];
    cout << "+im";
    cout << k1[1];
    cout << "\n";
    return 0;
}