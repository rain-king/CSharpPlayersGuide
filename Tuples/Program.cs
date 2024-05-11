string? userInput = "";

Console.WriteLine("Choose a food type by writing a number:");
Console.WriteLine("1. Soup");
Console.WriteLine("2. Stew");
Console.WriteLine("3. Gumbo");
userInput = Console.ReadLine();

Type type = Type.Soup;
MainIngredient mainIngredient = MainIngredient.Mushrooms;
Seasoning seasoning = Seasoning.Spicy;

if (userInput != null)
    switch (userInput.Trim())
    {
        case "1":
            type = Type.Soup;
            break;
        case "2":
            type = Type.Stew;
            break;
        case "3":
            type = Type.Gumbo;
            break;
    }

Console.WriteLine("Choose a main ingredient by writing a number:");
Console.WriteLine("1. Mushrooms");
Console.WriteLine("2. Chicken");
Console.WriteLine("3. Carrots");
Console.WriteLine("4. Potatoes");
userInput = Console.ReadLine();

if (userInput != null)
    switch (userInput.Trim())
    {
        case "1":
            mainIngredient = MainIngredient.Mushrooms;
            break;
        case "2":
            mainIngredient = MainIngredient.Chicken;
            break;
        case "3":
            mainIngredient = MainIngredient.Carrots;
            break;
        case "4":
            mainIngredient = MainIngredient.Potatoes;
            break;
    }

Console.WriteLine("Choose a food seasoning by writing a number:");
Console.WriteLine("1. Spicy");
Console.WriteLine("2. Salty");
Console.WriteLine("3. Sweet");
userInput = Console.ReadLine();

if (userInput != null)
    switch (userInput.Trim())
    {
        case "1":
            seasoning = Seasoning.Spicy;
            break;
        case "2":
            seasoning = Seasoning.Salty;
            break;
        case "3":
            seasoning = Seasoning.Sweet;
            break;
    }

(Type type, MainIngredient mainIngredient, Seasoning seasoning) food = (type, mainIngredient, seasoning);

Console.WriteLine($"{food.seasoning} {food.mainIngredient} {food.type}");

enum Type {Soup, Stew, Gumbo}
enum MainIngredient {Mushrooms, Chicken, Carrots, Potatoes}
enum Seasoning {Spicy, Salty, Sweet}