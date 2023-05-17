#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
#include <fstream>
#include <sstream>

class Reference {
public:
    Reference() {}
    Reference(const std::string& company_name,
        const std::string& owner,
        const std::string& phone,
        const std::string& address,
        const std::string& activity_type)
        : company_name_(company_name),
        owner_(owner),
        phone_(phone),
        address_(address),
        activity_type_(activity_type) {}

    Reference(const std::string& str) {
        std::stringstream ss(str);
        std::getline(ss, company_name_, ',');
        std::getline(ss, owner_, ',');
        std::getline(ss, phone_, ',');
        std::getline(ss, address_, ',');
        std::getline(ss, activity_type_, ',');
    }

    std::string toString() const {
        std::stringstream ss;
        ss << company_name_ << "," << owner_ << "," << phone_ << "," << address_ << "," << activity_type_ << "\n";
        return ss.str();
    }

    friend std::ostream& operator<<(std::ostream& os, const Reference& ref) {
        os << "Company name: " << ref.company_name_ << "\n";
        os << "Owner: " << ref.owner_ << "\n";
        os << "Phone: " << ref.phone_ << "\n";
        os << "Address: " << ref.address_ << "\n";
        os << "Type of activity: " << ref.activity_type_ << "\n";
        return os;
    }

    void writeToFile(std::ofstream& file) const {
        file << toString();
    }


    bool searchByName(const std::string& name) const {
        return company_name_ == name;
    }

    bool searchByOwner(const std::string& owner) const {
        return owner_ == owner;
    }

    bool searchByPhone(const std::string& phone) const {
        return phone_ == phone;
    }

    bool searchByActivity(const std::string& activity_type) const {
        return activity_type_ == activity_type;
    }

    static void addEntry(std::vector<Reference>& entries, std::ofstream& file) {
        std::string name, owner, phone, address, activity_type;
        std::cout << "Enter company name: ";
        std::getline(std::cin, name);
        std::cout << "Enter owner name: ";
        std::getline(std::cin, owner);
        std::cout << "Enter phone number: ";
        std::getline(std::cin, phone);
        std::cout << "Enter address: ";
        std::getline(std::cin, address);
        std::cout << "Enter type of activity: ";
        std::getline(std::cin, activity_type);
        Reference new_entry(name, owner, phone, address, activity_type);
        entries.push_back(new_entry);
        std::cout << "New entry added successfully!\n";
        new_entry.writeToFile(file);
    }


    static void showAllEntries(const std::vector<Reference>& entries) {
        if (entries.empty()) {
            std::cout << "No entries found.\n";
            return;
        }
        std::cout << "List of all entries:\n";
        for (const auto& entry : entries) {
            std::cout << entry << "\n";
        }
    }

    static void searchEntries(const std::vector<Reference>& entries, bool(Reference::* search_func)(const std::string&) const) {
        std::string search_term;
        std::cout << "Enter search term: ";
        std::getline(std::cin, search_term);
        bool found = false;
        for (const auto& entry : entries) {
            if ((entry.*search_func)(search_term)) {
                std::cout << entry << "\n";
                found = true;
            }
        }
        if (!found) {
            std::cout << "No entries found for the search term.\n";
        }
    }

private:
    std::string company_name_;
    std::string owner_;
    std::string phone_;
    std::string address_;
    std::string activity_type_;
};

int main() {
    std::vector<Reference> entries;
    std::ofstream file("data.txt", std::ios::app);
    if (!file) {
        std::cerr << "Error: could not open file for writing\n";
        return 1;
    }
    while (true) {
        std::cout << "Select an option:\n";
        std::cout << "1. Search by company name\n";
        std::cout << "2. Search by owner name\n";
        std::cout << "3. Search by phone number\n";
        std::cout << "4. Search by type of activity\n";
        std::cout << "5. Show all entries\n";
        std::cout << "6. Add a new entry\n";
        std::cout << "7. Quit\n";

        int option;
        std::cin >> option;
        std::cin.ignore();

        switch (option) {
        case 1:
            Reference::searchEntries(entries, &Reference::searchByName);
            break;
        case 2:
            Reference::searchEntries(entries, &Reference::searchByOwner);
            break;
        case 3:
            Reference::searchEntries(entries, &Reference::searchByPhone);
            break;
        case 4:
            Reference::searchEntries(entries, &Reference::searchByActivity);
            break;
        case 5:
            Reference::showAllEntries(entries);
            break;
        case 6:
            Reference::addEntry(entries, file);
            break;
        case 7:
            file.close();
            return 0;
        default:
            std::cout << "Invalid option.\n";
            break;
        }
    }
}