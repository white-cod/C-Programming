#include <iostream>
#include <vector>
#include <fstream>
#include <locale>

class InvalidAmountException : public std::exception {
public:
    const char* what() const noexcept override {
        return "Введена неверная сумма";
    }
};

class InsufficientFundsException : public std::exception {
public:
    const char* what() const noexcept override {
        return "Недостаточно доступных средств";
    }
};

class MaxNotesException : public std::exception {
public:
    const char* what() const noexcept override {
        return "Максимальное количество выданных банкнот";
    }
};

class ATM {
public:
    ATM(int minimum_dispense, int max_dispense, std::vector<int> banknotes) : minimum_dispense_(minimum_dispense), max_dispense_(max_dispense), banknotes_(banknotes) {}

    void load_money(std::vector<int> banknotes) {
        banknotes_ = banknotes;
    }

    void dispense_money(int amount) {
        if (amount < 0 || amount % minimum_dispense_ != 0) {
            throw InvalidAmountException();
        }

        int total_amount = amount;
        std::vector<int> dispensed_notes(banknotes_.size(), 0);
        for (int i = banknotes_.size() - 1; i >= 0; i--) {
            int notes_to_dispense = std::min(total_amount / denominations[i], banknotes_[i]);
            dispensed_notes[i] = notes_to_dispense;
            total_amount -= notes_to_dispense * denominations[i];
        }

        if (total_amount != 0) {
            throw InsufficientFundsException();
        }

        int num_dispensed_notes = 0;
        for (const auto& notes : dispensed_notes) {
            num_dispensed_notes += notes;
        }

        if (num_dispensed_notes > max_dispense_) {
            throw MaxNotesException();
        }

        banknotes_ = dispensed_notes;
    }

    std::vector<int> get_banknotes() const { return banknotes_; }

    friend std::ostream& operator<<(std::ostream& os, const ATM& atm);

private:
    const std::vector<int> denominations = { 500, 200, 100, 50, 20, 10, 5, 2, 1 };
    const int minimum_dispense_;
    const int max_dispense_;
    std::vector<int> banknotes_;
};

std::ostream& operator<<(std::ostream& os, const ATM& atm) {
    os << "Банкноты: ";
    for (int i = atm.banknotes_.size() - 1; i >= 0; i--) {
        os << atm.banknotes_[i] << " x " << atm.denominations[i] << " ";
    }
    os << std::endl;
    return os;
}

class Bank {
public:
    Bank(int num_atms) : atms_(num_atms) {}

    void initialize_atms(std::vector<std::vector<int>> banknotes, std::vector<int> minimum_dispense, std::vector<int> max_dispense) {
        for (int i = 0; i < atms_.size(); i++) {
            ATM atm(minimum_dispense[i], max_dispense[i], banknotes[i]);
            atms_[i] = atm;                                                       //Принципиально не записывает
        }
    }

    double get_total_atm_balance() const {
        double total = 0;
        for (const auto& atm : atms_) {
            std::vector<int> banknotes = atm.get_banknotes();
            for (int i = 0; i < banknotes.size(); i++) {
                total += banknotes[i] * denominations[i];
            }
        }
        return total;
    }

    void withdraw_money(int atm_index, int amount) {
        try {
            atms_[atm_index].dispense_money(amount);
        }
        catch (const std::exception& e) {
            std::cerr << "Ошибка: " << e.what() << std::endl;
        }
    }

    friend std::ostream& operator<<(std::ostream& os, const Bank& bank);
    friend std::istream& operator>>(std::istream& is, Bank& bank);

private:
    const std::vector<int> denominations = { 500, 200, 100, 50, 20, 10, 5, 2, 1 };
    std::vector<ATM> atms_;
};

std::ostream& operator<<(std::ostream& os, const Bank& bank) {
    for (int i = 0; i < bank.atms_.size(); i++) {
        os << "ATM " << i << ":" << std::endl;
        os << bank.atms_[i];
    }
    os << "Общий баланс банкомата: " << bank.get_total_atm_balance() << std::endl;
    return os;
}

std::istream& operator>>(std::istream& is, Bank& bank) {
    int num_atms;
    is >> num_atms;

    if (num_atms != bank.atms_.size()) {
        std::cerr << "Ошибка: неправильное количество банкоматов в файле" << std::endl;
        return is;
    }

    for (int i = 0; i < num_atms; i++) {
        std::vector<int> banknotes(9);
        for (int j = 0; j < 9; j++) {
            is >> banknotes[j];
        }

        int min_dispense;
        int max_dispense;
        is >> min_dispense >> max_dispense;

        ATM atm(min_dispense, max_dispense, banknotes);
        bank.atms_[i] = atm;                                         //Та же история
    }

    return is;
}

int main() {
    std::setlocale(LC_ALL, "");
    Bank bank(3);
    std::vector<std::vector<int>> banknotes = {
        { 100, 50, 20 },
        { 100, 50, 20 },
        { 100, 50, 20 }
    };
    std::vector<int> min_dispense = { 10, 10, 10 };
    std::vector<int> max_dispense = { 50, 50, 50 };
    bank.initialize_atms(banknotes, min_dispense, max_dispense);

    std::cout << bank;

    bank.withdraw_money(0, 1000);

    std::cout << bank;

    std::ofstream file_out("atms.txt");
    if (file_out.is_open()) {
        file_out << bank;
        file_out.close();
    }

    std::ifstream file_in("atms.txt");
    if (file_in.is_open()) {
        Bank bank2(3);
        file_in >> bank2;
        std::cout << bank2;
        file_in.close();
    }

    return 0;
}