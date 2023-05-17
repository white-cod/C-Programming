#include <iostream>
using namespace std;

void swap(int* a, int* b)
{
    int tmp = *a;
    *a = *b;
    *b = tmp;


    const int N = 5;
    const int M = 5;
    int mas_a[N];
    int mas_b[M];

    for (int i = 0; i < N; i++)
    {
        mas_a[i] = rand() % 20;
        cout << mas_a[i] << ' ';
    }
    cout << endl;
    for (int i = 0; i < M; i++)
    {
        mas_b[i] = rand() % 20;
        cout << mas_b[i] << ' ';
    }
    cout << endl;
    for (int j = 0; j < N; j++)
        for (int i = 0; i < N; i++)
            if (mas_a[i] < mas_a[i - 1])  swap(&mas_a[i], &mas_a[i - 1]);
    for (int i = 0; i < N; i++)
        cout << mas_a[i] << ' ';
    cout << endl;
    for (int j = 0; j < M; j++)
        for (int i = 0; i < M; i++)
            if (mas_b[i] < mas_b[i - 1])  swap(&mas_b[i], &mas_b[i - 1]);
    for (int i = 0; i < M; i++)
        cout << mas_b[i] << ' ';
    cout << endl;
}