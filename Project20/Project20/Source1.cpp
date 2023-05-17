#include <iostream>
using namespace std;

void fillMassiv(int** pArray, int rowCount, int columnCount);
void printArray(int** pArray, int rowCount, int columnCount);
void addColumn(int** pArray, int rowCount, int columnCount, int index);
void deleteColumn(int** pArray, int rowCount, int columnCount, int index);

int main()
{
    setlocale(LC_ALL, "Rus");

    int const rowCount = 3;
    int const startColumnCount = 10;
    int columnCount = 3;
    int userIndex;
    int** simpleArray = new int* [rowCount];
    for (int i = 0; i < rowCount; i++)
    {
        simpleArray[i] = new int[startColumnCount];
    }
    fillMassiv(simpleArray, rowCount, columnCount);
    cout << "Стартовый массив: " << endl;
    printArray(simpleArray, rowCount, columnCount);
    //столбец можно добавить как в середину, так и в конец массива. поэтому 0...3
    cout << "Введите номер столбца от 0 до " << columnCount << " какой столбец вы хотите добавить? ";
    cin >> userIndex;
    if (userIndex >= 0 && userIndex <= columnCount)
    {
        columnCount++;
        addColumn(simpleArray, rowCount, columnCount, userIndex);
        printArray(simpleArray, rowCount, columnCount);
    }
    else
    {
        cout << "Не верное значение" << endl;
    }
    //удаление столбца
    cout << "Введите номер столбца от 0 до " << columnCount - 1 << " какой столбец вы ходите удалить? ";
    cin >> userIndex;
    if (userIndex >= 0 && userIndex < columnCount)
    {
        deleteColumn(simpleArray, rowCount, columnCount, userIndex);
        columnCount--;
        printArray(simpleArray, rowCount, columnCount);
    }
    else
    {
        cout << "Не верное значение" << endl;
    }
    //удаление массива
    for (int i = 0; i < rowCount; i++)
    {
        delete[] simpleArray[i];
    }
    delete[] simpleArray;
}
//инициализация массива
void fillMassiv(int** pArray, int rowCount, int columnCount)
{
    if (pArray == nullptr)
    {
        cout << "Ошибка!" << endl;
        return;
    }

    int value = 1;
    for (int i = 0; i < rowCount; i++)
    {
        for (int j = 0; j < columnCount; j++)
        {
            pArray[i][j] = value;
            value++;
        }
    }
}
//вывод массива на экран
void printArray(int** pArray, int rowCount, int columnCount)
{
    if (pArray == nullptr)
    {
        cout << "Ошибка!" << endl;
        return;
    }

    for (int i = 0; i < rowCount; i++)
    {
        for (int j = 0; j < columnCount; j++)
        {
            cout << pArray[i][j] << " ";
        }
        cout << endl;
    }
}
//добавление столбца
void addColumn(int** pArray, int rowCount, int columnCount, int index)
{
    if (pArray == nullptr)
    {
        cout << "Ошибка!" << endl;
        return;
    }

    for (int i = 0; i < rowCount; i++)
    {
        for (int j = 0; j < columnCount; j++)
        {
            //сдвигаем вправо значения
            if (j == index)
            {
                for (int k = columnCount; k > index; k--)
                {
                    pArray[i][k] = pArray[i][k - 1];
                }
                //заполняем вставленный столбец 0ми
                pArray[i][j] = 0;
            }
        }
    }
}
//удаление столбца
void deleteColumn(int** pArray, int rowCount, int columnCount, int index)
{
    if (pArray == nullptr)
    {
        cout << "Ошибка!" << endl;
        return;
    }

    for (int i = 0; i < rowCount; i++)
    {
        //j < columnCount, чтобы в крайний правый столбец записался мусор,
        //который до этого был справа, а не осталось правильное значение как до удаления.
        for (int j = index; j < columnCount; j++)
        {
            pArray[i][j] = pArray[i][j + 1];
        }
    }
}