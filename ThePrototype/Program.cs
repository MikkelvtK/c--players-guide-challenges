
int target;

do
{
    Console.Write("User 1, enter a number between 0 and 100: ");
    target = Convert.ToInt32(Console.ReadLine());
}
while (target < 0 || target > 100);

Console.Clear();
Console.WriteLine("User 2, guess the number.");

bool guessing = true;

while (guessing)
{
    Console.Write("What is your next guess? ");
    int guess = Convert.ToInt32(Console.ReadLine());

    if (guess > target)
    {
        Console.WriteLine($"{guess} is too high.");
    }

    else if (guess < target)
    {
        Console.WriteLine($"{guess} is too low.");
    }

    else
    {
        Console.WriteLine("You guessed the number!");
        guessing = false;
    }
}
