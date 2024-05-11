Arrow defaultArrow = new();
Arrow eliteArrow = Arrow.CreateEliteArrow();
Arrow beginnerArrow = Arrow.CreateBeginnerArrow();
Arrow marksmanArrow = Arrow.CreateMarksmanArrow();

Console.WriteLine($"The default arrow with {defaultArrow.ArrowHead} arrowhead, {defaultArrow.Shaft:N0}cm shaft, and {defaultArrow.Fletching} fletching, costs {defaultArrow.GetCost():N2} gold.");
Console.WriteLine($"The Elite arrow with {eliteArrow.ArrowHead} arrowhead, {eliteArrow.Shaft:N0}cm shaft, and {eliteArrow.Fletching} fletching, costs {eliteArrow.GetCost():N2} gold.");
Console.WriteLine($"The Beginner arrow with {beginnerArrow.ArrowHead} arrowhead, {beginnerArrow.Shaft:N0}cm shaft, and {beginnerArrow.Fletching} fletching, costs {beginnerArrow.GetCost():N2} gold.");
Console.WriteLine($"The Marksman arrow with {marksmanArrow.ArrowHead} arrowhead, {marksmanArrow.Shaft:N0}cm shaft, and {marksmanArrow.Fletching} fletching, costs {marksmanArrow.GetCost():N2} gold.");

class Arrow
{
    public ArrowHeadType ArrowHead { get; init; }
    public int Shaft { get; init; }
    public FletchingType Fletching { get; init; }

    public Arrow() : this(ArrowHeadType.Steel, 60, FletchingType.TurkeyFeathers)
    {
    }

    public Arrow(ArrowHeadType arrowHead, int shaft, FletchingType fletching)
    {
        ArrowHead = arrowHead;
        
        if (shaft >= 60 && shaft <= 100)
            Shaft = shaft;
        else
            throw new ArgumentOutOfRangeException("Shaft should be between 60 and 100 cm.");
        
        Fletching = fletching;
    }

    public static Arrow CreateEliteArrow() =>
        new(ArrowHeadType.Steel, 95, FletchingType.Plastic);
    
    public static Arrow CreateBeginnerArrow() =>
        new(ArrowHeadType.Wood, 75, FletchingType.GooseFeathers);

    public static Arrow CreateMarksmanArrow() =>
        new(ArrowHeadType.Steel, 65, FletchingType.GooseFeathers);
    
    public decimal GetCost()
    {
        decimal total = 0;
        
        if (ArrowHead == ArrowHeadType.Steel)
            total += 10;
        else if (ArrowHead == ArrowHeadType.Wood)
            total += 3;
        else if (ArrowHead == ArrowHeadType.Obsidian)
            total += 5;

        if (Fletching == FletchingType.Plastic)
            total += 10;
        else if (Fletching == FletchingType.TurkeyFeathers)
            total += 5;
        else if (Fletching == FletchingType.GooseFeathers)
            total += 3;

        total += (decimal) 0.05*Shaft;

        return total;
    }
}

enum ArrowHeadType {Steel, Wood, Obsidian}
enum FletchingType {Plastic, TurkeyFeathers, GooseFeathers}