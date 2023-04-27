using Project_School.CLI.Visitors;
using Project_School.Enums;
using Project_School.Interfaces.Visitor;
using Project_School.Misc;

namespace Project_School.CLI.Commands;

public class FindCommand : ICommand
{
    private FindVisitor _visitor;
    public Types Type { get; set; }
    private string _args;

    public string Args
    {
        get => _args;
        set { 
            _visitor = new FindVisitor(value);
            _args = value;
        }
    }
    public FindCommand()
    {
        _visitor = new FindVisitor("");
        _args = string.Empty;
    }
    public FindCommand(Types type, string args)
    {
        Initialize(type, args);
    }
    public void Initialize(Types type, string args)
    {
        _visitor = new FindVisitor(args);
        Type = type;
        _args = args;
    }
    public void Execute()
    {
        foreach (var e in Utils.GetListFromType(Type))
        {
            e.Accept(_visitor);
        }
    }
}