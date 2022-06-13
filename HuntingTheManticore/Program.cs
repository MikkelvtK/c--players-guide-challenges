
int manticore = 10;
int consolas = 15;
int round = 1;

int manticoreDistance = SetManticoreDistance();

Console.Clear();

Console.ForegroundColor = ConsoleColor.White;

while (manticore > 0 && consolas > 0)
{
    DisplayStatus(round, consolas, manticore);

    int cannonDamage = CalculateCannonDamage(round);
    DisplayCannonDamage(cannonDamage);

    Console.Write("Enter desired cannon range: ");
    int cannonRange = Convert.ToInt32(Console.ReadLine());

    if (cannonRange < manticoreDistance)
    {
        Console.WriteLine("That round FELL SHORT of the target.");
    }

    else if (cannonRange > manticoreDistance)
    {
        Console.WriteLine("That round OVERSHOT the target.");
    }

    else
    {
        Console.WriteLine("That round was a DIRECT HIT.");
        manticore -= cannonDamage;
    }

    round++;
    consolas--;
}

if (consolas <= 0 && manticore <= 0)
    Console.WriteLine("The Manticore has been destroyed, but at what cost. The city of Consolas has been destroyed with it.");
else if (manticore <= 0)
    Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
else
    Console.WriteLine("The Manticore succeeded in destroying the city of Consolas.");

int SetManticoreDistance()
{
    int distance;

    Random rand = new Random();
    distance = rand.Next(100) + 1; 

    return distance;
}

void DisplayStatus(int currentRound, int currentCityHealth, int currentManticoreHealth)
{
    Console.WriteLine($"---------------------------------------------");
    Console.WriteLine($"STATUS: Round: {currentRound}  City: {currentCityHealth}/15  Manticore: {currentManticoreHealth}/10");
}

int CalculateCannonDamage(int currentRound)
{
    if (currentRound % 3 == 0 && currentRound % 5 == 0)
        return 10;
    else if (currentRound % 3 == 0 || currentRound % 5 == 0)
        return 3;
    else
        return 1;
}

void DisplayCannonDamage(int cannonDamage)
{
    Console.Write("The cannon is expected to deal ");

    if (cannonDamage == 1)
        Console.ForegroundColor = ConsoleColor.Gray;

    else if (cannonDamage == 3)
        Console.ForegroundColor = ConsoleColor.Red;

    else
        Console.ForegroundColor = ConsoleColor.Yellow;

    Console.Write($"{cannonDamage} damage ");

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("this round.");
}