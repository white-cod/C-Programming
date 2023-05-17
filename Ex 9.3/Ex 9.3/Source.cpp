#include <iostream>
#include <fstream>
#include <string>

using namespace std;

int main()
{
    ifstream inFile("original.txt");

    if (!inFile.is_open())
    {
        cout << "Error opening file" << endl;
        return 1;
    }

    ofstream outFile("statistics.txt");

    int num_chars = 0, num_lines = 0, num_vowels = 0, num_consonants = 0, num_digits = 0;

    string line;
    while (getline(inFile, line))
    {
        ++num_lines;

        for (char c : line)
        {
            ++num_chars;
            if (isdigit(c))
            {
                ++num_digits;
            }
            else if (isalpha(c))
            {
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' || c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U')
                {
                    ++num_vowels;
                }
                else
                {
                    ++num_consonants;
                }
            }
        }
    }

    outFile << "Number of characters: " << num_chars << endl;
    outFile << "Number of lines: " << num_lines << endl;
    outFile << "Number of vowels: " << num_vowels << endl;
    outFile << "Number of consonants: " << num_consonants << endl;
    outFile << "Number of digits: " << num_digits << endl;

    inFile.close();
    outFile.close();

    return 0;
}