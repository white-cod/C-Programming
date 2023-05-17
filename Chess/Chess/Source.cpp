#include <iostream>
#include <string>

const int BOARD_SIZE = 8;

char board[BOARD_SIZE][BOARD_SIZE];

void InitializeBoard() {
    board[0][0] = 'R';
    board[0][1] = 'N';
    board[0][2] = 'B';
    board[0][3] = 'Q';
    board[0][4] = 'K';
    board[0][5] = 'B';
    board[0][6] = 'N';
    board[0][7] = 'R';
    for (int i = 0; i < BOARD_SIZE; i++) {
        board[1][i] = 'P';
    }
    for (int i = 2; i < 6; i++) {
        for (int j = 0; j < BOARD_SIZE; j++) {
            board[i][j] = ' ';
        }
    }
    for (int i = 0; i < BOARD_SIZE; i++) {
        board[6][i] = 'p';
    }
    board[7][0] = 'r';
    board[7][1] = 'n';
    board[7][2] = 'b';
    board[7][3] = 'q';
    board[7][4] = 'k';
    board[7][5] = 'b';
    board[7][6] = 'n';
    board[7][7] = 'r';
}

bool IsValidMove(int from_x, int from_y, int to_x, int to_y) {
    char piece = board[from_x][from_y];
    switch (piece) {
    case 'P':
        if (from_x - to_x == 1 && from_y == to_y) {
            return true;
        }
        break;
    case 'R':
        if (from_x == to_x || from_y == to_y) {
            return true;
        }
        break;
    case 'N':
        if ((from_x - to_x == 2 || from_x - to_x == -2) &&
            (from_y - to_y == 1 || from_y - to_y == -1)) {
            return true;
        }
        break;
    case 'B':
        if (from_x - to_x == from_y - to_y || from_x - to_x == to_y - from_y) {
            return true;
        }
        break;
    case 'Q':
        if (from_x == to_x || from_y == to_y || from_x - to_x == from_y - to_y || from_x - to_x == to_y - from_y) {
            return true;
        }
        break;
    case 'K':
        if ((from_x - to_x == 1 || from_x - to_x == -1) &&
            (from_y - to_y == 1 || from_y - to_y == -1)) {
            return true;
        }
        break;
    }
    return false;
}

void MakeMove(int from_x, int from_y, int to_x, int to_y) {
    board[to_x][to_y] = board[from_x][from_y];
    board[from_x][from_y] = ' ';
}

int main() {
    InitializeBoard();
    setlocale(LC_ALL, "");
    for (int i = 0; i < BOARD_SIZE; i++) {
        for (int j = 0; j < BOARD_SIZE; j++) {
            std::cout << board[i][j] << " ";
        }
        std::cout << std::endl;
    }

    int from_x, from_y, to_x, to_y;

    do {
        std::cout << "Введите строку и столбец фигуры, которую вы хотите переместить";
        std::cin >> from_x >> from_y;
    } while (from_x < 0 || from_x >= BOARD_SIZE || from_y < 0 || from_y >= BOARD_SIZE);

    do {
        std::cout << "Введите строку и столбец, куда вы хотите переместить фигуру";
        std::cin >> to_x >> to_y;
    } while (to_x < 0 || to_x >= BOARD_SIZE || to_y < 0 || to_y >= BOARD_SIZE);

    if (IsValidMove(from_x, from_y, to_x, to_y)) {
        MakeMove(from_x, from_y, to_x, to_y);
    }
    else {
        std::cout << "Неверный ход!" << std::endl;
    }

    for (int i = 0; i < BOARD_SIZE; i++) {
        for (int j = 0; j < BOARD_SIZE; j++) {
            std::cout << board[i][j] << " ";
        }
        std::cout << std::endl;
    }

    return 0;
}