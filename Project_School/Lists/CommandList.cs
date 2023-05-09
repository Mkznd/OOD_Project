using Project_School.CLI.Commands;
using Project_School.Interfaces.CLI;

namespace Project_School.Lists;

public static class CommandList
{
    private static readonly Dictionary<string, ICommand> Commands = new()
    {
        {"list", new ListCommand()},
        {"find", new FindCommand()},
        {"exit", new ExitCommand()}
    };

    public static ICommand GetCommandFromString(string s)
    {
        return Commands[s.ToLower()];
    }
}