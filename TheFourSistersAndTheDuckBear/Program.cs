
Console.WriteLine("How many chocolate eggs did the chickens lay?");
int amountOfEggs = Convert.ToInt32(Console.ReadLine());

int eggsPerSister = amountOfEggs / 4;
int eggsRemainder = amountOfEggs % 4;

Console.WriteLine("Each sister gets " + eggsPerSister + " chocolate eggs.");
Console.WriteLine("The duckbear gets " + eggsRemainder + " chocolate eggs.");

