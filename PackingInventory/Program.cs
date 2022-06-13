
Pack backpack = new(10, 20, 30);

while (true)
{
    Console.WriteLine(backpack.ToString());
    Console.WriteLine("" +
        "1 - Arrow\n" +
        "2 - Bow\n" +
        "3 - Rope\n" +
        "4 - Water\n" +
        "5 - Food\n" +
        "6 - Sword"
    );
    Console.Write("What item do you want to add to your backpack? ");
    string? input = Console.ReadLine();
    if (input == null) continue;

    bool wasAdded;
    switch (input)
    {
        case "1":
            wasAdded = backpack.Add(new Arrow());
            break;
        case "2":
            wasAdded = backpack.Add(new Bow());
            break;
        case "3":
            wasAdded = backpack.Add(new Rope());
            break;
        case "4":
            wasAdded = backpack.Add(new Water());
            break;
        case "5":
            wasAdded = backpack.Add(new Food());
            break;
        case "6":
            wasAdded = backpack.Add(new Sword());
            break;
        default:
            Console.WriteLine("You selected an invalid input.");
            continue;
    }

    if (!wasAdded)
    {
        Console.WriteLine("Your backpack is full. Good luck on your adventure!");
        break;
    }

    Console.WriteLine("Item was succesfully added.");
}

class Pack
{
    private InventoryItem[] Items { get; }

    private int ItemLimit { get; }
    private float VolumeLimit { get; }
    private float WeightLimit { get; }

    private int CurrentItemCount { get; set; }
    private float CurrentVolume { get; set; }
    private float CurrentWeight { get; set; }

    public Pack(int itemLimit, float volumeLimit, float weightLimit)
    {
        Items = new InventoryItem[itemLimit];

        ItemLimit = itemLimit;
        VolumeLimit = volumeLimit;
        WeightLimit = weightLimit;

        CurrentItemCount = 0;
        CurrentVolume = 0;
        CurrentWeight = 0;
    }

    public bool Add(InventoryItem item)
    {
        if (item.Weight + CurrentWeight > WeightLimit) return false;
        if (item.Volume + CurrentVolume > VolumeLimit) return false;
        if (CurrentItemCount == ItemLimit) return false;

        Items[CurrentItemCount] = item;
        CurrentItemCount++;
        CurrentVolume += item.Volume;
        CurrentWeight += item.Weight;
        return true;
    }

    public override string ToString()
    {
        if (CurrentItemCount == 0) return "Your backpack is empty.";

        string msg = "Pack containing ";

        for (int i = 0; i < CurrentItemCount; i++)
            msg += Items[i].ToString() + " ";


        return msg;
    }
}

class InventoryItem
{
    public float Weight { get; }
    public float Volume { get; }

    public InventoryItem(float weight, float volume)
    {
        Weight = weight;
        Volume = volume;
    }
}

class Arrow : InventoryItem
{
    public Arrow() : base(0.1f, 0.05f) { }

    public override string ToString()
    {
        return "Arrow";
    }
}

class Bow : InventoryItem
{
    public Bow() : base(1f, 4f) { }

    public override string ToString()
    {
        return "Bow";
    }
}

class Rope : InventoryItem
{
    public Rope() : base(1f, 1.5f) { }

    public override string ToString()
    {
        return "Rope";
    }
}

class Water : InventoryItem
{
    public Water() : base(2f, 3f) { }

    public override string ToString()
    {
        return "Water";
    }
}

class Food : InventoryItem
{
    public Food() : base(1f, 0.5f) { }

    public override string ToString()
    {
        return "Food";
    }
}

class Sword : InventoryItem
{
    public Sword() : base(5f, 3f) { }

    public override string ToString()
    {
        return "Sword";
    }
}