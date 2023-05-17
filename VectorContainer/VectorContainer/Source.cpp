#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

struct MinFunctor
{
    int operator()(const vector<int>& vec) const
    {
        return *min_element(vec.begin(), vec.end());
    }
};

struct MaxFunctor
{
    int operator()(const vector<int>& vec) const
    {
        return *max_element(vec.begin(), vec.end());
    }
};

struct DescendingSortFunctor
{
    void operator()(vector<int>& vec) const
    {
        sort(vec.rbegin(), vec.rend());
    }
};

struct AscendingSortFunctor {
    void operator()(vector<int>& vec) const
    {
        sort(vec.begin(), vec.end());
    }
};

struct IncreaseFunctor
{
    int val;
    IncreaseFunctor(int v) : val(v) {}
    void operator()(int& x) const
    {
        x += val;
    }
};


struct ReduceFunctor
{
    int val;
    ReduceFunctor(int v) : val(v) {}
    void operator()(int& x) const
    {
        x -= val;
    }
};

struct RemoveElementFunctor
{
    int val;
    RemoveElementFunctor(int v) : val(v)
    {}
    void operator()(vector<int>& vec) const
    {
        vec.erase(remove(vec.begin(), vec.end(), val), vec.end());
    }
};

int main()
{
    setlocale(LC_ALL, "");
    vector<int> vec{ 5, 3, 1, 4, 2 };

    MinFunctor minFunctor;
    int minVal = minFunctor(vec);
    cout << "Минимальное значение: " << minVal << endl;

    MaxFunctor maxFunctor;
    int maxVal = maxFunctor(vec);
    cout << "Максимальное значение: " << maxVal << endl;

    DescendingSortFunctor descendingSortFunctor;
    descendingSortFunctor(vec);
    cout << "В порядке убывания: ";
    for (int x : vec) {
        cout << x << " ";
    }
    cout << endl;

    AscendingSortFunctor ascendingSortFunctor;
    ascendingSortFunctor(vec);
    cout << "В порядке возростания: ";
    for (int x : vec) {
        cout << x << " ";
    }
    cout << endl;

    int increaseBy = 10;
    IncreaseFunctor increaseFunctor(increaseBy);
    for_each(vec.begin(), vec.end(), increaseFunctor);
    cout << "После увеличения на " << increaseBy << ": ";
    for (int x : vec) {
        cout << x << " ";
    }
    cout << endl;

    int reduceBy = 5;
    ReduceFunctor reduceFunctor(reduceBy);
    for_each(vec.begin(), vec.end(), reduceFunctor);
    cout << "После уменьшения на " << reduceBy << ": ";
    for (int x : vec) {
        cout << x << " ";
    }
    cout << endl;

    int removeVal = 4;
    RemoveElementFunctor removeElementFunctor(removeVal);
    removeElementFunctor(vec);
    cout << "После удаления " << removeVal << ": ";
    for (int x : vec) {
        cout << x << " ";
    }
    cout << endl;

    return 0;
}