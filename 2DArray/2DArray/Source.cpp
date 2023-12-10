#include <iostream>

using namespace std;

int main() {
    const int rows = 2;
    const int cols = 5;

    locale::global(locale(""));

    int StudentskyyArray[rows][cols] = {
        {101, 102, 103, 104, 105},
        {1, 2, 3, 4, 5}
    };

    cout << "Двовимiрний масив:\n";
    for (int i = 0; i < rows; ++i) {
        for (int j = 0; j < cols; ++j) {
            cout << StudentskyyArray[i][j] << " ";
        }
        cout << "\n";
    }

    const int oneDSize = rows * cols;
    int StudentskyyArray2[oneDSize];

    int index = 0;
    for (int i = 0; i < rows; ++i) {
        for (int j = 0; j < cols; ++j) {
            StudentskyyArray2[index] = StudentskyyArray[i][j];
            ++index;
        }
    }

    cout << "\nОдновимiрний масив:\n";
    for (int i = 0; i < oneDSize; ++i) {
       cout << StudentskyyArray2[i] << " ";
    }

    return 0;
}