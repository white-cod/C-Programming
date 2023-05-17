#include <iostream>
#include <string>
#include <vector>
#include <random>
using namespace std;

vector<string> responses =
{
  "Что?",
  "Сам подумай",
  "А я откуда знаю",
  "Хз",
  "Сделай сам"
  "Я не знаю"
  "У Кирилла спроси"
};

random_device rd;
mt19937 rng(rd());
uniform_int_distribution<int> uni(0, responses.size() - 1);

int main()
{
    setlocale(LC_ALL, "rus");
    while (true)
    {
        cout << "Я новая нейросеть которая ответит на любой ваш вопрос: ";
    string message;
    while (getline(cin, message))
    {
        cout << responses[uni(rng)] << endl;
    }
    return 0;
    }
}