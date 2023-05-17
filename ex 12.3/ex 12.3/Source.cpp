#include <iostream>
#include <string>
using namespace std;

template <typename T1, typename T2>
class base {
public:
    T1 value1;
    T2 value2;

    base(T1 v1, T2 v2) : value1(v1), value2(v2) {}
    ~base() {}

    void printValues() {
        cout << "value1: " << value1 << endl;
        cout << "value2: " << value2 << endl;
    }
};

template <typename T1, typename T2, typename T3, typename T4>
class child : public base<T1, T2> {
public:
    T3 value3;
    T4 value4;

    child(T1 v1, T2 v2, T3 v3, T4 v4) : base<T1, T2>(v1, v2), value3(v3), value4(v4) {}
    ~child() {}

    void printValues() {
        base<T1, T2>::printValues();
        cout << "value3: " << value3 << endl;
        cout << "value4: " << value4 << endl;
    }
};

template <typename T1, typename T2, typename T3, typename T4, typename T5, typename T6>
class child2 : public child<T1, T2, T3, T4> {
public:
    T5 value5;
    T6 value6;

    child2(T1 v1, T2 v2, T3 v3, T4 v4, T5 v5, T6 v6) : child<T1, T2, T3, T4>(v1, v2, v3, v4), value5(v5), value6(v6) {}
    ~child2() {}

    void printValues() {
        child<T1, T2, T3, T4>::printValues();
        cout << "value5: " << value5 << endl;
        cout << "value6: " << value6 << endl;
    }
};

int main() {
    child2<int, float, char, string, bool, double> c2(1, 2.3, 'a', "Hello", true, 3.14);
    c2.printValues();
    return 0;
}