#include <iostream>
using namespace std;

void show_array(int arr2[], const size_t& arr2_size)
{
    int* arr2_end = arr2 + arr2_size;
    cout << "{ ";
    while (arr2 != arr2_end)
        cout << *arr2++ << " ";
    cout << "}\n\n";
}

void main()
{
    const int size = 5;
    int arr[size] = { 5, 7, -8, 3, 9 }, temp;
    int arr2[size];
    int* ptr_arr1 = arr;
    int* ptr_arr2 = arr2;
    
    cout << "{ ";
    for (int i = 0; i < size; i++)
    {
        ptr_arr2 = ptr_arr1;
        cout << *ptr_arr2 << " ";
        ptr_arr1++;
        ptr_arr2++;
    }
    cout << "}\n\n";
    
    
    
    int* start = arr2, * end = &arr2[size - 1];

    while (start != end)
    {
        temp = *start;
        *start = *end;
        *end = temp;

        start++;
        end--;

    }
    show_array(arr2, size);
}


