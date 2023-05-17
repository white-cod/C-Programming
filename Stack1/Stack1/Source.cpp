#include <iostream>
using namespace std;

class Node
{
public:
    int data;
    Node* next;
    Node(int data)
    {
        this->data = data;
        next = nullptr;
    }
};

class Stack
{
private:
    Node* top;
    int size;
    int maxSize;

public:
    Stack(int maxSize)
    {
        top = nullptr;
        size = 0;
        this->maxSize = maxSize;
    }

    void push(int data)
    {
        if (size == maxSize)
        {
            cout << "Stack overflow. Increasing stack size." << endl;
            increaseSize();
        }
        Node* newNode = new Node(data);
        newNode->next = top;
        top = newNode;
        size++;
    }

    int pop()
    {
        if (top == nullptr)
        {
            cout << "Stack underflow." << endl;
            return -1;
        }
        int data = top->data;
        Node* temp = top;
        top = top->next;
        delete temp;
        size--;
        return data;
    }

    int peek()
    {
        if (top == nullptr)
        {
            cout << "Stack is empty." << endl;
            return -1;
        }
        return top->data;
    }

    bool isEmpty() { return top == nullptr; }

    int getSize() { return size; }

    void increaseSize()
    {
        maxSize *= 2;
    }
};

int main()
{
    Stack s(5);
    s.push(1);
    s.push(2);
    s.push(3);
    cout << "Top element is: " << s.peek() << endl;
    cout << "Popped element is: " << s.pop() << endl;
    cout << "Stack size is: " << s.getSize() << endl;
    return 0;
}