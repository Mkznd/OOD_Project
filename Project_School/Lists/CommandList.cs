using Project_School.CLI.Commands;
using Project_School.Interfaces.CLI;

namespace Project_School.Lists;

public static class CommandList
{
    private static readonly Dictionary<string, ICommand> Commands = new()
    {
        {"list", new ListCommand()},
        {"find", new FindCommand()},
        {"exit", new ExitCommand()},
        {"add", new AddCommand()},
        {"edit", new EditCommand()}
    };

    public static ICommand GetCommandFromString(string s)
    {
        return Commands[s.ToLower()];
    }
}