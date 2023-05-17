#include <iostream>
using namespace std;

void fillArr(int** pArr, int row, int colCount)
{
    if (pArr == nullptr)
    {
        cout << "Error!" << endl;
        return;
    }

    int value = 1;
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < colCount; j++)
        {
            pArr[i][j] = value;
            value++;
        }
    }
}

void printArr(int** pArr, int row, int colCount)
{
    if (pArr == nullptr)
    {
        cout << "Error!" << endl;
        return;
    }

    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < colCount; j++)
        {
            cout << pArr[i][j] << " ";
        }
        cout << endl;
    }
}

void addCol(int** pArr, int row, int colCount, int index)
{
    if (pArr == nullptr)
    {
        cout << "Error!" << endl;
        return;
    }

    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < colCount; j++)
        {
            if (j == index)
            {
                for (int k = colCount; k > index; k--)
                {
                    pArr[i][k] = pArr[i][k - 1];
                }
                pArr[i][j] = 0;
            }
        }
    }
}

void delCol(int** pArr, int row, int colCount, int index)
{
    if (pArr == nullptr)
    {
        cout << "Error!" << endl;
        return;
    }

    for (int i = 0; i < row; i++)
    {
        for (int j = index; j < colCount; j++)
        {
            pArr[i][j] = pArr[i][j + 1];
        }
    }
}

int main()
{
    int const row = 3;
    int const ColCount = 10;
    int colCount = 3;
    int userInd;
    int** simpArr = new int* [row];
    for (int i = 0; i < row; i++)
    {
        simpArr[i] = new int[ColCount];
    }
    fillArr(simpArr, row, colCount);
    cout << "Starting array: " << endl;
    printArr(simpArr, row, colCount);
    cout << "Enter a column number from 0 to " << colCount << " which column do you want to add? ";
    cin >> userInd;
    if (userInd >= 0 && userInd <= colCount)
    {
        colCount++;
        addCol(simpArr, row, colCount, userInd);
        printArr(simpArr, row, colCount);
    }
    else
    {
        cout << "Incorrect value" << endl;
    }
    cout << "Enter a column number from 0 to " << colCount - 1 << " which column do you want to delete? ";
    cin >> userInd;
    if (userInd >= 0 && userInd < colCount)
    {
        delCol(simpArr, row, colCount, userInd);
        colCount - 1;
        printArr(simpArr, row, colCount);
    }
    else
    {
        cout << "Incorrect value" << endl;
    }
}