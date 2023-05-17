#include <iostream>
using namespace std;

class Shape {
protected:
    int width, height;

public:
    Shape(int w = 0, int h = 0) {
        width = w;
        height = h;
    }
    virtual int area() {
        cout << "Parent class area :" << endl;
        return 0;
    }
};

class Rectangle : public Shape {
public:
    Rectangle(int w = 0, int h = 0) : Shape(w, h) { }

    int area() {
        cout << "Rectangle class area :" << endl;
        return (width * height);
    }
};

class Triangle : public Shape {
public:
    Triangle(int w = 0, int h = 0) : Shape(w, h) { }

    int area() {
        cout << "Triangle class area :" << endl;
        return (width * height / 2);
    }
};

int main() {
    Shape* shape;
    Rectangle rec(10, 7);
    Triangle  tri(10, 5);

    shape = &rec;
    shape->area();

    shape = &tri;
    shape->area();

    return 0;
}