using Project_School.Enums;
using Project_School.Interfaces.CLI;
using Project_School.Lists;

namespace Project_School.CLI;

public class CommandQueue
{
    private Queue<ICommand> _commands;
    private const string QueueString = "queue";
    private const string PrintString = "print";
    private const string CommitString = "commit";
    private const string ExportString = "export";
    private const string DismissString = "dismiss";
    public CommandQueue()
    {
        _commands = new Queue<ICommand>();
    }
    
    public CommandQueue(IEnumerable<ICommand> commands)
    {
        _commands = new Queue<ICommand>(commands);
    }

    public void Add(string? inputString)
    {
        if (inputString == null) return;

        var input = inputString.Split(' ', 3, StringSplitOptions.TrimEntries);
        if (QueueString.Equals(input[0], StringComparison.InvariantCultureIgnoreCase))
        {
            ExecuteQueueCommand(input);
            return;
        }
        var command = CommandList.GetCommandFromString(input[0]);
        bool tryParse;
        Types type;
        if (input.Length < 2)
        {
            tryParse = true;
            type = Types.Default;
        }
        else
        {
            tryParse = Enum.TryParse(input[1], true, out type);
        }

        if (!tryParse) return;
        var argsString = input.Length > 2 ? input[2] : string.Empty;
        command.Initialize(type, argsString);
        _commands.Enqueue(command);
    }

    void ExecuteQueueCommand(string[] input)
    {
        if (input.Length < 2) return;
        var subcommand = input[1];
        if (subcommand.Equals(PrintString, StringComparison.InvariantCultureIgnoreCase))
        {
            Print();
        }
        else if(subcommand.Equals(CommitString, StringComparison.InvariantCultureIgnoreCase))
        {
            Commit();
        }
        else if(subcommand.Equals(ExportString, StringComparison.InvariantCultureIgnoreCase))
        {
            Export();
        }
        else if(subcommand.Equals(DismissString, StringComparison.InvariantCultureIgnoreCase))
        {
            Dismiss();
        }
    }

    private void Print()
    {
        foreach (var command in _commands)
        {
            Console.WriteLine(command);
        }
    }

    private void Commit()
    {
        foreach (var command in _commands)
        {
            command.Execute();
        }
    }

    private void Export()
    {
        /*
         * export
         */
    }
    
    public void Dismiss()
    {
        _commands.Clear();
    }
}