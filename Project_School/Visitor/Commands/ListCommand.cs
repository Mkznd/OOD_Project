using Project_School.Enums;
using Project_School.Interfaces.Visitor;
using Project_School.Lists;
using Project_School.Misc;
using Project_School.Visitor.Visitors;

namespace Project_School.Visitor.Commands;

public class ListCommand : ICommand
{
    private readonly ListVisitor _visitor;
    public Types Type { get; set; }

    public ListCommand(Types type)
    {
        _visitor = new ListVisitor();
        Type = type;
    }
    public void Execute()
    {
        foreach (var e in Utils.GetListFromType(Type))
        {
            e.Accept(_visitor);
        }
    }
}