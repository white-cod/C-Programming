#include <iostream>
#include <string>
using namespace std;

int GetCharQty(string& str, char ch)
{
    int qt = 0;
    for (int i = 0; i < str.length(); i++)
        if (str[i] == ch) qt++;
    return qt;
}

int main()
{
    string str = "";
    char ch = ' ';
    int qty = 0;
    cout << str << "\nString: ";
    getline(cin, str);
    cout << '\n' << "Character to find:"; cin >> ch;
    qty = GetCharQty(str, ch);

    cout << '\n' << qty;
    return 0;
}