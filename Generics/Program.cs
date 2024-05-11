ColoredItem<Sword> blueSword = new(new Sword(), ConsoleColor.Blue);
ColoredItem<Bow> redBow = new(new Bow(), ConsoleColor.Red);
ColoredItem<Axe> greenAxe = new(new Axe(), ConsoleColor.Green);

blueSword.Display();
redBow.Display();
greenAxe.Display();
// Console.WriteLine("Hello world!"); green if color not set properly in generic

public class ColoredItem<T> where T : class
{
    ConsoleColor Color;
    T Item;
    public ColoredItem(T item, ConsoleColor color)
    {
        Item = item;
        Color = color;
    }
    public void Display()
    {
        ConsoleColor defaultColor = Console.ForegroundColor;
        Console.ForegroundColor = Color;
        Console.WriteLine(Item.ToString());
        Console.ForegroundColor = defaultColor;
    }
}
public class Sword { }
public class Bow { }
public class Axe { }