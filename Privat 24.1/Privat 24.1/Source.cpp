#include<iostream>
#include<cstring>
using namespace std;

struct account
{
    int account_number;
    float balance;
};


void print_confirmation()
{
    cout << "You sent ZSU 500 UAH" << endl;
}

int main()
{

    int recipient_account_number;
    float amount;

    cout << "Enter recipient account number: ";
    cin >> recipient_account_number;
    cout << "Enter amount to transfer: ";
    cin >> amount;

    print_confirmation();

    return 0;
}