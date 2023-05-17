#include <iostream>
#include <fstream>
#include <vector>
#include <string>

using namespace std;

class House
{
public:
    House(int number, int area, string type)
        : number(number), area(area), type(type) {}

    virtual void printDetails()
    {
        cout << "Number: " << number << endl;
        cout << "Area: " << area << " sq. ft." << endl;
        cout << "Type: " << type << endl;
    }

    virtual void read(ifstream& input)
    {
        input >> number >> area >> type;
    }

    virtual void write(ofstream& output)
    {
        output << number << " " << area << " " << type << endl;
    }

protected:
    int number;
    int area;
    string type;
};

class Shop : public House
{
public:
    Shop(int number, int area, string type, string name, int numEmployees)
        : House(number, area, type), name(name), numEmployees(numEmployees) {}

    void printDetails() override
    {
        House::printDetails();
        cout << "Name: " << name << endl;
        cout << "Number of employees: " << numEmployees << endl;
    }

    void read(ifstream& input) override
    {
        House::read(input);
        input >> name >> numEmployees;
    }

    void write(ofstream& output) override
    {
        House::write(output);
        output << name << " " << numEmployees << endl;
    }

private:
    string name;
    int numEmployees;
};

class Hospital : public House
{
public:
    Hospital(int number, int area, string type, string name, int numPatients)
        : House(number, area, type), name(name), numPatients(numPatients) {}

    void printDetails() override
    {
        House::printDetails();
        cout << "Name: " << name << endl;
        cout << "Number of patients: " << numPatients << endl;
    }

    void read(ifstream& input) override
    {
        House::read(input);
        input >> name >> numPatients;
    }

    void write(ofstream& output) override
    {
        House::write(output);
        output << name << " " << numPatients << endl;
    }

private:
    string name;
    int numPatients;
};

class School : public House
{
public:
    School(int number, int area, string type, string name, string level, int numStudents, int numTeachers)
        : House(number, area, type), name(name), level(level), numStudents(numStudents), numTeachers(numTeachers) {}

    void printDetails() override
    {
        House::printDetails();
        cout << "Name: " << name << endl;
        cout << "Level: " << level << endl;
        cout << "Number of students: " << numStudents << endl;
        cout << "Number of teachers: " << numTeachers << endl;
    }

    void read(ifstream& input) override
    {
        House::read(input);
        input >> name >> level >> numStudents >> numTeachers;
    }

    void write(ofstream& output) override
    {
        House::write(output);
        output << name << " " << level << " " << numStudents << " " << numTeachers << endl;
    }

private:
    string name;
    string level;
    int numStudents;
    int numTeachers;
};

class Street
{
public:
    void addHouse(House* house)
    {
        houses.push_back(house);
    }

    void printDetails()
    {
        for (House* house : houses)
        {
            house->printDetails();
            cout << "-----------------------------" << endl;
        }
    }

    void writeToFile(string filename)
    {
        ofstream output(filename);
        for (House* house : houses)
        {
            
            house->write(output);
        }
        output.close();
    }

    void readFromFile(string filename)
    {
        ifstream input(filename);
        string type;
        while (input >> type)
        {
            if (type == "House")
            {
                int number, area;
                input >> number >> area;
                House* house = new House(number, area, type);
                addHouse(house);
            }
            else if (type == "Shop")
            {
                int number, area, numEmployees;
                string name;
                input >> number >> area >> name >> numEmployees;
                House* house = new Shop(number, area, type, name, numEmployees);
                addHouse(house);
            }
            else if (type == "Hospital")
            {
                int number, area, numPatients;
                string name;
                input >> number >> area >> name >> numPatients;
                House* house = new Hospital(number, area, type, name, numPatients);
                addHouse(house);
            }
            else if (type == "School")
            {
                int number, area, numStudents, numTeachers;
                string name, level;
                input >> number >> area >> name >> level >> numStudents >> numTeachers;
                House* house = new School(number, area, type, name, level, numStudents, numTeachers);
                addHouse(house);
            }
        }
        input.close();
    }
private:
    vector<House*> houses;
};

int main()
{
    Street street;

    int houseNumber, houseArea;
    string houseType = "House";
    cout << "Enter the number and area of the house: ";
    cin >> houseNumber >> houseArea;
    House* house1 = new House(houseNumber, houseArea, houseType);
    street.addHouse(house1);

    int shopNumber, shopArea, numEmployees;
    string shopType = "Shop", shopName;
    cout << "Enter the number and area of the shop: ";
    cin >> shopNumber >> shopArea;
    cout << "Enter the name and number of employees of the shop: ";
    cin >> shopName >> numEmployees;
    Shop* shop1 = new Shop(shopNumber, shopArea, shopType, shopName, numEmployees);
    street.addHouse(shop1);

    int hospitalNumber, hospitalArea, numPatients;
    string hospitalType = "Hospital", hospitalName;
    cout << "Enter the number and area of the hospital: ";
    cin >> hospitalNumber >> hospitalArea;
    cout << "Enter the name and number of patients of the hospital: ";
    cin >> hospitalName >> numPatients;
    Hospital* hospital1 = new Hospital(hospitalNumber, hospitalArea, hospitalType, hospitalName, numPatients);
    street.addHouse(hospital1);

    int schoolNumber, schoolArea, numStudents, numTeachers;
    string schoolType = "School", schoolName, schoolLevel;
    cout << "Enter the number and area of the school: ";
    cin >> schoolNumber >> schoolArea;
    cout << "Enter the name, level, number of students, and number of teachers of the school: ";
    cin >> schoolName >> schoolLevel >> numStudents >> numTeachers;
    School* school1 = new School(schoolNumber, schoolArea, schoolType, schoolName, schoolLevel, numStudents, numTeachers);
    street.addHouse(school1);

    street.printDetails();

    return 0;
}