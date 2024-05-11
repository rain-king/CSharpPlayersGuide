int cavernSize = PromptGameSize();
Game game = new(cavernSize);
game.Start();

int PromptGameSize()
{
    Console.Write("Would you like to play a small, medium or large game? ");
    string readInput = Console.ReadLine()?.Trim().ToLower() ?? "small";

    switch (readInput)
    {
        case "small":
            return 4;
        case "medium":
            return 6;
        case "large":
            return 8;
        default:
            return 4;
    }
}

public class Game
{
    public int CavernSize { get; init; }
    private Room[,] _cavern;
    private int _currentRow;
    private int _currentColumn;
    private bool _gameWin = false;
    private bool _gameLose = false;
    private bool _fountainIsActive = false;
    private string _readAction = "nothing";
    private Random _random = new(0);
    private ConsoleColor _baseColor = Console.ForegroundColor;
    public Game(int cavernSize)
    {
        CavernSize = cavernSize;
        _cavern = new Room[CavernSize, CavernSize];
    }
    public void Start()
    {
        InitializeCavern();
        
        do
        {
            PrintLine();
            PrintRoom();
            Sense();
            Prompt();
            Action();
            Effects();
        } while (!(_gameWin || _gameLose));
        
        if (_gameWin && !_gameLose)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You won!");
            Console.ForegroundColor = _baseColor;
        }
        else if (_gameLose)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You lost!");
            Console.ForegroundColor = _baseColor;
        }
    }

    private void InitializeCavern()
    {
        int[] entrance = GetRandomEntrance();

        _currentRow = entrance[0]; _currentColumn = entrance[1];
        // random location NOT at entrance
        int[] fountain = {
            (entrance[0] + _random.Next(1,CavernSize)) % CavernSize,
            (entrance[1] + _random.Next(1,CavernSize)) % CavernSize
        };

        for (int row = 0; row < CavernSize; row++)
        {
            for (int column = 0; column < CavernSize; column++)
            {
                if (row == entrance[0] && column == entrance[1])
                    _cavern[row, column] = new Room(RoomType.Entrance);
                else if (row == fountain[0] && column == fountain[1])
                    _cavern[row, column] = new Room(RoomType.Fountain);
                else
                    _cavern[row, column] = new Room(RoomType.Empty);
            }
        }

        int pits = CavernSize switch
        {
            4 => 1,
            6 => 2,
            8 => 4,
            _ => (int)Math.Sqrt(CavernSize)
        };
        for (int i = pits; i >= 1; i--)
        {
            ModifyRandomEmptyRoom(RoomType.Pit);
        }

        int maelstroms = CavernSize switch
        {
            4 => 1,
            6 => 1,
            8 => 2,
            _ => (int)Math.Round(Math.Sqrt(Math.Sqrt(CavernSize)))
        };
        for (int i = maelstroms; i >= 1; i--)
        {
            // anywhere but entrance
            int randomRow = (entrance[0] + _random.Next(1, CavernSize)) % CavernSize;
            int randomColumn = (entrance[1] + _random.Next(1, CavernSize)) % CavernSize;
            _cavern[randomRow, randomColumn].Types.Add(RoomType.Maelstrom);
        }
    }
    private void ModifyRandomEmptyRoom(RoomType type)
    {
        int randomRow; int randomColumn;
        // find empty room to add pit
        do
        {
            randomRow = _random.Next(CavernSize); randomColumn = _random.Next(CavernSize);
        } while (!_cavern[randomRow, randomColumn].Types.Contains(RoomType.Empty));
        _cavern[randomRow, randomColumn].Types.Remove(RoomType.Empty);
        _cavern[randomRow, randomColumn].Types.Add(type);
    }
    // gets a row and column on the edge of the cavern
    private int[] GetRandomEntrance()
    {
        switch (_random.Next(4))
        {
            case 0:
                return [0, _random.Next(CavernSize)];
            case 1:
                return [CavernSize - 1, _random.Next(CavernSize)];
            case 2:
                return [_random.Next(CavernSize), 0];
            case 3:
                return [_random.Next(CavernSize), CavernSize-1];
            default:
                return [0, _random.Next(CavernSize)];
        }
    }
    private void PrintLine()
    {
        for (int i = 0; i < Console.WindowWidth; i++)
            Console.Write("=");
    }
    private void PrintRoom()
    {
        Console.WriteLine($"You're in the room at (Row={_currentRow}, Column={_currentColumn}).");
    }
    private void Sense()
    {
        if (_cavern[_currentRow, _currentColumn].Types.Contains(RoomType.Entrance))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You see light in this room coming from outside the cavern. This is the entrance.");
            Console.ForegroundColor = _baseColor;
        }
        if (_cavern[_currentRow, _currentColumn].Types.Contains(RoomType.Fountain))
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            if (!_fountainIsActive)
                Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
            else
                Console.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
            Console.ForegroundColor = _baseColor;
        }
        if (NeighborHas(RoomType.Pit))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You feel a draft. There is a pit in a nearby room.");
            Console.ForegroundColor = _baseColor;
        }
        if (NeighborHas(RoomType.Maelstrom))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You hear the growling and groaning of a maelstrom nearby.");
            Console.ForegroundColor = _baseColor;
        }
    }
    private bool NeighborHas(RoomType type)
    {
        bool neighborHas = _cavern[NorthRow(), WestColumn()].Types.Contains(type);
        neighborHas |= _cavern[NorthRow(), _currentColumn].Types.Contains(type);
        neighborHas |= _cavern[NorthRow(), EastColumn()].Types.Contains(type);
        neighborHas |= _cavern[_currentRow, WestColumn()].Types.Contains(type);
        neighborHas |= _cavern[_currentRow, EastColumn()].Types.Contains(type);
        neighborHas |= _cavern[SouthRow(), WestColumn()].Types.Contains(type);
        neighborHas |= _cavern[SouthRow(), _currentColumn].Types.Contains(type);
        neighborHas |= _cavern[SouthRow(), EastColumn()].Types.Contains(type);
        return neighborHas;
    }
    private void Prompt()
    {
        Console.Write("What do you want to do? ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        _readAction = Console.ReadLine()?.Trim().ToLower() ?? "nothing";
        Console.ForegroundColor = _baseColor;
    }
    private void Action()
    {
        switch (_readAction)
        {
            case "move north":
                _currentRow = NorthRow();
                break;
            case "move south":
                _currentRow = SouthRow();
                break;
            case "move east":
                _currentColumn = EastColumn();
                break;
            case "move west":
                _currentColumn = WestColumn();
                break;
            case "enable fountain":
                _fountainIsActive = true;
                break;
            default:
                break;
        }
    }
    private int NorthRow() => _currentRow == 0 ? 0 : _currentRow - 1;
    private int SouthRow() => _currentRow == CavernSize - 1 ? CavernSize - 1 : _currentRow + 1;
    private int EastColumn() => _currentColumn == CavernSize - 1 ? CavernSize - 1 : _currentColumn + 1;
    private int WestColumn() => _currentColumn == 0 ? 0 : _currentColumn - 1;
    
    private void Effects()
    {
        // maelstrom effect
        if (_cavern[_currentRow, _currentColumn].Types.Contains(RoomType.Maelstrom))
        {
            MoveMaelstrom();
            MaelstromMovesPlayer();
        }
        // win condition
        if (_fountainIsActive && _cavern[_currentRow, _currentColumn].Types.Contains(RoomType.Entrance))
            _gameWin = true;
        // finish turn at pit effect
        if (_cavern[_currentRow, _currentColumn].Types.Contains(RoomType.Pit))
        {
            _gameLose = true;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You fell in a pit.");
            Console.ForegroundColor = _baseColor;
        }
    }

    private void MoveMaelstrom()
    {
        _cavern[_currentRow, _currentColumn].Types.Remove(RoomType.Maelstrom);
        int newMaelstromRow = Mod(_currentRow + 1, CavernSize);
        int newMaelstromColumn = Mod(_currentColumn - 2, CavernSize);
        _cavern[newMaelstromRow, newMaelstromColumn].Types.Add(RoomType.Maelstrom);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("The maelstrom has moved.");
        Console.ForegroundColor = _baseColor;
    }
    private void MaelstromMovesPlayer()
    {
        _currentRow = Mod(_currentRow - 1, CavernSize);
        _currentColumn = Mod(_currentColumn + 2, CavernSize);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("You've been moved by the maelstrom.");
        Console.ForegroundColor = _baseColor;
    }

    private int Mod(int x, int y) => (x%y + y)%y;
    private class Room(RoomType type)
    {
        public List<RoomType> Types {get; set;} = [type];
    }
    private enum RoomType {Entrance, Empty, Fountain, Pit, Maelstrom}
}

