#include <iostream>
using namespace std;

int main()
{
	setlocale(LC_ALL, "");
	float weight, ras, s1, s2, smax = 0;
	float const maxcapacity = 300;
	cout << "Введите вес перевозимого груза (в кг)\n";
	cin >> weight;
	if (weight > 2000)
	{
		cout << "Самолет не взлетит!\n";
	}
	if (weight >= 1501 && weight <= 2000)
	{
	   ras = 9; smax = maxcapacity / ras;
	}
	if (weight >= 1001 && weight <= 1500)
	{
	   ras = 7; smax = maxcapacity / ras;
	}
	if (weight >= 501 && weight <= 1000)
	{
	   ras = 4; smax = maxcapacity / ras;
	}
	if (weight >= 0 && weight <= 500)
	{
		ras = 1; smax = maxcapacity / ras;
	}
	cout << "Введите расстояние между аэропортами A и B (в км)\n";
	cin >> s1;
	if (smax <= s1)
	{
		cout << "Топлева до аэропорта В не хватит!\n";
	}
	else
	{
		s1 = smax - s1;
	}
	cout << "Введите расстояние между аэропортами В и С (в км)\n";
	cin >> s2;
	if (smax <= s2) { cout << "Полёт невозможен! Топлива не хватит до точки C!\n";  }        
	if (smax > s2) {                                                                                               
		s2 = (s2 - s1) * ras; {                                                                                  
			if (s2 < 0) { cout << "Нет необходимости доливать топливо, в баке достаточно топлива.\n";  }}
		cout << "В точке B необходимо долить " << s2 << " литров топлива для полёта до точки C.\n";
	}
	return 0;

}