internal class Program
{
    public static void Main(string[] args)
    {
        char [,] board = new char [8, 8]
        {
            {' ', 'X', ' ', 'X', ' ', 'X', ' ', 'X'},
            {'X', ' ', 'X', ' ', 'X', ' ', 'X', ' '},
            {' ', 'X', ' ', 'X', ' ', 'X', ' ', 'X'},
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',},
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',},
            {'O', ' ', 'O', ' ', 'O', ' ', 'O', ' ',},
            {' ', 'O', ' ', 'O', ' ', 'O', ' ', 'O'},
            {'O', ' ', 'O', ' ', 'O', ' ', 'O', ' ',}
        };

        char[] boardLetter = new char [8] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };

        bool player = true;

        void showBoard(char[,] board)
        {
            int size = board.GetLength(0);
            Console.Write("    ");
            for (int i = 0; i < boardLetter.GetLength(0); i++)
            {
                Console.Write($" {boardLetter[i]}  ");
            }
            Console.WriteLine();
    
            Console.WriteLine("   +---+---+---+---+---+---+---+---+");

            for (int i = 0; i < size; i++)
            {
                Console.Write($"  {i + 1} ");
                for (int j = 0; j < size; j++)
                {
                    Console.Write($" {board[i,j]} |");
                }
                Console.WriteLine();
                Console.WriteLine("   +---+---+---+---+---+---+---+---+");
            }
        }

        bool isGameStill()
        {
            char character, playerCharacter = ' ';
            bool foundPlayer = false;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    character = board[i,j];
                    if (character != ' ')
                    {
                        if (!foundPlayer)
                        {
                            playerCharacter = character;
                            foundPlayer = true;
                        } else if (character != playerCharacter)
                        {
                            return true;
                        }
                    }
                }
            }
    
            return false;
        }

        void playerMove()
        {
            char playerChar = player ? 'O' : 'X';
            Console.Write($"Player {playerChar} can now move! Write the cordinates of the pawn you want to move: ");
            string pawnCordinate = Console.ReadLine();
    
            int pawnCordinateX = int.Parse(pawnCordinate.Substring(1)) - 1;
            int pawnCordinateY = 0;
            char pawnCordinateYchar = char.Parse(pawnCordinate.Substring(0, 1));

            switch (pawnCordinateYchar)
            {
                case 'A':
                    pawnCordinateY = 0;
                    break;
                case 'B':
                    pawnCordinateY = 1;
                    break;
                case 'C':
                    pawnCordinateY = 2;
                    break;
                case 'D':
                    pawnCordinateY = 3;
                    break;
                case 'E':
                    pawnCordinateY = 4;
                    break;
                case 'F':
                    pawnCordinateY = 5;
                    break;
                case 'G':
                    pawnCordinateY = 6;
                    break;
                case 'H':
                    pawnCordinateY = 7;
                    break;
                default:
                    break;
            }
            
            // Console.WriteLine($"{board[pawnCordinateX, pawnCordinateY]}");

            if (playerChar == 'O' && board[pawnCordinateX, pawnCordinateY] == 'O')
            {
                Console.Write("Write the cordinates of the field that you want to move: ");
                string fieldCordinate = Console.ReadLine();
                
                int fieldCordinateX = int.Parse(fieldCordinate.Substring(1)) - 1;
                int fieldCordinateY = 0;
                char fieldCordinateYchar = char.Parse(fieldCordinate.Substring(0, 1));
                
                switch (fieldCordinateYchar)
                {
                    case 'A':
                        fieldCordinateY = 0;
                        break;
                    case 'B':
                        fieldCordinateY = 1;
                        break;
                    case 'C':
                        fieldCordinateY = 2;
                        break;
                    case 'D':
                        fieldCordinateY = 3;
                        break;
                    case 'E':
                        fieldCordinateY = 4;
                        break;
                    case 'F':
                        fieldCordinateY = 5;
                        break;
                    case 'G':
                        fieldCordinateY = 6;
                        break;
                    case 'H':
                        fieldCordinateY = 7;
                        break;
                    default:
                        break;
                }

                Console.WriteLine($"Field: {fieldCordinateX}{fieldCordinateY} Pawn: {pawnCordinateX}{pawnCordinateY}");
                Console.WriteLine();
                if (true)
                {
                    if (board[fieldCordinateX, fieldCordinateY] == ' ' && pawnCordinateX - fieldCordinateX == 1 && (pawnCordinateY - fieldCordinateY == 1 || fieldCordinateY - pawnCordinateY == 1))
                    {
                        char pawn = board[pawnCordinateX, pawnCordinateY];
                        board[fieldCordinateX, fieldCordinateY] = pawn;
                        board[pawnCordinateX, pawnCordinateY] = ' ';
                        pawn = ' ';
                        // Console.Clear();
                        player = true;
                        showBoard(board);
                    }
                }
                else
                {
                    Console.WriteLine("Error occured while moving field");
                }
            }
        }

        showBoard(board);
        while (isGameStill())
        {
            playerMove();
        }
    }
}