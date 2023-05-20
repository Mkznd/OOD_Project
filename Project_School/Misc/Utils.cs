using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;
using Project_School.BaseRepresentation;
using Project_School.Enums;
using Project_School.Interfaces.CLI;
using Project_School.Interfaces.Common;
using Project_School.Lists;

namespace Project_School.Misc;

public static class Utils
{
    public static List<ICanBeVisited> GetListFromType(Types type)
    {
        return type switch
        {
            Types.Class => new List<ICanBeVisited>(ClassList.Classes.Values.ToList()),
            Types.Teacher => new List<ICanBeVisited>(TeacherList.Teachers.Values.ToList()),
            Types.Student => new List<ICanBeVisited>(StudentList.Students.Values.ToList()),
            Types.Room => new List<ICanBeVisited>(RoomList.Rooms.Values.ToList()),
            Types.Default => throw new InvalidOperationException(),
            _ => throw new InvalidOperationException()
        };
    }
    
    public static dynamic GetRealTypeFromICanBeVisited(ICanBeVisited element,Types type)
    {
        return type switch
        {
            Types.Class => (IClass)element,
            Types.Teacher => (ITeacher)element,
            Types.Student => (IStudent)element,
            Types.Room =>(IRoom)element,
            Types.Default => throw new InvalidOperationException(),
            _ => throw new InvalidOperationException()
        };
    }

    public static Queue<Queue<string>> GetTokensFromArgsString(string args)
    {
        var partiallyBroken = new Queue<string>(args.Split(","));
        var result = BreakArguments(partiallyBroken);

        var queue = new Queue<Queue<string>>(result);
        return queue;
    }

    public static IEnumerable<Queue<string>> BreakArguments(Queue<string> partiallyBroken)
    {
        var result = partiallyBroken
            .Select(BreakArgumentIntoQueue);
        return result;
    }

    public static Queue<string> BreakArgumentIntoQueue(string s)
    {
        const string pattern = @"(?<=[<>=])";
        return new Queue<string>(Regex.Split(s, pattern));
    }

    public static void DecomposeArgument<T>(T element, Queue<string> arg,
        out PropertyInfo operand, out string @operator, out string strVal)
    {
        var temp = arg.Dequeue();
        strVal = arg.Dequeue();

        var opString = temp.TrimEnd(temp[^1]);
        var a = element.GetType().GetProperties();
        operand = a.First(s => opString.Equals(s.Name, StringComparison.CurrentCultureIgnoreCase));
        @operator = temp[^1].ToString();
    }

    public static object ParseNumericString(string input)
    {
        var numericTypes = new Type[] {typeof(int), typeof(long), typeof(float), typeof(double), typeof(decimal)};
        foreach (var type in numericTypes)
        {
            if (!TypeDescriptor.GetConverter(type).CanConvertFrom(typeof(string))) continue;
            try
            {
                var value = Convert.ChangeType(input, type);
                return value;
            }
            catch
            {
                // Conversion failed, try the next type
            }
        }

        // If we've reached this point, the input string couldn't be parsed into any of the numeric types
        return input;
    }

}