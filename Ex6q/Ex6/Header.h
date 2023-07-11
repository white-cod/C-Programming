#pragma once
#include <iostream>

template <typename T>
class Matrix
{
private:
    int rows, cols;
    T** data;

public:
    Matrix(int rows, int cols) : rows(rows), cols(cols)
    {
        data = new T * [rows];
        for (int i = 0; i < rows; i++)
        {
            data[i] = new T[cols];
        }
    }

    ~Matrix()
    {
        for (int i = 0; i < rows; i++)
        {
            delete[] data[i];
        }
        delete[] data;
    }

    void fillFromKeyboard()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                cin >> data[i][j];
            }
        }
    }

    void fillWithRandom()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                data[i][j] = rand();
            }
        }
    }

    void display()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                cout << data[i][j] << " ";
            }
            cout << endl;
        }
    }

    Matrix operator+(const Matrix& other)
    {
        if (rows != other.rows || cols != other.cols)
        {
            cout << "Cannot add matrices of different dimensions." << endl;
            exit(1);
        }
        Matrix result(rows, cols);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result.data[i][j] = data[i][j] + other.data[i][j];
            }
        }
        return result;
    }

    Matrix operator-(const Matrix& other)
    {
        if (rows != other.rows || cols != other.cols)
        {
            cout << "Cannot subtract matrices of different dimensions." << endl;
            exit(1);
        }
        Matrix result(rows, cols);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result.data[i][j] = data[i][j] - other.data[i][j];
            }
        }
        return result;
    }

    Matrix operator*(const Matrix& other)
    {
        if (cols != other.rows)
        {
            cout << "Invalid dimensions for matrix multiplication." << endl;
            exit(1);
        }
        Matrix result(rows, other.cols);
        for (int i = 0; i < cols; j++)
        {
            for (int k = 0; k < cols; k++)
            {
                result.data[i][k] += data[i][k] * other.data[k][i];
            }
        }
        return result;
    }
    Matrix operator/(const Matrix& other)
    {
        if (cols != other.rows)
        {
            cout << "Invalid dimensions for matrix division." << endl;
            exit(1);
        }
        Matrix result(rows, other.cols);
        return result;
    }

    T findMax()
    {
        T max = data[0][0];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (data[i][j] > max)
                {
                    max = data[i][j];
                }
            }
        }
        return max;
    }

    T findMin()
    {
        T min = data[0][0];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (data[i][j] < min)
                {
                    min = data[i][j];
                }
            }
        }
        return min;
    }
};