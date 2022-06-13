
Chest chestState = Chest.Locked;

while (true)
{
    Console.Write($"The chest is {chestState}. What do you want to do? ");
    string answer = Console.ReadLine();

    if (answer == "unlock" && chestState == Chest.Locked)
        chestState = Chest.Closed;
    else if (answer == "lock" && chestState == Chest.Closed)
        chestState = Chest.Locked;
    else if (answer == "open" && chestState == Chest.Closed)
        chestState = Chest.Open;
    else
        chestState = Chest.Closed;
}

enum Chest { Open, Closed, Locked }
