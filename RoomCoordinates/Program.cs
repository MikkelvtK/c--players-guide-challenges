
Coordinate c1 = new(1, 2);
Coordinate c2 = new(2, 2);
Coordinate c3 = new(4, 7);

bool isNeighbour1 = IsNeighbour(c1, c2);
bool isNeighbour2 = IsNeighbour(c1, c3);

Console.WriteLine(isNeighbour1);
Console.WriteLine(isNeighbour2);

bool IsNeighbour(Coordinate coordinate1, Coordinate coordinate2)
{
    int rowDifference = Math.Abs(coordinate1.Row - coordinate2.Row);
    int colDifference = Math.Abs(coordinate1.Column - coordinate2.Column);

    if (rowDifference == 1 && colDifference == 0)
        return true;

    if (colDifference == 1 && rowDifference == 0)
        return true;

    return false;
}

struct Coordinate
{
    public int Row { get; }
    public int Column { get; }

    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }
}
