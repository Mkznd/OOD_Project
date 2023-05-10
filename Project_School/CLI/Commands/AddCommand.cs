using Project_School.CLI.Visitors;
using Project_School.Enums;
using Project_School.Interfaces.CLI;
using Project_School.Misc;

namespace Project_School.CLI.Commands;

public class AddCommand : ICommand
{
    private AddVisitor _visitor;
    private Representation _representation;
    public Types _Type { get; set; }

    public AddCommand()
    {
        _representation = Representation.Default;
        _visitor = new AddVisitor();
    }

    public AddCommand(Types type, string representation)
    {
        Initialize(type, representation);
    }

    public void Execute()
    {
        var e = Utils.GetListFromType(_Type).FirstOrDefault();
        e?.Accept(_visitor);
    }

    public void Initialize(Types type, string args)
    {
        _Type = type;
        var res = Enum.TryParse(args, true, out _representation);
        if (!res || _representation == Representation.Default) throw new ArgumentException("Invalid representation!");
        _visitor = new AddVisitor(_representation);
    }
}