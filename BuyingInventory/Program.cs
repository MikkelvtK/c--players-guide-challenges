
Console.WriteLine(
    "The folliwing items are available:\n" +
    "1 - Rope\n" +
    "2 - Torches\n" +
    "3 - Climbing Equipment\n" +
    "4 - Clean Water\n" +
    "5 - Machete\n" +
    "6 - Canoe\n" +
    "7 - Food Supplies"
);

Console.Write("What number do you want to see the price of? ");
int choice = Convert.ToInt32(Console.ReadLine());

Console.Write("What is your name? ");
string playerName = Console.ReadLine();

int itemDiscount = playerName == "Mikkel" ? 2 : 1;

string description = choice switch
{
    1 => $"Rope costs {10 / itemDiscount} gold.",
    2 => $"Torches cost {15 / itemDiscount} gold.",
    3 => $"Climbing equipment costs {25 / itemDiscount}",
    4 => $"Clean water costs {1 / itemDiscount}",
    5 => $"Machete costs {20 / itemDiscount}",
    6 => $"Canoe costs {200 / itemDiscount}",
    7 => $"Food supplies cost {1 / itemDiscount}",
    _ => "We do not have that item."
};

Console.WriteLine(description);
