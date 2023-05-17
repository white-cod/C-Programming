#include <iostream>
using namespace std;

int main() {
    while (true) {
        int* ptr = new int;
        *ptr = 10;
        delete ptr;
    }
    return 0;
}