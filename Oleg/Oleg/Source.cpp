#include <iostream>
#include <string>

using namespace std;

int main() {
    int a = 0;
    int ans;
    string surname;

    cout << "The Oleg Convincer v2.0" << endl;
    cout << "What is Oleg's surname?" << endl;

    while (a == 0) {
        cin >> surname;

        if (surname == "Pasochka") {
            cout << "Are you Oleg?" << endl;
            cout << "1. Yes" << endl;
            cout << "2. No" << endl;
            cin >> ans;

            if (ans == 1) {
                cout << "Hi, Oleg!" << endl;
                a = 1;
            }
            else {
                cout << "Try again." << endl;
            }
        }
        else {
            cout << "Error: Incorrect surname." << endl;
            cout << "What is Oleg's surname?" << endl;
        }
    }

    return 0;
}