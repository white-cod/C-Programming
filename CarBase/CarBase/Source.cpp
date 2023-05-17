#include <iostream>
#include <vector>
#include <cstdlib>
#include <ctime>

using namespace std;

class Car;
class Driver;
class Flight;
class Dispatcher;

enum class FlightStatus {
    PENDING,
    ASSIGNED,
    COMPLETED
};

class Car {
public:
    Car(string make, string model) : make(make), model(model) {}

    string getMake() const {
        return make;
    }

    string getModel() const {
        return model;
    }

private:
    string make;
    string model;
};

class Driver {
public:
    Driver(string name) : name(name) {}

    string getName() const {
        return name;
    }

private:
    string name;
};

class Flight {
public:
    Flight(string origin, string destination) : origin(origin), destination(destination), status(FlightStatus::PENDING) {}

    string getOrigin() const {
        return origin;
    }

    string getDestination() const {
        return destination;
    }

    FlightStatus getStatus() const {
        return status;
    }

    void assignCar(Car* car) {
        this->car = car;
        status = FlightStatus::ASSIGNED;
    }

    void complete() {
        status = FlightStatus::COMPLETED;
    }

    Car* getAssignedCar() const {
        return car;
    }

private:
    string origin;
    string destination;
    FlightStatus status;
    Car* car = nullptr;
};

class Dispatcher {
public:
    Dispatcher() {}

    void addDriver(Driver* driver) {
        drivers.push_back(driver);
    }

    void addCar(Car* car) {
        cars.push_back(car);
    }

    void addFlight(Flight* flight) {
        flights.push_back(flight);
    }

    void dispatch() {
        for (Flight* flight : flights) {
            if (flight->getStatus() == FlightStatus::PENDING) {
                Driver* driver = getRandomDriver();
                Car* car = getRandomCar();
                if (driver != nullptr && car != nullptr) {
                    flight->assignCar(car);
                    cout << "Flight from " << flight->getOrigin() << " to " << flight->getDestination()
                        << " assigned to driver " << driver->getName() << " with car " << car->getMake() << " " << car->getModel() << endl;
                }
            }
            else if (flight->getStatus() == FlightStatus::ASSIGNED) {
                Car* car = flight->getAssignedCar();
                if (car != nullptr) {
                    flight->complete();
                    cout << "Flight from " << flight->getOrigin() << " to " << flight->getDestination()
                        << " completed by car " << car->getMake() << " " << car->getModel() << endl;
                }
            }
        }
    }

private:
    vector<Driver*> drivers;
    vector<Car*> cars;
    vector<Flight*> flights;

    Driver* getRandomDriver() const {
        if (drivers.empty()) {
            return nullptr;
        }
        int index = rand() % drivers.size();
        return drivers[index];
    }

    Car* getRandomCar() const {
        if (cars.empty()) {
            return nullptr;
        }
        int index = rand() % cars.size();
        return cars[index];
    }
};

int main() {
    srand(time(nullptr));
    setlocale(LC_ALL, "");
    Driver driver1("John");
    Driver driver2("Alice");
    Driver driver3("Bob");
    Car car1("Toyota", "Corolla");
    Car car2("Honda", "Civic");
    Car car3("Ford", "Focus");
    Flight flight1("New York", "Los Angeles");
    Flight flight2("Chicago", "Houston");
    Flight flight3("Miami", "Seattle");

    Dispatcher dispatcher;
    dispatcher.addDriver(&driver1);
    dispatcher.addDriver(&driver2);
    dispatcher.addDriver(&driver3);
    dispatcher.addCar(&car1);
    dispatcher.addCar(&car2);
    dispatcher.addCar(&car3);
    dispatcher.addFlight(&flight1);
    dispatcher.addFlight(&flight2);
    dispatcher.addFlight(&flight3);

    for (int i = 0; i < 5; i++) {
        cout << "Dispatching flights..." << endl;
        dispatcher.dispatch();
        cout << endl;
    }

    return 0;
}