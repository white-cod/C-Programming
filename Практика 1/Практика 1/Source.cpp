#include <iostream>
using namespace std;

double run(double distance, int days)
{
    for (int d = days; d > 1; --d)
    {
        distance += distance * 0.1;
    }
    return distance;

}
double sumRun(double distance, int days)
{
    double sumDays = distance;
    for (int d = days; d > 1; --d)
    {
        distance += distance * 0.1;
        sumDays += distance;
    }
    return sumDays;
}

int main()
{
    setlocale(LC_ALL, "");

    int days = 0;
    cout << "Введите количество день тренировок ";
    cin >> days;
    double dayDistance = 10;

    //а) пробег лыжника за второй, третий, ..., десятый день тренировок
    cout << "а. Пробег лыжника за " << days << " день составляет " << run(dayDistance, days) << " км." << endl;
        

    //б) какой суммарный путь он пробежал за первые 7 дней тренировок.
    cout << "б. Пробег лыжника за 7 дней равен " << sumRun(dayDistance, 7) << " км. " << endl << endl;
    
    //в) суммарный путь за n дней тренировок
    cout << "Введите кол-во дней для суммарного пробега ";
    cin >> days;
    cout << "в. Суммарный пробег за " << days << " дней равен " << sumRun(dayDistance, days) << " км. " << endl << endl;
       
        
    return 0;
}
