
foreach (CardColor color in Enum.GetValues(typeof(CardColor)))
{
    foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
    {
        Card card = new(color, rank);
        Console.WriteLine($"Card: {card.ToString()}");
        Console.WriteLine($"Is a number: {card.IsNumber}");
    }
}

class Card
{
    public CardColor Color { get; }
    public CardRank Rank { get; }
    public bool IsNumber { get; }

    public Card(CardColor color, CardRank rank)
    {
        Color = color;
        Rank = rank;
        IsNumber = rank >= CardRank.One && rank <= CardRank.Ten;
    }

    public string ToString()
    {
        return $"The {Color} {Rank}";
    }
}

enum CardColor { Red, Green, Blue, Yellow }
enum CardRank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Dollar, Percent, Caret, Ampersand }
