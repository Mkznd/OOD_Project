using Project_School.CLI.Visitors;
using Project_School.Enums;
using Project_School.Interfaces.CLI;
using Project_School.Misc;

namespace Project_School.CLI.Commands;

public class EditCommand : ICommand
{
    private EditVisitor _visitor;
    private List<dynamic> _list;
    private string _args;
    public Types _Type { get; set; }


    public EditCommand()
    {
        _visitor = new EditVisitor();
        _args = string.Empty;
    }

    public EditCommand(Types type, string args)
    {
        Initialize(type, args);
    }

    public void Execute()
    {
        
        if (_list.Count == 1)
        {
            ((ICanBeVisited)_list[0]).Accept(_visitor);
        }
    }

    public void Initialize(Types type, string args)
    {
        _Type = type;
        _args = args;
        var list = Utils.GetListFromType(_Type).Select(el => Utils.GetRealTypeFromICanBeVisited(el ,_Type))
            .Where(el => ArgumentComplianceChecker
                .IsCompliantToArgs(Utils.GetTokensFromArgsString(_args), el)).ToList();
        _list = new List<dynamic>(list);

        if (_list.Count != 1) return;
        Utils.OutputAvailableFields(Utils.GetRealTypeFromEnum(type));
        var inputObjects
            = InputCommandsFunctions.GetInputs(Utils.GetRealTypeFromEnum(type), out string input, list[0]);
        Console.WriteLine("Input finished!");
        _visitor = new EditVisitor(args, inputObjects, input);
    }
}