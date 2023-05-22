using Project_School.Enums;
using Project_School.Interfaces.CLI;

namespace Project_School.CLI.Commands;

public class QueueCommand : ICommand
{
    private CommandQueue _commandQueue;

    public QueueCommand(CommandQueue commandQueue)
    {
        _commandQueue = commandQueue;
    }

    public void Initialize(Types type, string args)
    {
        
    }
    public void Execute()
    {
        throw new NotImplementedException();
    }
}