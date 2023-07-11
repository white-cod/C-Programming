#include <iostream>
#include <string>

using namespace std;

class Pet
{
public:
    Pet(string name) : name_(name) {}
    virtual ~Pet() {}

    virtual void speak() = 0;

    string getName() const { return name_; }

private:
    string name_;
};

class Dog : public Pet
{
public:
    Dog(string name) : Pet(name) {}
    virtual ~Dog() {}

    void speak()
    {
        cout << getName() << " barks." << endl;
    }
};

class Cat : public Pet
{
public:
    Cat(string name) : Pet(name) {}
    virtual ~Cat() {}

    void speak()
    {
        cout << getName() << " meows." << endl;
    }
};

class Parrot : public Pet
{
public:
    Parrot(string name) : Pet(name) {}
    virtual ~Parrot() {}

    void speak()
    {
        cout << getName() << " says hello." << endl;
    }
};

int main()
{
	Dog dog("Rufus");
	dog.speak();

	Cat cat("Felix");
	cat.speak();

	Parrot parrot("Polly");
	parrot.speak();

	return 0;
}