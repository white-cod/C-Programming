#include <iostream>
#include <string>
#include <queue>
#include <stack>

using namespace std;

class CircularQueue {
private:
    int* arr;
    int front;
    int rear;
    int capacity;
    int count;

public:
    CircularQueue(int size = 5) {
        capacity = size;
        arr = new int[capacity];
        front = 0;
        rear = -1;
        count = 0;
    }

    ~CircularQueue() {
        delete[] arr;
    }

    void enqueue(int item) {
        if (isFull()) {
            cout << "[Circular Queue] Error: Queue is full!\n";
            return;
        }
        rear = (rear + 1) % capacity;
        arr[rear] = item;
        count++;
        cout << "[Circular Queue] Added: " << item << endl;
    }

    void dequeue() {
        if (isEmpty()) {
            cout << "[Circular Queue] Error: Queue is empty!\n";
            return;
        }
        cout << "[Circular Queue] Removed: " << arr[front] << endl;
        front = (front + 1) % capacity;
        count--;
    }

    void display() {
        if (isEmpty()) {
            cout << "[Circular Queue] Queue is empty.\n";
            return;
        }
        cout << "[Circular Queue] Current state: ";
        for (int i = 0; i < count; i++) {
            cout << arr[(front + i) % capacity] << " ";
        }
        cout << endl;
    }

    bool isEmpty() { return count == 0; }
    bool isFull() { return count == capacity; }
};

struct Node {
    int data;
    Node* next;
    Node(int val) : data(val), next(nullptr) {}
};

class LinkedQueue {
private:
    Node* front;
    Node* rear;

public:
    LinkedQueue() {
        front = nullptr;
        rear = nullptr;
    }

    ~LinkedQueue() {
        while (!isEmpty()) {
            dequeue();
        }
    }

    void enqueue(int item) {
        Node* newNode = new Node(item);
        if (rear == nullptr) {
            front = rear = newNode;
        }
        else {
            rear->next = newNode;
            rear = newNode;
        }
        cout << "[Linked Queue] Added: " << item << endl;
    }

    void dequeue() {
        if (isEmpty()) {
            cout << "[Linked Queue] Error: Queue is empty!\n";
            return;
        }
        Node* temp = front;
        cout << "[Linked Queue] Removed: " << front->data << endl;
        front = front->next;
        if (front == nullptr) {
            rear = nullptr;
        }
        delete temp;
    }

    void display() {
        if (isEmpty()) {
            cout << "[Linked Queue] Queue is empty.\n";
            return;
        }
        cout << "[Linked Queue] Current state: ";
        Node* temp = front;
        while (temp != nullptr) {
            cout << temp->data << " ";
            temp = temp->next;
        }
        cout << endl;
    }

    bool isEmpty() { return front == nullptr; }
};

void reverseStringSimulation(const string& input) {
    cout << "\n--- String Reversal ---" << endl;
    cout << "Input string: " << input << endl;

    stack<char> s;

    for (char c : input) {
        s.push(c);
    }

    cout << "Reversed string: ";
    while (!s.empty()) {
        cout << s.top();
        s.pop();
    }
    cout << endl;
}

struct Document {
    string name;
    int pages;
};

void printerSimulation() {
    cout << "\n--- Printer Queue Simulation ---" << endl;
    queue<Document> printerQueue;

    printerQueue.push({ "Lab4.pdf", 5 });
    printerQueue.push({ "Photo.png", 1 });
    printerQueue.push({ "Essay.docx", 12 });

    cout << "Documents in print queue: " << printerQueue.size() << endl;

    while (!printerQueue.empty()) {
        Document currentDoc = printerQueue.front();
        cout << "Printing document: '" << currentDoc.name
            << "' (Pages: " << currentDoc.pages << ")... Done" << endl;
        printerQueue.pop();

        cout << "Remaining files in queue: " << printerQueue.size() << endl;
    }
    cout << "All documents printed!" << endl;
}

int main() {
    cout << "=========================================" << endl;
    cout << "MAIN TASK" << endl;
    cout << "=================================\n" << endl;

    cout << "--- 1. Circular Queue (Array) ---" << endl;
    CircularQueue cq(3);
    cq.enqueue(10);
    cq.enqueue(20);
    cq.enqueue(30);
    cq.display();
    cq.enqueue(40);
    cq.dequeue();
    cq.enqueue(40);
    cq.display();

    cout << "\n--- 2. Queue (Linked List) ---" << endl;
    LinkedQueue lq;
    lq.enqueue(100);
    lq.enqueue(200);
    lq.enqueue(300);
    lq.display();
    lq.dequeue();
    lq.display();

    cout << "\n=========================================" << endl;
    cout << "EXTRA TASKS" << endl;
    cout << "==================================" << endl;

    reverseStringSimulation("DataStructures");
    printerSimulation();

    return 0;
}