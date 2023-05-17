#include <iostream>
#define _USE_MATH_DEFINES
#include <cmath>
const double M_PI = std::atan(1.0) * 4;

using namespace std;

int main()
{
    setlocale(LC_ALL, "");
    const double g = 9.81;

    double distance;
    double elevation;
    double muzzle_velocity;
    double time_of_flight;
    double impact_velocity;
    double impact_angle;

    cout << "Введите расстояние до цели (м): ";
    cin >> distance;
    cout << "Введите угол орудия (градусы): ";
    cin >> elevation;
    cout << "Введите начальную скорость снаряда (м/с): ";
    cin >> muzzle_velocity;

    double elevation_rad = elevation * M_PI / 180.0;
    double range = distance * cos(elevation_rad);
    time_of_flight = range / muzzle_velocity;
    double max_height = (pow(range, 2.0) * sin(elevation_rad) * cos(elevation_rad)) / (2 * g);
    impact_velocity = muzzle_velocity * cos(elevation_rad);
    impact_angle = atan((pow(impact_velocity, 2.0) + sqrt(pow(impact_velocity, 4.0) - g * (g * pow(range, 2.0) + 2 * max_height * pow(impact_velocity, 2.0)))) / (g * range));

    cout << "Время полета снаряда равно " << time_of_flight << " с." << endl;
    cout << "Максимальная высота корпуса составляет " << max_height << " м." << endl;
    cout << "Скорость снаряда " << impact_velocity << " м/с." << endl;
    cout << "Угол падения снаряда " << impact_angle * 180.0 / M_PI << " градусов." << endl;

    return 0;
}
