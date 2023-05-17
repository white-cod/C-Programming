#include <iostream>
#include <stack>
using namespace std;

void checkBrackets(string str)
{
    stack<char> correct;
    for (int i = 0; i < str.length(); i++)
    {
        char charStr = str[i];
        if (charStr == '(' || charStr == '[' || charStr == '{')
            correct.push(charStr);
        else if (charStr == ')' || charStr == ']' || charStr == '}')
        {
            if (correct.empty() ||
                (charStr == ')' && correct.top() != '(') ||
                (charStr == ']' && correct.top() != '[') ||
                (charStr == '}' && correct.top() != '{'))
            {
                cout << str.substr(0, i) << endl;
                return;
            }
            correct.pop();
        }
    }
    if (correct.empty())
        cout << str << " - correct" << endl;
    else
        cout << str << " - incorrect" << endl;
}

int main()
{
    cout << "Test:\n\n";
    checkBrackets("({x-y-z}*[x+2y]-(z+4x))");
    checkBrackets("({x-y-z}*[x+2y]-(z+4x)");
    cout << "\nWrong:\n\n";
    checkBrackets("([x-y-z}*[x+2y)-{z+4x)]");
    return 0;
}