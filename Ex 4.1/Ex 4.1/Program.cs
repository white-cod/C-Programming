using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {

            char[,] board = new char[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = '-';
                }
            }

            Random rand = new Random();
            bool playerTurn = rand.Next(2) == 0;

            while (true)
            {
                Console.WriteLine("Текущая доска:");
                PrintBoard(board);

                if (CheckWin(board, 'X'))
                {
                    Console.WriteLine("Вы выиграли!");
                    break;
                }
                else if (CheckWin(board, 'O'))
                {
                    Console.WriteLine("Компьютер победил!");
                    break;
                }
                else if (IsBoardFull(board))
                {
                    Console.WriteLine("Ничея!");
                    break;
                }

                if (playerTurn)
                {
                    Console.WriteLine("Ваша очередь (X):");
                    int row = GetRow();
                    int col = GetColumn();
                    if (board[row, col] != '-')
                    {
                        Console.WriteLine("Эта позиция уже занята!");
                        continue;
                    }
                    board[row, col] = 'X';
                }

                else
                {
                    Console.WriteLine("Очередь компьютера (O):");
                    int[] move = GetComputerMove(board);
                    board[move[0], move[1]] = 'O';
                }

                playerTurn = !playerTurn;
            }
        }

        static void PrintBoard(char[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static bool CheckWin(char[,] board, char player)
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player)
                {
                    return true;
                }
            }

            for (int j = 0; j < 3; j++)
            {
                if (board[0, j] == player && board[1, j] == player && board[2, j] == player)
                {
                    return true;
                }
            }

            if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
            {
                return true;
            }
            if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
            {
                return true;
            }

            return false;
        }

        static bool IsBoardFull(char[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == '-')
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static int GetRow()
        {
            Console.Write("Введите строку (0-2): ");
            string input = Console.ReadLine();
            int row;
            while (!int.TryParse(input, out row) || row < 0 || row > 2)
            {
                Console.Write("Неверный ввод. Введите строку (0-2): ");
                input = Console.ReadLine();
            }
            return row;
        }

        static int GetColumn()
        {
            Console.Write("Введите столбец (0-2): ");
            string input = Console.ReadLine();
            int col;
            while (!int.TryParse(input, out col) || col < 0 || col > 2)
            {
                Console.Write("Неверный ввод. Введите столбец (0-2): ");
                input = Console.ReadLine();
            }
            return col;
        }

        static int[] GetComputerMove(char[,] board)
        {
            int[] move = new int[2];
            bool foundMove = false;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == '-')
                    {
                        board[i, j] = 'O';
                        if (CheckWin(board, 'O'))
                        {
                            move[0] = i;
                            move[1] = j;
                            foundMove = true;
                            break;
                        }
                        board[i, j] = '-';
                    }
                }
                if (foundMove) break;
            }

            if (!foundMove)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i, j] == '-')
                        {
                            board[i, j] = 'X';
                            if (CheckWin(board, 'X'))
                            {
                                move[0] = i;
                                move[1] = j;
                                foundMove = true;
                                break;
                            }
                            board[i, j] = '-';
                        }
                    }
                    if (foundMove) break;
                }
            }

            if (!foundMove)
            {
                Random rand = new Random();
                int row, col;
                do
                {
                    row = rand.Next(3);
                    col = rand.Next(3);
                } while (board[row, col] != '-');
                move[0] = row;
                move[1] = col;
            }

            Console.WriteLine("Компьютер выбрал ряд " + move[0] + " колонка " + move[1]);

            return move;
        }
    }
}