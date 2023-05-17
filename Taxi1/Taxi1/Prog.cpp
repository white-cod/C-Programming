#include <iostream>
#include <queue>
using namespace std;

class Minibus {
public:
    Minibus(int arrivalTime, int freePlaces) : arrivalTime(arrivalTime), freePlaces(freePlaces) {}
    int arrivalTime;
    int freePlaces;
};

class Passenger {
public:
    Passenger(int arrivalTime) : arrivalTime(arrivalTime) {}
    int arrivalTime;
};

void busStop(int firstTime, int lastTime, int arrivalOfPassengers, int arrivalOfTax, bool isFinalStop, queue<Passenger>& passengers, queue<Minibus>& minibuses) {
    for (int i = firstTime; i < lastTime; i++) {
        if (i % arrivalOfPassengers == 0 && i != 0) {
            passengers.push(Passenger(i));
        }
        if (i % arrivalOfTax == 0 && i != 0) {
            int freePlace = isFinalStop ? 20 : rand() % 20;
            minibuses.push(Minibus(i, freePlace));
        }
    }
}

int main() {
    srand(time(0));
    setlocale(LC_ALL, "");
    int arrivalOfPassengers, arrivalOfTax, N;
    bool isFinalStop;
    queue<Passenger> passengers;
    queue<Minibus> minibuses;

    cout << "Is it the final stop? \n1 - Yes\n0 - No\n";
    cin >> isFinalStop;
    cout << "Specify the average time between appearances of passengers at the stop in the morning (6:00 - 9:00) (min): ";
    cin >> arrivalOfPassengers;
    cout << "Enter the average time between appearances of minibuses at a bus stop in the morning (6:00 - 9:00) (min): ";
    cin >> arrivalOfTax;
    busStop(0, 180, arrivalOfPassengers, arrivalOfTax, isFinalStop, passengers, minibuses);

    cout << "Enter the average time between arrivals of passengers at a stop during the day (9:00 - 16:00) (min): ";
    cin >> arrivalOfPassengers;
    cout << "Enter the average time between appearances of minibuses at a bus stop during the day (9:00 - 16:00) (min): ";
    cin >> arrivalOfTax;
    busStop(180, 600, arrivalOfPassengers, arrivalOfTax, isFinalStop, passengers, minibuses);

    cout << "Enter the average time between arrivals of passengers at a stop in the evening (16:00 - 23:00) (min): ";
    cin >> arrivalOfPassengers;
    cout << "Enter the average time between appearances of minibuses at the bus stop in the evening (16:00 - 23:00) (min): ";
    cin >> arrivalOfTax;
    busStop(600, 1021, arrivalOfPassengers, arrivalOfTax, isFinalStop, passengers, minibuses);

    cout << "Calculate the time interval between the appearance of minibuses so that there are no more peopleat the bus stop:" << endl;

    int numberOfPassengers = 0, sumOfTime = 0;
    while (!passengers.empty() && !minibuses.empty()) {
        if (minibuses.front().freePlaces > 0) {
            int currentPassengerArrival = passengers.front().arrivalTime;
            int currentMinibusArrival = minibuses.front().arrivalTime;
            sumOfTime += currentMinibusArrival - currentPassengerArrival;
            numberOfPassengers++;
            minibuses.front().freePlaces--;
            passengers.pop();
            if (minibuses.front().freePlaces == 0) {
                minibuses.pop();
            }
        }
        else {
            minibuses.pop();
        }
    }
    cout << "Interval between minibuses: " << sumOfTime / numberOfPassengers << endl;
    return 0;
}