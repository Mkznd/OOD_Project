using Project_School.CLI.Visitors;
using Project_School.Enums;
using Project_School.Interfaces.CLI;
using Project_School.Misc;

namespace Project_School.CLI.Commands;

public class EditCommand : ICommand
{
    private EditVisitor _visitor;
    private string _args;
    public string Args
    {
        get => _args;
        set
        {
            _visitor = new EditVisitor(value);
            _args = value;
        }
    }
    public Types _Type { get; set; }


    public EditCommand()
    {
        _visitor = new EditVisitor("");
        _args = string.Empty;
    }

    public EditCommand(Types type, string args)
    {
        Initialize(type, args);
    }

    public void Execute()
    {
        var list = Utils.GetListFromType(_Type).Select(el => Utils.GetRealTypeFromICanBeVisited(el ,_Type))
            .Where(el => ArgumentComplianceChecker
                .IsCompliantToArgs(Utils.GetTokensFromArgsString(_args), el)).ToList();
        if (list.Count == 1)
        {
            ((ICanBeVisited)list[0]).Accept(_visitor);
        }
    }

    public void Initialize(Types type, string args)
    {
        _visitor = new EditVisitor(args);
        _Type = type;
        _args = args;
    }
}