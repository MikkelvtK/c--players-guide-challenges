
ColoredItem<Sword> blueSword = new(new Sword(), ConsoleColor.Blue);
ColoredItem<Bow> redBow = new(new Bow(), ConsoleColor.Red);
ColoredItem<Axe> greenAxe = new(new Axe(), ConsoleColor.Green);

blueSword.Display();
redBow.Display();
greenAxe.Display();

public class Sword { }
public class Bow { }
public class Axe { }

public class ColoredItem<T>
{
    public T Item { get; set; }
    public ConsoleColor Color { get; set; }

    public ColoredItem(T item, ConsoleColor color)
    {
        Item = item;
        Color = color;
    }

    public void Display()
    {
        Console.ForegroundColor = Color;
        Console.WriteLine(Item?.ToString());
    }
}
