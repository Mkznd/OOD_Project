using Project_School.CLI.Commands;
using Project_School.Interfaces.Visitor;

namespace Project_School.Lists;

public static class CommandList
{
    private static readonly Dictionary<string, ICommand> Commands = new()
    {
        {"list", new ListCommand()},
        {"find", new FindCommand()}
    };
    
    public static ICommand GetCommandFromString(string s)
    {
        return Commands[s.ToLower()];
    }
}