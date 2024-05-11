using Packs;

string? userInput;
int capacity = 10;
decimal weightLimit = 10m;
decimal volumeLimit = 10m;

Console.WriteLine("Create a new pack. Specify its item capacity (a positive integer):");
userInput = Console.ReadLine();
try
{
    capacity = Convert.ToInt32(userInput);
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
Console.WriteLine("Specify its weight capacity (a positive decimal):");
userInput = Console.ReadLine();
try
{
    weightLimit = Convert.ToDecimal(userInput);
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
Console.WriteLine("Specify its volume capacity (a positive decimal):");
userInput = Console.ReadLine();
try
{
    volumeLimit = Convert.ToDecimal(userInput);
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

Pack pack = new(capacity, weightLimit, volumeLimit);

do
{
    pack.PrintStatus();
    Console.WriteLine("Want to add an item?");
    Console.WriteLine("1. Arrow");
    Console.WriteLine("2. Bow");
    Console.WriteLine("3. Rope");
    Console.WriteLine("4. Water");
    Console.WriteLine("5. Food ration");
    Console.WriteLine("6. Sword");
    Console.WriteLine("0. Exit program.");
    Console.Write("Enter a number: ");
    userInput = Console.ReadLine()?.Trim() ?? "0";

    switch (userInput)
    {
        case "0":
            // pack.Print();
            break;
        case "1":
            pack.Add(new Arrow());
            break;
        case "2":
            pack.Add(new Bow());
            break;
        case "3":
            pack.Add(new Rope());
            break;
        case "4":
            pack.Add(new Water());
            break;
        case "5":
            pack.Add(new FoodRation());
            break;
        case "6":
            pack.Add(new Sword());
            break;
    }
} while (userInput != "0");
