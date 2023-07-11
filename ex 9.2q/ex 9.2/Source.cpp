#include <iostream>
#include <fstream>
#include <string>

using namespace std;

int main()
{
    ifstream file1("file1.txt");
    ifstream file2("file2.txt");

    if (!file1.is_open() || !file2.is_open())
    {
        cout << "Error opening file(s)!" << endl;
        return 1;
    }

    string line1, line2;
    int line_number = 1;
    while (getline(file1, line1) && getline(file2, line2))
    {
        if (line1 != line2)
        {
            cout << "Mismatch at line " << line_number << ": " << line1 << " vs " << line2 << endl;
            return 1;
        }
        line_number++;
    }

    if (getline(file1, line1))
    {
        cout << "File 1 is longer than file 2, last line: " << line1 << endl;
        return 1;
    }
    else if (getline(file2, line2))
    {
        cout << "File 2 is longer than file 1, last line: " << line2 << endl;
        return 1;
    }

    cout << "Files match!" << endl;
    return 0;
}