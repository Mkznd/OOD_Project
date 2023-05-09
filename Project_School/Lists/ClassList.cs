using Project_School.Interfaces.Common;

namespace Project_School.Lists;

public static class ClassList
{
    public static readonly Dictionary<string, IClass> Classes = new();

    public static string GetId(IClass classString)
    {
        return $"{classString.Name}{classString.Code}{classString.Duration}";
    }

    public static void AddToList(IClass @class)
    {
        Classes.Add(GetId(@class), @class);
    }
}