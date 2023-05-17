#include <iostream>
#include <queue>
using namespace std;

void busStop(int firstTime, int lastTime, int arrivalOfTax, int& arrivalOfPassengers, bool isFinalStop,
	queue <char>& passengers, queue <int>& numberOfFreePlace, queue <int>& leaveStop, queue <int>& arrivalAtStop)
{
	int freePlace{};
	for (int i{ firstTime }; i < lastTime; i++)
	{
		if (i % arrivalOfPassengers == 0 && i != 0)
		{
			passengers.push('p');
			arrivalAtStop.push(i);
		}
		if (i % arrivalOfTax == 0 && i != 0)
		{
			if (isFinalStop == 1)
				freePlace = 20;
			else
				freePlace = rand() % 20;
			numberOfFreePlace.push(freePlace);
			while (freePlace != 0) {
				if (!passengers.empty())
				{
					passengers.pop();
					leaveStop.push(i);
				}
				freePlace--;
			}
		}
	}
}

int main()
{
	srand(time(0));
	setlocale(LC_ALL, "");
	int arrivalOfPassengers{}, arrivalOfTax{}, freePlace{}, N{};
	int arrayOfTime[3]{};
	bool isFinalStop{};
	queue <char> passengers;
	queue <int> arrivalAtStop;
	queue <int> leaveStop;
	queue <int> timeOfStay;
	queue <int> numberOfFreePlace;
	cout << "Is it the final stop? \n1 - Yes\n0 - No\n";
	cin >> isFinalStop;
	cout << "Specify the average time between appearances of passengers at the stop in the morning (6:00 - 9:00) (min): ";
	cin >> arrivalOfPassengers;
	cout << "Enter the average time between appearances of minibuses at a bus stop in the morning (6:00 - 9:00) (min): ";
	cin >> arrivalOfTax;
	busStop(0, 180, arrivalOfPassengers, arrivalOfTax, isFinalStop, passengers, arrivalAtStop, leaveStop, numberOfFreePlace);
	arrayOfTime[0] = arrivalOfPassengers;
	cout << "Enter the average time between arrivals of passengers at a stop during the day (9:00 - 16:00) (min): ";
	cin >> arrivalOfPassengers;
	cout << "Enter the average time between appearances of minibuses at a bus stop during the day (9:00 - 16:00) (min): ";
	cin >> arrivalOfTax;
	busStop(180, 600, arrivalOfPassengers, arrivalOfTax, isFinalStop, passengers, arrivalAtStop, leaveStop, numberOfFreePlace);
	arrayOfTime[1] = arrivalOfPassengers;
	cout << "Enter the average time between arrivals of passengers at a stop in the evening (16:00 - 23:00) (min): ";
	cin >> arrivalOfPassengers;
	cout << "Enter the average time between appearances of minibuses at the bus stop in the evening (16:00 - 23:00) (min): ";
	cin >> arrivalOfTax;
	busStop(600, 1021, arrivalOfPassengers, arrivalOfTax, isFinalStop, passengers, arrivalAtStop, leaveStop, numberOfFreePlace);
	arrayOfTime[2] = arrivalOfPassengers;
	arrivalOfPassengers = (arrayOfTime[0] + arrayOfTime[1] + arrayOfTime[2]) / 3;
	cout << "Calculate the time interval between the appearance of minibuses so that there are no more people at the bus stop:";
	while (N <= 0)
	{
		cin >> N;
	}
	int numberOfPassengers{}, sumOfTime{};
	while (!arrivalAtStop.empty() && !leaveStop.empty())
	{
		timeOfStay.push(leaveStop.front() - arrivalAtStop.front());
		arrivalAtStop.pop();
		leaveStop.pop();
	}
	while (!timeOfStay.empty())
	{
		sumOfTime += timeOfStay.front();
		timeOfStay.pop();
		numberOfPassengers++;
	}
	system("cls");
	cout << endl << "Average time spent by a person at a bus stop: " << sumOfTime / numberOfPassengers << " min." << endl;

	int sumfreePlace{};
	int numberOfBuses{};
	while (!numberOfFreePlace.empty())
	{
		sumfreePlace += numberOfFreePlace.front();
		numberOfFreePlace.pop();
		numberOfBuses++;
	}

	float passengerFlow = static_cast<float>(1) / arrivalOfPassengers;
	int intervalBetweenBuses = ((sumfreePlace / numberOfBuses) + N) / (passengerFlow * 2);
	cout << "A sufficient time interval between the arrivals of minibuses so that there are no more than " << N << " people at the same time: " << intervalBetweenBuses << " min." << endl;
}