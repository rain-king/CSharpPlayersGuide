﻿Console.WriteLine("Write three commands for the robot");
string? command1 = Console.ReadLine();
string? command2 = Console.ReadLine();
string? command3 = Console.ReadLine();

string?[] strings = [command1, command2, command3];

Robot robot = new()
{
    Commands = StringsToRobotCommands(strings)
};
robot.Run();

IRobotCommand?[] StringsToRobotCommands(string?[] strings)
{
    var commands = new IRobotCommand?[strings.Length];
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
    public IRobotCommand?[] Commands { get; set; } = new IRobotCommand?[3];
    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public interface IRobotCommand
{
    void Run(Robot robot);    
}
public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}
public class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}
public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.Y++;
    }
}
public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.Y--;
    }
}
public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.X++;
    }
}
public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.X--;
    }
}