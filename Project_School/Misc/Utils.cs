using System.Reflection;
using System.Text.RegularExpressions;
using Project_School.BaseRepresentation;
using Project_School.Enums;
using Project_School.Interfaces.CLI;
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
}