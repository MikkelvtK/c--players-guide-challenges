
int[] array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };

int currentSmallest = int.MaxValue;
int total = 0;

foreach (int number in array)
{
    if (number < currentSmallest)
    {
        currentSmallest = number;
    }

    total += number;
}

float average = (float)total / array.Length;

Console.WriteLine($"Smallest number: {currentSmallest}");
Console.WriteLine($"Average: {average}");