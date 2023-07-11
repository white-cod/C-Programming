#include <iostream>
#include <cstdlib>
#include "Header.h"

using namespace std;

int main()
{
    srand(time(NULL));

    int rows, cols;
    cout << "Enter the number of rows: ";
    cin >> rows;
    cout << "Enter the number of columns: ";
    cin >> cols;

    Matrix<int> m1(rows, cols);
    cout << "Enter the elements of matrix m1:" << endl;
    m1.fillFromKeyboard();

    Matrix<int> m2(rows, cols);
    cout << "Enter the elements of matrix m2:" << endl;
    m2.fillFromKeyboard();

    cout << "Matrix m1:" << endl;
    m1.display();
    cout << "Matrix m2:" << endl;
    m2.display();

    Matrix<int> m3 = m1 + m2;
    cout << "Matrix m1 + m2:" << endl;
    m3.display();

    Matrix<int> m4 = m1 - m2;
    cout << "Matrix m1 - m2:" << endl;
    m4.display();

    Matrix<int> m5 = m1 * m2;
    cout << "Matrix m1 * m2:" << endl;
    m5.display();

    Matrix<int> m6 = m1 / m2;
    cout << "Matrix m1 / m2:" << endl;
    m6.display();

    cout << "Max value in m1: " << m1.findMax() << endl;
    cout << "Min value in m1: " << m1.findMin() << endl;

    return 0;
}