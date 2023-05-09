using System.Collections;
using System.Reflection;
using Project_School.BaseRepresentation;
using Project_School.Enums;
using Project_School.FirstRepresentation;
using Project_School.FirstRepresentation.Adapters;
using Project_School.Interfaces.CLI;
using Project_School.Interfaces.Common;
using Project_School.Lists;
using Project_School.Misc;

namespace Project_School.CLI.Visitors;



public class AddVisitor : IVisitor
{
    private readonly Representation _representation;
    public AddVisitor()
    {
    }
    public AddVisitor(Representation rep)
    {
        _representation = rep;
    }

    private bool IsValueType(PropertyInfo p)
    {
        return !typeof(IEnumerable).IsAssignableFrom(p.PropertyType)
               || p.PropertyType == typeof(string);
    }
    public void VisitClass(IClass element)
    {
        OutputAvailableFields(typeof(Class));
        var inputObjects = GetInputs(element, out var input);

        if (input == "done")
        {
            IClass @class;
            if (_representation == Representation.Base)
            {
                @class = new Class();
                foreach (var kvp in inputObjects)
                {
                    var prop = @class.GetType().GetProperty(kvp.Key);
                    prop?.SetValue(@class,
                        prop.PropertyType == typeof(uint) ? uint.Parse(kvp.Value.ToString()) : kvp.Value);
                }
            }
            else
            {
                var classString = new ClassString();
                foreach (var kvp in inputObjects)
                {
                    classString.GetType().GetProperty(kvp.Key)?.SetValue(classString, kvp.Value);
                }
                @class = new ClassStringAdapter(classString);
            }
            
            ClassList.AddToList(@class);
            
        }
        else
        {
            Environment.Exit(0);
        }
    }
    private Dictionary<string, object> GetInputs(IClass element, out string input)
    {
        var availableProps = typeof(Class).GetProperties().Where(IsValueType).Select(p => p.Name);
        var inputObjects = new Dictionary<string, object>();
        foreach (var e in availableProps)
        {
            inputObjects[e] = new object();
        }

        input = Console.ReadLine();
        while (!input.Equals("done", StringComparison.InvariantCultureIgnoreCase)
               && !input.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
        {
            var argsQueue = Utils.BreakArgumentIntoQueue(input);
            Utils.DecomposeArgument(element, argsQueue,
                out var operand, out var @operator, out var strVal);
            inputObjects[operand.Name] = strVal;
            input = Console.ReadLine();
        }

        return inputObjects;
    }

    public void VisitRoom(IRoom element)
    {
        OutputAvailableFields(typeof(Room));

    }
    public void VisitStudent(IStudent element)
    {
        OutputAvailableFields(typeof(Student));
    }

    public void VisitTeacher(ITeacher element)
    {
        OutputAvailableFields(typeof(Teacher));
    }
    
    private void OutputAvailableFields(Type type)
    {
        var props = type.GetProperties().Where(IsValueType).Select(p => p.Name);
        Console.WriteLine($"Available fields: [{string.Join(',', props)}]");
    }
}