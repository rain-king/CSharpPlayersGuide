string? userInput;

do
{
    Console.WriteLine("Enter a password:");
    userInput = Console.ReadLine();

    if (userInput != null)
        if (PasswordValidator.IsValid(userInput))
            Console.WriteLine("Password is valid.");
        else
            Console.WriteLine("Password is invalid.");
} while (userInput != null);

public static class PasswordValidator
{
    public static bool IsValid(string password)
    {
        bool valid;
        valid = Has6Characters(password);
        valid &= HasNoMoreThan13Characters(password);
        valid &= HasUpper(password);
        valid &= HasLower(password);
        valid &= HasDigit(password);
        return valid;
    }

    private static bool Has6Characters(string password)
    {
        bool has6Characters = password.Length >= 6;
        if (!has6Characters)
            Console.WriteLine("Password should be at least 6 characters long.");
        return has6Characters;
    }
    private static bool HasNoMoreThan13Characters(string password)
    {
        bool hasNoMoreThan13Chars = password.Length <= 13;
        if (!hasNoMoreThan13Chars)
            Console.WriteLine("Password should be at most 13 characters long.");
        return hasNoMoreThan13Chars;
    }
    private static bool HasUpper(string password)
    {
        bool hasUpper = false;
        foreach (char character in password)
        {
            hasUpper |= char.IsUpper(character);
        }
        if (!hasUpper)
            Console.WriteLine("Password lacks uppercase characters.");
        return hasUpper;
    }
    private static bool HasLower(string password)
    {
        bool hasLower = false;
        foreach (char character in password)
        {
            hasLower |= char.IsLower(character);
        }
        if (!hasLower)
            Console.WriteLine("Password lacks lowercase characters.");
        return hasLower;
    }
    private static bool HasDigit(string password)
    {
        bool hasDigit = false;
        foreach (char character in password)
        {
            hasDigit |= char.IsDigit(character);
        }
        if (!hasDigit)
            Console.WriteLine("Password lacks digit characters.");
        return hasDigit;
    }
}