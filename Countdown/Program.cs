
Countdown(10);

void Countdown(int n)
{
    if (n == 0) return;

    Console.WriteLine(n);
    Countdown(n - 1);
}
