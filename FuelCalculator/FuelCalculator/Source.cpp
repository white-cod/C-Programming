#include <iostream>
using namespace std;
int main()
{
    setlocale(LC_ALL, "");
    
    float fuel, count, res;
    cout << "¬вед≥ть к≥льк≥сть палива";
    cin >> count;
    cout << "¬каж≥ть витрату на 100 км";
    cin >> fuel;
    
    res = (count / fuel) * 100;
    cout << res;




}