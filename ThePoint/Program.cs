Point a = new(2, 3);
Point b = new(-4, 0);
Point c = new();

Console.WriteLine(a.ToString());
Console.WriteLine(b.ToString());
Console.WriteLine(c.ToString());

class Point
{
    int X { get; }
    int Y { get; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Point()
    {
        X = 0;
        Y = 0;
    }

    public string ToString()
    {
        return $"({X}, {Y})";
    }
}
