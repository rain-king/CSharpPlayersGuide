Coordinate coordinate1 = new(0,0);
Coordinate coordinate2 = new(0,1);
Coordinate coordinate3 = new(2,1);

Console.WriteLine($"Is {coordinate1} is adjacent to {coordinate2}? {coordinate1.IsAdjacent(coordinate2)}");
Console.WriteLine($"Is {coordinate2} is adjacent to {coordinate3}? {coordinate2.IsAdjacent(coordinate3)}");
Console.WriteLine($"Is {coordinate3} is adjacent to {coordinate1}? {coordinate3.IsAdjacent(coordinate1)}");

// coordinate1.Row = 3;
public struct Coordinate
{
    public int Row {get; init;}
    public int Column {get; init;}
    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public override string ToString()
    {
        return "Coordinate (" + Row.ToString() + ", " + Column.ToString() + ")";
    }

    public bool IsAdjacent(Coordinate coordinate)
        => (Math.Abs(Row - coordinate.Row) + Math.Abs(Column - coordinate.Column)) == 1;
}