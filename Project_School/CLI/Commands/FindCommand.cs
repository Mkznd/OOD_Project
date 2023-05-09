using Project_School.CLI.Visitors;
using Project_School.Enums;
using Project_School.Interfaces.CLI;
using Project_School.Misc;

namespace Project_School.CLI.Commands;

public class FindCommand : ICommand
{
    private string _args;
    private FindVisitor _visitor;

    public FindCommand()
    {
        _visitor = new FindVisitor("");
        _args = string.Empty;
    }

    public FindCommand(Types type, string args)
    {
        Initialize(type, args);
    }

    public Types Type { get; set; }

    public string Args
    {
        get => _args;
        set
        {
            _visitor = new FindVisitor(value);
            _args = value;
        }
    }

    public void Initialize(Types type, string args)
    {
        _visitor = new FindVisitor(args);
        Type = type;
        _args = args;
    }

    public void Execute()
    {
        foreach (var e in Utils.GetListFromType(Type)) e.Accept(_visitor);
    }
}