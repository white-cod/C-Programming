#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
using namespace std;

class Car
{
    string name;
    size_t year;
    double engine;
    double price;

public:
    Car(const string& name, const size_t year, const double engine, const double price)
        : name(name), year(year), engine(engine), price(price)
    { }

    void setName(const string& name)
    {
        this->name = name;
    }
    void setYear(size_t year)
    {
        this->year = year;
    }
    void setEngine(double engine)
    {
        this->engine = engine;
    }
    void setPrice(double price)
    {
        this->price = price;
    }

    const string& getName() const
    {
        return name;
    }

    const size_t& getYear() const
    {
        return year;
    }

    const double& getEngine() const
    {
        return engine;
    }

    const double& getPrice() const
    {
        return price;
    }


    friend class dataBase;

    struct compareByName
    {
        bool operator()(const Car& a, const Car& b) const
        {
            return a.name < b.name;
        }
    };

    struct compareByYear
    {
        bool operator()(const Car& a, const Car& b) const
        {
            return a.year < b.year;
        }
    };

};

class dataBase
{
    vector<Car>item;

public:

    void addCar(const Car& car)
    {
        item.push_back(car);
    }

    void deleteCar(int number)
    {
        item.erase(item.begin() + number - 1);
    }

    void showItem()
    {
        int number = 1;
        for (auto i = item.begin(); i != item.end(); ++i)
        {
            cout << number++ << " " << i->name << " " << i->year << " "
                << i->engine << " " << i->price << endl;

        }
    }

    void sortByName()
    {
        cout << " сортировка по названию: " << endl;

        Car::compareByName name;
        sort(item.begin(), item.end(), name);
        showItem();

        cout << endl;

    }

    void sortByYear()
    {
        cout << " сортировка по годам: " << endl;

        Car::compareByYear year;
        sort(item.begin(), item.end(), year);
        showItem();

        cout << endl;
    }
    void searchByName(const string& search)
    {
        for (auto i = item.begin(); i != item.end(); ++i)
        {
            if (i->name == search)
            {
                cout << " " << i->name << " " << i->year << " "
                    << i->engine << " " << i->price << endl;
            }

        }
    }

    void searchByYear(size_t y)
    {
        for (auto i = item.begin(); i != item.end(); ++i)
        {
            if (i->year == y)
            {
                cout << " " << i->name << " " << i->year << " "
                    << i->engine << " " << i->price << endl;
            }

        }
    }
};

int main()
{
    setlocale(LC_ALL, "");
    Car car_1("Toyota Camry", 2015, 2.5, 25000);
    Car car_2("Honda Accord", 2018, 2.0, 28000);
    Car car_3("Nissan Altima", 2020, 2.5, 30000);
    Car car_4("Mazda CX-5", 2019, 2.5, 35000);
    Car car_5("Ford Mustang", 2010, 4.0, 15000);

    dataBase db;
    db.addCar(car_1);
    db.addCar(car_2);
    db.addCar(car_3);
    db.addCar(car_4);
    db.addCar(car_5);

    while (true) {
        cout << "Выберите опцию:\n";
        cout << "1. Показать все автомобили\n";
        cout << "2. Добавить автомобиль\n";
        cout << "3. Удалить автомобиль\n";
        cout << "4. Поиск по названию\n";
        cout << "5. Поиск по году\n";
        cout << "6. Сортировать по имени\n";
        cout << "7. Сортировать по годам\n";
        cout << "8. Выйти\n";

        int choice;
        cin >> choice;

        if (choice == 1) {
            db.showItem();
        }
        else if (choice == 2) {
            string name;
            size_t year;
            double engine;
            double price;

            cout << "Введите название: ";
            cin >> name;
            cout << "Введите год: ";
            cin >> year;
            cout << "Введите объем двигателя: ";
            cin >> engine;
            cout << "Введите цену: ";
            cin >> price;

            Car newCar(name, year, engine, price);
            db.addCar(newCar);
        }
        else if (choice == 3) {
            int number;
            cout << "Введите номер автомобиля для удаления: ";
            cin >> number;

            db.deleteCar(number);
        }
        else if (choice == 4) {
            string name;
            cout << "Введите название для поиска: ";
            cin >> name;

            db.searchByName(name);
        }
        else if (choice == 5) {
            size_t year;
            cout << "Введите год для поиска: ";
            cin >> year;

            db.searchByYear(year);
        }
        else if (choice == 6) {
            db.sortByName();
        }
        else if (choice == 7) {
            db.sortByYear();
        }
        else if (choice == 8) {
            break;
        }
        else {
            cout << "Неверный выбор\n";
        }
    }

    return 0;
}