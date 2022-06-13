
Game game = new();
game.Run();

public class Game
{
    public Player Player { get; }
    public Board Board { get; }
    public Monster[] Monsters { get; }
    public ISense[] Senses { get; }
    public bool FountainIsActive { get; set; }

    public Game()
    {
        Board = new(4, 4);
        Player = new(new Position(0, 0));

        Board.Rooms[0, 0] = RoomType.Entrance;
        Board.Rooms[0, 2] = RoomType.FountainOfObjects;

        Monsters = new Monster[] {
            new Amarok(new Position(0, 1)),
            new Maelstrom(new Position(2, 0)),
        };

        Senses = new ISense[] { 
            new EntranceSense(), 
            new FountainSense(),
            new MonsterSense("You can smell the rotten stench of an amarok in a nearby room.", Monsters[0]),
            new MonsterSense("You hear the growling and groaning of a maelstrom nearby.", Monsters[1]),
        };
    }

    public bool HasWon()
    {
        int row = Player.Position.Row;
        int column = Player.Position.Column;
        RoomType currentRoom = Board.Rooms[row, column];

        return currentRoom == RoomType.Entrance && FountainIsActive;
    }

    public void UseMonsters()
    {
        foreach (Monster monster in Monsters)
        {
            if (monster.Position.Equals(Player.Position))
            {
                monster.Attack(Player);

                if (Player.IsAlive)
                    UseMonsters();
            }
        }
    }

    public void Run()
    {
        while (!HasWon() && Player.IsAlive)
        {
            Console.Clear();

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine($"You are in the room at {Player.Position}.");

            foreach (ISense sense in Senses)
                sense.Activate(this);

            ICommand command = new UnclearCommand();

            do
            {
                Console.Write("What do you want to do? ");
                string? userInput = Console.ReadLine();
                if (userInput == null)
                {
                    Console.WriteLine("I did not hear you.");
                    continue;
                }

                command = userInput switch
                {
                    "move north" => new MoveCommand(Direction.North),
                    "move east" => new MoveCommand(Direction.East),
                    "move south" => new MoveCommand(Direction.South),
                    "move west" => new MoveCommand(Direction.West),
                    "enable fountain" => new ActivateCommand(),
                    _ => new UnclearCommand()
                };

                command.Execute(this);
            } 
            while (command is UnclearCommand);

            UseMonsters();
        }

        if (HasWon())
        {
            Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");
            Console.WriteLine("You win!");
        }

        else
        {
            Console.WriteLine("You have failed to reactivate the Fountain of Objects and escape with your life.");
            Console.WriteLine("You lose.");
        }

        Console.ReadKey();
    }
}

public class Board
{
    public int TotalRows { get; }
    public int TotalColumns { get; }
    public RoomType[,] Rooms { get; }
    
    public Board(int totalRows, int totalColumns)
    {
        TotalRows = totalRows;
        TotalColumns = totalColumns;

        Rooms = new RoomType[totalRows, totalColumns];
        for (int i = 0; i < totalRows; i++)
            for (int j = 0; j < totalColumns; j++)
                Rooms[i, j] = RoomType.Empty;
    }

    public bool IsOffBoard(Position position)
    {
        if (position.Row < 0 || position.Row >= TotalRows) return true;
        if (position.Column < 0 || position.Column >= TotalColumns) return true;

        return false;
    }
}

public class GameObject
{
    public Position Position { get; set; }
    public bool IsAlive { get; set; }

    public GameObject(Position position)
    {
        Position = position;
        IsAlive = true;
    }

    public void Die()
    {
        IsAlive = false;
    }
}

public class Player : GameObject
{
    public Player(Position position) : base(position) { }
}

public abstract class Monster : GameObject
{
    public Monster(Position position) : base(position) { }

    public abstract void Attack(Player player);
    public abstract bool IsAdjacent(Player player);
}

public class Amarok : Monster
{
    public Amarok(Position position) : base(position) { }

    public override void Attack(Player player)
    {
        if (Position.Equals(player.Position))
        {
            player.Die();
            Console.WriteLine("An Amarok jumped from out the darkness and attacked. You did not survive.");
        }
    }

    public override bool IsAdjacent(Player player)
    {
        int rowDifference = Math.Abs(Position.Row - player.Position.Row);
        int columnDifference = Math.Abs(Position.Column - player.Position.Column);

        if (rowDifference == 1 && columnDifference == 0) return true;
        if (rowDifference == 0 && columnDifference == 1) return true;

        return false;
    }
}

public class Maelstrom : Monster
{
    public Maelstrom(Position position) : base(position) { }

    public override void Attack(Player player)
    {
        uint newPlayerRow = ((uint)player.Position.Row - 1) % 4;
        int newPlayerColumn = (player.Position.Column + 2) % 4;

        int newMaelstromRow = (Position.Row + 1) % 4;
        uint newMaelstromColumn = ((uint)Position.Column - 2) % 4;

        player.Position = new Position((int)newPlayerRow, newPlayerColumn);
        Position = new Position(newMaelstromRow, (int)newMaelstromColumn);

        Console.WriteLine("The growling and groaning Maelstrom and attacks you. You are blown accross the area.");
    }

    public override bool IsAdjacent(Player player)
    {
        int rowDifference = Math.Abs(Position.Row - player.Position.Row);
        int columnDifference = Math.Abs(Position.Column - player.Position.Column);

        if (rowDifference == 1 || columnDifference == 1) return true;

        return false;
    }
}

public interface ISense 
{
    void Activate(Game game);
}

public class FountainSense : ISense
{
    public void Activate(Game game)
    {
        int row = game.Player.Position.Row;
        int column = game.Player.Position.Column;
        RoomType currentRoom = game.Board.Rooms[row, column];

        if (currentRoom == RoomType.FountainOfObjects)
        {
            if (game.FountainIsActive)
                Console.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
            else
                Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
        }
    }
}

public class EntranceSense : ISense
{
    public void Activate(Game game)
    {
        int row = game.Player.Position.Row;
        int column = game.Player.Position.Column;
        RoomType currentRoom = game.Board.Rooms[row, column];

        if (currentRoom == RoomType.Entrance)
            Console.WriteLine("You see light coming from the cavern entrance.");
    }
}

public class MonsterSense : ISense
{
    private string CustomMessage { get; }
    private Monster Monster { get; }

    public MonsterSense(string message, Monster monster)
    {
        CustomMessage = message;
        Monster = monster;
    }

    public void Activate(Game game)
    {
        foreach (Monster monster in game.Monsters)
        {
            if (monster.Equals(Monster) && monster.IsAdjacent(game.Player))
            {
                Console.WriteLine(CustomMessage);
            }
        }
    }
}

public interface ICommand
{ 
    void Execute(Game game);
}

public class MoveCommand : ICommand
{
    private Direction Direction { get; }

    public MoveCommand(Direction direction)
    {
        Direction = direction;
    }

    public void Execute(Game game)
    {
        Position currentPosition = game.Player.Position;

        Position newPosition = Direction switch
        {
            Direction.North => new(currentPosition.Row - 1, currentPosition.Column),
            Direction.East => new(currentPosition.Row, currentPosition.Column + 1),
            Direction.South => new(currentPosition.Row + 1, currentPosition.Column),
            Direction.West => new(currentPosition.Row, currentPosition.Column - 1),
            _ => throw new NotImplementedException()
        };

        if (game.Board.IsOffBoard(newPosition))
            Console.WriteLine("You just hit a wall.");
        else
            game.Player.Position = newPosition;
    }
}

public class ActivateCommand : ICommand
{
    public void Execute(Game game)
    {
        int row = game.Player.Position.Row;
        int column = game.Player.Position.Column;
        RoomType currentRoom = game.Board.Rooms[row, column];

        if (currentRoom == RoomType.FountainOfObjects && !game.FountainIsActive)
            game.FountainIsActive = true;
        else if (game.FountainIsActive)
            Console.WriteLine("The Fountain of Objects is already active.");
        else
            Console.WriteLine("The Fountain of Objects is not in this room.");
    }
}

public class UnclearCommand : ICommand
{
    public void Execute(Game game)
    {
        Console.WriteLine("I do not understand this command.");
    }
}

public struct Position
{
    public int Row { get; }
    public int Column { get; }

    public Position(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public override string ToString()
    {
        return $"(Row={Row}, Column={Column})";
    }
}

public enum Direction { North, East, South, West }
public enum RoomType { Empty, FountainOfObjects, Entrance }
