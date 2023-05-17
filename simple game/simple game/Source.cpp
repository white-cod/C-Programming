#include <iostream>
#include <string>

int main() {

    int score = 0;
    std::string input;

    while (true) {
        std::cout << "Enter 'a' or 'b': ";
        std::cin >> input;

        if (input == "a") {
            score += 1;
            std::cout << "Correct! Your score is now " << score << std::endl;
        }
        else if (input == "b") {
            std::cout << "Incorrect! Your score is still " << score << std::endl;
        }
        else {
            std::cout << "Invalid input. Please try again." << std::endl;
        }
    }

    return 0;
}