#include <iostream>
using namespace std;

int main()
{
	setlocale(LC_ALL, "");
	double speed, S, t;
	int min, sec;
	cout << "Введите дистанцию забега\n";
	cin >> S;
	cout << "Введите время забега\n";
	cin >> t;
	min = t;
	sec = (t - min) * 100;
	t = (min * 60) + sec;
	speed = S / t * 3.6; 
	cout << "Расстояние: " << S << "m\n";
	cout << "Время: " << min << " Минут " << sec << " секунд. " << "В секундах - " << t << endl;
	cout << "Скорость: " << speed << "км/ч";
		
	return 0; 
}

