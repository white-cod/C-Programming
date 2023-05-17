#include <iostream>
#include <time.h>
using namespace std;

void fillarr(int** arr, int M, int N) 
{
    for (int i = 0; i < M; i++) 
    {
        for (int j = 0; j < N; j++) 
        {
            arr[i][j] = rand() % 100;
        }
    }
}

void printarr(int** arr, int M, int N) 
{
    for (int i = 0; i < M; i++) 
    {
        for (int j = 0; j < N; j++) 
        {
            cout << arr[i][j] << " ";
        }
        cout << endl;
    }
}

int main()
{
    srand(time(NULL));

    int M, N;
    cout << "string - ";
    cin >> M;
    cout << "column - ";
    cin >> N;

    int** temp = new int* [M];
    for (int i = 0; i < M; i++)
    {
        temp[i] = new int[N];
    }

    int* buf = nullptr;

    int step, n = 1, num, bufer;

    fillarr(temp, M, N);
    printarr(temp, M, N);

    cout << endl;
    cout << "step - ";
    cin >> step;
    cout << endl;
    cout << "1 - up" << endl;
    cout << "2 - down" << endl;
    cout << "3 - right" << endl;
    cout << "4 - left" << endl;
    cout << "Your choice: ";
    cin >> num;
    cout << endl;

    {
        switch (num)
        {
        case 1:
            for (int i = 0; i < step; i++)
            {

                buf = new int[N];

                for (int j = 0; j < N; j++)
                {
                    buf[j] = temp[0][j];
                }

                for (int j = 0; j < M - 1; j++)
                {
                    for (int t = 0; t < N; t++)
                    {
                        temp[j][t] = temp[j + 1][t];
                    }
                }

                for (int j = 0; j < N; j++)
                {
                    temp[M - 1][j] = buf[j];
                }

                delete[]buf;

            }
            printarr(temp, M, N);
            break;

        case 2:
            for (int i = 0; i < step; i++)
            {

                buf = new int[N];

                for (int j = 0; j < N; j++)
                {
                    buf[j] = temp[M - 1][j];
                }

                for (int j = M - 1; j > 0; j--)
                {
                    for (int t = 0; t < N; t++)
                    {
                        temp[j][t] = temp[j - 1][t];
                    }
                }

                for (int j = 0; j < N; j++)
                {
                    temp[0][j] = buf[j];
                }

                delete[]buf;

            }
            printarr(temp, M, N);
            break;

        case 3:
            for (int i = 0; i < step; i++)
            {

                for (int j = 0; j < M; j++)
                {
                    bufer = temp[j][N - 1];
                    for (int t = N - 1; t > 0; t--)
                    {
                        temp[j][t] = temp[j][t - 1];
                    }
                    temp[j][0] = bufer;
                }

            }
            printarr(temp, M, N);
            break;

        case 4:
            for (int i = 0; i < step; i++)
            {

                for (int j = 0; j < M; j++)
                {
                    bufer = temp[j][0];
                    for (int t = 0; t < N - 1; t++)
                    {
                        temp[j][t] = temp[j][t + 1];
                    }
                    temp[j][N - 1] = bufer;
                }


            }
            printarr(temp, M, N);
            break;

        }
    }
}