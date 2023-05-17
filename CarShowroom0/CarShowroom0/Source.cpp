#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

template<typename T>
class compareByName
{
public:
    bool operator()(const T& a, const T& b) const
    {
        return a.getName() < b.getName();
    }
};

template<typename T>
class compareByYear
{
public:
    bool operator()(const T& a, const T& b) const
    {
        return a.getYear() < b.getYear();
    }
};

template<typename T>
class dataBase
{
    vector<T> item;

public:

    void addItem(const T& item)
    {
        this->item.push_back(item);
    }

    void removeItem(int number)
    {
        this->item.erase(this->item.begin() + number - 1);
    }

    void showItems() const
    {
        int number = 1;
        for (auto i = item.begin(); i != item.end(); ++i)
        {
            cout << number++ << " " << i->getName() << " " << i->getYear() << " "
                << i->getEngine() << " " << i->getPrice() << endl;

        }
    }

    void sortBy(compareByName<T> nameComparator)
    {
        cout << "Поиск по названию " << endl;

        sort(item.begin(), item.end(), nameComparator);
        showItems();

        cout << endl;

    }

    void sortBy(compareByYear<T> yearComparator)
    {
        cout << "Поиск по году: " << endl;

        sort(item.begin(), item.end(), yearComparator);
        showItems();

        cout << endl;
    }

    void searchByName(const string& search) const
    {
        for (auto i = item.begin(); i != item.end(); ++i)
        {
            if (i->getName() == search)
            {
                cout << " " << i->getName() << " " << i->getYear() << " "
                    << i->getEngine() << " " << i->getPrice() << endl;
            }

        }
    }

    void searchByYear(size_t year) const
    {
        for (auto i = item.begin(); i != item.end(); ++i)
        {
            if (i->getYear() == year)
            {
                cout << " " << i->getName() << " " << i->getYear() << " "
                    << i->getEngine() << " " << i->getPrice() << endl;
            }

        }
    }
};

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
};

/*
int main()
{
    setlocale(LC_ALL, "");
    dataBase db;

    Car car_1("Toyota Camry", 2015, 2.5, 25000);
    Car car_2("Honda Accord", 2018, 2.0, 28000);
    Car car_3("Nissan Altima", 2020, 2.5, 30000);
    Car car_4("Mazda CX-5", 2019, 2.5, 35000);
    Car car_5("Ford Mustang", 2010, 4.0, 15000);
    db.addCar(car_1);
    db.addCar(car_2);
    db.addCar(car_3);
    db.addCar(car_4);
    db.addCar(car_5);

    std::cout << "Все автомобили:" << std::endl;
    db.showItem();

    db.sortByName();

    std::cout << "Поиск автомобиля с названием 'Toyota Camry':" << std::endl;
    db.searchByName("Toyota Camry");

    std::cout << "Поиск автомобилей 2020 года выпуска:" << std::endl;
    db.searchByYear(2020);

    db.deleteCar(2);

    std::cout << "Все автомобили в базе после удаления:" << std::endl;
    db.showItem();

    return 0;
}
*/