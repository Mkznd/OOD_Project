using System.Collections;
using System.Reflection;
using Project_School.Enums;

namespace Project_School.Misc;

public static class InputCommandsFunctions
{
    private const string Done = "done";
    private const string Exit = "exit";
    public static bool IsValueType(PropertyInfo p)
    {
        return !typeof(IEnumerable).IsAssignableFrom(p.PropertyType)
               || p.PropertyType == typeof(string);
    }

    public static Dictionary<string, object> GetInputs( Type type, out string input, object? element = null)
    {
        var availableProps = type.GetProperties().Where(IsValueType);
        var inputObjects = new Dictionary<string, object>();
        foreach (var e in availableProps)
        {
            if (element != null)
                inputObjects[e.Name] = e.GetValue(element) ?? new object();
            else
            {
                inputObjects[e.Name] =  new object();
            }
        }

        input = Console.ReadLine();
        while (!input.Equals(Done, StringComparison.InvariantCultureIgnoreCase)
               && !input.Equals(Exit, StringComparison.InvariantCultureIgnoreCase))
        {
            var argsQueue = Utils.BreakArgumentIntoQueue(input);
            Utils.DecomposeArgument(type, argsQueue,
                out var operand, out var @operator, out var strVal);
            inputObjects[operand.Name] = strVal;
            input = Console.ReadLine();
        }

        return inputObjects;
    }
    public static void FillObjectWithInputs(Dictionary<string, object> inputObjects, object obj, Type type)
    {
        foreach (var kvp in inputObjects)
        {
            var prop = obj.GetType().GetProperty(kvp.Key);
            if (prop is null)
            {
                throw new ArgumentException("Wrong parameter detected!");
            }

            if (type.IsEnum && prop.PropertyType == type)
            {
                if (Enum.TryParse(kvp.Value.ToString(), ignoreCase: true, out TeacherRank result))
                {
                    prop.SetValue(obj, result);
                }
            }
            else
            {
                if (prop.PropertyType == typeof(uint))
                {
                    var parse = uint.TryParse(kvp.Value.ToString() ?? "0", out var result);
                    prop.SetValue(obj, !parse ? 0 : result);
                }
                else if(prop.PropertyType == typeof(int))
                {
                    var parse = int.TryParse(kvp.Value.ToString() ?? "0", out var result);
                    prop.SetValue(obj, !parse ? 0 : result);
                }
                else if(prop.PropertyType == typeof(string))
                {
                    if(string.IsNullOrEmpty( kvp.Value.ToString())) prop.SetValue(obj, "");
                    prop.SetValue(obj, kvp.Value.ToString());
                }
                else
                {
                    prop.SetValue(obj, Convert.ChangeType(kvp.Value, prop.PropertyType));
                }
            }
            
        }
    }
}