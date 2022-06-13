
int result = AskForNumber("What is the airspeed velocity of an unladen swallow?");
Console.WriteLine("Answer: " + result);

int number = AskForNumberInRange("Pick a number between 0 and 100.", 0, 100);
Console.WriteLine("Answer: " + number);

int AskForNumber(string text)
{
    Console.Write(text + " ");
    int answer = Convert.ToInt32(Console.ReadLine());
    return answer;
}

int AskForNumberInRange(string text, int min, int max)
{
    int answer;

    do
    {
        Console.Write(text + " ");
        answer = Convert.ToInt32(Console.ReadLine());
    }
    while (answer < min || answer > max);

    return answer;
}