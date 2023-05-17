#pragma once
#include <iostream>
using namespace std;

template <typename T>
class Array
{
	T* Data;
	int Counter;
	int Size;
	int Grow;

public:
	Array();
	~Array();
	int getSize();
	void setSize(unsigned int size, int grow = 1);
	int getUpperBound();
	bool isEmpty();
	void freeExtra();
	void removeAll();
	T getAt(int index);
	void setAt(int index, T data);
	T& operator[](int index);
	void add(T data);
	void appEnd(Array& obj);
	Array<T>& operator= (const Array& obj);
	T** getData();
	void insertAt(int position, T data);
	void removeAt(int position);
	void show();
};

template <typename T>
Array<T>::Array()
{
	Counter = 0;
	Size = 0;
	Grow = 1;
	Data = nullptr;
}

template <typename T>
Array<T>::~Array()
{
	if (Data) free(Data);
	Data = nullptr;
}

template <typename T>
int Array<T>::getSize()
{
	return Size;
}

template <typename T>
void Array<T>::setSize(unsigned int size, int grow)
{
	Grow = grow = 1;

	if (size == Size)
	{
		return;
	}

	Size = size;

	if (Size > 0)
	{
		if (Size % Grow != 0)
		{
			Data = (T*)realloc(Data, sizeof(T) * (Size + (grow - Size % grow)));
		}
		else if (Size % Grow == 0)
		{
			Data = (T*)realloc(Data, sizeof(T) * Size);
		}
	}

	if (Counter > Size)
	{
		Counter = Size;
	}
}

template <typename T>
int Array<T>::getUpperBound()
{
	return Counter - 1;
}

template <typename T>
bool Array<T>::isEmpty()
{
	if (Counter == 0) return true;
	else return false;
}

template <typename T>
void Array<T>::freeExtra()
{
	if (Size % Grow != 0)
	{
		Data = (T*)realloc(Data, sizeof(T) * (Counter + (Grow - Counter % Grow)));;
		Size = Counter + (Grow - Counter % Grow);
	}
	else if (Size % Grow == 0)
	{
		Data = (T*)realloc(Data, sizeof(T) * Counter);
		Size = Counter;
	}
}

template <typename T>
void Array<T>::removeAll()
{
	free(Data);
	Data = nullptr;
	Counter = 0;
	Size = 0;
}

template <typename T>
T Array<T>::getAt(int index)
{
	if (index >= 0 && index < Counter) return Data[index];
}

template <typename T>
void Array<T>::setAt(int index, T data)
{
	if (index >= 0 && index < Size)
	{
		Data[index] = data;
		Counter = index + 1;
	}
}

template <typename T>
T& Array<T>::operator[](int index)
{
	if (index >= 0 && index < Counter) return Data[index];
}

template <typename T>
void Array<T>::add(T data)
{
	if (Counter < Size)
	{
		Data[Counter++] = data;
	}
	else if (Counter >= Size)
	{
		setSize(Size + 1);
		Data[Size - 1] = data;
		Counter++;
	}
}

template <typename T>
void Array<T>::appEnd(Array& obj) {
	int maxCounter = this->getUpperBound() > obj.getUpperBound() ? this->getUpperBound() + 1 : obj.getUpperBound() + 1;
	int minCounter = this->getUpperBound() < obj.getUpperBound() ? this->getUpperBound() + 1 : obj.getUpperBound() + 1;
	this->setSize(maxCounter, Grow);

	for (int i = 0; i < minCounter; i++)
	{
		Data[i] = Data[i] + obj[i];
	}
}

template <typename T>
Array<T>& Array<T>::operator= (const Array& obj)
{
	if (this == &obj) return *this;

	Grow = obj.Grow;
	Counter = obj.Counter;
	Size = obj.Size;

	Data = (T*)realloc(Data, sizeof(T) * (Size + (Grow - Size % Grow)));

	for (int i = 0; i < Counter; i++)
	{
		Data[i] = obj.Data[i];
	}

	return *this;
}

template <typename T>
T** Array<T>::getData()
{
	return &Data;
}

template <typename T>
void Array<T>::insertAt(int position, T data)
{
	if (position < 0 || position >= Counter)
	{
		return;
	}

	if (Counter >= Size)
	{
		setSize(Size + 1);
	}

	for (int i = Counter; i >= position; i--)
	{
		Data[i] = Data[i - 1];
	}

	Data[position] = data;
	Counter++;
}

template <typename T>
void Array<T>::removeAt(int position)
{
	if (position < 0 || position >= Counter)
	{
		return;
	}

	for (int i = position; i < Counter; i++)
	{
		Data[i] = Data[i + 1];
	}

	Counter--;
}

template <typename T>
void Array<T>::show()
{
	for (int i = 0; i < Counter; i++)
	{
		cout << Data[i] << " ";
	}

	cout << endl << endl;
}