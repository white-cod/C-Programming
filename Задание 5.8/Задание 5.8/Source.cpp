#include <iostream>
#include <windows.h>
#include <ctime>
using namespace std;
int RandInt(int min, int max)
{
    if (max < min)
        swap(max, min);
    return min + rand() % (max - min + 1);
}
void SetRndArray(int arr[], int n, int min, int max)
{
    for (size_t i = 0; i < n; i++)
        arr[i] = RandInt(min, max);
}
void ShowArray(int arr[], int n)
{
    for (size_t i = 0; i < n; i++)
        cout << arr[i] << '\t';
    cout << '\n';
}
int Positive(int arr[], int n)
{
    int PosEl = 0;
    for (size_t i = 0; i < n; i++)
    {
        if (arr[i] > 0)
            PosEl++;
    }
    return PosEl;
}
int Negative(int arr[], int n)
{
    int NegEl = 0;
    for (size_t i = 0; i < n; i++)
    {
        if (arr[i] < 0)
            NegEl++;
    }
    return NegEl;
}
int Zero(int arr[], int n)
{
    int Zer = 0;
    for (size_t i = 0; i < n; i++)
    {
        if (arr[i] == 0)
            Zer++;
    }
    return Zer;
}
int main()
{
    SetConsoleOutputCP(1251);
    int const size = 100;
    srand(time(0));
    int arr[size]{ 0 };
    int min = -10, max = 10;
    cout << "Введите размер массива: ";
    int n;
    cin >> n;
    if (n <= 0)
    {
        cout << "Введите положительное значение массива!\n";
            return 0;
    }
    if (n > 100)
    {
        cout << "Выберите меньший размер массива!\n";
        return 0;
    }
    SetRndArray(arr, n, min, max);
    RandInt(min, max);
    cout << "Массив: " << endl;
    ShowArray(arr, n);
    cout << "В передаваемом функции массиве элементов:\n\n- положительных: " << Positive(arr, n) << endl;
    cout << "- отрицательых: " << Negative(arr, n) << endl;
    cout << "- нулевых: " << Zero(arr, n) << endl;
}