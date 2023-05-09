using Project_School.CLI.Visitors;
using Project_School.Enums;
using Project_School.Interfaces.CLI;
using Project_School.Misc;

namespace Project_School.CLI.Commands;

public class ListCommand : ICommand
{
    private ListVisitor _visitor;

    public ListCommand()
    {
        _visitor = new ListVisitor();
    }

    public ListCommand(Types type)
    {
        Initialize(type, string.Empty);
    }

    public Types Type { get; set; }

    public void Initialize(Types type, string args)
    {
        _visitor = new ListVisitor();
        Type = type;
    }

    public void Execute()
    {
        foreach (var e in Utils.GetListFromType(Type)) e.Accept(_visitor);
    }
}