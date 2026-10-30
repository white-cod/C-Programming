#include <iostream>
#include <chrono>
#include <locale>

using namespace std;

bool isValidChar(char c) {
    return (c >= 'a' && c <= 'z') || c == ' ' || c == '.';
}

bool isVowel(char c) {
    return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' || c == 'y';
}

struct Node {
    char data;
    Node* prev;
    Node* next;
};

void appendNode(Node*& head, Node*& tail, char val) {
    Node* newNode = new Node{ val, nullptr, nullptr };
    if (!head) {
        head = tail = newNode;
    }
    else {
        tail->next = newNode;
        newNode->prev = tail;
        tail = newNode;
    }
}

void deleteNode(Node*& head, Node*& tail, Node* delNode) {
    if (!head || !delNode) return;
    if (head == delNode) head = delNode->next;
    if (tail == delNode) tail = delNode->prev;
    if (delNode->next) delNode->next->prev = delNode->prev;
    if (delNode->prev) delNode->prev->next = delNode->next;
    delete delNode;
}

void clearList(Node*& head, Node*& tail) {
    Node* current = head;
    while (current) {
        Node* next = current->next;
        delete current;
        current = next;
    }
    head = tail = nullptr;
}

int getFirstWordLength(const char* arr, int size) {
    int len = 0;
    for (int i = 0; i < size; i++) {
        if (arr[i] >= 'a' && arr[i] <= 'z') {
            len++;
        }
        else if (len > 0) {
            break;
        }
    }
    return len;
}

int getFirstWordLengthList(Node* head) {
    int len = 0;
    Node* current = head;
    while (current) {
        if (current->data >= 'a' && current->data <= 'z') {
            len++;
        }
        else if (len > 0) {
            break;
        }
        current = current->next;
    }
    return len;
}

void processArray(char* arr, int& size) {
    int firstLen = getFirstWordLength(arr, size);
    int currentWordLen = 0;
    int wordStart = -1;
    int i = 0;

    while (i < size) {
        if (arr[i] >= 'a' && arr[i] <= 'z') {
            if (currentWordLen == 0) wordStart = i;
            currentWordLen++;
            i++;
        }
        else {
            if (currentWordLen > firstLen) {
                int k = wordStart;
                int charsRemoved = 0;
                for (int j = 0; j < currentWordLen; j++) {
                    if (isVowel(arr[k])) {
                        for (int m = k; m < size - 1; m++) {
                            arr[m] = arr[m + 1];
                        }
                        size--;
                        charsRemoved++;
                    }
                    else {
                        k++;
                    }
                }
                for (int j = wordStart; j < wordStart + currentWordLen - charsRemoved; j++) {
                    cout << arr[j];
                }
                cout << " ";
                i = wordStart + currentWordLen - charsRemoved + 1;
            }
            else {
                i++;
            }
            currentWordLen = 0;
        }
    }
    cout << endl;
}

void processList(Node*& head, Node*& tail) {
    int firstLen = getFirstWordLengthList(head);
    int currentWordLen = 0;
    Node* wordStartNode = nullptr;
    Node* current = head;

    while (current) {
        if (current->data >= 'a' && current->data <= 'z') {
            if (currentWordLen == 0) wordStartNode = current;
            currentWordLen++;
            current = current->next;
        }
        else {
            if (currentWordLen > firstLen) {
                Node* temp = wordStartNode;
                for (int i = 0; i < currentWordLen; i++) {
                    Node* nextNode = temp->next;
                    if (isVowel(temp->data)) {
                        deleteNode(head, tail, temp);
                    }
                    else {
                        cout << temp->data;
                    }
                    temp = nextNode;
                }
                cout << " ";
            }
            currentWordLen = 0;
            current = current->next;
        }
    }
    cout << endl;
}

int main() {
    cout << "Enter the text (lowercase Latin letters and spaces, with a period at the end):" << endl;

    int capacity = 10;
    int size = 0;
    char* arr = new char[capacity];

    Node* head = nullptr;
    Node* tail = nullptr;

    char c;
    while (cin.get(c)) {
        if (c == '\n') continue;

        if (!isValidChar(c)) {
            cout << "\nError: Invalid character '" << c << "'." << endl;
            delete[] arr;
            clearList(head, tail);
            return 1;
        }

        if (size == capacity) {
            capacity *= 2;
            char* newArr = new char[capacity];
            for (int i = 0; i < size; i++) {
                newArr[i] = arr[i];
            }
            delete[] arr;
            arr = newArr;
        }

        arr[size++] = c;
        appendNode(head, tail, c);

        if (c == '.') {
            break;
        }
    }

    if (size == 0 || (size == 1 && arr[0] == '.')) {
        cout << "Error: Empty input" << endl;
        delete[] arr;
        clearList(head, tail);
        return 1;
    }

    cout << "\nResult (Dynamic Array)" << endl;
    auto startArr = chrono::high_resolution_clock::now();
    processArray(arr, size);
    auto endArr = chrono::high_resolution_clock::now();

    long long durationArr = chrono::duration_cast<chrono::microseconds>(endArr - startArr).count();
    cout << "Execution time : " << durationArr << " microseconds" << endl;
    cout << "Memory used: " << capacity * sizeof(char) << " byte" << endl;

    cout << "\nResult (Address list)" << endl;
    auto startList = chrono::high_resolution_clock::now();
    processList(head, tail);
    auto endList = chrono::high_resolution_clock::now();

    long long durationList = chrono::duration_cast<chrono::microseconds>(endList - startList).count();
    cout << "Execution time: " << durationList << " microseconds" << endl;
    cout << "Memory used: " << size * sizeof(Node) + 2 * sizeof(Node*) << " byte" << endl;

    delete[] arr;
    clearList(head, tail);

    return 0;
}