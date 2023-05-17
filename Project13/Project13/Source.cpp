#include <iostream>
using namespace std;

void merge_sort(int* a, size_t size_a, int* b, size_t size_b, int* result)
{
    while (size_a != 0 && size_b != 0)
    {
        if (*a > *b)
        {
            *result++ = *b++;
            --size_b;
        }
        else if (*a < *b)
        {
            *result++ = *a++;
            --size_a;
        }
        else
        {
            *result++ = *a++;
            *result++ = *b++;
            --size_a;
            --size_b;
        }
    }

    while (size_a--)
        *result++ = *a++;

    while (size_b--)
        *result++ = *b++;
}

#define SIZE1 3
#define SIZE2 4

int main()
{
    int a[SIZE1] = { 1, 3, 5 };
    cout << "1 array {1, 3, 5}\n";
    int b[SIZE2] = { 2, 4, 6, 7 };
    cout << "2 array {2, 4, 6, 7}\n";
    int result[SIZE1 + SIZE2];
    int i;
    merge_sort(a, SIZE1, b, SIZE2, result);
    for (i = 0; i < SIZE1 + SIZE2; i++)
        printf("%d ", result[i]);
    return 0;
}