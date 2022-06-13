
Console.Write("Choose the arrow to buy (elite, beginner, marksman, custom): ");
string? answer = Console.ReadLine();

Arrow userArrow;

if (answer == "custom")
{
    Arrowhead userArrowhead = GetArrowArrowhead();
    Fletching userFletching = GetArrowFletching();
    int userArrowLength = GetArrowLength();
    userArrow = new Arrow(userArrowhead, userFletching, userArrowLength);
}

else
{
    userArrow = answer switch
    {
        "elite" => Arrow.CreateEliteArrow(),
        "beginner" => Arrow.CreateBeginnerArrow(),
        "marksmen" => Arrow.CreateMarksmanArrow()
    };
}

Console.WriteLine($"The total cost of the arrow: {userArrow.Cost}.");

Arrowhead GetArrowArrowhead()
{
    Console.Write("Enter arrowhead type (steel, wood, obsidian): ");
    string? answer = Console.ReadLine();

    return answer switch
    {
        "steel" => Arrowhead.Steel,
        "wood" => Arrowhead.Wood,
        "obsidian" => Arrowhead.Obsidian
    };
}

Fletching GetArrowFletching()
{
    Console.Write("Enter fletching type (plastic, turkey feathers, goose feathers): ");
    string? answer = Console.ReadLine();

    return answer switch
    {
        "plastic" => Fletching.Plastic,
        "turkey feathers" => Fletching.TurkeyFeathers,
        "goose feathers" => Fletching.GooseFeathers
    };
}

int GetArrowLength()
{
    int length;
    do
    {
        Console.Write("Enter length between 60 and 100: ");
        length = Convert.ToInt32(Console.ReadLine());
    }
    while (length < 60 || length > 100);

    return length;
}

public class Arrow
{
    public Arrowhead Arrowhead { get; }
    public Fletching Fletching { get; }
    public int Length { get; }

    public Arrow(Arrowhead arrowhead, Fletching fletching, int length)
    {
        Arrowhead = arrowhead;
        Fletching = fletching;
        Length = length;
    }

    public float Cost
    {
        get
        {
            float cost = 0.0f;

            cost += Length * 0.05f;

            if (Arrowhead == Arrowhead.Steel) cost += 10;
            else if (Arrowhead == Arrowhead.Wood) cost += 3;
            else cost += 5;

            if (Fletching == Fletching.Plastic) cost += 10;
            else if (Fletching == Fletching.TurkeyFeathers) cost += 5;
            else cost += 3;

            return cost;
        }
    }

    public static Arrow CreateEliteArrow() => new Arrow(Arrowhead.Steel, Fletching.Plastic, 95);
    public static Arrow CreateBeginnerArrow() => new Arrow(Arrowhead.Wood, Fletching.GooseFeathers, 75);
    public static Arrow CreateMarksmanArrow() => new Arrow(Arrowhead.Steel, Fletching.GooseFeathers, 65);
}

public enum Arrowhead { Steel, Wood, Obsidian }
public enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }
