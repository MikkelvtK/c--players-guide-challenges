
Console.Title = "Defense of Consolas";

Console.Write("Target row? ");
int targetRow = Convert.ToInt32(Console.ReadLine());

Console.Write("Target column? ");
int targetColumn = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Deploy to:");

Console.ForegroundColor = ConsoleColor.Yellow;

// Above
Console.WriteLine($"({targetRow - 1}, {targetColumn})");

// Right
Console.WriteLine($"({targetRow}, {targetColumn + 1})");

// Below
Console.WriteLine($"({targetRow + 1}, {targetColumn})");

// Left
Console.WriteLine($"({targetRow}, {targetColumn - 1})");

Console.Beep();
Console.ForegroundColor = ConsoleColor.White;
