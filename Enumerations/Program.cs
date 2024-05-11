string? userInput = "";
var currentChestStatus = Chest.Locked;

do
{
    switch (currentChestStatus)
    {
        case Chest.Locked:
            Console.Write("The chest is locked. What do you want to do? ");
            break;
        case Chest.Closed:
            Console.Write("The chest is unlocked. What do you want to do? ");
            break;
        case Chest.Open:
            Console.Write("The chest is open. What do you want to do? ");
            break;
    }
    userInput = Console.ReadLine();
    
    switch (currentChestStatus)
    {
        case Chest.Locked:
            LockedAction();
            break;
        case Chest.Closed:
            ClosedAction();
            break;
        case Chest.Open:
            OpenAction();
            break;
    }
} while (userInput != "exit");

void LockedAction()
{
    switch (userInput)
    {
        case "unlock":
            currentChestStatus = Chest.Closed;
            break;
        case "open":
            Console.WriteLine("Chest is locked. Try unlocking first.");
            break;
        case "lock":
            break;
        case "close":
            break;
    }
}

void ClosedAction()
{
    switch (userInput)
    {
        case "unlock":
            break;
        case "open":
            currentChestStatus = Chest.Open;
            break;
        case "lock":
            currentChestStatus = Chest.Locked;
            break;
        case "close":
            break;
    }
}

void OpenAction()
{
    switch (userInput)
    {
        case "unlock":
            break;
        case "open":
            break;
        case "lock":
            Console.WriteLine("Chest is open. Try closing first.");
            break;
        case "close":
            currentChestStatus = Chest.Closed;
            break;
    }
}

enum Chest { Open, Closed, Locked }