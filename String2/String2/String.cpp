#include "String.h"

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    string userstring;
    cout << "Введите свою строку\n";
    cin >> userstring;
    cout << "Строка была занесена в класс String\n";
    String data(userstring);
    int size = data.returnSize();
    int choice;
    
    cout << "1 - найти и вывести элемент по индексу \n";
    cout << "2 - найти элемент и вывести его индекс в строке \n";
    cin >> choice;
    system("cls");
    switch (choice)
    {
    case 1:system("cls");
    {
        cout << "Введите индекс: \n";
        int index;
        cin >> index;
        if (index > size || index < 1)
        {
            cout << "Неправильно введён индекс.\n";
        }
        else
        {
            cout << "Элементом по индексу " << index << " является: " << data[index] << ".\n";
        }
        break;
    }
    case 2:system("cls");
    {
        cout << "Введите элемент для поиска: ";
        char element;
        cin >> element;
        int elementIndex = data(element);
        if (elementIndex != -1)
            cout << "Индекс элемента \"" << element << "\": " << elementIndex << ".\n";
        else
            cout << "Элемент не найден.\n";
        break;
    }
    default:
    {
        cout << "Такой команды нет.\n";
    }
    }
}