#include <iostream>
#include <cstring>
#include <cmath>

using namespace std;

int main()
{
    // Declare variables
    double nums[2];
    char op;
    double result;

    // Get input from the user
    cout << "Enter the first number: ";
    cin >> nums[0];
    cout << "Enter the second number: ";
    cin >> nums[1];
    cout << "Enter the operator (+, -, *, /): ";
    cin >> op;

    // Perform the calculation
    if (op == '+') {
        result = nums[0] + nums[1];
    }
    else if (op == '-') {
        result = nums[0] - nums[1];
    }
    else if (op == '*') {
        result = nums[0] * nums[1];
    }
    else if (op == '/') {
        result = nums[0] / nums[1];
    }
    else {
        cout << "Invalid operator!" << endl;
        return 1;
    }

    // Print the result
    cout << "Result: " << result << endl;

    return 0;
}