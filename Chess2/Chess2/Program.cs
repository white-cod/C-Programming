using System;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Board board = new Board();
            board.Initialize();

            bool gameOver = false;
            bool isWhiteTurn = true;

            while (!gameOver)
            {
                Console.Clear();
                Console.WriteLine("Chess Game\n");

                board.Display();

                Console.WriteLine($"{(isWhiteTurn ? "Белые" : "Черные")}");
                Console.Write("Введите позицию фигуры (например, a2): ");
                string fromPosition = Console.ReadLine();
                Console.Write("Введите конечную позицию: ");
                string toPosition = Console.ReadLine();

                try
                {
                    board.MovePiece(fromPosition, toPosition, isWhiteTurn);

                    isWhiteTurn = !isWhiteTurn;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }

                if (board.IsCheckmate(!isWhiteTurn))
                {
                    Console.Clear();
                    Console.WriteLine("Chess Game\n");
                    board.Display();
                    Console.WriteLine($"Checkmate! {(isWhiteTurn ? "Черные" : "Белые")} победили.");
                    gameOver = true;
                }
                else if (board.IsStalemate(!isWhiteTurn))
                {
                    Console.Clear();
                    Console.WriteLine("Chess Game\n");
                    board.Display();
                    Console.WriteLine("Ничья.");
                    gameOver = true;
                }
            }
        }
    }

    public enum Color
    {
        White,
        Black
    }

    public enum PieceType
    {
        Pawn,
        Knight,
        Bishop,
        Rook,
        Queen,
        King
    }

    public class Piece
    {
        public Color Color { get; set; }
        public PieceType Type { get; set; }
        public bool HasMoved { get; set; }

        public Piece(Color color, PieceType type)
        {
            Color = color;
            Type = type;
            HasMoved = false;
        }

        public override string ToString()
        {
            switch (Type)
            {
                case PieceType.Pawn:
                    return Color == Color.White ? "p" : "P";
                case PieceType.Knight:
                    return Color == Color.White ? "k" : "K";
                case PieceType.Bishop:
                    return Color == Color.White ? "b" : "B";
                case PieceType.Rook:
                    return Color == Color.White ? "r" : "R";
                case PieceType.Queen:
                    return Color == Color.White ? "q" : "Q";
                case PieceType.King:
                    return Color == Color.White ? "kg" : "KG";
                default:
                    return "";
            }
        }
    }

    public class Board
    {
        private Piece[,] _board;

        public Board()
        {
            _board = new Piece[8, 8];
        }

        public void Initialize()
        {
            _board[0, 0] = new Piece(Color.White, PieceType.Rook);
            _board[0, 1] = new Piece(Color.White, PieceType.Knight);
            _board[0, 2] = new Piece(Color.White, PieceType.Bishop);
            _board[0, 3] = new Piece(Color.White, PieceType.Queen);
            _board[0, 4] = new Piece(Color.White, PieceType.King);
            _board[0, 5] = new Piece(Color.White, PieceType.Bishop);
            _board[0, 6] = new Piece(Color.White, PieceType.Knight);
            _board[0, 7] = new Piece(Color.White, PieceType.Rook);

            for (int i = 0; i < 8; i++)
            {
                _board[1, i] = new Piece(Color.White, PieceType.Pawn);
            }

            _board[7, 0] = new Piece(Color.Black, PieceType.Rook);
            _board[7, 1] = new Piece(Color.Black, PieceType.Knight);
            _board[7, 2] = new Piece(Color.Black, PieceType.Bishop);
            _board[7, 3] = new Piece(Color.Black, PieceType.Queen);
            _board[7, 4] = new Piece(Color.Black, PieceType.King);
            _board[7, 5] = new Piece(Color.Black, PieceType.Bishop);
            _board[7, 6] = new Piece(Color.Black, PieceType.Knight);
            _board[7, 7] = new Piece(Color.Black, PieceType.Rook);

            for (int i = 0; i < 8; i++)
            {
                _board[6, i] = new Piece(Color.Black, PieceType.Pawn);
            }
        }

        public void Display()
        {
            Console.WriteLine("  A  B  C  D  E  F  G  H");
            Console.WriteLine("  --------------------------");

            for (int row = 0; row < 8; row++)
            {
                Console.Write($"{8 - row} ");

                for (int col = 0; col < 8; col++)
                {
                    Console.Write($" {_board[row, col]?.ToString() ?? " "} ");
                }

                Console.WriteLine($" {8 - row}");
            }

            Console.WriteLine("  --------------------------");
            Console.WriteLine("  A  B  C  D  E  F  G  H");
        }

        public void MovePiece(string fromPosition, string toPosition, bool isWhiteTurn)
        {
            int fromRow = 8 - int.Parse(fromPosition[1].ToString());
            int fromCol = fromPosition[0] - 'a';
            int toRow = 8 - int.Parse(toPosition[1].ToString());
            int toCol = toPosition[0] - 'a';

            if (_board[fromRow, fromCol] == null)
            {
                throw new Exception("В указанной позиции нет фигуры.");
            }

            if (_board[fromRow, fromCol].Color == Color.Black && isWhiteTurn ||
                _board[fromRow, fromCol].Color == Color.White && !isWhiteTurn)
            {
                throw new Exception("Сейчас не твоя очередь.");
            }

            if (!_board[fromRow, fromCol].IsValidMove(fromRow, fromCol, toRow, toCol, _board))
            {
                throw new Exception("Неверный ход.");
            }

            _board[toRow, toCol] = _board[fromRow, fromCol];
            _board[fromRow, fromCol] = null;

            _board[toRow, toCol].HasMoved = true;
        }

        public bool IsCheckmate(bool isWhiteTurn)
        {
            return false;
        }

        public bool IsStalemate(bool isWhiteTurn)
        {
            return false;
        }
    }

    public static class PieceExtensions
    {
        public static bool IsValidMove(this Piece piece, int fromRow, int fromCol, int toRow, int toCol, Piece[,] board)
        {
            if (toRow < 0 || toRow > 7 || toCol < 0 || toCol > 7)
            {
                return false;
            }

            switch (piece.Type)
            {
                case PieceType.Pawn:
                    return piece.IsValidPawnMove(fromRow, fromCol, toRow, toCol, board);
                case PieceType.Knight:
                    return piece.IsValidKnightMove(fromRow, fromCol, toRow, toCol, board);
                case PieceType.Bishop:
                    return piece.IsValidBishopMove(fromRow, fromCol, toRow, toCol, board);
                case PieceType.Rook:
                    return piece.IsValidRookMove(fromRow, fromCol, toRow, toCol, board);
                case PieceType.Queen:
                    return piece.IsValidQueenMove(fromRow, fromCol, toRow, toCol, board);
                case PieceType.King:
                    return piece.IsValidKingMove(fromRow, fromCol, toRow, toCol, board);
                default:
                    return false;
            }
        }

        public static bool IsValidPawnMove(this Piece pawn, int fromRow, int fromCol, int toRow, int toCol, Piece[,] board)
        {
            int direction = pawn.Color == Color.White ? -1 : 1;

            if (fromCol == toCol && (toRow == fromRow + direction || (fromRow == 1 || fromRow == 6) && toRow == fromRow + direction * 2))
            {
                if (board[toRow, toCol] != null)
                {
                    return false;
                }

                if (fromRow == 3 && toRow == 2 && board[3, toCol] != null && board[3, toCol].Type == PieceType.Pawn && board[3, toCol].Color != pawn.Color && board[3, toCol].HasMoved)
                {
                    return true;
                }
                else if (fromRow == 4 && toRow == 5 && board[4, toCol] != null && board[4, toCol].Type == PieceType.Pawn && board[4, toCol].Color != pawn.Color && board[4, toCol].HasMoved)
                {
                    return true;
                }

                return true;
            }

            if (Math.Abs(fromCol - toCol) == 1 && toRow == fromRow + direction && board[toRow, toCol] != null && board[toRow, toCol].Color != pawn.Color)
            {
                return true;
            }

            return false;
        }

        public static bool IsValidKnightMove(this Piece knight, int fromRow, int fromCol, int toRow, int toCol, Piece[,] board)
        {
            int rowDiff = Math.Abs(toRow - fromRow);
            int colDiff = Math.Abs(toCol - fromCol);

            return rowDiff == 2 && colDiff == 1 ||
                   rowDiff == 1 && colDiff == 2;
        }

        public static bool IsValidBishopMove(this Piece bishop, int fromRow, int fromCol, int toRow, int toCol, Piece[,] board)
        {
            if (Math.Abs(toRow - fromRow) != Math.Abs(toCol - fromCol))
            {
                return false;
            }

            int rowDirection = (toRow - fromRow) / Math.Abs(toRow - fromRow);
            int colDirection = (toCol - fromCol) / Math.Abs(toCol - fromCol);

            for (int i = 1; i < Math.Abs(toRow - fromRow); i++)
            {
                if (board[fromRow + i * rowDirection, fromCol + i * colDirection] != null)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsValidRookMove(this Piece rook, int fromRow, int fromCol, int toRow, int toCol, Piece[,] board)
        {
            if (fromRow != toRow && fromCol != toCol)
            {
                return false;
            }

            if (fromRow == toRow)
            {
                int colDirection = (toCol - fromCol) / Math.Abs(toCol - fromCol);

                for (int i = 1; i < Math.Abs(toCol - fromCol); i++)
                {
                    if (board[fromRow, fromCol + i * colDirection] != null)
                    {
                        return false;
                    }
                }
            }
            else
            {
                int rowDirection = (toRow - fromRow) / Math.Abs(toRow - fromRow);

                for (int i = 1; i < Math.Abs(toRow - fromRow); i++)
                {
                    if (board[fromRow + i * rowDirection, fromCol] != null)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool IsValidQueenMove(this Piece queen, int fromRow, int fromCol, int toRow, int toCol, Piece[,] board)
        {
            if (fromRow != toRow && fromCol != toCol && Math.Abs(toRow - fromRow) != Math.Abs(toCol - fromCol))
            {
                return false;
            }

            if (fromRow == toRow || fromCol == toCol)
            {
                return IsValidRookMove(queen, fromRow, fromCol, toRow, toCol, board);
            }
            else
            {
                return IsValidBishopMove(queen, fromRow, fromCol, toRow, toCol, board);
            }
        }

        public static bool IsValidKingMove(this Piece king, int fromRow, int fromCol, int toRow, int toCol, Piece[,] board)
        {
            int rowDiff = Math.Abs(toRow - fromRow);
            int colDiff = Math.Abs(toCol - fromCol);

            return rowDiff <= 1 && colDiff <= 1;
        }
    }
}