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

int player = 0;

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



showBoard(board);