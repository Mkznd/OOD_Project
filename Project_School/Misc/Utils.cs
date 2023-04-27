using System.Collections;
using Project_School.CLI.Commands;
using Project_School.Enums;
using Project_School.Interfaces.Visitor;
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
            _ => throw new InvalidOperationException()
        };
    }

    public static Queue<Queue<string>> GetTokensFromArgsString(string args)
    {
        var partiallyBroken = new Queue<string>(args.Split(","));
        string[] delimiters = {"=", ">", "<"};
        var result = partiallyBroken
            .Select(s => new Queue<string>(s.Split(delimiters, StringSplitOptions.TrimEntries)));
        var queue = new Queue<Queue<string>>(result);
        return queue;
    }
}