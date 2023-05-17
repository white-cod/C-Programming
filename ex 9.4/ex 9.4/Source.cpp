#include <iostream>
#include <string>

using namespace std;

char shift(char c, int k)
{
    if (!isalpha(c))
    {
        return c;
    }
    char base = islower(c) ? 'a' : 'A';
    return (c - base + k) % 26 + base;
}

string caesar_encrypt(string s, int k)
{
    string result = "";
    for (char c : s)
    {
        result += shift(c, k);
    }
    return result;
}

int main()
{
    string s;
    int k;
    cout << "Enter a message to encrypt: ";
    getline(cin, s);
    cout << "Enter a key (1-25): ";
    cin >> k;
    cout << "Encrypted message: " << caesar_encrypt(s, k) << endl;
    return 0;
}