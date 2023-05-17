#include<iostream>
using namespace std;

void Mult(double, double);
void Mult(int a, int b) {
	cout << a * b;
}

int main() {
	Mult(3.2, 6.1);
	return 0;
}