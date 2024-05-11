Color yellow = Color.Yellow();
Color electricPurple = new(165, 0, 255);

Console.WriteLine($"Yellow is R: {yellow.R}, G: {yellow.G}, B: {yellow.B}");
Console.WriteLine($"Electric purple is R: {electricPurple.R}, G: {electricPurple.G}, B: {electricPurple.B}");

public class Color
{
    public byte R {get; set;}
    public byte G {get; set;}
    public byte B {get; set;}

    public static Color White() => new(255, 255, 255);
    public static Color Black() => new(0, 0, 0);
    public static Color Red() => new(255, 0, 0);
    public static Color Green() => new(0, 128, 0);
    public static Color Blue() => new(0, 0, 255);
    public static Color Orange() => new(255, 165, 0);
    public static Color Yellow() => new(255, 255, 0);
    public static Color Purple() => new(128, 0, 128);

    public Color(byte red, byte green, byte blue)
    {
        R = red;
        G = green;
        B = blue;
    }

}