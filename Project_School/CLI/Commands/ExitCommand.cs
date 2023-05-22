using Project_School.Enums;
using Project_School.Interfaces.CLI;

namespace Project_School.CLI.Commands;

public class ExitCommand : ICommand
{
    public void Execute()
    {
        Environment.Exit(0);
    }

    public void Initialize(Types type, string args)
    {
        Execute();
    }
}