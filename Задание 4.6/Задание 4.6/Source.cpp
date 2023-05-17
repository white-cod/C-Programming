#include <iostream>
using namespace std;
int main()
{
	setlocale(LC_ALL, "");
	int const n = 12;
	int profit[n];
	int start, end, minPrMonth, maxPrMonth;
	for (int i = 0; i < n; i++)
	{
		cout << "¬ведите вашу прибль за " << i + 1 << " мес€ц\n";
		cout << " ѕрибль:\n";
		cin >> profit[i];
	}
	cout << "¬ведите первый интересующий вас мес€ц "
		"ћес€ц:\n";
	cin >> start;
	cout << "¬ведите последний интересующий вас мес€ц "
		"ћес€ц:\n";
	cin >> end;
	minPrMonth = start - 1;
	maxPrMonth = start - 1;
	for (int i = start; i <= end - 1; i++)
	{
		if (profit[i] > profit[maxPrMonth])
		{
			maxPrMonth = i;
		}
		if (profit[i] < profit[minPrMonth])
		{
			minPrMonth = i;
		}
	}
	cout << "¬ы получили минимальную прибль в "
		<< minPrMonth + 1 << " мес€це.\n";
	cout << "¬ы получили максимальную прибль в "
		<< maxPrMonth + 1 << " мес€це.\n";
	return 0;
}