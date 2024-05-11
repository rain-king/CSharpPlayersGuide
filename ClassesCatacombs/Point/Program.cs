Point point1 = new(2, 3);
Point point2 = new(-4, 0);

Console.WriteLine($"({point1.X}, {point1.Y})");
Console.WriteLine($"({point2.X}, {point2.Y})");

public class Point
{
    public double X {get; set;}
    public double Y {get; set;}

    public Point() : this(0, 0)
    {
    }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }
}