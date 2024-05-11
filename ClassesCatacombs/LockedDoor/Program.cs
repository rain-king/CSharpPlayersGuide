string? userInput;

Console.Write("Enter a password for your door: ");
userInput = Console.ReadLine() ?? "";

Door door = new(userInput);

Console.WriteLine("Your door has been created.");

do
{
    switch (door.Status)
    {
        case DoorStatus.Locked:
            Console.WriteLine("The door is locked, what do you want to do?");
            break;
        case DoorStatus.Open:
            Console.WriteLine("The door is open, what do you want to do?");
            break;
        case DoorStatus.Closed:
            Console.WriteLine("The door is closed, what do you want to do?");
            break;
    }

    userInput = Console.ReadLine()?.ToLower().Trim() ?? "exit";

    if (userInput == "open")
    {
        door.Open();
    }
    else if (userInput == "close")
    {
        door.Close();
    }
    else if (userInput == "unlock")
    {
        Console.Write("Write the door's password: ");
        userInput = Console.ReadLine() ?? "";
        door.Unlock(userInput);
    }
    else if (userInput == "lock")
    {
        door.Lock();
    }
} while (userInput != "exit");

public class Door
{
    private DoorStatus _status;
    public DoorStatus Status {get => _status;}

    private string _password;

    public Door() : this("")
    {
    }
    public Door(string? password)
    {
        _status = DoorStatus.Locked;
        _password = password ?? "";
    }

    public void Unlock(string password)
    {
        if (_password == password)
        {
            Unlock();
        }
        else
        {
            Console.WriteLine("Wrong password.");
        }
    }
    private void Unlock()
    {
        if (_status == DoorStatus.Locked)
        {
            _status = DoorStatus.Closed;   
        }
        else
        {
            Console.WriteLine("Door must be locked to unlock.");
        }
    }

    public void Open()
    {
        if (_status == DoorStatus.Closed || _status == DoorStatus.Open)
        {
            _status = DoorStatus.Open;
        }
        else
        {
            Console.WriteLine("Door must be closed and unlocked to open.");
        }
    }

    public void Close()
    {
        if (_status == DoorStatus.Open || _status == DoorStatus.Closed)
        {
            _status = DoorStatus.Closed;
        }
        else
        {
            Console.WriteLine("Door must be open to close.");
        }
    }

    public void Lock()
    {
        if (_status == DoorStatus.Closed || _status == DoorStatus.Locked)
        {
            _status = DoorStatus.Locked;
        }
        else
        {
            Console.WriteLine("Door must be closed and unlocked to lock.");
        }
    }
}

public enum DoorStatus {Open, Closed, Locked}