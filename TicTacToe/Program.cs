
Game game = new();
game.Run();

class Player
{
    public PlayerSide PlayerSide { get; }

    public Player(PlayerSide player)
    {
        PlayerSide = player;
    }

    public void GetMove(Board board)
    {
        (int i, int j) field = (-1, -1);

        do
        {
            Console.Write("What square do you want to play in? (Between 1 and 9) ");

            string? input = Console.ReadLine();
            if (input == null) continue;

            field = input switch
            {
                "1" => (0, 0),
                "2" => (0, 1),
                "3" => (0, 2),
                "4" => (1, 0),
                "5" => (1, 1),
                "6" => (1, 2),
                "7" => (2, 0),
                "8" => (2, 1),
                "9" => (2, 2),
                _ => (-1, -1)
            };
        } 
        while (board.BoardState[field.i, field.j] != Field.Empty || field == (-1, -1));

        board.UpdateBoard(field, PlayerSide);
    }
}

class Board 
{
    public char[, ] BoardState { get; private set; }

    public Board()
    {
        BoardState = new char[3, 3];

        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                BoardState[i, j] = Field.Empty;
    }

    public void UpdateBoard((int, int) position, PlayerSide playerSide)
    {
        (int i, int j) = position;

        if (playerSide == PlayerSide.X) BoardState[i, j] = Field.X;
        else BoardState[i, j] = Field.O;
    }

    public void DisplayBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($" {BoardState[i, 0]} | {BoardState[i, 1]} | {BoardState[i, 2]}");
            if (i < 2) Console.WriteLine("---+---+---");
        }
    }
}

class Game 
{
    private Board Board { get; } = new();
    private Player PlayerX { get; } = new(PlayerSide.X);
    private Player PlayerY { get; } = new(PlayerSide.O);

    public Game() { }

    public void Run()
    {
        Player currentPlayer;
        int round = 0;
        bool gameRunning = true;

        while (gameRunning)
        {
            if (round % 2 == 0) 
                currentPlayer = PlayerX;
            else 
                currentPlayer = PlayerY;

            Console.Clear();
            Console.WriteLine($"It is {currentPlayer.PlayerSide}'s turn.");
            Board.DisplayBoard();
            currentPlayer.GetMove(Board);
            char valueToCheck = currentPlayer.PlayerSide == PlayerSide.X ? Field.X : Field.O;

            if (CheckForWinner(valueToCheck))
            {
                EndGame($"Player {currentPlayer.PlayerSide} has won!");
                gameRunning = false;
            }

            if (CheckForTie())
            {
                EndGame("The game has end in a tie.");
                gameRunning = false;
            }

            round++;
        }       
    }

    private bool CheckForWinner(char value)
    {
        bool rightDiagonal = Board.BoardState[0, 0] == value && Board.BoardState[1, 1] == value && Board.BoardState[2, 2] == value;
        bool leftDiagonal = Board.BoardState[2, 0] == value && Board.BoardState[1, 1] == value && Board.BoardState[0, 2] == value;

        if (rightDiagonal || leftDiagonal) return true;

        for (int i = 0; i < 3; i++)
        {
            bool row = Board.BoardState[i, 0] == value && Board.BoardState[i, 1] == value && Board.BoardState[i, 2] == value;
            bool column = Board.BoardState[0, i] == value && Board.BoardState[1, i] == value && Board.BoardState[2, i] == value;
            if (row || column) return true;
        }

        return false;
    }

    private bool CheckForTie()
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (Board.BoardState[i, j] == Field.Empty) return false;

        return true;
    }

    private void EndGame(string feedback)
    {
        Console.Clear();
        Board.DisplayBoard();
        Console.WriteLine(feedback);
    }
}

static class Field
{
    public static char Empty { get; } = ' ';
    public static char X { get; } = 'X';
    public static char O { get; } = 'O';
}

enum PlayerSide { X, O }
