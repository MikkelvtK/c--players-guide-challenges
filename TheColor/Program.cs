
Color green = new(0, 255, 0);
Color orange = Color.Orange;

Console.WriteLine($"({green.R}, {green.G}, {green.B})");
Console.WriteLine($"({orange.R}, {orange.G}, {orange.B})");

class Color
{
    public byte R { get; }
    public byte G { get; }
    public byte B { get; }

    public Color(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }

    static public Color White { get; } = new(255, 255, 255);
    static public Color Black { get; } = new(0, 0, 0);
    static public Color Red { get; } = new(255, 0, 0);
    static public Color Orange { get; } = new(255, 165, 0);
    static public Color Yellow { get; } = new(255, 255, 0);
    static public Color Green { get; } = new(0, 128, 0);
    static public Color Blue { get; } = new(0, 0, 255);
    static public Color Purple { get; } = new(128, 0, 128);
}
