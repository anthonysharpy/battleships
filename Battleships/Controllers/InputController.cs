namespace Battleships;

internal static class InputController
{
    // The use of generics makes it seem a bit more complicated, but actually I think it's
    // a very convenient way to fetch user input as any desired type, provided a parser method
    // is written for it.
    public static T GetUserInput<T>(string prompt, Func<string, T?> inputParser)
    {
        Console.Write(prompt);
        var input = Console.ReadLine() ?? "";

        var result = inputParser(input);

        // Keep fetching input until the validator function says it's valid (i.e. not null).
        while (result == null)
        {
            Console.Write("Invalid input, please try again: ");
            input = Console.ReadLine() ?? "";
            result = inputParser(input);
        }

        return result;
    }
}
