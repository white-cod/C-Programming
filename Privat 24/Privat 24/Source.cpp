#include <iostream>

using namespace std;

int login() {
    int userID = 555689;
    int pin = 0000;
    int insID;
    int insPin;
    int a = 0;
    while (a == 0) {
        cout << "Please, enter your user ID: ";
        cin >> insID;
        if (insID == userID) {
            a = 1;
            while (a == 1) {
                cout << "Please, enter the pin-code: ";
                cin >> insPin;
                if (insPin == pin) {
                    return pin;
                    break;
                }
                else {
                    cout << "The pin-code is incorrect. Please, try again\n";
                }
            }
        }
        else {
            cout << "You have inserted the incorrect ID. Please, try again\n";
        }
    }

}

int amountOfMOney() {
    int bankID = 000111222333;
    float amMon = 100000.00;
    cout << "Your account state:\nAccount number:  " << bankID << "\nAmount of money: " << amMon << " $";
    return amMon;
}


int main() {
    cout << "Welcome to Privet24\n";
    login();
    int ans;
    cout << "Welcome Person#0001.\nWhich action with your bank account would you like to perform?\n";
    cout << "1. To see the amount of money on your account\n";
    cout << "2. To withdraw your money\n";
    cout << "3. To transfer your money to another account\n";
    cout << "4. To see the history of transactions\n";
    cin >> ans;
    switch (ans) {
    case 1: amountOfMOney();
    }

}