Console.WriteLine("Write three commands for the robot");
string? command1 = Console.ReadLine();
string? command2 = Console.ReadLine();
string? command3 = Console.ReadLine();

string?[] strings = [command1, command2, command3];

Robot robot = new()
{
    Commands = StringsToRobotCommands(strings)
};
robot.Run();

RobotCommand?[] StringsToRobotCommands(string?[] strings)
{
    var commands = new RobotCommand?[strings.Length];
    for (int i = 0; i < commands.Length; i++)
    {
        switch (strings[i]?.Trim().ToLower())
        {
            case "on":
                commands[i] = new OnCommand();
                break;
            case "off":
                commands[i] = new OffCommand();
                break;
            case "north":
                commands[i] = new NorthCommand();
                break;
            case "south":
                commands[i] = new SouthCommand();
                break;
            case "east":
                commands[i] = new EastCommand();
                break;
            case "west":
                commands[i] = new WestCommand();
                break;
        }
    }
    return commands;
}

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public RobotCommand?[] Commands { get; set; } = new RobotCommand?[3];
    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public abstract class RobotCommand
{
    public abstract void Run(Robot robot);    
}
public class OnCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}
public class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}
public class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.Y++;
    }
}
public class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.Y--;
    }
}
public class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.X++;
    }
}
public class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.X--;
    }
}