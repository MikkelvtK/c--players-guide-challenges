
string direction = "";

Console.Write("X: ");
int x = Convert.ToInt32(Console.ReadLine());

Console.Write("Y: ");
int y = Convert.ToInt32(Console.ReadLine());

if (y == 1) direction += "N";
else if (y == -1) direction += "S";

if (x == 1) direction += "E";
else if (x == -1) direction += "W";

if (direction == "") Console.WriteLine("The enemy is here!");
else Console.WriteLine($"The enemy is to the {direction} direction!");
