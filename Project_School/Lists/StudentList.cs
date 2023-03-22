using Project_School.Interfaces;

namespace Project_School;

public static class StudentList
{
    public static readonly Dictionary<string, IStudent> Students = new();
    public static string GetId(IHuman studentString)
    {
        return $"{string.Join(' ', studentString.Names)}{studentString.Surname}";
    }
}