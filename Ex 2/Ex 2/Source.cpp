#include <iostream>
using namespace std;

template <typename T>
struct Element
{
    T data;
    Element<T>* Next;
};

template <class T>
class List
{
    Element<T>* start;
    Element<T>* end;
    int FillList;
public:
    List();
    ~List();
    void Add(T data);
    void Del();
    void DelAll();
    void Print();
    int GetCount();

    Element<T> CopyList(const List& obj)
    {
        if (!obj.start)
        {
            FillList = 0;
            start = end = NULL;
        }
        start = new Element<T>(*obj.start);
        Element<T>* temp = start;
        FillList = 1;
        for (Element<T>* i = obj.start->Next; i != nullptr; i = i->Next)
        {
            temp->Next = new Element<T>(*i);
            temp = temp->Next;
            ++FillList;
        }
        temp->Next = nullptr;
        return *start;
    }
};

int main()
{
    List <char> lst;
    char s[]{ "Hello world!\n" };
    cout << s << "\n";
    int len = strlen(s);
    for (int i{}; i < len; i++)
    {
        lst.Add(s[i]);
    }
    lst.Print();
    lst.Del();
    lst.Del();
    lst.Print();

    List <int> lst2;
    int arr[6]{ 1,2,3,4,5,6 };
    for (int i{}; i < 6; i++)
    {
        lst2.Add(arr[i]);
    }
    lst2.Print();
    List <int> lst3;
    cout << "lst3\n";
    lst3.CopyList(lst2);
    lst3.Print();
}

template <class T>
List<T>::List()
{
    start = end = NULL;
    FillList = 0;
}
template <class T>
List<T>::~List()
{
    DelAll();
}
template <class T>
void List<T>::Add(T data)
{
    Element<T>* temp = new Element<T>;
    temp->data = data;
    temp->Next = NULL;
    if (start != NULL)
    {
        end->Next = temp;
        end = temp;
    }
    else {
        start = end = temp;
    }
    FillList++;
}
template <class T>
void List<T>::Del()
{
    Element<T>* temp = start;
    start = start->Next;
    delete temp;
}
template <class T>
void List<T>::DelAll()
{
    while (start != NULL)
    {
        Del();
    }
}
template <class T>
void List<T>::Print()
{
    Element<T>* temp = start;
    while (temp != NULL)
{
        cout << temp->data << " ";
        temp = temp->Next;
    }
    cout << endl;
}
template <class T>
int List<T>::GetCount()
{
    return FillList;
}