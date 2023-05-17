#include "Flat.h"

int main()
{
    int a1, p1, a2, p2, a3, p3;
    cout << "Enter the area of the first flat\n";
    cin >> a1;
    cout << "Enter the price of the first flat\n";
    cin >> p1;
    cout << "Enter the area of the second flat\n";
    cin >> a2;
    cout << "Enter the price of the second flat\n";
    cin >> p2;
    cout << "Enter the area of the third flat\n";
    cin >> a3;
    cout << "Enter the price of the third flat\n";
    cin >> p3;
    Flat obj1(a1, p1), obj2(a2, p2), obj3(a3, p3);
    bool result;
    result = obj1 == obj2;
    result == 0 ? cout << "different\n" : cout << "identic\n";
    result = obj1 == obj3;
    result == 0 ? cout << "different\n" : cout << "identic\n";

    cout << "\n" << obj3;
    obj3 = obj1;
    cout << obj3 << "\n";

    result = obj1 > obj2;
    result == 0 ? cout << "less\n" : cout << "larger\n";
}

ostream& operator <<(ostream& output, Flat object)
{
    output << "\nprice - " << object.price << " $ \n" << "types_of_clothing - " << object.area << "\n";
    return output;
}