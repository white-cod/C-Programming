#include <iostream>
#include <queue>
using namespace std;

class Event {
public:
    int arrivalTime;
    int type;

    Event(int arrivalTime, int type) : arrivalTime(arrivalTime), type(type) {}

    bool operator<(const Event& other) const {
        return arrivalTime > other.arrivalTime;
    }
};

void busStop(int firstTime, int lastTime, int arrivalOfPassengers, int arrivalOfTax, bool isFinalStop, priority_queue<Event>& events) {
    for (int i = firstTime; i < lastTime; i++) {
        if (i % arrivalOfPassengers == 0 && i != 0) {
            events.push(Event(i, 0));
        }
        if (i % arrivalOfTax == 0 && i != 0) {
            int freePlace = isFinalStop ? 20 : rand() % 20;
            events.push(Event(i, 1));
        }
    }
}

int main() {
    srand(time(0));
    setlocale(LC_ALL, "");
    int arrivalOfPassengers, arrivalOfTax, N{};
    bool isFinalStop;
    priority_queue<Event> events;
    cout << "Is it the final stop? \n1 - Yes\n0 - No\n";
    cin >> isFinalStop;
    cout << "Specify the average time between appearances of passengers at the stop in the morning (6:00 - 9:00) (min): ";
    cin >> arrivalOfPassengers;
    cout << "Enter the average time between appearances of minibuses at a bus stop in the morning (6:00 - 9:00) (min): ";
    cin >> arrivalOfTax;
    busStop(0, 180, arrivalOfPassengers, arrivalOfTax, isFinalStop, events);

    cout << "Enter the average time between arrivals of passengers at a stop during the day (9:00 - 16:00) (min): ";
    cin >> arrivalOfPassengers;
    cout << "Enter the average time between appearances of minibuses at a bus stop during the day (9:00 - 16:00) (min): ";
    cin >> arrivalOfTax;
    busStop(180, 600, arrivalOfPassengers, arrivalOfTax, isFinalStop, events);

    cout << "Enter the average time between arrivals of passengers at a stop in the evening (16:00 - 23:00) (min): ";
    cin >> arrivalOfPassengers;
    cout << "Enter the average time between appearances of minibuses at the bus stop in the evening (16:00 - 23:00) (min): ";
    cin >> arrivalOfTax;
    busStop(600, 1021, arrivalOfPassengers, arrivalOfTax, isFinalStop, events);

    cout << "Calculate the time interval between the appearance of minibuses so that there are no more people at the bus stop:" << endl;
    while (N <= 0) {
        cin >> N;
    }
    int numberOfPassengers = 0, sumOfTime = 0, freePlaces = 20;
    while (!events.empty() && numberOfPassengers < N) {
        Event currentEvent = events.top();
        events.pop();
        if (currentEvent.type == 0) { // passenger
            if (freePlaces > 0) {
                int currentPassengerArrival = currentEvent.arrivalTime;
                int currentMinibusArrival = events.top().arrivalTime;
                sumOfTime += currentMinibusArrival - currentPassengerArrival;
                numberOfPassengers++;
                freePlaces--;
            }
        }
        else { // minibus
            freePlaces = isFinalStop ? 20 : rand() % 20;
        }
    }
    if (numberOfPassengers == N)
        cout << "Interval between minibuses: " << sumOfTime / numberOfPassengers << endl;
    else
        cout << "Not enough minibuses to transport all the passengers" << endl;
    return 0;
}